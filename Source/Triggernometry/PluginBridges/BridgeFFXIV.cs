using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Linq;
using System.Globalization;
using Advanced_Combat_Tracker;

namespace Triggernometry.PluginBridges
{

    public static class BridgeFFXIV
    {

        private static string ActPluginName = "FFXIV_ACT_Plugin.dll";
        private static string ActPluginType = "FFXIV_ACT_Plugin";
        private static ActPluginData ActPluginPrevious = null;

        internal delegate void LoggingDelegate(Plugin.DebugLevelEnum level, string text);
        internal static event LoggingDelegate OnLogEvent;

        public static Int64 LastCheck = 0;
        public static Int64 TickNum = 0;
        public static uint PlayerId = 0;

        public static Configuration cfg;

        public static List<VariableClump> PartyMembers = new List<VariableClump>(new VariableClump[8] {
            new VariableClump(), new VariableClump(), new VariableClump(), new VariableClump(),
            new VariableClump(), new VariableClump(), new VariableClump(), new VariableClump()
        });
        public static int NumPartyMembers = 0;
        public static VariableClump Myself;

        internal static bool ckw = false;
        private static List<Int64> cks = new List<long>();

        internal static string ConvertToHex(Int64 x)
        {
            return x.ToString("X8");
        }

        private delegate void NetworkReceiveDelegate(string connection, long epoch, byte[] message);

