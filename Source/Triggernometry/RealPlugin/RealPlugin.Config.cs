using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Variables;

namespace Triggernometry
{

    public partial class RealPlugin
    {

        private Configuration _cfg;
        internal Configuration cfg
        {
            get
            {
                return _cfg;
            }
        }

        internal bool configBroken = false;
        internal DateTime lastConfigSave = DateTime.Now;

        private void AutofixConfiguration()
        {
            if (cfg == null)
            {
                return;
            }
            if (cfg._ShowWelcomeHasBeenSet == false && (cfg.Root.Folders.Count > 0 || cfg.Root.Triggers.Count > 0))
            {
                cfg.ShowWelcome = false;
            }
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            if (v < new Version("1.1.6.0"))
            {
                if (cfg.FfxivPartyOrdering == Configuration.FfxivPartyOrderingEnum.Legacy)
                {
                    cfg.FfxivPartyOrdering = Configuration.FfxivPartyOrderingEnum.CustomSelfFirst;
                }
            }
            Configuration dummy = new Configuration();
            foreach (KeyValuePair<string, VariableScalar> kp in dummy.Constants)
            {
                if (cfg.Constants.ContainsKey(kp.Key) == false)
                {
                    cfg.Constants[kp.Key] = new VariableScalar() { Value = kp.Value.Value, LastChanged = kp.Value.LastChanged, LastChanger = kp.Value.LastChanger };
                }
            }
            cfg.Constants["TriggernometryVersionMajor"] = new VariableScalar() { Value = v.Major.ToString() };
            cfg.Constants["TriggernometryVersionMinor"] = new VariableScalar() { Value = v.Minor.ToString() };
            cfg.Constants["TriggernometryVersionBuild"] = new VariableScalar() { Value = v.Build.ToString() };
            cfg.Constants["TriggernometryVersionRevision"] = new VariableScalar() { Value = v.Revision.ToString() };
        }

        public void BackupConfiguration()
        {
            string curver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string cfgver = cfg.PluginVersion ?? "pre1.0.4.4";
            cfg.PrevPluginVersion = cfgver;
            if (cfgver != curver)
            {
                string oldfn = Path.Combine(path, pluginName + ".config.xml");
                string bacfn = Path.Combine(path, pluginName + "." + cfgver + ".config.xml");
                if (File.Exists(oldfn) == true)
                {
                    if (File.Exists(bacfn) == false)
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/cfgbackupupdate", "Plugin updated from {0} to {1}, backing up configuration as {2}", cfgver, curver, bacfn));
                        File.Copy(oldfn, bacfn, false);
                    }
                    else
                    {
                        FilteredAddToLog(DebugLevelEnum.Warning, I18n.Translate("internal/Plugin/cfgbackupdatewarn", "Plugin updated from {0} to {1}, but a backup configuration file already exists, not overwriting", cfgver, curver));
                    }
                }
                cfg.PluginVersion = curver;
            }
        }

        public void SaveCurrentConfig()
        {
            lastConfigSave = DateTime.Now;
            SaveConfigToFile(cfg, Path.Combine(path, pluginName + ".config.xml"), true);
        }

        private Configuration LoadConfigFromFile(string filename)
        {
            try
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/cfgload", "Loading configuration from '{0}'", filename));
                FileInfo fi = new FileInfo(filename);
                string origfilename = filename;
                string cre = "";
                if (fi.Exists == false)
                {
                    FilteredAddToLog(DebugLevelEnum.Warning, I18n.Translate("internal/Plugin/cfgnew", "Configuration file '{0}' does not exist, creating a new configuration", filename));
                    Configuration c = new Configuration();
                    PropertyInfo setter = c.GetType().GetProperty("SecuritySettingsLocked", BindingFlags.NonPublic | BindingFlags.Instance);
                    setter.SetValue(c, true);
                    return c;
                }
                bool corruptFallback = false;
                string lastLine = File.ReadLines(filename).LastOrDefault();
                if (lastLine == null || lastLine.Trim() != "</Configuration>")
                {
                    // configuration has been corrupted, try loading previous config file instead
                    string newfilename = filename + ".previous";
                    fi = new FileInfo(newfilename);
                    // translation file is loaded after this, so the I18n won't work
                    cre = I18n.Translate("internal/Plugin/cfgcorrupted",
                        "Configuration file has been corrupted: \n" +
                        "'{0}' \n\n" +
                        "Loading previous configuration file: \n" +
                        "'{1}'",
                        filename, newfilename);
                    MessageBox.Show(cre, "Triggernometry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (fi.Exists == true)
                    {
                        filename = newfilename;
                        corruptFallback = true;
                    }
                }
                Configuration cx = null;
                XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    cx = (Configuration)xs.Deserialize(fs);
                    PropertyInfo setter = cx.GetType().GetProperty("SecuritySettingsLocked", BindingFlags.NonPublic | BindingFlags.Instance);
                    setter.SetValue(cx, true);
                    cx.isnew = false;
                    cx.lastWrite = fi.LastWriteTimeUtc;
                }
                if (corruptFallback == true)
                {
                    cx.corruptRecoveryError = cre;
                    SaveConfigToFile(cx, origfilename, false);
                }
                return cx;
            }
            catch (Exception ex)
            {
                FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/cfgloadfail", "Loading configuration file failed, make sure you are running the latest version - overwriting configuration suppressed"));
                configBroken = true;
                GenericExceptionHandler(I18n.Translate("internal/Plugin/cfgloadex", "Loading the configuration file '{0}' failed due to an exception", filename), ex);
            }
            return null;
        }

        private void SaveConfigToFile(Configuration cfg, string filename, bool switchprevious)
        {
            try
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/cfgsave", "Saving configuration to '{0}'", filename));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                string test = "";
                ns.Add("", "");
                XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                using (MemoryStream ms = new MemoryStream())
                {
                    PropertyInfo setter = cfg.GetType().GetProperty("SecuritySettingsLocked", BindingFlags.NonPublic | BindingFlags.Instance);
                    setter.SetValue(cfg, false);
                    xs.Serialize(ms, cfg, ns);
                    setter.SetValue(cfg, true);
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        test = sr.ReadToEnd();
                        test = SerializeInvalidXmlCharacters(test);
                    }
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    using (StreamWriter sw = new StreamWriter(ms))
                    {
                        sw.Write(test);
                        sw.Flush();
                        ms.Position = 0;
                        Configuration cx = (Configuration)xs.Deserialize(ms);
                    }
                }
                using (FileStream fs = File.Open(filename + ".temp", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(test);
                        sw.Flush();
                    }
                }
                string lastLine = File.ReadLines(filename + ".temp").LastOrDefault();
                if (lastLine == null || lastLine.Trim() != "</Configuration>")
                {
                    throw new Exception(I18n.Translate("internal/Plugin/cfgsaveincomplete", "The saving process was interrupted.") + "\n");
                }
                if (switchprevious == true)
                {
                    if (File.Exists(filename + ".previous") == true)
                    {
                        File.Delete(filename + ".previous");
                    }
                    if (File.Exists(filename) == true)
                    {
                        File.Move(filename, filename + ".previous");
                    }
                    File.Move(filename + ".temp", filename);
                }
                else
                {
                    File.Copy(filename + ".temp", filename, true);
                    File.Delete(filename + ".temp");
                }
            }
            catch (Exception ex)
            {
                GenericExceptionHandler(I18n.Translate("internal/Plugin/cfgsaveex", "Saving the configuration file '{0}' failed due to an exception", filename), ex);
            }
        }

    }
}
