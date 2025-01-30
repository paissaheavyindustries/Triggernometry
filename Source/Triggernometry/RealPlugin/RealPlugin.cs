using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triggernometry.CustomControls;
using Triggernometry.Utilities;
using Triggernometry.Variables;

namespace Triggernometry
{

    public partial class RealPlugin
    {

        public class CustomTriggerProxy
        {

            public bool Active { get; set; }
            public string ShortRegexString { get; set; }
            public string SoundData { get; set; }
            public int SoundType { get; set; }
            public string TimerName { get; set; }
            public bool Tabbed { get; set; }
            public bool Timer { get; set; }

        }

        public class CustomTriggerCategoryProxy
        {

            public string Category { get; set; }
            public bool RestrictToCategoryZone { get; set; }
            public List<CustomTriggerProxy> Items = new List<CustomTriggerProxy>();

        }

        public class PluginWrapper
        {
            public object pluginObj { get; set; }
            public Panel PnlInfo { get; set; }
            public TabPage TabPage { get; set; }
            public FileInfo PluginFile { get; set; }
            public Label LblTitle { get; set; }
            public Label LblStatus { get; set; }
            public Button BtnX { get; set; }
            public CheckBox CbxEnabled { get; set; }
            public string FileVersion { get; set; }
            public string PluginType { get; set; }
        }

        public IntPtr XivProcHandle => Memory.XivProcHandle;

        private delegate void LogLineProcDelegate(LogEvent le);
        public delegate bool SimpleBoolDelegate();
        public delegate void SimpleVoidDelegate();
        public delegate double SimpleDoubleDelegate();
        public delegate string SimpleStringDelegate();
        public delegate void BoolDelegate(bool boolParam);
        public delegate void TabPageDelegate(TabPage tp);
        public delegate void TtsDelegate(string text);
        public delegate void SoundDelegate(string filename, int volume);
        public delegate List<CustomTriggerCategoryProxy> CustomTriggerDelegate();
        public delegate PluginWrapper InstanceDelegate(string ActPluginName, string ActPluginType);
        public delegate void ACTEncounterLogDelegate(string message);
        private Queue<LogEvent> EventQueue = new Queue<LogEvent>();
        private ManualResetEvent QueueWakeupEvent = null;
        public CustomControls.UserInterface ui = null;

        public string path { get; set; }
        private bool isInitialized { get; set; } = false;
        internal Thread EventQueueThread = null;
        private ManualResetEvent ExitEvent = null;
        private TabPage mytp;
        private bool complainAboutReload = false;
        private string updateDownloadUrl;
        public string pluginName { get; set; }
        public string pluginPath { get; set; }
        internal Endpoint _ep = null;
        private bool firstevent = true;
        internal bool runningAsAdmin;
        internal string currentZone = null;
        internal DateTime LastDelayWarning = DateTime.Now;
        internal VariableStore sessionvars = new VariableStore();
        internal ObsController _obs = null;
        internal LiveSplitController _livesplit = null;
        internal CancellationTokenSource cts = null;
        internal object ctslock = new object();
        public Form mainform { get; set; }
        internal int MinX = int.MaxValue, MinY = int.MaxValue, MaxX = int.MinValue, MaxY = int.MinValue;

        public SimpleBoolDelegate InCombatHook { get; set; }
        public SimpleBoolDelegate CustomTriggerCheckHook { get; set; }
        public BoolDelegate SetCombatStateHook { get; set; }
        public SimpleStringDelegate CurrentZoneHook { get; set; }
        public SimpleStringDelegate ActiveEncounterHook { get; set; }
        public SimpleStringDelegate LastEncounterHook { get; set; }
        public SimpleDoubleDelegate EncounterDurationHook { get; set; }
        public TtsDelegate TtsPlaybackHook { get; set; }
        public SoundDelegate SoundPlaybackHook { get; set; }
        public CustomTriggerDelegate CustomTriggerHook { get; set; }
        public static InstanceDelegate InstanceHook { get; set; }
        public SimpleVoidDelegate CornerShowHook { get; set; }
        public SimpleVoidDelegate CornerHideHook { get; set; }
        public TabPageDelegate TabLocateHook { get; set; }
        public SimpleVoidDelegate CheckUpdateHook { get; set; }
        public SimpleBoolDelegate ActInitedHook { get; set; }
        public ACTEncounterLogDelegate ACTEncounterLogHook { get; set; }