        public static void SubscribeToNetworkEvents(Plugin p)
        {
            try
            {
                object plug = GetInstance();
                if (plug == null)
                {
                    throw new ArgumentException("No plugin instance available");
                }
                PropertyInfo pi = plug.GetType().GetProperty("DataSubscription", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (pi == null)
                {
                    throw new ArgumentException("No DataSubscription found");
                }
                dynamic subs = pi.GetValue(plug);
                if (subs == null)
                {
                    throw new ArgumentException("DataSubscription not initialized");
                }
                EventInfo ei = subs.GetType().GetEvent("ParsedLogLine", BindingFlags.GetField | BindingFlags.Public | BindingFlags.Instance);
                if (subs == null)
                {
                    throw new ArgumentException("No ParsedLogLine found");
                }
                MethodInfo mix = p.GetType().GetMethod("NetworkLogLineReceiver");
                Type deltype = ei.EventHandlerType;
                Delegate handler = Delegate.CreateDelegate(deltype, p, mix);
                ei.AddEventHandler(subs, handler);
                LogMessage(Plugin.DebugLevelEnum.Info, I18n.Translate("internal/ffxiv/networksubok", "Subscribed to FFXIV network events"));
            }
            catch (Exception ex)
            {
                LogMessage(Plugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/networksubexception", "Could not subscribe to FFXIV network events due to an exception: {0}", ex.Message));
            }
        }

        public static void UnsubscribeFromNetworkEvents(Plugin p)
        {
            try
            {
                object plug = GetInstance();
                if (plug == null)
                {
                    throw new ArgumentException("No plugin instance available");
                }
                PropertyInfo pi = plug.GetType().GetProperty("DataSubscription", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (pi == null)
                {
                    throw new ArgumentException("No DataSubscription found");
                }
                dynamic subs = pi.GetValue(plug);
                if (subs == null)
                {
                    throw new ArgumentException("DataSubscription not initialized");
                }
                EventInfo ei = subs.GetType().GetEvent("ParsedLogLine", BindingFlags.GetField | BindingFlags.Public | BindingFlags.Instance);
                if (subs == null)
                {
                    throw new ArgumentException("No ParsedLogLine found");
                }
                MethodInfo mix = p.GetType().GetMethod("NetworkLogLineReceiver");
                Type deltype = ei.EventHandlerType;
                Delegate handler = Delegate.CreateDelegate(deltype, p, mix);
                ei.RemoveEventHandler(subs, handler);
                LogMessage(Plugin.DebugLevelEnum.Info, I18n.Translate("internal/ffxiv/networkunsubok", "Unsubscribed from FFXIV network events"));
            }
            catch (Exception ex)
            {
                LogMessage(Plugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/networkunsubexception", "Could not unsubscribe from FFXIV network events due to an exception: {0}", ex.Message));
            }
        }

        private static void LogMessage(Plugin.DebugLevelEnum level, string message)
        {
            if (OnLogEvent != null)
            {
                OnLogEvent(level, message);
            }
        }

        public static string TranslateJob(string id)
        {
            switch (id)
            {
                // JOBS
                case "33": return "AST";
                case "23": return "BRD";
                case "25": return "BLM";
                case "36": return "BLU";
                case "38": return "DNC";
                case "32": return "DRK";
                case "22": return "DRG";
                case "37": return "GNB";
                case "31": return "MCH";
                case "20": return "MNK";
                case "30": return "NIN";
                case "19": return "PLD";
                case "35": return "RDM";
                case "34": return "SAM";
                case "28": return "SCH";
                case "27": return "SMN";
                case "21": return "WAR";
                case "24": return "WHM";
                // CRAFTERS
                case "14": return "ALC";
                case "10": return "ARM";
                case "9": return "BSM";
                case "8": return "CRP";
                case "15": return "CUL";
                case "11": return "GSM";
                case "12": return "LTW";
                case "13": return "WVR";
                // GATHERERS
                case "17": return "BTN";
                case "18": return "FSH";
                case "16": return "MIN";
                // CLASSES
                case "26": return "ACN";
                case "5": return "ARC";
                case "6": return "CNJ";
                case "1": return "GLA";
                case "4": return "LNC";
                case "3": return "MRD";
                case "2": return "PUG";
                case "29": return "ROG";
                case "7": return "THM";
            }
            return "";
        }

        public static string TranslateRole(string id)
        {
            switch (id)
            {
                // JOBS
                case "33": return "Healer";
                case "23": return "DPS";
                case "25": return "DPS";
                case "36": return "DPS";
                case "38": return "DPS";
                case "32": return "Tank";
                case "22": return "DPS";
                case "37": return "Tank";
                case "31": return "DPS";
                case "20": return "DPS";
                case "30": return "DPS";
                case "19": return "Tank";
                case "35": return "DPS";
                case "34": return "DPS";
                case "28": return "Healer";
                case "27": return "DPS";
                case "21": return "Tank";
                case "24": return "Healer";
                // CRAFTERS
                case "14": return "Crafter";
                case "10": return "Crafter";
                case "9": return "Crafter";
                case "8": return "Crafter";
                case "15": return "Crafter";
                case "11": return "Crafter";
                case "12": return "Crafter";
                case "13": return "Crafter";
                // GATHERERS
                case "17": return "Gatherer";
                case "18": return "Gatherer";
                case "16": return "Gatherer";
                // CLASSES
                case "26": return "Healer";
                case "5": return "DPS";
                case "6": return "Healer";
                case "1": return "Tank";
                case "4": return "DPS";
                case "3": return "Tank";
                case "2": return "DPS";
                case "29": return "DPS";
                case "7": return "DPS";
            }
            return "";
        }

        public static void PopulateClumpFromCombatant(VariableClump vc, dynamic cmx, int inParty, int orderNum)
        {
            vc.SetValue("name", cmx.Name);
            vc.SetValue("currenthp", cmx.CurrentHP);
            vc.SetValue("currentmp", cmx.CurrentMP);
            vc.SetValue("currentgp", cmx.CurrentGP);
            vc.SetValue("currentcp", cmx.CurrentCP);
            vc.SetValue("maxhp", cmx.MaxHP);
            vc.SetValue("maxmp", cmx.MaxMP);
            vc.SetValue("maxgp", cmx.MaxGP);
            vc.SetValue("maxcp", cmx.MaxCP);
            vc.SetValue("level", cmx.Level);
            vc.SetValue("jobid", cmx.Job);
            vc.SetValue("job", TranslateJob(cmx.Job.ToString()));
            vc.SetValue("role", TranslateRole(cmx.Job.ToString()));
            vc.SetValue("x", cmx.PosX);
            vc.SetValue("y", cmx.PosY);
            vc.SetValue("z", cmx.PosZ);
            vc.SetValue("id", ConvertToHex(cmx.ID));
            vc.SetValue("inparty", inParty);
            vc.SetValue("order", orderNum);
            if (cmx.IsCasting == true)
            {
                vc.SetValue("casttargetid", ConvertToHex(cmx.CastTargetID));
            }
            else
            {
                vc.SetValue("casttargetid", 0);
            }
            if (cmx.TargetID > 0)
            {
                vc.SetValue("targetid", ConvertToHex(cmx.TargetID));
            }
            else
            {
                vc.SetValue("targetid", 0);
            }
            vc.SetValue("heading", cmx.Heading);
            vc.SetValue("distance", cmx.EffectiveDistance);
            vc.SetValue("worldid", cmx.WorldID);
            vc.SetValue("worldname", cmx.WorldName);
            vc.SetValue("currentworldid", cmx.CurrentWorldID);
        }

        private static object GetInstance()
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
                        return p.pluginObj;
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
                                LogMessage(Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/ffxiv/oldactplugin", "FFXIV ACT plugin version is lower ({0}) than expected ({1}), some functions may not work as expected", vi.FileVersion, expectedActVers));
                                break;
                            }
                        }
                        return p.pluginObj;
                    }
                }
            }
            if (ckw == false)
            {
                LogMessage(Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/ffxiv/missingactplugin", "FFXIV ACT plugin with filename ({0}) or type ({1}) could not be located, some functions may not work as expected", ActPluginName, ActPluginType));
                ckw = true;
            }
            return null;
        }

