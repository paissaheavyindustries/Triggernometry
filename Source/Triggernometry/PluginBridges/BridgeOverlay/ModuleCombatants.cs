using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Triggernometry.FFXIV;
using System.Text;

namespace Triggernometry.PluginBridges
{
    [OverlayModule]
    internal static class ModuleCombatants
    {
        public static bool Ready;
        private static object _combatantMemoryManager;

        private static MethodInfo _getCombatantListMethod;

        private static object _currentCombatantMemory;

        private static FieldInfo _memoryField;
        private static dynamic memory => _memoryField.GetValue(_currentCombatantMemory);

        private static FieldInfo _charmapAddressField;
        private static IntPtr charmapAddress => (IntPtr)_charmapAddressField.GetValue(_currentCombatantMemory);

        private static FieldInfo _numMemoryCombatantsField;
        private static int numMemoryCombatants => (int)_numMemoryCombatantsField.GetValue(_currentCombatantMemory);

        private static FieldInfo _combatantSizeField;
        private static int combatantSize => (int)_combatantSizeField.GetValue(_currentCombatantMemory);

        private static MethodInfo _getMobFromByteArrayMethod;

        static ModuleCombatants()
        {
            Initialize();
        }

        internal static void Initialize()
        {
            try
            {
                _combatantMemoryManager = BridgeOverlay.Container.Resolve($"RainbowMage.OverlayPlugin.MemoryProcessors.Combatant.ICombatantMemory, OverlayPlugin.Core");
                _getCombatantListMethod = _combatantMemoryManager.GetType().GetMethod("GetCombatantList", BindingFlags.Public | BindingFlags.Instance)
                    ?? throw new ReflectionNotFoundException("CombatantMemoryManager.GetCombatantList");

                _currentCombatantMemory = _combatantMemoryManager.GetType().GetField("memory", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(_combatantMemoryManager)
                    ?? throw new ReflectionNotFoundException("CombatantMemoryManager.memory");
                var combatantMemoryType = _currentCombatantMemory.GetType().BaseType;
                _memoryField = combatantMemoryType.GetField("memory", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?? throw new ReflectionNotFoundException("CombatantMemory.memory");
                _charmapAddressField = combatantMemoryType.GetField("charmapAddress", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?? throw new ReflectionNotFoundException("CombatantMemory.charmapAddress");
                _numMemoryCombatantsField = combatantMemoryType.GetField("numMemoryCombatants", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?? throw new ReflectionNotFoundException("CombatantMemory.numMemoryCombatants");
                _combatantSizeField = combatantMemoryType.GetField("combatantSize", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?? throw new ReflectionNotFoundException("CombatantMemory.combatantSize");
                _getMobFromByteArrayMethod = combatantMemoryType.GetMethod("GetMobFromByteArray", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?? throw new ReflectionNotFoundException("CombatantMemory.GetMobFromByteArray");
            }
            catch (ReflectionNotFoundException ex)
            {
                // _currentCombatantMemory could be null before OverlayPlugin finishes its initialization
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, ex.Message);
                Ready = false;
                return;
            }
            catch (Exception ex)
            {
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Error,
                    I18n.Translate("internal/BridgeOverlay/failInitModule",
                    "OverlayPlugin {1} module initialization failed due to: {0}",
                    ex.ToString(), "Combatant")
                );
                Ready = false;
                return;
            }
            Ready = true;
        }

        // use the original method from OverlayPlugin
        /*
        public static IEnumerable<FFXIV.Entity> InternalGetEntities()
        {
            if (!Ready)
            { 
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, "OverlayPlugin not ready");
                return new List<FFXIV.Entity>();
            }
            IList combatantList = _getCombatantListMethod.Invoke(_combatantMemoryManager, null) as IList; // List<Combatant> defined by OverlayPlugin
            return combatantList.Cast<object>().Select(c => (FFXIV.Entity)new OpEntity(c, IntPtr.Zero));
        }
        */

        const int ptrSize = 8;  // Int64 pointer size

        /// <returns>Empty if Overlay is not ready.</returns>
        internal static IEnumerable<FFXIV.Entity> InternalGetEntities()
        {
            if (BridgeOverlay.Ready && !ModuleCombatants.Ready)
            {
                try { ModuleCombatants.Initialize(); } catch { }
            }
            if (!Ready)
            {
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, I18n.Translate(
                    "internal/BridgeOverlay/moduleCombatantsNotReady",
                    "OverlayPlugin not ready when trying to get entities, will retry later."));
                yield break;
            }

            var seen = new HashSet<uint>();
            byte[] source = memory.GetByteArray(charmapAddress, ptrSize * numMemoryCombatants);
            if (source == null || source.Length == 0)
                yield break;

            for (int i = 0; i < numMemoryCombatants; i++)
            {
                IntPtr p = GetPointerFromSource(source, i);
                if (p == IntPtr.Zero) continue;

                byte[] c = memory.GetByteArray(p, combatantSize);
                dynamic combatant = GetMobFromByteArray(c, 0);
                if (combatant == null || seen.Contains(combatant.ID))
                    continue;
                FFXIV.Entity entity = new OpEntity(combatant, p);
                seen.Add(entity.ID);
                yield return entity;
            }
        }

        private static unsafe IntPtr GetPointerFromSource(byte[] source, int index)
        {
            fixed (byte* bp = source)
            {
                return new IntPtr(*(long*)&bp[index * ptrSize]);
            }
        }

        /// <returns>Null if not found.</returns>
        private static dynamic GetMobFromByteArray(byte[] source, uint mycharID)
        {
            return _getMobFromByteArrayMethod.Invoke(_currentCombatantMemory, new object[] { source, mycharID });
        }

        /// <returns>OpEntity.NullEntity() if not found.</returns>
        internal static FFXIV.Entity InternalGetEntityByID(uint id)
        {
            return InternalGetEntities().FirstOrDefault(entity => entity.ID == id) ?? OpEntity.NullEntity();
        }

        /// <returns>OpEntity.NullEntity() if not found.</returns>
        internal static FFXIV.Entity InternalGetMyself()
        {
            return InternalGetEntities().FirstOrDefault() ?? OpEntity.NullEntity();
        }

        // OverlayPlugin/OverlayPlugin.Core/MemoryProcessors/Combatant/Common.cs
        public class OpEntity : FFXIV.Entity
        {
            private readonly dynamic _entity; // the original combatant object from OverlayPlugin, properties DO NOT change over time
            public override PluginSource PluginSource { get; set; } = PluginSource.OverlayPlugin;
            public override IntPtr Address { get; set; } // .Address (not updated yet)
            public override string Name => _entity.Name;
            public override uint ID => _entity.ID;
            public override uint BNpcID => _entity.BNpcID;
            public override uint OwnerID => _entity.OwnerID;
            public override EntityType Type => (EntityType)(byte)_entity.Type;
            public override byte EffectiveDistance => _entity.RawEffectiveDistance;
            public override ObjectStatus ObjectStatus => (ObjectStatus)(byte)_entity.Status;
            public override float PosX => _entity.PosX;
            public override float PosY => _entity.PosY;
            public override float PosZ => _entity.PosZ;
            public override float Heading => _entity.Heading;
            public override float Radius => _entity.Radius;
            public override ModelStatus ModelStatus => (ModelStatus)(int)_entity.ModelStatus;
            public override bool IsTargetable => _entity.IsTargetable;
            public override uint CurrentHP => (uint)_entity.CurrentHP; // int
            public override uint MaxHP => (uint)_entity.MaxHP; // int
            public override uint CurrentMP => (uint)_entity.CurrentMP; // int
            public override uint MaxMP => (uint)_entity.MaxMP; // int
            public override ushort CurrentCP => _entity.CurrentCP;
            public override ushort MaxCP => _entity.MaxCP;
            public override ushort CurrentGP => _entity.CurrentGP;
            public override ushort MaxGP => _entity.MaxGP;
            public override short TransformationID => _entity.TransformationId;
            public override Job Job => FFXIV.Job.TryGetJob(_entity.Job/*numeric id*/, out Job result) ? result : FFXIV.Job.GetJob(0);
            public override byte Level => _entity.Level;
            public override MonsterType MonsterType { get; set; }  //=> _entity.MonsterType; (not updated yet)
            public override bool IsEnemy { get; set; }  //=> _entity.IsEnemy; (not updated yet)
            public override bool IsAggressive { get; set; } //=> _entity.IsAggressive; (not updated yet)
            public override bool InCombat { get; set; }  //=> _entity.InCombat; (not updated yet)
            public override bool InParty // (not updated yet)
            {
                get
                {
                    if (HexID.StartsWith("10"))
                    {
                        var xivCombatant = BridgeFFXIV.GetIdEntity(HexID);
                        return xivCombatant.GetValue("inparty").ToString() == "1";
                    }
                    else return false;
                }
            }
            public override bool InAlliance // (not updated yet)
            {
                get
                {
                    if (HexID.StartsWith("10"))
                    {
                        var xivCombatant = BridgeFFXIV.GetIdEntity(HexID);
                        return xivCombatant.GetValue("inalliance").ToString() == "1";
                    }
                    else return false;
                }
            }
            // public override bool IsFriend => _entity.IsFriend;
            public override byte WeaponID => _entity.WeaponId;
            public override uint TargetID => _entity.TargetID;
            public override uint BNpcNameID => _entity.BNpcNameID;
            public override ushort CurrentWorldID => _entity.CurrentWorldID;
            public override ushort WorldID => _entity.WorldID;
            public override List<Status> Statuses
            {
                get
                {
                    if (_entity.Effects is IEnumerable<dynamic> opEffects)
                        return opEffects.Select(e => (Status)new OpStatus(e, this)).ToList();
                    else return new List<Status>();
                }
            }
            public override bool IsCasting => (_entity.IsCasting1 & 1) == 1;
            public override byte CastType => _entity.IsCasting2;
            public override uint CastID => _entity.CastBuffID;
            public override uint CastTargetID => _entity.CastTargetID;
            public override float CastPosX => _entity.CastGroundTargetX;
            public override float CastPosY => _entity.CastGroundTargetY;
            public override float CastPosZ => _entity.CastGroundTargetZ;
            public override float CastTime => _entity.CastDurationCurrent;
            public override float MaxCastTime => _entity.CastDurationMax;

            internal OpEntity(object opCombatantObj, IntPtr address)
            {
                _entity = opCombatantObj;
                Address = address;
            }

            internal new static FFXIV.Entity NullEntity() => new FFXIV.Entity()
            { 
                Exist = false,
                PluginSource = PluginSource.OverlayPlugin,
            };

        }

        // OverlayPlugin/OverlayPlugin.Core/MemoryProcessors/Combatant/Common.cs
        public class OpStatus : Status
        {
            public override PluginSource PluginSource { get; set; } = PluginSource.OverlayPlugin;

            private readonly dynamic _rawEffectEntry;
            public override ushort StatusID => _rawEffectEntry.BuffID;
            public override ushort Stack => _rawEffectEntry.Stack;
            public override float Timer => _rawEffectEntry.Timer;
            public override uint SourceID => _rawEffectEntry.ActorID;

            private readonly FFXIV.Entity _target;
            public override FFXIV.Entity Target => _target;

            public OpStatus(dynamic opEffectEntry, FFXIV.Entity target)
            {
                _rawEffectEntry = opEffectEntry;
                _target = target;
            }
        }

    }
}