        private static RealPlugin _plug;
        public static RealPlugin plug
        {
            get 
            { 
                if (_plug == null)
                    _plug = new RealPlugin();
                return _plug;
            }
        }

        public static void ResetPlugin()
        {
            _plug = new RealPlugin();
        }

        private RealPlugin()
        {
            ThreadPool.SetMinThreads(10, 10);
            PluginBridges.BridgeFFXIV.OnLogEvent += BridgeFFXIV_OnLogEvent;
            _ep = new Endpoint();
            _ep.OnStatusChange += _ep_OnStatusChange;
        }

        internal static Font CreateFontFromDefinition(string name, float size, Action.TextAuraEffectEnum effect)
        {
            FontStyle fs = FontStyle.Regular;
            if ((effect & Action.TextAuraEffectEnum.Bold) == Action.TextAuraEffectEnum.Bold)
            {
                fs |= FontStyle.Bold;
            }
            if ((effect & Action.TextAuraEffectEnum.Italic) == Action.TextAuraEffectEnum.Italic)
            {
                fs |= FontStyle.Italic;
            }
            if ((effect & Action.TextAuraEffectEnum.Underline) == Action.TextAuraEffectEnum.Underline)
            {
                fs |= FontStyle.Underline;
            }
            if ((effect & Action.TextAuraEffectEnum.Strikeout) == Action.TextAuraEffectEnum.Strikeout)
            {
                fs |= FontStyle.Strikeout;
            }
            return new Font(name, size, fs);
        }

        internal static void ApplyFontOverrideToForm(Form f, Font fnt)
        {
            foreach (Control c in f.Controls)
            {
                ApplyFontOverrideToControl(c, fnt);
            }
        }

        internal static void ApplyFontOverrideToControl(Control c, Font fnt)
        {
            foreach (Control cc in c.Controls)
            {
                ApplyFontOverrideToControl(cc, fnt);
            }
            if (c is ToolStrip)
            {
                ToolStrip ts = (ToolStrip)c;
                foreach (ToolStripItem tsi in ts.Items)
                {
                    tsi.Font = fnt;
                }
            }
            switch (c)
            {
                case TextBox x:
                    x.Font = fnt; break;
                case ExpressionTextBox x:
                    x.Font = fnt; break;
                case Button x:
                    x.Font = fnt; break;
                case MenuButton x:
                    x.Font = fnt; break;
                case Label x:
                    x.Font = fnt; break;
                case ComboBox x:
                    x.Font = fnt; break;
                case ListBox x:
                    x.Font = fnt; break;
                case CheckBox x:
                    x.Font = fnt; break;
                case DataGridView x:
                    x.Font = fnt; break;
                case TreeView x:
                    x.Font = fnt; break;
                case GroupBox x:
                    x.Font = fnt; break;
                case NumericUpDown x:
                    x.Font = fnt; break;
                case TabControl x:
                    x.Font = fnt; break;
            }
        }

        private void _ep_OnStatusChange(Endpoint.StatusEnum newStatus, string statusDesc)
        {
            FilteredAddToLog(DebugLevelEnum.Verbose, String.Format("Endpoint ({0}) {1}", newStatus, statusDesc));
        }

        private void BridgeFFXIV_OnLogEvent(DebugLevelEnum level, string text)
        {
            FilteredAddToLog(level, text);
        }

