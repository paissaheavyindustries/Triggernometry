using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Triggernometry.CustomControls;

namespace Triggernometry
{

    public partial class RealPlugin
    {
        private static readonly HttpClient client = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        public class UpdateManifest
        {

            [XmlAttribute]
            public string Version { get; set; }

            [XmlAttribute]
            public string PluginDownloadURI { get; set; }

            [XmlAttribute]
            public string LanguageDownloadURI { get; set; }

            [XmlAttribute]
            public string Message { get; set; }

        }

        #region Plugin Update

        internal void CheckForUpdates(bool isManual = false)
        {
            switch (cfg.UpdateCheckMethod)
            {
                case Configuration.UpdateCheckMethodEnum.ACT:
                    CheckForUpdatesACT();
                    break;
                case Configuration.UpdateCheckMethodEnum.Builtin:
                    CheckForUpdatesBuiltin();
                    break;
                case Configuration.UpdateCheckMethodEnum.External:
                    CheckForUpdatesExternal(cfg.UpdateExternalChannelURI);
                    break;
            }
        }

        internal void CheckForUpdatesACT()
        {
            CheckUpdateHook();
        }

        internal void CheckForUpdatesBuiltin()
        {
            Task tx = new Task(() =>
            {
                string curver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string[] curvers = curver.Split(".".ToArray());
                string newest = curver;
                string[] newests = curvers;
                string newestasset = "";
                try
                {
                    string json = "";
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers["User-Agent"] = "Triggernometry Auto-update";
                        byte[] rawdata = wc.DownloadData(@"https://api.github.com/repos/paissaheavyindustries/Triggernometry/releases");
                        json = Encoding.UTF8.GetString(rawdata);
                    }
                    dynamic releases = new JavaScriptSerializer().DeserializeObject(json);
                    foreach (dynamic release in releases)
                    {
                        string fullrver = (string)release["tag_name"];
                        string[] rvers = fullrver.Split(".".ToArray());
                        if (rvers[0][0] == 'v')
                        {
                            rvers[0] = rvers[0].Substring(1);
                        }
                        fullrver = String.Join(".", rvers);
                        for (int i = 0; i < 4; i++)
                        {
                            int a = Int32.Parse(newests[i]);
                            int b = Int32.Parse(rvers[i]);
                            if (a > b)
                            {
                                //FilteredAddToLog(DebugLevelEnum.Info, "Newest version " + newest + " > release version " + fullrver);
                                break;
                            }
                            if (a < b)
                            {
                                //FilteredAddToLog(DebugLevelEnum.Info, "Newest version " + newest + " < release version " + fullrver);
                                newest = fullrver;
                                newests = rvers;
                                newestasset = release["assets"][0]["browser_download_url"];
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/vercheckfail", "Version update check failed: {0}", ex.ToString()));
                }
                if (newest != curver)
                {
                    FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/verchecknew", "Version check: A new version {0} is available for download to replace current version {1}", newest, curver));
                    updateDownloadUrl = newestasset;
                    CustomControls.Toast t = new CustomControls.Toast();
                    t.ToastText = I18n.Translate("internal/Plugin/downloadnewver", "A new version ({0}) is available for download. Would you like to open the download page?", newest);
                    t.OnYes += AutoUpdatePromptResult;
                    t.OnNo += AutoUpdatePromptResult;
                    t.ToastType = CustomControls.Toast.ToastTypeEnum.YesNo;
                    ui.QueueToast(t);
                }
                else
                {
                    FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/verchecksame", "Version check: Newest version {0} is the same or older than current version {1}", newest, curver));
                }
            });
            tx.Start();
        }

        public void CheckForUpdatesExternal(string uri, bool isManual = false)
        {
            Task.Run(() =>
            {
                Version localVersion, remoteVersion;
                UpdateManifest um = null;
                try
                {
                    string manifest;
                    Uri u = new Uri(uri);
                    if (u.IsFile == false)
                    {
                        manifest = client.GetStringAsync(uri).GetAwaiter().GetResult();
                        XmlSerializer xs = new XmlSerializer(typeof(UpdateManifest));
                        using (MemoryStream ms = new MemoryStream())
                        {
                            um = (UpdateManifest)xs.Deserialize(ms);
                        }
                    }
                    else
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(UpdateManifest));
                        using (FileStream fs = File.Open(uri, FileMode.Open, FileAccess.Read))
                        {
                            um = (UpdateManifest)xs.Deserialize(fs);
                        }
                    }
                    remoteVersion = Version.Parse(um.Version.Trim());
                    localVersion = Assembly.GetExecutingAssembly().GetName().Version;
                    if (remoteVersion > localVersion)
                    {
                        plug.FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/extupdateavailable", "External update available (current version: {0}, remote version: {1})", localVersion, remoteVersion));
                        string filePath = Path.Combine(pluginPath, $"{pluginName}.dll");
                        Toast t = new Toast
                        {
                            ToastText = string.Format(um.Message, localVersion, remoteVersion),
                            ToastType = Toast.ToastTypeEnum.YesNo
                        };
                        t.OnYes += (_, __) => UpdatePluginExternal(um, filePath, localVersion, remoteVersion);
                        ui.QueueToast(t);
                    }
                }
                catch (Exception ex)
                {
                    plug.FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/extupdatefailed", "Couldn't process update manifest from {0}, error: {1}", uri, ex.Message));
                    return;
                }
            });
        }

