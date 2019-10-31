using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Costura;

namespace TriggernometryProxy
{

    public class ProxyPlugin : IActPluginV1
    {

        private Triggernometry.RealPlugin Instance;

        private ActPluginData ActPluginPrevious = null;

        public ProxyPlugin()
        {
            CosturaUtility.Initialize();
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            Instance = new Triggernometry.RealPlugin();
            Instance.mainform = ActGlobals.oFormActMain;
            Instance.InCombatHook = InCombat;
            Instance.EndCombatHook = EndCombat;
            Instance.CurrentZoneHook = GetCurrentZone;
            Instance.ActiveEncounterHook = ExportActiveEncounter;
            Instance.LastEncounterHook = ExportLastEncounter;
            Instance.EncounterDurationHook = GetEncounterDuration;
            Instance.TtsPlaybackHook = InvokeTtsMethod;
            Instance.SoundPlaybackHook = InvokeSoundMethod;
            Instance.CustomTriggerCheckHook = HasCustomTriggers;
            Instance.CustomTriggerHook = GetCustomTriggers;
            Triggernometry.RealPlugin.InstanceHook = GetInstance;
            GetPluginNameAndPath();
            ActGlobals.oFormActMain.OnLogLineRead += OFormActMain_OnLogLineRead;
            Instance.InitPlugin(pluginScreenSpace, pluginStatusText);
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;
            Instance.DeInitPlugin();
        }

        private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            Instance.OnLogLineRead(isImport, logInfo.logLine, logInfo.detectedZone);
        }

        public void GetPluginNameAndPath()
        {
            Instance.path = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config");
            Instance.pluginPath = Instance.path;
            string name = null;
            foreach (ActPluginData p in ActGlobals.oFormActMain.ActPlugins)
            {
                if (p.pluginObj == this)
                {
                    name = p.pluginFile.Name;
                    Instance.pluginPath = p.pluginFile.Directory.FullName;
                    break;
                }
            }
            if (name == null || name.Trim().Length == 0)
            {
                name = "Triggernometry";
            }
            Instance.pluginName = name;
        }

        public bool InCombat()
        {
            return ActGlobals.oFormActMain.InCombat;
        }

        public void EndCombat()
        {
            ActGlobals.oFormActMain.EndCombat(false);
        }

        public string GetCurrentZone()
        {
            return ActGlobals.oFormActMain.CurrentZone;
        }

