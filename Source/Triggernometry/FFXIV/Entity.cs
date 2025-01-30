using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Triggernometry;
using Triggernometry.PluginBridges;
using Triggernometry.Utilities;

namespace Triggernometry.FFXIV
{   
    public class Entity
    {
        #region Basic Properties
        public bool Exist { get; set; } = true;
        public virtual PluginSource PluginSource { get; set; } = PluginSource.None;

        public virtual IntPtr Address { get; set; }
        public virtual string Name { get; set; }
        public virtual uint ID { get; set; }
        public virtual uint BNpcID { get; set; }
        public virtual uint OwnerID { get; set; }
        public virtual EntityType Type { get; set; }
        public virtual byte EffectiveDistance { get; set; }
        public virtual ObjectStatus ObjectStatus { get; set; }
        public virtual float PosX { get; set; }
        public virtual float PosY { get; set; }
        public virtual float PosZ { get; set; }
        public virtual float Heading { get; set; }
        public virtual float Radius { get; set; }
        public virtual ModelStatus ModelStatus { get; set; }
        public virtual bool IsTargetable { get; set; }
        public virtual uint CurrentHP { get; set; }
        public virtual uint MaxHP { get; set; }
        public virtual uint CurrentMP { get; set; }
        public virtual uint MaxMP { get; set; }
        public virtual ushort CurrentCP { get; set; }
        public virtual ushort MaxCP { get; set; }
        public virtual ushort CurrentGP { get; set; }
        public virtual ushort MaxGP { get; set; }
        public virtual short TransformationID { get; set; }
        public virtual Job Job { get; set; } = Job.EmptyJob;
        public virtual byte Level { get; set; }
        public virtual MonsterType MonsterType { get; set; }
        public virtual bool IsEnemy { get; set; }
        public virtual bool IsAggressive { get; set; }
        public virtual bool InCombat { get; set; }
        public virtual bool InParty { get; set; }
        public virtual bool InAlliance { get; set; }
        public virtual bool IsFriend { get; set; }
        public virtual byte WeaponID { get; set; }
        public virtual uint TargetID { get; set; }
        public virtual uint BNpcNameID { get; set; }
        public virtual ushort CurrentWorldID { get; set; }
        public virtual ushort WorldID { get; set; }
        public virtual List<Status> Statuses { get; set; } = new List<Status>();
        public virtual bool IsCasting { get; set; }
        public virtual byte CastType { get; set; }
        public virtual uint CastID { get; set; }
        public virtual uint CastTargetID { get; set; }
        public virtual float CastPosX { get; set; }
        public virtual float CastPosY { get; set; }
        public virtual float CastPosZ { get; set; }
        public virtual float CastTime { get; set; }
        public virtual float MaxCastTime { get; set; }

        public string HexAddress => Address.ToString("X");
        public string HexID => ID.ToString("X");
        public string OwnerHexID => OwnerID.ToString("X");
        public string TargetHexID => TargetID.ToString("X");
        public string CastHexID => CastID.ToString("X");
        public bool IsCharacter => Type == EntityType.Pc || Type == EntityType.BattleNpc
                                || Type == EntityType.EventNpc || Type == EntityType.Retainer;

        public Vector2 PosXY => new Vector2(PosX, PosY);
        public Vector3 Pos => new Vector3(PosX, PosY, PosZ);