        private void UpdatePluginExternal(UpdateManifest um, string filePath, Version localVersion, Version remoteVersion)
        {
            Task.Run(async () =>
            {
                try
                {
                    string tmpPath = filePath + ".tmp";
                    Uri u = new Uri(um.PluginDownloadURI);
                    byte[] fileBytes;
                    if (u.IsFile == false)
                    {
                        fileBytes = await client.GetByteArrayAsync(um.PluginDownloadURI);
                        File.WriteAllBytes(tmpPath, fileBytes);
                    }
                    else
                    {
                        File.Copy(um.PluginDownloadURI, tmpPath, true);
                    }
                    if (File.Exists(filePath))
                    {
                        string backupPath = $"{filePath}.{localVersion}.backup";
                        if (File.Exists(backupPath))
                            File.Delete(backupPath);
                        File.Move(filePath, backupPath);
                    }
                    File.Move(tmpPath, filePath);
                    if (um.LanguageDownloadURI != null)
                    {
                        UpdateTranslationExternal(um);
                    }
                    string logt = I18n.Translate("internal/Plugin/extupdatesuccess", "Plugin version updated from {0} to {1}. Restart ACT for changes to take effect.", localVersion, remoteVersion);
                    plug.FilteredAddToLog(DebugLevelEnum.Info, logt);
                    ui.QueueToast(new Toast
                    {
                        ToastText = logt,
                        ToastType = Toast.ToastTypeEnum.OK
                    });
                }
                catch (Exception ex)
                {
                    string err = I18n.Translate("internal/Plugin/extupdatedlfailed", "Couldn't download plugin update from {0}, error: {1}", um.PluginDownloadURI, ex.Message);
                    plug.FilteredAddToLog(DebugLevelEnum.Error, err);
                    ui.QueueToast(new Toast
                    {
                        ToastText = err,
                        ToastType = Toast.ToastTypeEnum.OK
                    });
                }
            });
        }

        public void UpdateTranslationExternal(UpdateManifest um)
        {
            string fileName = Path.GetFileName(um.LanguageDownloadURI);
            string localPath = Path.Combine(pluginPath, fileName);
            Task.Run(async () =>
            {
                try
                {
                    Uri u = new Uri(um.PluginDownloadURI);
                    if (u.IsFile == false)
                    {
                        var fileBytes = await client.GetByteArrayAsync(um.LanguageDownloadURI);
                        File.WriteAllBytes(localPath, fileBytes);
                    }
                    else
                    {
                        File.Copy(um.LanguageDownloadURI, localPath, true);
                    }
                    string logt = I18n.Translate("internal/Plugin/exttranssuccess", "Translation updated, restart ACT for changes to take effect.");
                    plug.FilteredAddToLog(DebugLevelEnum.Info, logt);
                }
                catch (Exception ex)
                {
                    string err = I18n.Translate("internal/Plugin/exttransdlfailed", "Couldn't download language update from {0}, error: {1}", um.LanguageDownloadURI, ex.Message);
                    plug.FilteredAddToLog(DebugLevelEnum.Error, err);
                    ui.QueueToast(new Toast
                    {
                        ToastText = err,
                        ToastType = Toast.ToastTypeEnum.OK
                    });
                }
            });
        }

