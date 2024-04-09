using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using Triggernometry.Variables;
using System.Linq;
using System.Text;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;

namespace Triggernometry.PluginBridges
{

    public static class BridgeFFXIV
    {

        private static string ActPluginName = "FFXIV_ACT_Plugin.dll";
        private static string ActPluginType = "FFXIV_ACT_Plugin";

        internal static VariableDictionary _nullCombatant = new VariableDictionary();
        public static VariableDictionary NullCombatant => (VariableDictionary)_nullCombatant.Duplicate(); // for scripts

        internal delegate void LoggingDelegate(RealPlugin.DebugLevelEnum level, string text);
        internal static event LoggingDelegate OnLogEvent;

        public static Int64 LastCheck = 0;
        public static Int64 TickNum = 0;
        public static uint PlayerId = 0;
        public static string PlayerHexId = "";

        public static uint ZoneID = 0;

        public static Configuration cfg;

        public static List<VariableDictionary> PartyMembers = new List<VariableDictionary>(new VariableDictionary[8] {
            new VariableDictionary(), new VariableDictionary(), new VariableDictionary(), new VariableDictionary(),
            new VariableDictionary(), new VariableDictionary(), new VariableDictionary(), new VariableDictionary()
        });
        public static int NumPartyMembers = 0;
        public static int PrevNumPartyMembers = 0;
        public static VariableDictionary Myself;

        internal static bool ckw = false;

        internal static string ConvertToHex(Int64 x)
        {
            return x.ToString("X8");
        }

        private delegate void NetworkReceiveDelegate(string connection, long epoch, byte[] message);

        static BridgeFFXIV()
        {
            SetupNullCombatant();
        }

        public static void ClearCombatant(VariableDictionary vc)
        {
            vc.SetValue("name", "");
            vc.SetValue("currenthp", "");
            vc.SetValue("currentmp", "");
            vc.SetValue("currentgp", "");
            vc.SetValue("currentcp", "");
            vc.SetValue("maxhp", "");
            vc.SetValue("maxmp", "");
            vc.SetValue("maxgp", "");
            vc.SetValue("maxcp", "");
            vc.SetValue("level", "");
            vc.SetValue("jobid", "");
            foreach (var kvp in Entity.jobs["-1"])
            {
                vc.SetValue(kvp.Key, kvp.Value);  // role, job, etc.
            }
            vc.SetValue("x", "");
            vc.SetValue("y", "");
            vc.SetValue("z", "");
            vc.SetValue("h", "");
            vc.SetValue("id", "");
            vc.SetValue("inparty", "");
            vc.SetValue("inalliance", "");
            vc.SetValue("order", "");
            vc.SetValue("casttargetid", "");
            vc.SetValue("targetid", "");
            vc.SetValue("heading", "");
            vc.SetValue("distance", "");
            vc.SetValue("worldid", "");
            vc.SetValue("worldname", "");
            vc.SetValue("currentworldid", "");
            vc.SetValue("bnpcid", "");
            vc.SetValue("bnpcnameid", "");
            vc.SetValue("ownerid", "");
            vc.SetValue("type", "");
            vc.SetValue("iscasting", "");
            vc.SetValue("castid", "");
            vc.SetValue("casttime", "");
            vc.SetValue("maxcasttime", "");
            vc.SetValue("partytype", "");
            vc.SetValue("address", "");
        }

        public static void SetupNullCombatant()
        {
            ClearCombatant(_nullCombatant);
        }

