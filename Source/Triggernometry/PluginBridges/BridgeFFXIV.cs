using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Triggernometry.Variables;
using Triggernometry.FFXIV;

namespace Triggernometry.PluginBridges
{

    public static class BridgeFFXIV
    {

        private const string ActPluginName = "FFXIV_ACT_Plugin.dll";
        private const string ActPluginType = "FFXIV_ACT_Plugin.FFXIV_ACT_Plugin";
        public static Configuration cfg = RealPlugin.plug.cfg;

        internal delegate void LoggingDelegate(RealPlugin.DebugLevelEnum level, string text);
        internal static event LoggingDelegate OnLogEvent;

        public static Int64 LastCheck = 0;
        public static Int64 TickNum = 0;
        public static uint ZoneID = 0;

        private delegate void NetworkReceiveDelegate(string connection, long epoch, byte[] message);

        static BridgeFFXIV()
        {
            SetupNullCombatant();
        }

        private static bool _missingPluginWarned = false;
        public static RealPlugin.PluginWrapper GetWrappedPlugin()
        {
            var wrap = RealPlugin.InstanceHook(ActPluginName, ActPluginType);
            if (wrap.pluginObj == null)
            {
                if (_missingPluginWarned == false)
                {
                    LogMessage(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/ffxiv/missingactplugin", "FFXIV ACT plugin with filename ({0}) or type ({1}) could not be located, some functions may not work as expected", ActPluginName, ActPluginType));
                    _missingPluginWarned = true;
                }
                return null;
            }
            else
            {
                var expectedVersion = "2.7.0.5"; // added deucalion
                if (new Version(wrap.FileVersion) < new Version(expectedVersion))
                {
                    LogMessage(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/ffxiv/oldactplugin", "FFXIV ACT plugin version is lower ({0}) than expected ({1}), some functions may not work as expected", wrap.FileVersion, expectedVersion));
                }
                _missingPluginWarned = false;
            }
            return wrap;
        }

        public static object GetInstance() => GetWrappedPlugin().pluginObj;

        public static PropertyInfo GetDataRepository(object plug)
        {
            return plug?.GetType()?.GetProperty("DataRepository", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static object GetDataRepositoryInstance(object plug) => GetDataRepository(plug)?.GetValue(plug);

        public static Process GetProcess()
        {
            try
            {
                object plug = GetInstance();
                object dataRepositoryInstance = GetDataRepositoryInstance(plug);
                if (dataRepositoryInstance == null)
                {
                    return null;
                }
                return (Process)dataRepositoryInstance.GetType().GetMethod("GetCurrentFFXIVProcess").Invoke(dataRepositoryInstance, null);
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/procexception", "Exception in FFXIV process retrieve: {0}", ex.Message));
            }
            return null;
        }

        public static int GetProcessId() => GetProcess()?.Id ?? 0;

        public static string GetProcessName() => GetProcess()?.ProcessName ?? "";

        public static string GetGameVersion()
        {
            try
            {
                object plug = GetInstance();
                object dataRepositoryInstance = GetDataRepositoryInstance(plug);
                if (dataRepositoryInstance == null)
                {
                    return null;
                }
                var result = dataRepositoryInstance.GetType().GetMethod("GetGameVersion")?.Invoke(dataRepositoryInstance, null);
                return result?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, ex.ToString());
                return "";
            }
        }

        public static void SubscribeToZoneChanged(RealPlugin p)
        {
            try
            {
                object plug = GetInstance() 
                    ?? throw new ArgumentException("No plugin instance available");
                PropertyInfo pi = plug.GetType().GetProperty("DataSubscription", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    ?? throw new ArgumentException("No DataSubscription found");
                object subs = pi.GetValue(plug) 
                    ?? throw new ArgumentException("DataSubscription not initialized");
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

        #region Actions

        public static CheckBox chkLogAllNetwork => (CheckBox)ScanControl(GetWrappedPlugin().TabPage, "chkLogAllNetwork");
        public static CheckBox chkUseDeucalion => (CheckBox)ScanControl(GetWrappedPlugin().TabPage, "chkUseDeucalion");

        private static Control ScanControl(Control parent, string name)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Name == name)
                {
                    return ctrl;
                }
                else if (ctrl.HasChildren)
                {
                    Control foundControl = ScanControl(ctrl, name);
                    if (foundControl != null)
                    {
                        return foundControl;
                    }
                }
            }
            return null;
        }

        public static void UseDeucalion(bool enabled)
        {
            if (chkUseDeucalion.InvokeRequired)
            {
                chkUseDeucalion.Invoke(new System.Action(() => chkUseDeucalion.Checked = enabled));
            }
            else
            {
                chkUseDeucalion.Checked = enabled;
            }
        }

        public static void LogAllNetwork(bool enabled)
        {
            if (chkLogAllNetwork.InvokeRequired)
            {
                chkLogAllNetwork.Invoke(new System.Action(() => chkLogAllNetwork.Checked = enabled));
            }
            else
            {
                chkLogAllNetwork.Checked = enabled;
            }
        }
        #endregion Actions

        #region Combatants

        internal static VariableDictionary _nullCombatant = new VariableDictionary();
        public static VariableDictionary NullCombatant => (VariableDictionary)_nullCombatant.Duplicate(); // for scripts

        public static uint PlayerId = 0;
        public static string PlayerHexId = "";
        public static VariableDictionary Myself;

        public static int NumPartyMembers = 0;
        public static int PrevNumPartyMembers = 0;
        public static List<VariableDictionary> PartyMembers = new List<VariableDictionary>(new VariableDictionary[8] {
            new VariableDictionary(), new VariableDictionary(), new VariableDictionary(), new VariableDictionary(),
            new VariableDictionary(), new VariableDictionary(), new VariableDictionary(), new VariableDictionary()
        });

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
            foreach (var propName in Job.LegalJobPropNames)
            {
                vc.SetValue(propName.ToLower(), Job.EmptyJob.QueryProperty(propName));  // role, job, jobid, etc.
            }
        }

        public static void SetupNullCombatant()
        {
            ClearCombatant(_nullCombatant);
        }

        internal static string ConvertToHex(Int64 x) => x.ToString("X8");

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
            Job job = Job.GetJob(cmx.Job); 
            foreach (var propName in Job.LegalJobPropNames)
            {
                vc.SetValue(propName.ToLower(), job.QueryProperty(propName));  // role, job, jobid, etc.
            }
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

        public class XivEntity : FFXIV.Entity
        {
            private readonly dynamic _entity; // the original combatant object from FFXIV_ACT_Plugin, properties change over time
            public override PluginSource PluginSource { get; set; } = PluginSource.XivPlugin;
            public override IntPtr Address => _entity.Address;
            public override string Name => _entity.Name;
            public override uint ID => _entity.ID;
            public override uint BNpcID => _entity.BNpcID;
            public override uint OwnerID => _entity.OwnerID;
            public override EntityType Type => (EntityType)_entity.type; // actually only 1 (PC) or 2 (BattleNpc)
            public override byte EffectiveDistance => _entity.EffectiveDistance;
            public override float PosX => _entity.PosX;
            public override float PosY => _entity.PosY;
            public override float PosZ => _entity.PosZ;
            public override float Heading => _entity.Heading;
            public override uint CurrentHP => _entity.CurrentHP;
            public override uint MaxHP => _entity.MaxHP;
            public override uint CurrentMP => _entity.CurrentMP;
            public override uint MaxMP => _entity.MaxMP;
            public override ushort CurrentCP => (ushort)_entity.CurrentCP; // uint
            public override ushort MaxCP => (ushort)_entity.MaxCP; // uint
            public override ushort CurrentGP => (ushort)_entity.CurrentGP; // uint
            public override ushort MaxGP => (ushort)_entity.MaxGP; // uint
            public override Job Job => FFXIV.Job.TryGetJob(_entity.Job/*int*/, out Job result) ? result : FFXIV.Job.GetJob(0);
            public override byte Level => (byte)_entity.Level; // int
            //public override bool InCombat { get; set; }
            public override bool InParty => (int)_entity.PartyType == 1;
            public override bool InAlliance => (int)_entity.PartyType == 2;
            public override uint TargetID => _entity.TargetID;
            public override uint BNpcNameID => _entity.BNpcNameID;
            public override ushort CurrentWorldID => (ushort)_entity.CurrentWorldID; // uint
            public override ushort WorldID => (ushort)_entity.WorldID; // uint
            public override List<Status> Statuses
            {
                get
                {
                    var statuses = new List<Status>();
                    if (_entity.NetworkBuffs is Array networkBuffs) // NetworkBuff[30]
                    {
                        foreach (Status status in networkBuffs.Cast<dynamic>().Select(e => (Status)new XivStatus(e, this)))
                        {
                            if (status.StatusID != 0)
                            {
                                statuses.Add(status);
                            }
                            else break;
                        }
                    }
                    return statuses;
                }
            }
            public override bool IsCasting => _entity.IsCasting;
            public override uint CastID => _entity.CastBuffID;
            public override uint CastTargetID => _entity.CastTargetID;
            public override float CastTime => _entity.CastDurationCurrent;
            public override float MaxCastTime => _entity.CastDurationMax;

            internal XivEntity() { }
            internal XivEntity(object xivEntity)
            {
                _entity = xivEntity;
            }

            internal new static FFXIV.Entity NullEntity() => new FFXIV.Entity()
            {
                Exist = false,
                PluginSource = PluginSource.XivPlugin,
            };

            /* example:
            class Combatant
            Fields:
              NetworkBuffs : NetworkBuff[] = FFXIV_ACT_Plugin.Common.Models.NetworkBuff[];
            Properties:
              ID : UInt32 = 1073743259;
              OwnerID : UInt32 = 0;
              type : Byte = 2;
              Job : Int32 = 0;
              Level : Int32 = 80;
              Name : String = Striking Dummy;
              CurrentHP : UInt32 = 2134350;
              MaxHP : UInt32 = 2134350;
              CurrentMP : UInt32 = 0;
              MaxMP : UInt32 = 10000;
              CurrentCP : UInt32 = 0;
              MaxCP : UInt32 = 0;
              CurrentGP : UInt32 = 0;
              MaxGP : UInt32 = 0;
              IsCasting : Boolean = False;
              CastBuffID : UInt32 = 0;
              CastTargetID : UInt32 = 3758096384;
              CastDurationCurrent : Single = 0;
              CastDurationMax : Single = 0;
              PosX : Single = 510.3607;
              PosY : Single = -392.0923;
              PosZ : Single = 167.9883;
              Heading : Single = -2.460303;
              CurrentWorldID : UInt32 = 0;
              WorldID : UInt32 = 0;
              WorldName : String = ;
              BNpcNameID : UInt32 = 541;
              BNpcID : UInt32 = 13728;
              TargetID : UInt32 = 0;
              EffectiveDistance : Byte = 81;
              PartyType : PartyType = None;
              Address : IntPtr = 2079081754992;
              Order : Int32 = 10;
             */
        }

        public class XivStatus : Status
        {
            public override PluginSource PluginSource { get; set; } = PluginSource.XivPlugin;

            private readonly dynamic _networkBuff;
            public override ushort StatusID => _networkBuff.BuffID;
            public override ushort Stack => _networkBuff.BuffExtra;
            private DateTime Timestamp => _networkBuff.Timestamp;
            private float Duration => _networkBuff.Duration;
            public override float Timer => Duration - (float)(DateTime.Now - Timestamp).TotalSeconds;
            public override uint SourceID => _networkBuff.ActorID;

            private readonly FFXIV.Entity _target;
            public override FFXIV.Entity Target => _target;
            public XivStatus(dynamic networkBuff, FFXIV.Entity target)
            {
                _networkBuff = networkBuff;
                _target = target;
            }

            /* example:
            class NetworkBuff
            Properties:
              BuffID : ushort = 1191;
              BuffExtra : ushort = 0;
              Timestamp : DateTime = 2024/12/26 16:40:36;
              Duration : float = 20;
              ActorID : uint = 277654321;
              ActorName : string = My Name;
              TargetID : uint = 277654321;
              TargetName : String = My Name;
              RefreshPending : Boolean = False;
             */
        }

        internal static IEnumerable<FFXIV.Entity> InternalGetEntities()
        {
            try
            {
                object plug = null;
                plug = GetInstance();
                if (plug != null)
                {
                    PropertyInfo pi = GetDataRepository(plug);
                    CombatantData cd = GetCombatants(plug, pi);
                    var combatants = cd.Combatants as IEnumerable<dynamic>;
                    return combatants.Select(c => (FFXIV.Entity)new XivEntity(c));
                }
            }
            catch (Exception ex)
            {
                LogMessage(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ffxiv/allentitiesexception", 
                    "Exception in FFXIV all entities retrieve: {0}", ex.Message));
            }
            return Enumerable.Empty<FFXIV.Entity>();
        }

        /// <returns>XivEntity.NullEntity() if not found.</returns>
        internal static FFXIV.Entity InternalGetEntityByID(uint id)
        {
            return InternalGetEntities().FirstOrDefault(entity => entity.ID == id) ?? XivEntity.NullEntity();
        }

        /// <returns>XivEntity.NullEntity() if not found.</returns>
        internal static FFXIV.Entity InternalGetMyself()
        {
            return InternalGetEntities().FirstOrDefault() ?? XivEntity.NullEntity();
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
            return Myself ?? NullCombatant;
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

        #endregion Combatants

    }

}