        private void AutoUpdatePromptResult(CustomControls.Toast t, bool result)
        {
            if (result == true)
            {
                System.Diagnostics.Process.Start(updateDownloadUrl);
            }
        }

        #endregion

        #region Repo Update

        private void ClearRepository(Repository r)
        {
            ui.ClearRepository(r);
        }

        internal async Task RepositoryUpdate(Repository r, bool singleUpdate, bool isStartup)
        {
            r.LastUpdatedTrig = DateTime.Now;
            ClearRepository(r);
            r.ClearLog();
            string trans;
            bool useBackup = isStartup && r.UpdatePolicy != Repository.UpdatePolicyEnum.Startup;
            // update the repo
            if (!useBackup)
            {
                try
                {
                    if (singleUpdate == true)
                    {
                        trans = I18n.Translate("internal/Plugin/repoupdate", "Updating repository {0} at {1}", r.Name, r.Address);
                        FilteredAddToLog(DebugLevelEnum.Verbose, trans);
                        r.AddToLog(trans);
                        ShowProgress(-1, trans);
                    }
                    long localsize = 0;
                    (DateTime remdate, long remsize) = await FetchRepositoryMetadata(r);
                    DateTime cacheExpiry = DateTime.Now.AddMinutes(0 - cfg.CacheRepoExpiry);
                    bool cacheExpired = false;
                    if (r.KeepLocalBackup == true)
                    {
                        string repofn = GetRepositoryBackupFilename(r);
                        if (File.Exists(repofn) == true)
                        {
                            FileInfo fi = new FileInfo(repofn);
                            localsize = fi.Length;
                            cacheExpired = (fi.LastWriteTime < cacheExpiry);
                        }
                    }
                    // nothing has changed: try to load local backup
                    if (remdate == r.LastUpdated && remsize == localsize && localsize > 0 && r.KeepLocalBackup == true && cacheExpired == false)
                    {
                        trans = I18n.Translate("internal/Plugin/repousingbackup", "Repository {0} hasn't changed since {1}, and size hasn't changed from {2}, using local backup", r.Name, remdate, localsize);
                        FilteredAddToLog(DebugLevelEnum.Info, trans);
                        r.AddToLog(trans);
                        if (LoadLocalBackupForRepository(r) == true) // success
                        {
                            if (singleUpdate)
                                CompleteSingleUpdate(r);
                            return;
                        }
                    }
                    else
                    {
                        trans = I18n.Translate("internal/Plugin/repofetching", "Repository {0} has changed since {1} (new timestamp {2}), or size has changed from {3} (new size {4}), fetching new version", r.Name, r.LastUpdated, remdate, localsize, remsize);
                        FilteredAddToLog(DebugLevelEnum.Verbose, trans);
                        r.LastUpdated = remdate;
                    }
                    string data;
                    trans = I18n.Translate("internal/Plugin/repodownloading", "Downloading repository {0} from {1}", r.Name, r.Address);
                    FilteredAddToLog(DebugLevelEnum.Info, trans);
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(10);
                        httpClient.DefaultRequestHeaders.Add("User-Agent", "Triggernometry Repository Updater");
                        byte[] rawdata = await httpClient.GetByteArrayAsync(r.Address);
                        data = Encoding.UTF8.GetString(rawdata);
                    }
                    TriggernometryExport exp = TriggernometryExport.Unserialize(data);
                    if (!exp.Corrupted)
                    {
                        r.ContentSize = data.Length;
                        AddContentToRepository(exp, r);
                        if (r.KeepLocalBackup == true)
                        {
                            SaveLocalBackupForRepository(r, data);
                        }
                    }
                    else
                    {
                        trans = I18n.Translate("internal/Plugin/repoexportnull", "Data for repository {0} could not be unserialized, make sure you are running the latest version of Triggernometry", r.Name);
                        FilteredAddToLog(DebugLevelEnum.Error, trans);
                        r.AddToLog(trans);
                    }
                }
                catch (Exception ex)
                {
                    trans = I18n.Translate("internal/Plugin/repoupdateexception", "Couldn't update repository {0} due to exception: {1}", r.Name, ex.ToString());
                    r.AddToLog(trans);
                    FilteredAddToLog(DebugLevelEnum.Error, trans);
                    useBackup = true; // use local backup if the update failed
                }
            }
            // load local backup
            if (useBackup && r.KeepLocalBackup)
            {
                trans = I18n.Translate("internal/Plugin/repousinglocal", "Loading local backup of repository {0}", r.Name);
                FilteredAddToLog(DebugLevelEnum.Info, trans);
                r.AddToLog(trans);
                LoadLocalBackupForRepository(r);
            }
            if (singleUpdate)
                CompleteSingleUpdate(r);
        }