        public Entity() { }
        public static Entity NullEntity() => new Entity() { Exist = false };
        public virtual Entity Snapshot() => new Entity
        {
            Exist = Exist, PluginSource = PluginSource.None,
            Address = Address, Name = Name, ID = ID, BNpcID = BNpcID, OwnerID = OwnerID, Type = Type,
            EffectiveDistance = EffectiveDistance, ObjectStatus = ObjectStatus,
            PosX = PosX, PosY = PosY, PosZ = PosZ, Heading = Heading, Radius = Radius,
            ModelStatus = ModelStatus, IsTargetable = IsTargetable,
            CurrentHP = CurrentHP, MaxHP = MaxHP, CurrentMP = CurrentMP, MaxMP = MaxMP,
            CurrentCP = CurrentCP, MaxCP = MaxCP, CurrentGP = CurrentGP, MaxGP = MaxGP,
            TransformationID = TransformationID,
            Job = Job, Level = Level,
            MonsterType = MonsterType, IsEnemy = IsEnemy,
            IsAggressive = IsAggressive, InCombat = InCombat,
            InParty = InParty, InAlliance = InAlliance, IsFriend = IsFriend,
            WeaponID = WeaponID, TargetID = TargetID, BNpcNameID = BNpcNameID, 
            CurrentWorldID = CurrentWorldID, WorldID = WorldID,
            Statuses = Statuses.Select(s => s.Snapshot()).ToList(),
            IsCasting = IsCasting, CastType = CastType, CastID = CastID, CastTargetID = CastTargetID,
            CastPosX = CastPosX, CastPosY = CastPosY, CastPosZ = CastPosZ,
            CastTime = CastTime, MaxCastTime = MaxCastTime,
        };

        #endregion Basic Properties

        #region Get Entities

        public static IEnumerable<Entity> GetEntities()
        {
            var result = ModuleCombatants.InternalGetEntities();
            if (!result.Any())
                result = BridgeFFXIV.InternalGetEntities();
            return result;
        }

        public static IEnumerable<Entity> GetEntities(bool useOverlay)
        { 
            return useOverlay ? ModuleCombatants.InternalGetEntities() : BridgeFFXIV.InternalGetEntities();
        }