        private static PropertyInfo GetDataRepository(object plug)
        {
            return plug.GetType().GetProperty("DataRepository", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private class CombatantData
        {

            public object Lock { get; set; }
            public dynamic Combatants { get; set; }

        }

        private static CombatantData GetCombatants(object plug, PropertyInfo reprop)
        {
            if (reprop == null)
            {
                // use _Memory
                FieldInfo fi = plug.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                dynamic mmry = fi.GetValue(plug);
                if (mmry == null)
                {
                    return null;
                }
                fi = mmry.GetType().GetField("_config", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                dynamic cnfg = fi.GetValue(mmry);
                if (cnfg == null)
                {
                    return null;
                }
                fi = cnfg.GetType().GetField("ScanCombatants", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                dynamic cmbt = fi.GetValue(cnfg);
                if (cmbt == null)
                {
                    return null;
                }
                fi = cmbt.GetType().GetField("_CurrentPlayerID", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                PlayerId = fi.GetValue(cmbt);
                CombatantData cd = new CombatantData();
                fi = cmbt.GetType().GetField("_Combatants", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                cd.Combatants = fi.GetValue(cmbt);
                fi = cmbt.GetType().GetField("_CombatantsLock", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                cd.Lock = fi.GetValue(cmbt);
                return cd;
            }
            else
            {
                // use DataRepository
                MethodInfo mi = reprop.GetGetMethod();
                object o = mi.Invoke(plug, null);
                mi = o.GetType().GetMethod("GetCurrentPlayerID", BindingFlags.Instance | BindingFlags.Public);
                PlayerId = (uint)mi.Invoke(o, null);
                mi = o.GetType().GetMethod("GetCombatantList", BindingFlags.Instance | BindingFlags.Public);
                CombatantData cd = new CombatantData();
                cd.Combatants = mi.Invoke(o, null);
                cd.Lock = cd;
                return cd;
            }
        }

        public static void UpdateState()
        {
            int phase = 0;
            try
            {
                Int64 old = Interlocked.Read(ref LastCheck);
                Int64 now = DateTime.Now.Ticks;
                if (((now - old) / TimeSpan.TicksPerMillisecond) < 1000)
                {
                    return;
                }
                Interlocked.Exchange(ref LastCheck, now);
                object plug = null;
                phase = 99;
                plug = GetInstance();
                if (plug == null)
                {
                    return;
                }
                phase = 1;
                PropertyInfo pi = GetDataRepository(plug);
                phase = 2;
                CombatantData cd = GetCombatants(plug, pi);
                phase = 3;
                lock (cd.Lock)
                {
                    int ex = 0;
                    foreach (dynamic cmx in cd.Combatants)
                    {
                        int nump;
                        try
                        {
                            nump = (int)cmx.PartyType;
                        }
                        catch (Exception)
                        {
                            nump = 0;
                        }
                        if (cmx.ID == PlayerId || nump == 1)
                        {
                            if (ex >= PartyMembers.Count)
                            {
                                throw new InvalidOperationException(I18n.Translate("internal/ffxiv/partytoobig", "Party structure has more than {0} members", PartyMembers.Count));
                            }
                            phase = 4;
                            if (cmx.ID == PlayerId)
                            {
                                Myself = PartyMembers[ex];
                            }
                            phase = 5;
                            PopulateClumpFromCombatant(PartyMembers[ex], cmx, 1, ex + 1);
                            phase = 6;
                            ex++;
                            if (ex >= PartyMembers.Count)
                            {
                                // full party found
                                break;
                            }
                        }
                    }
                    phase = 7;
                    if (cfg.FfxivPartyOrdering == Configuration.FfxivPartyOrderingEnum.CustomSelfFirst)
                    {
                        //DebugPlayerSorting("a1", PartyMembers);
                        PartyMembers.Sort(SortPlayersSelf);
                        int ro = 1;
                        foreach (VariableClump vc in PartyMembers)
                        {
                            vc.SetValue("order", "" + ro);
                            ro++;
                        }
                        //DebugPlayerSorting("a2", PartyMembers);
                    }
                    else if (cfg.FfxivPartyOrdering == Configuration.FfxivPartyOrderingEnum.CustomFull)
                    {
                        //DebugPlayerSorting("b1", PartyMembers);
                        PartyMembers.Sort(SortPlayers);
                        int ro = 1;
                        foreach (VariableClump vc in PartyMembers)
                        {
                            vc.SetValue("order", "" + ro);
                            ro++;
                        }
                        //DebugPlayerSorting("b2", PartyMembers);
                    }
                    phase = 8;
                    NumPartyMembers = ex;
                }
            }
            catch (Exception ex)
            {
                LogMessage(Plugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/updateexception", "Exception in FFXIV state update: {0} at stage {1}", ex.Message, phase));
            }
        }

        /*private static void DebugPlayerSorting(string header, IEnumerable<VariableClump> vc)
        {
            int ro = 1;
            foreach (VariableClump a in vc)
            {
                System.Diagnostics.Debug.WriteLine(header + ": " + ro + " -- " + a.GetValue("name") + ", " + a.GetValue("job") + " --> " + a.GetValue("order") + " / " + cfg.GetPartyOrderValue(a.GetValue("jobid")));
                ro++;
            }
        }*/

        public static int SortPlayersSelf(VariableClump a, VariableClump b)
        {
            if (a == Myself && b != Myself)
            {
                //System.Diagnostics.Debug.WriteLine(a.GetValue("name") + " (ME) < " + b.GetValue("name"));
                return -1;
            }
            if (b == Myself && a != Myself)
            {
                //System.Diagnostics.Debug.WriteLine(a.GetValue("name") + " > " + b.GetValue("name") + " (ME)");
                return 1;
            }
            return SortPlayers(a, b);
        }

        public static int SortPlayers(VariableClump a, VariableClump b)
        {
            int av = cfg.GetPartyOrderValue(a.GetValue("jobid"));
            int bv = cfg.GetPartyOrderValue(b.GetValue("jobid"));
            if (av < bv)
            {
                //System.Diagnostics.Debug.WriteLine(a.GetValue("name") + " (" + av + ") < " + b.GetValue("name") + " (" + bv + ")");
                return -1;
            }
            if (av > bv)
            {
                //System.Diagnostics.Debug.WriteLine(a.GetValue("name") + " (" + av + ") > " + b.GetValue("name") + " (" + bv + ")");
                return 1;
            }
            //System.Diagnostics.Debug.WriteLine(a.GetValue("name") + " (" + av + ") -(" + a.GetValue("name").CompareTo(b.GetValue("name")) + ")- " + b.GetValue("name") + " (" + bv + ")");
            return a.GetValue("name").CompareTo(b.GetValue("name"));
        }

        public static VariableClump GetNamedEntity(string name)
        {
            VariableClump vc = new VariableClump();
            try
            {
                object plug = null;
                plug = GetInstance();
                if (plug == null)
                {
                    return vc;
                }
                PropertyInfo pi = GetDataRepository(plug);
                CombatantData cd = GetCombatants(plug, pi);
                lock (cd.Lock)
                {
                    foreach (dynamic cmx in cd.Combatants)
                    {                        
                        if (cmx.Name == name)
                        {
                            int inParty = 0;
                            try
                            {
                                if ((int)cmx.PartyType == 1)
                                {
                                    inParty = 1;
                                }
                                else
                                {
                                    inParty = 0;
                                }
                            }
                            catch (Exception)
                            {
                                inParty = 0;
                            }
                            PopulateClumpFromCombatant(vc, cmx, inParty, 0);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(Plugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/namedexception", "Exception in FFXIV named entity retrieve: {0}", ex.Message));
            }
            return vc;
        }

        public static VariableClump GetIdEntity(string id, out bool found)
        {
            VariableClump vc = new VariableClump();
            found = false;
            try
            {
                object plug = null;
                plug = GetInstance();
                if (plug == null)
                {
                    return vc;
                }
                PropertyInfo pi = GetDataRepository(plug);
                CombatantData cd = GetCombatants(plug, pi);
                lock (cd.Lock)
                {
                    foreach (dynamic cmx in cd.Combatants)
                    {
                        if (String.Compare(ConvertToHex(cmx.ID), id, true) == 0)
                        {
                            int inParty = 0;
                            try
                            {
                                if ((int)cmx.PartyType == 1)
                                {
                                    inParty = 1;
                                }
                                else
                                {
                                    inParty = 0;
                                }
                            }
                            catch (Exception)
                            {
                                inParty = 0;
                            }
                            PopulateClumpFromCombatant(vc, cmx, inParty, 0);
                            found = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(Plugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/idexception", "Exception in FFXIV ID entity retrieve: {0}", ex.Message));
            }
            return vc;
        }

        public static VariableClump GetPartyMember(int index)
        {
            UpdateState();
            if (index < 1 || index > NumPartyMembers)
            {
                return new VariableClump();
            }
            return PartyMembers[index - 1];
        }

        public static VariableClump GetMyself()
        {
            UpdateState();
            return Myself;
        }

        public static VariableClump GetNamedPartyMember(string name)
        {
            UpdateState();
            foreach (VariableClump vc in PartyMembers)
            {
                if (vc.GetValue("name") == name)
                {
                    return vc;
                }
            }
            return new VariableClump();
        }

        public static VariableClump GetIdPartyMember(string id, out bool found)
        {
            found = false;
            UpdateState();
            foreach (VariableClump vc in PartyMembers)
            {
                if (String.Compare(vc.GetValue("id"), id, true) == 0)
                {
                    found = true;
                    return vc;
                }
            }
            return new VariableClump();
        }

    }

}