        public void GenericExceptionHandler(string msg, Exception ex)
        {
            string text = msg + ": " + Environment.NewLine + Environment.NewLine + ex.Message + " " + ex.StackTrace;
            var inner = ex.InnerException;
            while (inner != null)
            {
                text += "\n---------\nInner: " + inner.Message;
                text += "\n " + inner.StackTrace;
                inner = inner.InnerException;
        }
            MessageBox.Show(ui, text, I18n.Translate("internal/Plugin/exception", "Exception"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FixDuplicateFolderReferences(Dictionary<Guid, List<Folder>> references, Configuration c, Folder f)
        {
            if (f == null)
            {
                Dictionary<Guid, List<Folder>> existing = new Dictionary<Guid, List<Folder>>();
                foreach (Folder sf in c.Root.Folders)
                {
                    FixDuplicateFolderReferences(existing, c, sf);
                }
                foreach (KeyValuePair<Guid, List<Folder>> kp in existing)
                {
                    if (kp.Value.Count <= 1)
                    {
                        continue;
                    }
                    Folder ori = kp.Value[0];
                    foreach (Folder refe in kp.Value)
                    {
                        if (refe == ori)
                        {
                            continue;
                        }
                        refe.Id = Guid.NewGuid();
                        FilteredAddToLog(DebugLevelEnum.Warning, I18n.Translate("internal/UserInterface/folderidreassign", "Reassigning new id ({0}) for folder ({1}) due to already assigned id ({2}) on folder ({3})", refe.Id, refe.Name, ori.Id, ori.Name));
                    }
                }
            }
            else
            {
                if (references.ContainsKey(f.Id) == false)
                {
                    references[f.Id] = new List<Folder>();
                }
                references[f.Id].Add(f);
                foreach (Folder sf in f.Folders)
                {
                    FixDuplicateFolderReferences(references, null, sf);
                }
            }
        }

        public void IfYouSeeThisErrorYouNeedToRestartACT()
        {
            complainAboutReload = true;
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            InitLanguage();
            string exwhere = I18n.Translate("internal/Plugin/initseek", "seeking plugin instance");
            try
            {
                FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/initing", "Initializing"));
                //CombobulateTranslations();
                exwhere = I18n.Translate("internal/Plugin/inifilename", "determining filename");
                pluginName = Path.GetFileNameWithoutExtension(pluginName);
                FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/filenameis", "Plugin filename is '{0}' at '{1}'", pluginName, pluginPath));
                exwhere = I18n.Translate("internal/Plugin/inilanguages", "loading languages");
                LoadLanguages();
                exwhere = I18n.Translate("internal/Plugin/inicfg", "loading configuration");
                _cfg = LoadConfigFromFile(Path.Combine(path, pluginName + ".config.xml"));
                SetupDefaultSecurity();
                AutofixConfiguration();
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                BackupConfiguration();
                FixDuplicateFolderReferences(null, cfg, null);
                PluginBridges.BridgeFFXIV.cfg = cfg;
                if (cfg.Language != null)
                {
                    ChangeLanguage(cfg.Language);
                }
                exwhere = I18n.Translate("internal/Plugin/iniactui", "setting up ACT ui");
                mytp = pluginScreenSpace;
                pluginScreenSpace.Text = "Triggernometry";
                exwhere = I18n.Translate("internal/Plugin/inievents", "creating events");
                ExitEvent = new ManualResetEvent(false);
                QueueWakeupEvent = new ManualResetEvent(false);
                ActionUpdateEvent = new AutoResetEvent(false);
                exwhere = I18n.Translate("internal/Plugin/iniui", "creating user interface");
                ui = new CustomControls.UserInterface();
                ui.btnCornerPopup.Tag = pluginScreenSpace;
                ui.cfg = cfg;
                I18n.TranslateControl("Plugin", ui);
                ui.UpdateUiFont();
                ui.Dock = DockStyle.Fill;
                ui.plug = this;
                pluginScreenSpace.Controls.Add(ui);
                if (cfg.corruptRecoveryError != "")
                {
                    FilteredAddToLog(DebugLevelEnum.Error, cfg.corruptRecoveryError);
                }
                exwhere = I18n.Translate("internal/Plugin/inicache", "performing cache cleanup");
                ClearCache();
                InitAudio(ref exwhere);
                exwhere = I18n.Translate("internal/Plugin/iniwelcome", "preparing welcome");
                ui.pnlWelcome.Dock = DockStyle.Fill;
                ui.pnlUi.Dock = DockStyle.Fill;
                if (cfg != null && cfg.ShowWelcome == true)
                {
                    ui.pnlUi.Visible = false;
                    ui.pnlWelcome.Visible = true;
                    ui.btnOptions.Enabled = false;
                }
                else
                {
                    ui.pnlUi.Visible = true;
                    ui.pnlWelcome.Visible = false;
                    ui.btnOptions.Enabled = true;
                }
                if (cfg.UpdateNotifications == Configuration.UpdateNotificationsEnum.Yes)
                {
                    exwhere = I18n.Translate("internal/Plugin/iniupdates", "checking for updates");
                    CheckForUpdates();
                }
                exwhere = I18n.Translate("internal/Plugin/initoasts", "setting up toasts");
                if (complainAboutReload == true)
                {
                    ui.ComplainAboutReload();
                }
                ui.SetupToasts();
                ui.SetupLanguageMenu();
                runningAsAdmin = CheckIfAdministrator(cfg.WarnAdmin);
                exwhere = I18n.Translate("internal/Plugin/initree", "building internal data");
                ui.BuildFullTreeFromConfiguration();
                int PrimaryX = 0, PrimaryY = 0;
                foreach (Screen s in Screen.AllScreens)
                {
                    FilteredAddToLog(DebugLevelEnum.Info, String.Format("{0}{1}: {2},{3} - {4},{5}", s.DeviceName, s.Primary == true ? " (*)" : "", s.Bounds.Left, s.Bounds.Top, s.Bounds.Left + s.Bounds.Width, s.Bounds.Top + s.Bounds.Height));
                    if (s.WorkingArea.Left < MinX)
                    {
                        MinX = s.WorkingArea.Left;
                    }
                    if (s.WorkingArea.Top < MinY)
                    {
                        MinY = s.WorkingArea.Top;
                    }
                    if (s.WorkingArea.Left + s.WorkingArea.Width > MaxX)
                    {
                        MaxX = s.WorkingArea.Left + s.WorkingArea.Width;
                    }
                    if (s.WorkingArea.Top + s.WorkingArea.Height > MaxY)
                    {
                        MaxY = s.WorkingArea.Top + s.WorkingArea.Height;
                    }
                    if (s.Primary == true)
                    {
                        PrimaryX = s.WorkingArea.Left;
                        PrimaryY = s.WorkingArea.Top;
                    }
                }
                FilteredAddToLog(DebugLevelEnum.Info, String.Format("*: {0},{1} - {2},{3}", MinX, MinY, MaxX, MaxY));
                InitActionQueue();
                EventQueueThread = new Thread(new ThreadStart(LogLineProcessorThread));
                EventQueueThread.Name = "EventQueueThread";
                EventQueueThread.Start();
                InitAura();
                _obs = new ObsController();
                _livesplit = new LiveSplitController();
                InitScripting();
                exwhere = I18n.Translate("internal/Plugin/iniendpoint", "starting endpoint");
                if (cfg.StartEndpointOnLaunch == true)
                {
                    _ep.Start();
                }
                pluginStatusText.Text = I18n.Translate("internal/Plugin/iniready", "Ready");
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/inited", "Initialized"));
                Task tx = new Task(() =>
                {
                    AllRepositoryUpdates(true);
                });
                tx.Start();
                isInitialized = true;
            }
            catch (Exception ex)
            {
                pluginStatusText.Text = I18n.Translate("internal/Plugin/inierror", "Error while {0} ({1})", exwhere, ex.ToString());
            }
        }        

        private void ShowProgress(int progress, string state)
        {
            ui.ShowProgress(progress, state);
        }

        private void ShowProgressWhenComplete(string state)
        {
            ui.ShowProgress(100, state);
            System.Threading.Thread.Sleep(2000);
            ui.ShowProgress(0, "");
        }

        public void DeInitPlugin()
        {
            ui?.CloseForms();
            PluginBridges.BridgeFFXIV.UnsubscribeFromNetworkEvents(this);
            if (_ep != null)
            {
                _ep.Stop();
                _ep.Dispose();
                _ep = null;
            }
            if (_obs != null)
            {
                _obs.Dispose();
                _obs = null;
            }
            if (_livesplit != null)
            {
                _livesplit?.Dispose();
                _livesplit = null;
            }
            Memory.DisposeXivProcHandle();
            ExitEvent?.Set();
            DeinitActionQueue();
            if (EventQueueThread != null)
            {
                if (EventQueueThread.Join(5000) == false)
                {
                    EventQueueThread.Abort();
                }
                EventQueueThread = null;
            }
            DeInitAura();
            if (QueueWakeupEvent != null)
            {
                QueueWakeupEvent.Dispose();
                QueueWakeupEvent = null;
            }
            if (configBroken == false)
            {
                SaveCurrentConfig();
            }
            //SaveDefaultLanguage(Path.Combine(path, "default.triglations.xml"));
            if (cts != null)
            {
                cts.Dispose();
                cts = null;
            }
            DeInitAudio();
            if (ui != null)
            {
                ui.Dispose();
                ui = null;
            }
            if (ExitEvent != null)
            {
                ExitEvent.Dispose();
                ExitEvent = null;
            }
            _plug = null;
        }

        internal CancellationToken GetCancellationToken()
        {
            lock (ctslock)
            {
                if (cts == null)
                {
                    cts = new CancellationTokenSource();
                }
                return cts.Token;
            }
        }

        internal void RefreshCancellationToken()
        {
            lock (ctslock)
            {
                if (cts != null)
                {
                    cts.Cancel();
                    cts.Dispose();
                }
                cts = new CancellationTokenSource();
            }
        }

        internal void LogLineQueuer(string text, string zone, LogEvent.SourceEnum src)
        {
            LogEvent le = new LogEvent();
            le.Text = text;
            le.ZoneName = zone;
            le.Source = src;
            le.Timestamp = DateTime.Now;
            lock (EventQueue)
            {
                EventQueue.Enqueue(le);
                QueueWakeupEvent.Set();
            }
        }

        internal void LogLineQueuerMass(IEnumerable<string> text, string zone, LogEvent.SourceEnum src, bool testMode, bool testModeZoneId)
        {
            int max = text.Count();
            int i = 0;
            LogEvent[] lex = new LogEvent[text.Count()];
            foreach (string x in text)
            {
                lex[i] = new LogEvent();
                lex[i].Text = x;
                lex[i].ZoneName = zone;
                lex[i].Source = src;
                lex[i].Timestamp = DateTime.Now;
                lex[i].TestMode = testMode;
                lex[i].ZoneId = testModeZoneId ? zone : null;
                i++;
            }
            if (lex.Count() > 0)
            {
                lock (EventQueue)
                {
                    foreach (LogEvent le in lex)
                    {
                        EventQueue.Enqueue(le);
                    }
                    QueueWakeupEvent.Set();
                }
            }
        }

        private void LogLineProcessorThread()
        {
            List<LogEvent> lxx = new List<LogEvent>();
            WaitHandle[] wh = new WaitHandle[2];
            wh[0] = ExitEvent;
            wh[1] = QueueWakeupEvent;
            if (ReadyForOperation() == false)
            {
                do
                {
                    Thread.Sleep(100);
                } while (ReadyForOperation() == false);
            }
            EventQueue.Clear();
            while (true)
            {
                switch (WaitHandle.WaitAny(wh, Timeout.Infinite))
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            lock (EventQueue)
                            {
                                lxx.AddRange(EventQueue);
                                EventQueue.Clear();
                                QueueWakeupEvent.Reset();
                            }
                            foreach (LogEvent lx in lxx)
                            {
                                LogLineProcessor(lx);
                            }
                            lxx.Clear();
                        }
                        break;
                }
            }
        }

        internal void LogLineProcessor(LogEvent le)
        {
            if (firstevent == true)
            {
                PluginBridges.BridgeFFXIV.SubscribeToZoneChanged(this);
                firstevent = false;
            }
            switch (le.Source)
            {
                case LogEvent.SourceEnum.Log:
                    lock (ActiveTextTriggers) // verified
                    {
                        foreach (Trigger t in ActiveTextTriggers)
                        {
                            if (t.ZoneBlocked == true && le.TestMode == false)
                            {
                                continue;
                            }
                            TestTrigger(t, le, Action.TriggerForceTypeEnum.NoSkip);
                        }
                    }
                    break;
                case LogEvent.SourceEnum.NetworkFFXIV:
                    lock (ActiveFFXIVNetworkTriggers) // verified
                    {
                        foreach (Trigger t in ActiveFFXIVNetworkTriggers)
                        {
                            if (t.ZoneBlocked == true && le.TestMode == false)
                            {
                                continue;
                            }
                            TestTrigger(t, le, Action.TriggerForceTypeEnum.NoSkip);
                        }
                    }
                    break;
                case LogEvent.SourceEnum.ACT:
                    lock (ActiveACTTriggers) // verified
                    {
                        foreach (Trigger t in ActiveACTTriggers)
                        {
                            if (t.ZoneBlocked == true && le.TestMode == false)
                            {
                                continue;
                            }
                            TestTrigger(t, le, Action.TriggerForceTypeEnum.NoSkip);
                        }
                    }
                    break;
                case LogEvent.SourceEnum.Endpoint:
                    lock (ActiveEndpointTriggers) // verified
                    {
                        foreach (Trigger t in ActiveEndpointTriggers)
                        {
                            if (t.ZoneBlocked == true && le.TestMode == false)
                            {
                                continue;
                            }
                            TestTrigger(t, le, Action.TriggerForceTypeEnum.NoSkip);
                        }
                    }
                    break;
            }
            double del = (DateTime.Now - le.Timestamp).TotalMilliseconds;
            if (del > 100.0)
            {
                if ((DateTime.Now - LastDelayWarning).TotalSeconds > 10.0)
                {
                    FilteredAddToLog(DebugLevelEnum.Warning, I18n.Translate("internal/Plugin/warnprocdelay", "Line ({0}) took {1} ms to process, may be falling behind", le.Text, del));
                    LastDelayWarning = DateTime.Now;
                }
            }
        }

        internal void ZoneChanged(string zone)
        {
            int allowed = 0, restricted = 0;
            lock (Triggers)
            {
                foreach (Trigger t in Triggers)
                {
                    bool block = (t.PassesZoneRestriction(zone) == false);
                    t.ZoneBlocked = block;
                    if (block)
                    {
                        restricted++;
                    }
                    else
                    {
                        allowed++;
                    }
                }
            }
            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/zoneupdate", "Zone update to '{0}' - allowed triggers: {1}, restricted triggers: {2}", zone, allowed, restricted));
        }

        public void ExtendedACTEvents(string[] data)
        {
            switch (data[0])
            {
                case "OnCombatStart":
                case "OnCombatEnd":
                    LogLineQueuer(data[0], currentZone != null ? currentZone : "", LogEvent.SourceEnum.ACT);
                    break;
            }
        }

        public void EndpointReceive(string data)
        {
            string detectedZone = currentZone != null ? currentZone : "";
            try
            {
                if (cfg.LogEndpoint == true)
                {
                    FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/endpointline", "Endpoint data: ({0})", data));
                }
                LogLineQueuer(data, detectedZone, LogEvent.SourceEnum.Endpoint);
            }
            catch (Exception ex)
            {
                FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/endpointlineprocex", "Exception ({0}) when processing endpoint data ({1}) in zone ({2})", ex.ToString(), data, detectedZone));
            }
        }

        public void BeforeLogLineRead(bool isImport, string logLine, string detectedZone)
        {
            if (isImport == true || isInitialized == false)
            {
                return;
            }
            if (currentZone == null || detectedZone != currentZone)
            {
                currentZone = detectedZone;
                ZoneChanged(currentZone);
            }
            try
            {
                if (cfg.FfxivLogNetwork == true)
                {
                    FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/ffxivnetworklogline", "Network log line: ({0})", logLine));
                }
                LogLineQueuer(logLine, detectedZone, LogEvent.SourceEnum.NetworkFFXIV);
            }
            catch (Exception ex)
            {
                FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/ffxivnetworkprocex", "Exception ({0}) when processing network log line ({1}) in zone ({2})", ex.Message, logLine, detectedZone));
            }
        }

        public void OnLogLineRead(bool isImport, string logLine, string detectedZone)
        {
            if (isImport == true || isInitialized == false)
            {
                return;
            }
            if (currentZone == null || detectedZone != currentZone)
            {
                currentZone = detectedZone;
                ZoneChanged(currentZone);
            }
            try
            {
                if (logLine != "" && (logLine.Length < 5 || logLine.Substring(logLine.Length - 5) != "] FB:"))
                {
                    if (cfg.LogNormalEvents == true)
                    {
                        FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/logline", "Log line: ({0})", logLine));
                    }
                    LogLineQueuer(logLine, detectedZone, LogEvent.SourceEnum.Log);
                }
            }
            catch (Exception ex)
            {
                FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/procex", "Exception ({0}) when processing log line ({1}) in zone ({2})", ex.Message, logLine, detectedZone));
            }
        }

        public void ZoneChangeDelegate(uint ZoneID, string ZoneName) // BridgeFFXIV.SubscribeToZoneChanged()
        {
            PluginBridges.BridgeFFXIV.ZoneID = ZoneID;
            // to-do: Memory.UpdateOffset1B(); // async  
            ZoneChanged(currentZone);
        }

        public Control GetCornerControl()
        {
            return ui.btnCornerPopup;
        }

        private void ClearCache()
        {
            int cleared = 0, clearedt = 0;
            cleared = ClearCache("TriggernometryRemoteImages", cfg.CacheImageExpiry);
            if (cleared > 0)
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/cachecleanimage", "{0} item(s) cleared from image cache with expiry {1}", cleared, cfg.CacheImageExpiry));
                clearedt += cleared;
            }
            cleared = ClearCache("TriggernometryRemoteSounds", cfg.CacheSoundExpiry);
            if (cleared > 0)
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/cachecleansound", "{0} item(s) cleared from sound cache with expiry {1}", cleared, cfg.CacheSoundExpiry));
                clearedt += cleared;
            }
            cleared = ClearCache("TriggernometryJsonCache", cfg.CacheJsonExpiry);
            if (cleared > 0)
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/cachecleanjson", "{0} item(s) cleared from JSON cache with expiry {1}", cleared, cfg.CacheJsonExpiry));
                clearedt += cleared;
            }
            cleared = ClearCache("TriggernometryRepoBackups", cfg.CacheRepoExpiry);
            if (cleared > 0)
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/cachecleanrepo", "{0} item(s) cleared from repository cache with expiry {1}", cleared, cfg.CacheRepoExpiry));
                clearedt += cleared;
            }
            if (clearedt > 0)
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/cacheclean", "Total of {0} cached item(s) cleared", clearedt));
            }
        }

        internal int ClearCache(string cachedir, int expiry)
        {
            string cachepath = Path.Combine(path, cachedir);
            DateTime dt = DateTime.Now.AddMinutes(0 - expiry);
            DirectoryInfo di = new DirectoryInfo(cachepath);
            if (di.Exists == true)
            {
                int i = 0;
                FileInfo[] fis = di.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    if (fi.LastWriteTime < dt)
                    {
                        fi.Delete();
                        i++;
                    }
                }
                return i;
            }
            return 0;
        }
    }

}