        private async Task<(DateTime remdate, long remsize)> FetchRepositoryMetadata(Repository r)
        {
            var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Head, new Uri(r.Address));
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
            {
                var response = await client.SendAsync(request, cts.Token);
                var lastmod = response.Content.Headers.LastModified;
                DateTime remdate = lastmod.HasValue ? lastmod.Value.DateTime : r.LastUpdated;
                long remsize = response.Content.Headers.ContentLength.GetValueOrDefault(0);
                return (remdate, remsize);
            }
        }

        private void CompleteSingleUpdate(Repository r)
        {
            string trans = I18n.Translate("internal/Plugin/repoupdatecomplete", "Repository update complete");
            r.AddToLog(trans);
            ShowProgressWhenComplete(trans);
        }

        internal void AllRepositoryUpdates(bool isStartup)
        {
            List<Repository> lr = new List<Repository>();
            lr.AddRange(from ix in cfg.RepositoryRoot.Repositories where ix.Enabled == true select ix);
            RepositoryUpdates(lr, isStartup);
        }

        internal async void RepositoryUpdates(IEnumerable<Repository> lr, bool isStartup)
        {
            if (!lr.Any())
            {
                return;
            }
            string trans = I18n.Translate("internal/Plugin/repoupdates", "Going to update {0} repositories", lr.Count());
            FilteredAddToLog(DebugLevelEnum.Info, trans);
            ShowProgress(-1, trans);
            int total = lr.Count();
            int completed = 0;
            object progressLock = new object();
            var tasks = lr.Select(r => Task.Run(async () =>
            {
                if (ExitEvent.WaitOne(0))
                {
                    return;
                }
                string updateTrans = I18n.Translate("internal/Plugin/repoupdate", "Updating repository {0} at {1}", r.Name, r.Address);
                FilteredAddToLog(DebugLevelEnum.Verbose, updateTrans);
                r.AddToLog(updateTrans);
                await RepositoryUpdate(r, false, isStartup);
                lock (progressLock)
                {
                    completed++;
                    ShowProgress((int)Math.Floor(100.0 * completed / total), $"正在更新仓库 {completed} / {total}");
                }
            }));
            await Task.WhenAll(tasks);
            ShowProgressWhenComplete(I18n.Translate("internal/Plugin/repoupdatecomplete", "Repository update complete"));
        }

        private void ApplyRepositoryRestrictions(Folder f, Repository r)
        {
            var ix = from tx in r.FolderStates where tx.Id == f.Id select tx;
            if (ix.Count() == 0)
            {
                switch (r.NewBehavior)
                {
                    case Repository.NewBehaviorEnum.AlwaysEnable:
                        f.Enabled = true;
                        break;
                    case Repository.NewBehaviorEnum.AlwaysDisable:
                        f.Enabled = false;
                        break;
                }
                r.FolderStates.Add(new Repository.RepositoryItem() { Id = f.Id, Enabled = f.Enabled });
            }
            else
            {
                Repository.RepositoryItem ri = ix.First();
                f.Enabled = ri.Enabled;
            }
            foreach (Folder subf in f.Folders)
            {
                ApplyRepositoryRestrictions(subf, r);
            }
            List<Trigger> torem = new List<Trigger>();
            foreach (Trigger t in f.Triggers)
            {
                if (ApplyRepositoryRestrictions(t, r) == false)
                {
                    torem.Add(t);
                }
            }
            foreach (Trigger t in torem)
            {
                f.Triggers.Remove(t);
            }
            f.Repo = r;
        }

        private bool ApplyActionSpecificRestrictions(IEnumerable<Action> actions, Repository r)
        {
            foreach (Action a in actions)
            {
                if (a._ActionType == Action.ActionTypeEnum.ExecuteScript && r.AllowScriptExecution == false)
                {
                    return false;
                }
                if (a._ActionType == Action.ActionTypeEnum.LaunchProcess && r.AllowProcessLaunch == false)
                {
                    return false;
                }
                if (a._ActionType == Action.ActionTypeEnum.WindowMessage && r.AllowWindowMessages == false)
                {
                    return false;
                }
                if (a._ActionType == Action.ActionTypeEnum.DiskFile && r.AllowDiskOperations == false)
                {
                    return false;
                }
                if (a._ActionType == Action.ActionTypeEnum.ObsControl && r.AllowObsControl == false)
                {
                    return false;
                }
                if (a._ActionType == Action.ActionTypeEnum.Loop)
                {
                    bool ret = ApplyActionSpecificRestrictions(a.LoopActions, r);
                    if (ret == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ApplyRepositoryRestrictions(Trigger t, Repository r)
        {
            bool ret = ApplyActionSpecificRestrictions(t.Actions, r);
            if (ret == false)
            {
                return false;
            }
            var ix = from tx in r.TriggerStates where tx.Id == t.Id select tx;
            if (ix.Count() == 0)
            {
                switch (r.NewBehavior)
                {
                    case Repository.NewBehaviorEnum.AlwaysEnable:
                        t.Enabled = true;
                        break;
                    case Repository.NewBehaviorEnum.AlwaysDisable:
                        t.Enabled = false;
                        break;
                }
                r.TriggerStates.Add(new Repository.RepositoryItem() { Id = t.Id, Enabled = t.Enabled });
            }
            else
            {
                Repository.RepositoryItem ri = ix.First();
                t.Enabled = ri.Enabled;
            }
            switch (r.AudioOutput)
            {
                case Repository.AudioOutputEnum.AlwaysOverride:
                    {
                        foreach (Action a in t.Actions)
                        {
                            a._SoundRouting = Configuration.AudioRoutingMethodEnum.Triggernometry;
                            a._TTSRouting = Configuration.AudioRoutingMethodEnum.Triggernometry;
                        }
                    }
                    break;
                case Repository.AudioOutputEnum.NeverOverride:
                    {
                    }
                    break;
            }
            t.Repo = r;
            return true;
        }

        private void RegisterRepositoryFolder(Repository r, Folder f, bool parentenable)
        {
            if (f.Enabled == false)
            {
                parentenable = false;
            }
            foreach (Folder fs in f.Folders)
            {
                fs.Parent = f;
                RegisterRepositoryFolder(r, fs, parentenable);
            }
            foreach (Trigger t in f.Triggers)
            {
                t.Parent = f;
                RegisterRepositoryTrigger(r, t, parentenable);
            }
        }

        private void RegisterRepositoryTrigger(Repository r, Trigger t, bool parentenable)
        {
            //if (t.Enabled == true && parentenable == true)
            //{
            AddTrigger(t, parentenable);
            //}
            if (t._IsReadme == true && t.Enabled == true)
            {
                r.ReadmeTriggers.Add(t);
            }
        }

        private void AddContentToRepository(TriggernometryExport exp, Repository r)
        {
            r.ReadmeTriggers.Clear();
            if (exp.ExportedFolder != null)
            {
                ApplyRepositoryRestrictions(exp.ExportedFolder, r);
                r.Root.Folders.Add(exp.ExportedFolder);
                RegisterRepositoryFolder(r, exp.ExportedFolder, r.Enabled && ui.treeView1.Nodes[1].Checked);
            }
            if (exp.ExportedTrigger != null)
            {
                if (ApplyRepositoryRestrictions(exp.ExportedTrigger, r) == false)
                {
                    return;
                }
                r.Root.Triggers.Add(exp.ExportedTrigger);
                exp.ExportedTrigger.Parent = r.Root;
                RegisterRepositoryTrigger(r, exp.ExportedTrigger, r.Enabled);
            }
            ui.BuildTreeForRepository(exp, r);
        }

        internal string GetRepositoryBackupFilename(Repository r)
        {
            string fn = Path.Combine(path, "TriggernometryRepoBackups");
            return Path.Combine(fn, GenerateHash(r.Address) + ".xml");
        }

        private bool LoadLocalBackupForRepository(Repository r)
        {
            string trans;
            try
            {
                string fn = GetRepositoryBackupFilename(r);
                trans = I18n.Translate("internal/Plugin/repoloadinglocal", "Loading local backup of repository {0} in {1}", r.Name, fn);
                FilteredAddToLog(DebugLevelEnum.Verbose, trans);
                r.AddToLog(trans);
                string data = File.ReadAllText(fn);
                TriggernometryExport exp = TriggernometryExport.Unserialize(data);
                if (!exp.Corrupted)
                {
                    r.LastUpdated = File.GetLastWriteTime(fn);
                    r.ContentSize = data.Length;
                    AddContentToRepository(exp, r);
                    trans = I18n.Translate("internal/Plugin/repoloadedlocal", "Loaded local backup of repository {0} from {1}", r.Name, fn);
                    FilteredAddToLog(DebugLevelEnum.Info, trans);
                    r.AddToLog(trans);
                    return true;
                }
                else
                {
                    trans = I18n.Translate("internal/Plugin/repoexportnull", "Data for repository {0} could not be unserialized, make sure you are running the latest version of Triggernometry", r.Name);
                    FilteredAddToLog(DebugLevelEnum.Error, trans);
                    r.AddToLog(trans);
                }
            }
            catch (Exception ex)
            {
                trans = I18n.Translate("internal/Plugin/repoloadlocalexception", "Couldn't load local backup of repository {0} due to exception: {1}", r.Name, ex.ToString());
                FilteredAddToLog(DebugLevelEnum.Error, trans);
                r.AddToLog(trans);
            }
            return false;
        }

        private void SaveLocalBackupForRepository(Repository r, string data)
        {
            string trans;
            try
            {
                string fn = Path.Combine(path, "TriggernometryRepoBackups");
                string fn2 = Path.Combine(fn, GenerateHash(r.Address) + ".xml");
                trans = I18n.Translate("internal/Plugin/reposavinglocal", "Saving local backup of repository {0} in {1}", r.Name, fn2);
                FilteredAddToLog(DebugLevelEnum.Verbose, trans);
                r.AddToLog(trans);
                if (Directory.Exists(fn) == false)
                {
                    Directory.CreateDirectory(fn);
                }
                File.WriteAllText(fn2, data);
                trans = I18n.Translate("internal/Plugin/reposavedlocal", "Saved local backup of repository {0} in {1}", r.Name, fn2);
                FilteredAddToLog(DebugLevelEnum.Info, trans);
                r.AddToLog(trans);
            }
            catch (Exception ex)
            {
                trans = I18n.Translate("internal/Plugin/reposavelocalexception", "Couldn't save local backup of repository {0} due to exception: {1}", r.Name, ex.ToString());
                FilteredAddToLog(DebugLevelEnum.Error, trans);
                r.AddToLog(trans);
            }
        }

        #endregion
    }
}