        public static void SubscribeToZoneChanged(RealPlugin p)
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
                EventInfo ei = subs.GetType().GetEvent("ZoneChanged", BindingFlags.GetField | BindingFlags.Public | BindingFlags.Instance);
                if (ei != null)
                {
                    MethodInfo mix = p.GetType().GetMethod("ZoneChangeDelegate");
                    Type deltype = ei.EventHandlerType;
                    Delegate handler = Delegate.CreateDelegate(deltype, p, mix);
                    ei.AddEventHandler(subs, handler);
                }
                else
                {
                    LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/ffxivnozonechanged", "No ZoneChanged found"));
                }
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/ffxivzonechangedexception", "Could not subscribe to FFXIV zone change due to an exception: {0}", ex.Message));
            }
        }

        public static void UnsubscribeFromNetworkEvents(RealPlugin p)
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
                LogMessage(RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/ffxiv/networkunsubok", "Unsubscribed from FFXIV network events"));
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/networkunsubexception", "Could not unsubscribe from FFXIV network events due to an exception: {0}", ex.Message));
            }
        }

        private static void LogMessage(RealPlugin.DebugLevelEnum level, string message)
        {
            if (OnLogEvent != null)
            {
                OnLogEvent(level, message);
            }
        }

        public static void PopulateClumpFromCombatant(VariableDictionary vc, dynamic cmx, int inParty, int inAlliance, int orderNum)
        {
            if (cmx == null || cmx.Name == null) { ClearCombatant(vc); return; }
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
            vc.SetValue("x", cmx.PosX);
            vc.SetValue("y", cmx.PosY);
            vc.SetValue("z", cmx.PosZ);
            vc.SetValue("id", ConvertToHex(cmx.ID));
            vc.SetValue("inparty", inParty);
            vc.SetValue("inalliance", inAlliance);
            vc.SetValue("order", orderNum);
            vc.SetValue("casttargetid", (cmx.IsCasting) ? ConvertToHex(cmx.CastTargetID) : 0);
            vc.SetValue("targetid", (cmx.TargetID > 0) ? ConvertToHex(cmx.TargetID) : 0);
            vc.SetValue("iscasting", Convert.ToInt32(cmx.IsCasting));
            vc.SetValue("casttime", cmx.CastDurationCurrent);
            vc.SetValue("maxcasttime", cmx.CastDurationMax);
            vc.SetValue("castid", (cmx.CastBuffID > 0) ? cmx.CastBuffID.ToString("X") : 0);
            vc.SetValue("heading", cmx.Heading);
            vc.SetValue("h", cmx.Heading);
            vc.SetValue("distance", cmx.EffectiveDistance);
            vc.SetValue("worldid", cmx.WorldID);
            vc.SetValue("worldname", cmx.WorldName);
            vc.SetValue("currentworldid", cmx.CurrentWorldID);
            vc.SetValue("homeworldid", cmx.WorldID);
            vc.SetValue("homeworldname", cmx.WorldName);
            vc.SetValue("ownerid", (cmx.OwnerID > 0) ? ConvertToHex(cmx.OwnerID) : 0);
            vc.SetValue("bnpcnameid", cmx.BNpcNameID);
            vc.SetValue("bnpcid", cmx.BNpcID);
            vc.SetValue("partytype", cmx.PartyType.ToString());
            vc.SetValue("address", $"{cmx.Address}"); // IntPtr
            string jobid = cmx.Job.ToString();
            vc.SetValue("jobid", jobid);
            if (Entity.jobs.ContainsKey(jobid))
            {
                foreach (var kvp in Entity.jobs[jobid])
                {
                    vc.SetValue(kvp.Key, kvp.Value);  // role, job, etc.
                }
            }
            //vc.SetValue("all", GetPropertiesAndValues(cmx));
        }

        /*
        public static string GetPropertiesAndValues(object obj)
        {
            if (obj == null) return "Object is null";

            StringBuilder result = new StringBuilder();

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                string typeName = property.PropertyType.Name;
                result.AppendLine($"{property.Name}: ({typeName}){value}");
            }

            return result.ToString();
        }
        */

        private static object GetInstance()
        {            
            RealPlugin.PluginWrapper wrap = RealPlugin.InstanceHook(ActPluginName, ActPluginType);
            switch (wrap.state)
            {
                case 0:
                    {
                        if (ckw == false)
                        {
                            LogMessage(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/ffxiv/missingactplugin", "FFXIV ACT plugin with filename ({0}) or type ({1}) could not be located, some functions may not work as expected", ActPluginName, ActPluginType));
                            ckw = true;
                        }
                        return null;
                    }
                case 1:
                    {
                        return wrap.pluginObj;
                    }
                case 2:
                    {
                        LogMessage(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/ffxiv/oldactplugin", "FFXIV ACT plugin version is lower ({0}) than expected ({1}), some functions may not work as expected", wrap.fileversion, wrap.expectedversion));
                        return wrap.pluginObj;
                    }
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
                PlayerHexId = ConvertToHex(PlayerId);
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
                PlayerHexId = ConvertToHex(PlayerId);
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
                if (((now - old) / TimeSpan.TicksPerMillisecond) < 500)
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
                            PopulateClumpFromCombatant(PartyMembers[ex], cmx, 1, nump == 2 ? 1 : 0, ex + 1);
                            phase = 6;
                            for (int i = 0; i < ex; i++)
                            {
                                if (PartyMembers[ex].CompareTo(PartyMembers[i]) == 0)
                                {
                                    ex--;
                                    break;
                                }
                            }
                            ex++;
                            if (ex >= PartyMembers.Count)
                            {
                                // full party found
                                break;
                            }
                        }   
                    }
                    phase = 7;
                    NumPartyMembers = ex;
                    if (PrevNumPartyMembers > NumPartyMembers)
                    {
                        for (int i = NumPartyMembers; i < PrevNumPartyMembers; i++)
                        {
                            ClearCombatant(PartyMembers[i]);
                        }
                    }
                    PrevNumPartyMembers = NumPartyMembers;
                    phase = 8;
                    if (cfg.FfxivPartyOrdering == Configuration.FfxivPartyOrderingEnum.CustomSelfFirst)
                    {
                        //DebugPlayerSorting("a1", PartyMembers);
                        PartyMembers.Sort(SortPlayersSelf);
                        int ro = 1;
                        foreach (VariableDictionary vc in PartyMembers)
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
                        foreach (VariableDictionary vc in PartyMembers)
                        {
                            vc.SetValue("order", "" + ro);
                            ro++;
                        }
                        //DebugPlayerSorting("b2", PartyMembers);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/updateexception", "Exception in FFXIV state update: {0} at stage {1}", ex.Message, phase));
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

        public static int SortPlayersSelf(VariableDictionary a, VariableDictionary b)
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

        public static int SortPlayers(VariableDictionary a, VariableDictionary b)
        {
            int av = cfg.GetPartyOrderValue(a.GetValue("jobid").ToString());
            int bv = cfg.GetPartyOrderValue(b.GetValue("jobid").ToString());
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
            // https://github.com/paissaheavyindustries/Triggernometry/issues/9
            return b.GetValue("id").CompareTo(a.GetValue("id"));
        }

        public static VariableDictionary GetNamedEntity(string name)
        {            
            try
            {
                object plug = null;
                plug = GetInstance();
                if (plug == null)
                {
                    return _nullCombatant;
                }
                PropertyInfo pi = GetDataRepository(plug);
                CombatantData cd = GetCombatants(plug, pi);
                lock (cd.Lock)
                {
                    foreach (dynamic cmx in cd.Combatants)
                    {                        
                        if (cmx.Name == name)
                        {
                            int nump = 0;
                            try
                            {
                                nump = (int)cmx.PartyType;
                            }
                            catch (Exception)
                            {
                            }
                            VariableDictionary vc = new VariableDictionary();
                            PopulateClumpFromCombatant(vc, cmx, nump == 1 ? 1 : 0, nump == 2 ? 1 : 0, 0);
                            return vc;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/namedexception", "Exception in FFXIV named entity retrieve: {0}", ex.Message));
            }
            return _nullCombatant;
        }

        public static VariableDictionary GetIdEntity(string id)
        {
            try
            {
                object plug = null;
                plug = GetInstance();
                if (plug == null)
                {
                    return _nullCombatant;
                }
                PropertyInfo pi = GetDataRepository(plug);
                CombatantData cd = GetCombatants(plug, pi);
                lock (cd.Lock)
                {
                    foreach (dynamic cmx in cd.Combatants)
                    {
                        if (String.Compare(ConvertToHex(cmx.ID), id, true) == 0)
                        {
                            int nump = 0;
                            try
                            {
                                nump = (int)cmx.PartyType;
                            }
                            catch (Exception)
                            {
                            }
                            VariableDictionary vc = new VariableDictionary();
                            PopulateClumpFromCombatant(vc, cmx, nump == 1 ? 1 : 0, nump == 2 ? 1 : 0, 0);
                            return vc;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/idexception", "Exception in FFXIV ID entity retrieve: {0}", ex.Message));
            }
            return _nullCombatant;
        }

        public static List<VariableDictionary> GetAllEntities()
        {
            List<VariableDictionary> allEntities = new List<VariableDictionary>();
            try
            {
                object plug = null;
                plug = GetInstance(); 
                if (plug == null)
                {
                    return allEntities;
                }
                PropertyInfo pi = GetDataRepository(plug);
                CombatantData cd = GetCombatants(plug, pi); 
                lock (cd.Lock)
                {
                    foreach (dynamic cmx in cd.Combatants) 
                    {
                        int nump = 0;
                        try
                        {
                            nump = (int)cmx.PartyType;
                        }
                        catch { }

                        VariableDictionary vc = new VariableDictionary();
                        try
                        {
                            PopulateClumpFromCombatant(vc, cmx, nump == 1 ? 1 : 0, nump == 2 ? 1 : 0, 0);
                            allEntities.Add(vc);
                        }
                        catch (Exception ex)
                        {   // some NPC entities do not follow the same memory struct with ordinary combatants.
                            // the wrongly parsed properties could cause errors.
                            LogMessage(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/ffxiv/allentitiesexceptionsingle",
                                "Failed to get entity data: name = {0}, id = {1}. Exception: {2}", 
                                cmx.Name, ConvertToHex(cmx.ID), ex.Message));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/allentitiesexception", "Exception in FFXIV all entities retrieve: {0}", ex.Message));
            }
            return allEntities;
        }

        public static VariableDictionary GetPartyMember(int index)
        {
            UpdateState();
            if (index < 1 || index > NumPartyMembers)
            {
                return _nullCombatant;
            }
            return PartyMembers[index - 1];
        }

        public static VariableDictionary GetMyself()
        {
            UpdateState();
            return Myself;
        }

        public static VariableDictionary GetNamedPartyMember(string name)
        {
            UpdateState();
            foreach (VariableDictionary vc in PartyMembers)
            {
                if (vc.GetValue("name").ToString() == name)
                {
                    return vc;
                }
            }
            return _nullCombatant;
        }

        public static VariableDictionary GetIdPartyMember(string id)
        {
            UpdateState();
            foreach (VariableDictionary vc in PartyMembers)
            {
                if (String.Compare(vc.GetValue("id").ToString(), id, true) == 0)
                {
                    return vc;
                }
            }
            return _nullCombatant;
        }

        public static Process GetProcess()
        {
            try
            {
                object plug = GetInstance();
                if (plug == null)
                {
                    return null;
                }
                PropertyInfo pi = GetDataRepository(plug);
                if (pi == null)
                {
                    return null;
                }
                MethodInfo mi = pi.GetGetMethod();
                object o = mi.Invoke(plug, null);
                mi = o.GetType().GetMethod("GetCurrentFFXIVProcess", BindingFlags.Instance | BindingFlags.Public);
                return (Process)mi.Invoke(o, null);
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/procexception", "Exception in FFXIV process retrieve: {0}", ex.Message));
            }
            return null;
        }

        public static int GetProcessId()
        {
            Process p = GetProcess();
            if (p == null)
            {
                return 0;
            }            
            return p.Id;
        }

        public static string GetProcessName()
        {
            Process p = GetProcess();
            if (p == null)
            {
                return "";
            }
            return p.ProcessName;
        }

    }

}