        public string ExportLastEncounter()
        {
            Advanced_Combat_Tracker.FormActMain act = Advanced_Combat_Tracker.ActGlobals.oFormActMain;
            FieldInfo fi = act.GetType().GetField("defaultTextFormat", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            dynamic texf = fi.GetValue(act);
            if (texf != null)
            {
                int zones = act.ZoneList.Count;
                for (int ii = zones - 1; ii >= 0; ii--)
                {
                    int encs = act.ZoneList[ii].Items.Count;
                    for (int jj = encs - 1; jj >= 1; jj--)
                    {
                        if (act.ZoneList[ii].Items[jj] != act.ActiveZone.ActiveEncounter)
                        {
                            return act.GetTextExport(act.ZoneList[ii].Items[jj], texf);
                        }
                    }
                }
            }
            return "";
        }

        public string ExportActiveEncounter()
        {
            Advanced_Combat_Tracker.FormActMain act = Advanced_Combat_Tracker.ActGlobals.oFormActMain;
            FieldInfo fi = act.GetType().GetField("defaultTextFormat", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            dynamic texf = fi.GetValue(act);
            return act.GetTextExport(act.ActiveZone.ActiveEncounter, texf);
        }

        public double GetEncounterDuration()
        {
            return ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Duration.TotalSeconds;
        }

        public void InvokeTtsMethod(string tts)
        {
            if (ActGlobals.oFormActMain.PlayTtsMethod != null)
            {
                ActGlobals.oFormActMain.PlayTtsMethod(tts);
            }
        }

        public void InvokeSoundMethod(string filename, int volume)
        {
            if (ActGlobals.oFormActMain.PlaySoundMethod != null)
            {
                ActGlobals.oFormActMain.PlaySoundMethod(filename, volume);
            }
        }

        public bool HasCustomTriggers()
        {
            return (ActGlobals.oFormActMain.CustomTriggers.Count > 0);
        }

        public List<Triggernometry.RealPlugin.CustomTriggerCategoryProxy> GetCustomTriggers()
        {
            List<Triggernometry.RealPlugin.CustomTriggerCategoryProxy> alltrigs = new List<Triggernometry.RealPlugin.CustomTriggerCategoryProxy>(); ;
            var trigs = from ix in ActGlobals.oFormActMain.CustomTriggers
                        group ix by new { ix.Value.Category, ix.Value.RestrictToCategoryZone } into ixs
                        select new { Key = ixs.Key, Items = ixs.ToList() };
            foreach (var trig in trigs)
            {
                Triggernometry.RealPlugin.CustomTriggerCategoryProxy ctp = new Triggernometry.RealPlugin.CustomTriggerCategoryProxy();
                ctp.Category = trig.Key.Category;
                ctp.RestrictToCategoryZone = trig.Key.RestrictToCategoryZone;
                foreach (var tx in trig.Items)
                {
                    Triggernometry.RealPlugin.CustomTriggerProxy ct = new Triggernometry.RealPlugin.CustomTriggerProxy();
                    ct.Active = tx.Value.Active;
                    ct.ShortRegexString = tx.Value.ShortRegexString;
                    ct.SoundData = tx.Value.SoundData;
                    ct.SoundType = tx.Value.SoundType;
                    ct.TimerName = tx.Value.TimerName;
                    ct.Tabbed = tx.Value.Tabbed;
                    ct.Timer = tx.Value.Timer;
                    ctp.Items.Add(ct);
                }
                alltrigs.Add(ctp);
            }
            return alltrigs;
        }

        public Triggernometry.RealPlugin.PluginWrapper GetInstance(string ActPluginName, string ActPluginType)
        {
            foreach (ActPluginData p in ActGlobals.oFormActMain.ActPlugins)
            {
                string tn = p.pluginObj != null ? p.pluginObj.GetType().Name : "(null)";
                if (
                    (
                        (String.Compare(p.pluginFile.Name, ActPluginName, true) == 0)
                        ||
                        (String.Compare(tn, ActPluginType, true) == 0)
                    )
                    &&
                    (String.Compare(p.lblPluginStatus.Text, "FFXIV Plugin Started.", true) == 0)
                )
                {
                    if (ActPluginPrevious == p)
                    {
                        return new Triggernometry.RealPlugin.PluginWrapper() { pluginObj = p.pluginObj, state = 1 };
                    }
                    else
                    {
                        ActPluginPrevious = p;
                        System.Diagnostics.FileVersionInfo vi = System.Diagnostics.FileVersionInfo.GetVersionInfo(p.pluginFile.FullName);
                        int[] expectedActVer = new int[4] { 2, 0, 1, 5 };
                        string expectedActVers = "2.0.1.5";
                        int[] currentActVer = new int[4] { vi.FileMajorPart, vi.FileMinorPart, vi.FileBuildPart, vi.FilePrivatePart };                        
                        for (int i = 0; i < 4; i++)
                        {
                            if (currentActVer[i] > expectedActVer[i])
                            {
                                break;
                            }
                            if (currentActVer[i] < expectedActVer[i])
                            {                                
                                return new Triggernometry.RealPlugin.PluginWrapper() { pluginObj = p.pluginObj, state = 2, fileversion = vi.FileVersion.ToString(), expectedversion = expectedActVers };
                            }
                        }
                        return new Triggernometry.RealPlugin.PluginWrapper() { pluginObj = p.pluginObj, state = 1 };
                    }
                }
            }
            return new Triggernometry.RealPlugin.PluginWrapper() { pluginObj = null, state = 0 };
        }

    }

}