        public static Entity GetEntityByID(string hexID) => GetEntityByID(uint.Parse(hexID, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
        public static Entity GetEntityByID(uint id)
        {
            var result = ModuleCombatants.InternalGetEntityByID(id);
            if (!result.Exist)
                result = BridgeFFXIV.InternalGetEntityByID(id);
            return result;
        }

        public static Entity GetEntityByID(string hexID, bool useOverlay) => GetEntityByID(uint.Parse(hexID, NumberStyles.HexNumber, CultureInfo.InvariantCulture), useOverlay);
        public static Entity GetEntityByID(uint id, bool useOverlay)
        { 
            return useOverlay ? ModuleCombatants.InternalGetEntityByID(id) : BridgeFFXIV.InternalGetEntityByID(id);
        }

        public static Entity GetMyself()
        {
            var result = ModuleCombatants.InternalGetMyself();
            if (!result.Exist)
                result = BridgeFFXIV.InternalGetMyself();
            return result;
        }

        public static Entity GetMyself(bool useOverlay)
        { 
            return useOverlay ? ModuleCombatants.InternalGetMyself() : BridgeFFXIV.InternalGetMyself();
        }

        /// <summary> Cache when changing zone / starting ACT.</summary>
        internal static void UpdateMySnapshot() => MySnapshot = GetMyself();
        public static Entity MySnapshot { get; private set; } = NullEntity();
        public static uint   MyID => MySnapshot.ID;
        public static string MyHexID => MySnapshot.HexID;
        public static string MyName => MySnapshot.Name;
        public static IntPtr MyAddress => MySnapshot.Address;

        private static readonly Regex entityNameGuess = new Regex("^[^<>()=&|!,]+$", RegexOptions.Compiled);

        // to-do: sortings
        public static IEnumerable<Entity> GetFilteredEntities(string expr)
        {
            // only given a single id (10123456)
            if (uint.TryParse(expr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out uint id))
            {
                var entity = GetEntityByID(id);
                return entity != null ? new Entity[] { entity } : new Entity[0];
            }
            // only given a single name
            if (entityNameGuess.IsMatch(expr))
            {
                var entities = GetEntities().Where(e => e.Name == expr.Trim());
                if (entities.Count() >= 1) return entities;
            }
            // given an expression (x > 100 && y < 100 && type = 1)
            List<Func<Entity, string>> funcTokens = EntityLexer(expr);
            return GetEntities().Where(entity => {
                var tokens = funcTokens.Select(func => func(entity)).ToList();
                var result = MathParser.MathParserLogic(tokens);
                return !MathParser.IsZero(result);
            });
        }

        public static IEnumerable<Entity> GetFilteredEntities(string expr, bool useOverlay)
        {
            // only given a single id (10123456)
            if (uint.TryParse(expr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out uint id))
            {
                var entity = GetEntityByID(id, useOverlay);
                return entity != null ? new Entity[] { entity } : new Entity[0];
            }
            // only given a single name
            if (entityNameGuess.IsMatch(expr))
            {
                var entities = GetEntities(useOverlay).Where(e => e.Name == expr.Trim());
                if (entities.Count() >= 1) return entities;
            }
            // given an expression (x > 100 && y < 100 && type = 1)
            List<Func<Entity, string>> funcTokens = EntityLexer(expr);
            return GetEntities(useOverlay).Where(entity => {
                var tokens = funcTokens.Select(func => func(entity)).ToList();
                var result = MathParser.MathParserLogic(tokens);
                return !MathParser.IsZero(result);
            });
        }

        private static List<Func<Entity, string>> EntityLexer(string expr)
        {
            var rawTokens = MathParser.Lexer(expr);
            Entity dummy = new Entity();
            var funcTokens = new List<Func<Entity, string>>();
            for (int i = 0; i < rawTokens.Count; i++)
            {
                var token = rawTokens[i];
                // regular entity/job properties
                if (dummy.TryQueryProperty(token, null, out var result))
                {
                    // disambiguation: "distance" is also a numeric function
                    if (token.Equals("distance", StringComparison.InvariantCultureIgnoreCase)
                        && i + 1 < rawTokens.Count && rawTokens[i + 1] == "(")
                    {
                        funcTokens.Add(e => token);
                    }
                    else
                    {
                        funcTokens.Add(e => e.QueryProperty(token, null));
                    }
                }
                // entity methods (with args)
                else if (LegalEntityMethodNames.Contains(token) && i + 1 < rawTokens.Count && rawTokens[i + 1] == "(")
                {
                    int depth = 1;
                    bool paired = false;
                    for (int j = i + 2; j < rawTokens.Count; j++)
                    {
                        if (rawTokens[j] == "(")
                            depth++;
                        else if (rawTokens[j] == ")")
                        {
                            depth--;
                            if (depth == 0)
                            {
                                var methodArgs = rawTokens.GetRange(i + 2, j - i - 2); // between (...)
                                funcTokens.Add(e => e.QueryProperty(token, methodArgs).Replace(" ", "")); // to-do: spaces in numeric expressions
                                i = j;
                                paired = true;
                                break;
                            }
                        }
                    }
                    if (!paired) funcTokens.Add(e => token);
                }
                // normal numeric tokens
                else
                {
                    funcTokens.Add(e => token);
                }
            }
            return funcTokens;
        }

        #endregion Get Entities

        #region Query Properties

        private readonly static Dictionary<string, Func<Entity, object>> _propAccessors
            = new Dictionary<string, Func<Entity, object>>(StringComparer.OrdinalIgnoreCase)
        {
            { "Exist",          e => e.Exist },
            { "PluginSource",   e => e.PluginSource },
            { "Address",        e => e.Address },
            { "HexAddress",     e => e.HexAddress },
            { "Name",           e => e.Name },
            { "ID",             e => e.HexID },
            { "BNpcID",         e => e.BNpcID },
            { "OwnerID",        e => e.OwnerHexID },
            { "TypeName",       e => e.Type },
            { "Type",           e => (byte)e.Type },
            { "EffectiveDistance",  e => e.EffectiveDistance },
            { "Distance",       e => e.EffectiveDistance },
            { "ObjectStatus",   e => (byte)e.ObjectStatus },
            { "X",              e => e.PosX },
            { "PosX",           e => e.PosX },
            { "Y",              e => e.PosY },
            { "PosY",           e => e.PosY },
            { "Z",              e => e.PosZ },
            { "PosZ",           e => e.PosZ },
            { "XY",             e => new Vector2(e.PosX, e.PosY) },
            { "PosXY",          e => new Vector2(e.PosX, e.PosY) },
            { "XYZ",            e => new Vector3(e.PosX, e.PosY, e.PosZ) },
            { "Pos",            e => new Vector3(e.PosX, e.PosY, e.PosZ) },
            { "H",              e => e.Heading },
            { "Heading",        e => e.Heading },
            { "Radius",         e => e.Radius },
            { "ModelStatus",    e => (int)e.ModelStatus },
            { "IsTargetable",   e => e.IsTargetable },
            { "IsVisible",      e => e.ModelStatus == ModelStatus.Visible },
            { "HP",             e => e.CurrentHP },
            { "CurrentHP",      e => e.CurrentHP },
            { "MaxHP",          e => e.MaxHP },
            { "MP",             e => e.CurrentMP },
            { "CurrentMP",      e => e.CurrentMP },
            { "MaxMP",          e => e.MaxMP },
            { "CP",             e => e.CurrentCP },
            { "CurrentCP",      e => e.CurrentCP },
            { "MaxCP",          e => e.MaxCP },
            { "GP",             e => e.CurrentGP },
            { "CurrentGP",      e => e.CurrentGP },
            { "MaxGP",          e => e.MaxGP },
            { "TransformationID",   e => e.TransformationID },
            { "Level",          e => e.Level },
            { "MonsterType",    e => (byte)e.MonsterType },
            { "IsEnemy",        e => e.IsEnemy },
            { "IsAggressive",   e => e.IsAggressive },
            { "InCombat",       e => e.InCombat },
            { "InParty",        e => e.InParty },
            { "InAlliance",     e => e.InAlliance },
            { "IsFriend",       e => e.IsFriend },
            { "WeaponID",       e => e.WeaponID },
            { "TargetID",       e => e.TargetHexID },
            { "BNpcNameID",     e => e.BNpcNameID },
            { "CurrentWorldID", e => e.CurrentWorldID },
            { "WorldID",        e => e.WorldID },
            { "HomeWorldID",    e => e.WorldID },
            { "WorldName",      e => (e.Type == EntityType.Pc || e.Type == EntityType.Retainer /* Retainer needs to be tested */)
                                    ? BridgeFFXIV.GetIdEntity(e.HexID).GetValue("worldname").ToString()
                                    : "" },
            { "IsCasting",      e => e.IsCasting },
            { "CastType",       e => e.CastType },
            { "CastID",         e => e.CastID },
            { "CastHexID",      e => e.CastHexID },
            { "CastTargetID",   e => e.IsCasting ? e.CastTargetID.ToString("X") : "0" },
            { "CastX",          e => e.CastPosX },
            { "CastPosX",       e => e.CastPosX },
            { "CastY",          e => e.CastPosY },
            { "CastPosY",       e => e.CastPosY },
            { "CastZ",          e => e.CastPosZ },
            { "CastPosZ",       e => e.CastPosZ },
            { "CastPos",        e => new Vector3(e.CastPosX, e.CastPosY, e.CastPosZ) },
            { "CastTime",       e => e.CastTime },
            { "MaxCastTime",    e => e.MaxCastTime },
            { "Order",          e => 0 },  // Obsolete
            { "StatusIDs",      e => e.Statuses.Select(s => s.StatusID) },
            { "StatusHexIDs",   e => e.Statuses.Select(s => s.StatusHexID) },
            { "StatusCount",    e => e.Statuses.Count },
            { "Marker",         e => Memory.TargetMarkerOnEntity(e.ID) },
            { "MarkerID",       e => (int)Memory.TargetMarkerOnEntity(e.ID) },
        };

        /// <summary>
        /// Note: <br />
        /// The given <see cref="IEnumerable"/>&lt;<see cref="string"/>&gt; args should not be null. 
        /// </summary>
        private readonly static Dictionary<string, Func<Entity, IEnumerable<string>, object>> _methodAccessors
            = new Dictionary<string, Func<Entity, IEnumerable<string>, object>>(StringComparer.OrdinalIgnoreCase)
        {
            { "HasStatus",      (e, args) => {
                if (args.Count() != 1) throw ArgCountError("HasStatus", "1", args);
                var statusID = (ushort)MathParser.Parse(args.First());
                return e.Statuses.Any(s => s.StatusID == statusID);
            }},
            { "StatusTimer",    (e, args) => {
                if (args.Count() != 1) throw ArgCountError("StatusTimer", "1", args);
                var statusID = (ushort)MathParser.Parse(args.First());
                return e.Statuses.FirstOrDefault(s => s.StatusID == statusID)?.Timer ?? -1f;
            }},
            { "StatusStack",    (e, args) => {
                if (args.Count() != 1) throw ArgCountError("StatusStack", "1", args);
                var statusID = (ushort)MathParser.Parse(args.First());
                return e.Statuses.FirstOrDefault(s => s.StatusID == statusID)?.Stack ?? -1;
            }},
        };

        private static Exception ArgCountError(string methodName, string requiredArgCount, IEnumerable<string> args)
        {
            string expr = $"_entity.{methodName}({string.Join(", ", args)})";
            return Context.ArgCountError(methodName, requiredArgCount, args.Count(), expr);
        }

        /// <summary>
        /// All "property" names that could be used to query a "property" (with no arguments). <br />
        /// Aliases are included, such as "H" and "Heading" are both for Entity.Heading. <br />
        /// Job-related properties or method names (with arguments) are not included.
        /// </summary>
        internal static readonly HashSet<string> LegalEntityPropNames
            = new HashSet<string>(_propAccessors.Keys, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// All "method" names that could be used to query a "method" (with arguments). <br />
        /// Aliases are included. <br />
        /// </summary>
        internal static readonly HashSet<string> LegalEntityMethodNames
            = new HashSet<string>(_methodAccessors.Keys, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Recommended property names that are used to query all properties when not specified. <br />
        /// Aliases are NOT included.
        /// </summary>
        internal static readonly HashSet<string> RecommendedEntityPropNames
            = new HashSet<string>(LegalEntityPropNames.Except(new string[] {
                "Exist", "PluginSource", "EffectiveDistance",
                "PosX", "PosY", "PosZ", "XY", "PosXY", "XYZ", "Pos", "H",
                "HP", "MP", "CP", "GP",
                "WorldID", "WorldName",
                "CastPosX", "CastPosY", "CastPosZ", "CastPos",
                "Order", "StatusIDs", "Marker", "MarkerID"
            }, StringComparer.OrdinalIgnoreCase), StringComparer.OrdinalIgnoreCase);

        /// <summary> Try to query a single property/method from the entity by separated property/method name and arguments. </summary>
        /// <param name="propertyName">Property/method name. </param>
        /// <param name="args">Null for properties, and the separated arguments for methods. </param>
        /// <param name="result">The value as data string (<see cref="ToDataStringExtension.ToDataString(object)"/>).</param>
        /// <returns> True if the the property/method name is valid and outputs a result.</returns>
        public bool TryQueryProperty(string propertyName, IEnumerable<string> args, out string result)
        {
            object value;
            int argCount = args?.Count() ?? 0;
            if (args?.Any() == true && _methodAccessors.TryGetValue(propertyName, out var methodAccessor))
            {
                value = methodAccessor(this, args);
            }
            else if (_propAccessors.TryGetValue(propertyName, out var propAccessor))
            {
                value = propAccessor(this);
            }
            else if (this.Job.TryQueryProperty(propertyName, out string jobProp)) // Job, JobID, JobEN, Role, etc.
            {
                value = jobProp;
            }
            else
            {
                result = null;
                return false;
            }
            result = value.ToDataString();
            return true;
        }

        /// <summary>
        /// Query a single property/method from the entity by separated property/method name and arguments. <br />
        /// </summary>
        /// <param name="propertyName">Property/method name. </param>
        /// <param name="args">Null for properties, and the separated arguments for methods. </param>
        /// <returns>
        /// The value as data string (<see cref="ToDataStringExtension.ToDataString(object)"/>). </returns>
        /// <exception cref="ArgumentException">The property/method name is invalid.</exception>
        public string QueryProperty(string propertyName, IEnumerable<string> args)
        {
            if (TryQueryProperty(propertyName, args, out string result))
                return result;
            var argsExpr = args != null ? $"({string.Join(", ", args)})" : "";
            throw new ArgumentException(I18n.Translate("internal/FFXIV/Entity/wrongProp",
                "({0}) is not a valid entity property expression. Full expression: {1}",
                propertyName, $"Entity.{propertyName}{argsExpr}"));
        }

        /// <summary> Query a single property/method from the entity by a raw expression. </summary>
        /// <param name="rawExpression">
        /// Could be a property name, or a method with arguments. <br /> 
        /// e.g. <c>Name</c> <c>HasStatus(0x32)</c>
        /// </param>
        /// <exception cref="ArgumentException">Any property/method name is invalid.</exception>
        public string QueryProperty(string rawExpression)
        {
            var propName = rawExpression;
            var args = new string[0];
            var leftIdx = rawExpression.IndexOf('(');
            if (leftIdx > 0 && propName.EndsWith(")"))
            {
                propName = rawExpression.Substring(0, leftIdx);
                var rawArgs = rawExpression.Substring(leftIdx + 1, rawExpression.Length - leftIdx - 2);
                args = Context.SplitArguments(rawArgs);
            }
            return QueryProperty(propName, args);
        }

        /// <summary> Query all given properties/methods from the entity by a raw expression. </summary>
        /// <param name="rawExpression">
        /// Multiple raw expressions separated with comma. <br /> 
        /// e.g. <c>X, Y, HasStatus(0x32), Heading</c>
        /// </param>
        /// <exception cref="ArgumentException">Any property/method name is invalid.</exception>
        public IEnumerable<string> QueryProperties(string rawExpression)
        {
            var rawProps = Context.SplitArguments(rawExpression);
            return rawProps.Select(QueryProperty);
        }

        #endregion Query Properties
    }

    #region Enums

    public enum PluginSource
    { 
        None,
        XivPlugin,
        OverlayPlugin
    }

    // FFXIVClientStructs/FFXIVClientStructs/FFXIV/Client/UI/Misc/RaptureTextModule.cs
    public enum EntityType : byte
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

    public enum MonsterType : byte
    {
        Friendly = 0,
        Enemy = 4,
        Enemy2 = 10, // Observed, temp name
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
    [Flags]
    public enum AggressionFlag : byte
    {
        IsAggressive = 0x1,
        IsInCombat = 0x2,
    }
    
    #endregion Enums
}

public static class ToDataStringExtension // put it here for now
{
    public static string ToDataString(this object prop)
    {
        if (prop == null) return "";
        switch (prop)
        {
            case string s:
                return s;
            case bool b:
                return b ? "1" : "0";
            case Enum e:
                return e.ToString();
            case Vector2 v2:
                return $"{I18n.ThingToString(v2.X)}, {I18n.ThingToString(v2.Y)}";
            case Vector3 v3:
                return $"{I18n.ThingToString(v3.X)}, {I18n.ThingToString(v3.Y)}, {I18n.ThingToString(v3.Z)}";
            case float f:
                return I18n.ThingToString(f);
            case double d:
                return I18n.ThingToString(d);
            case IFormattable formattable:
                return formattable.ToString(null, CultureInfo.InvariantCulture);
            case IEnumerable data:
                return string.Join(", ", data.Cast<object>().Select(x => x.ToDataString()));
            default:
                return prop.ToString();
        }
    }
}