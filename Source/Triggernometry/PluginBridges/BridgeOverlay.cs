using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Triggernometry;

namespace Triggernometry.PluginBridges
{
    public static class BridgeOverlay
    {
        private const string PluginName = "OverlayPlugin.dll";
        private const string PluginType = "RainbowMage.OverlayPlugin.PluginLoader";

        static BridgeOverlay()
        {
            GetReflectedFields();
        }

        public static bool Ready;
        public static RealPlugin.PluginWrapper WrappedPlugin;
        public static object _combatantMemoryManager;
        public static MethodInfo _getCombatantListMethod;

        public static void GetReflectedFields()
        {
            WrappedPlugin = RealPlugin.InstanceHook(PluginName, PluginType);
            object op = WrappedPlugin?.pluginObj ?? throw new Exception("OverlayPlugin");
            if (op == null)
            { 
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, "OverlayPlugin not found");
                Ready = false;
                return;
            }
            try
            {
                object pluginMain = op.GetType().GetField("pluginMain", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(op) ?? throw new Exception("pluginMain not found");

                object container = pluginMain.GetType().GetField("_container", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(pluginMain) ?? throw new Exception("pluginMain._container not found");

                Type combatantMemoryType = Type.GetType("RainbowMage.OverlayPlugin.MemoryProcessors.Combatant.ICombatantMemory, OverlayPlugin.Core")
                    ?? throw new Exception("combatantMemoryType not found");

                MethodInfo resolveMethodGeneric = container.GetType().GetMethod("Resolve", BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null)
                    ?? throw new Exception("resolveMethodGeneric not found");
                MethodInfo resolveMethodSpecific = resolveMethodGeneric.MakeGenericMethod(combatantMemoryType);

                _combatantMemoryManager = resolveMethodSpecific.Invoke(container, null)
                    ?? throw new Exception("CombatantMemoryManager not found");

                _getCombatantListMethod = _combatantMemoryManager.GetType().GetMethod("GetCombatantList")
                    ?? throw new Exception("GetCombatantListMethod not found");
                Ready = true;
            }
            catch (Exception ex)
            {
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Error, 
                    I18n.Translate("internal/BridgeOverlay/initfail", "OverlayPlugin initialization failed due to: {0}", ex.ToString())
                );
                Ready = false;
            }
        }

        public static List<OpCombatant> GetCombatants(bool queryStatus = false)
        {
            if (!Ready)
            { 
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, "OverlayPlugin not ready");
                return new List<OpCombatant>();
            }
            IList combatantList = _getCombatantListMethod.Invoke(_combatantMemoryManager, null) as IList; // List<Combatant> defined by OverlayPlugin
            return combatantList.Cast<dynamic>().Select(c => new OpCombatant(c, queryStatus)).ToList();
        }

        // OverlayPlugin/OverlayPlugin.Core/MemoryProcessors/Combatant/Common.cs
        public class OpCombatant
        {
            public dynamic Combatant;

            public uint ID;
            public uint OwnerID;
            public ObjectType Type;
            public MonsterType MonsterType;
            public ObjectStatus Status;
            public ModelStatus ModelStatus;
            public AggressionStatus AggressionStatus;
            public uint TargetID;
            public bool IsTargetable;

            public byte Job;
            public string Name;

            public int CurrentHP;
            public int MaxHP;

            public float PosX;
            public float PosY;
            public float PosZ;
            public float Heading;
            public float Radius;

            public string Distance;
            public string EffectiveDistance;

            public List<EffectEntry> Effects;

            public uint BNpcID;
            public int CurrentMP;
            public int MaxMP;
            public byte Level;

            public uint BNpcNameID;

            public ushort WorldID;
            public ushort CurrentWorldID;
            public uint NPCTargetID;
            public ushort CurrentGP;
            public ushort MaxGP;
            public ushort CurrentCP;
            public ushort MaxCP;
            public uint PCTargetID;
            public byte IsCasting1;
            public byte IsCasting2;
            public uint CastBuffID;
            public uint CastTargetID;
            public float CastGroundTargetX;
            public float CastGroundTargetY;
            public float CastGroundTargetZ;
            public float CastDurationCurrent;
            public float CastDurationMax;

            public short TransformationId;
            public byte WeaponId;

            public string HexID => ID.ToString("X8");
            public string OwnerHexID => OwnerID.ToString("X8");

            public OpCombatant(dynamic opCombatant, bool queryStatus)
            {
                Combatant = opCombatant;

                ID = opCombatant.ID;
                OwnerID = opCombatant.OwnerID;
                Type = (ObjectType)(int)opCombatant.Type;
                MonsterType = (MonsterType)(int)opCombatant.MonsterType;
                Status = (ObjectStatus)(int)opCombatant.Status;
                ModelStatus = (ModelStatus)(int)opCombatant.ModelStatus;
                AggressionStatus = (AggressionStatus)(int)opCombatant.AggressionStatus;
                TargetID = opCombatant.TargetID;
                IsTargetable = opCombatant.IsTargetable;

                Job = opCombatant.Job;
                Name = opCombatant.Name;

                CurrentHP = opCombatant.CurrentHP;
                MaxHP = opCombatant.MaxHP;

                PosX = opCombatant.PosX;
                PosY = opCombatant.PosY;
                PosZ = opCombatant.PosZ;
                Heading = opCombatant.Heading;
                Radius = opCombatant.Radius;

                Distance = opCombatant.Distance;
                EffectiveDistance = opCombatant.EffectiveDistance;

                BNpcID = opCombatant.BNpcID;
                CurrentMP = opCombatant.CurrentMP;
                MaxMP = opCombatant.MaxMP;
                Level = opCombatant.Level;

                BNpcNameID = opCombatant.BNpcNameID;

                WorldID = opCombatant.WorldID;
                CurrentWorldID = opCombatant.CurrentWorldID;
                NPCTargetID = opCombatant.NPCTargetID;
                CurrentGP = opCombatant.CurrentGP;
                MaxGP = opCombatant.MaxGP;
                CurrentCP = opCombatant.CurrentCP;
                MaxCP = opCombatant.MaxCP;
                PCTargetID = opCombatant.PCTargetID;
                IsCasting1 = opCombatant.IsCasting1;
                IsCasting2 = opCombatant.IsCasting2;
                CastBuffID = opCombatant.CastBuffID;
                CastTargetID = opCombatant.CastTargetID;
                CastGroundTargetX = opCombatant.CastGroundTargetX;
                CastGroundTargetY = opCombatant.CastGroundTargetY;
                CastGroundTargetZ = opCombatant.CastGroundTargetZ;
                CastDurationCurrent = opCombatant.CastDurationCurrent;
                CastDurationMax = opCombatant.CastDurationMax;

                TransformationId = opCombatant.TransformationId;
                WeaponId = opCombatant.WeaponId;

                if (queryStatus && opCombatant.Effects != null)
                {
                    if (opCombatant.Effects is IEnumerable<dynamic> opEffects)
                        Effects = opEffects.Select(e => new EffectEntry(e)).ToList();
                }
            }

            public double GetDistance(OpCombatant target)
            {
                var distanceX = Math.Abs(PosX - target.PosX);
                var distanceY = Math.Abs(PosY - target.PosY);
                return Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
            }
        }

        // OverlayPlugin/OverlayPlugin.Core/MemoryProcessors/Combatant/Common.cs
        public class EffectEntry
        {
            public ushort BuffID;
            public ushort Stack;
            public float Timer;
            public uint ActorID;
            public bool isOwner;

            public EffectEntry(dynamic opEffectEntry)
            { 
                BuffID = opEffectEntry.BuffID;
                Stack = opEffectEntry.Stack;
                Timer = opEffectEntry.Timer;
                ActorID = opEffectEntry.ActorID;
                isOwner = opEffectEntry.isOwner;
            }
        }

        // FFXIVClientStructs/FFXIVClientStructs/FFXIV/Client/UI/Misc/RaptureTextModule.cs
        public enum ObjectType : byte
        {
            None = 0,
            Pc = 1,
            BattleNpc = 2,
            EventNpc = 3,
            Treasure = 4,
            Aetheryte = 5,
            GatheringPoint = 6,
            EventObj = 7,
            Mount = 8,
            Companion = 9,
            Retainer = 10,
            AreaObject = 11,
            HousingEventObject = 12,
            Cutscene = 13,
            MjiObject = 14,
            Ornament = 15,
            CardStand = 16
        }

        // OverlayPlugin/OverlayPlugin.Core/MemoryProcessors/Combatant/Common.cs
        public enum MonsterType : byte
        {
            Friendly = 0,
            Hostile = 4
        }

        // OverlayPlugin/OverlayPlugin.Core/MemoryProcessors/Combatant/Common.cs
        public enum ObjectStatus : byte
        {
            NormalActorStatus = 191,
            NormalSubActorStatus = 190,
            TemporarilyUntargetable = 189,
            LoadsUntargetable = 188
        }

        // OverlayPlugin/OverlayPlugin.Core/MemoryProcessors/Combatant/Common.cs
        public enum ModelStatus : int
        {
            Visible = 0,
            Unloaded = 2048,
            Hidden = 16384,
        }

        // OverlayPlugin/OverlayPlugin.Core/MemoryProcessors/Combatant/Common.cs
        public enum AggressionStatus : byte
        {
            Passive = 0,
            Aggressive = 1,
            EngagedPassive = 2,
            EngagedAggressive = 3
        }


    }
}
