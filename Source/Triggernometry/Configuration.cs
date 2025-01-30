using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Triggernometry.Variables;

namespace Triggernometry
{

    public class Configuration
    {
        // Configuration Form

        #region General

        // Logging

        [XmlAttribute]
        public RealPlugin.DebugLevelEnum DebugLevel { get; set; } = RealPlugin.DebugLevelEnum.Info;

        [XmlAttribute]
        public string VerboseDebug // Old version
        {
            get
            {
                return null;
            }
            set
            {
                if (value == "true")
                {
                    DebugLevel = RealPlugin.DebugLevelEnum.Verbose;
                }
                else
                {
                    DebugLevel = RealPlugin.DebugLevelEnum.Info;
                }
            }
        }

        [XmlAttribute]
        public bool LogNormalEvents { get; set; } = true;

        [XmlAttribute]
        public bool LogVariableExpansions { get; set; } = false;

        // Startup

        internal bool _ShowWelcomeHasBeenSet = false;
        private bool _ShowWelcome { get; set; } = true;

        [XmlAttribute]
        public bool ShowWelcome
        {
            get
            {

                return _ShowWelcome;
            }
            set
            {
                _ShowWelcome = value;
                _ShowWelcomeHasBeenSet = true;
            }
        }

        [XmlAttribute]
        public bool WarnAdmin { get; set; } = true;

        public enum UpdateCheckMethodEnum
        {
            Builtin,
            ACT,
            External
        }

        [XmlAttribute]
        public UpdateNotificationsEnum UpdateNotifications { get; set; } = UpdateNotificationsEnum.Undefined;

        [XmlAttribute]
        public UpdateCheckMethodEnum UpdateCheckMethod { get; set; } = UpdateCheckMethodEnum.ACT;

        [XmlAttribute]
        public string UpdateExternalChannelURI { get; set; } = "";

        // Startup Trigger/Folder

        public enum StartupTriggerTypeEnum
        {
            Trigger,
            Folder
        }

        [XmlAttribute]
        public StartupTriggerTypeEnum StartupTriggerType { get; set; } = StartupTriggerTypeEnum.Trigger;

        [XmlAttribute]
        public Guid StartupTriggerId { get; set; } = Guid.Empty;

        #endregion

        #region Audio

        public enum AudioRoutingMethodEnum
        {
            None,
            Triggernometry,
            ACT,
            ExternalApplication
        }

        // Global volume adjustment

        [XmlAttribute]
        public int SfxVolumeAdjustment { get; set; } = 100;

        [XmlAttribute]
        public int TtsVolumeAdjustment { get; set; } = 100;

        // ACT hooks

        [XmlAttribute]
        public string UseACTForSound
        {
            get
            {
                return null;
            }
            set
            {
                bool temp = bool.Parse(value);
                if (temp == true)
                {
                    SoundMethod = AudioRoutingMethodEnum.ACT;
                }
                else
                {
                    SoundMethod = AudioRoutingMethodEnum.Triggernometry;
                }
            }
        }

        [XmlAttribute]
        public string UseACTForTTS
        {
            get
            {
                return null;
            }
            set
            {
                bool temp = bool.Parse(value);
                if (temp == true)
                {
                    TtsMethod = AudioRoutingMethodEnum.ACT;
                }
                else
                {
                    TtsMethod = AudioRoutingMethodEnum.Triggernometry;
                }
            }
        }

        [XmlAttribute]
        public int SoundRepCooldown { get; set; } = 500;

        [XmlAttribute]
        public int TtsRepCooldown { get; set; } = 500;

        [XmlAttribute]
        public AudioRoutingMethodEnum SoundMethod { get; set; } = AudioRoutingMethodEnum.Triggernometry;

        [XmlAttribute]
        public string SoundExternalApp { get; set; } = "";

        [XmlAttribute]
        public string SoundExternalAppArgs { get; set; } = "";

        [XmlAttribute]
        public AudioRoutingMethodEnum TtsMethod { get; set; } = AudioRoutingMethodEnum.Triggernometry;

        [XmlAttribute]
        public string TtsExternalApp { get; set; } = "";

        [XmlAttribute]
        public string TtsExternalAppArgs { get; set; } = "";

        #endregion

        #region Shortcuts

        [XmlAttribute]

        public bool EnableShortcutTemplates { get; set; } = true;
        public bool UseAbbrevInTemplates { get; set; } = true;
        public bool WrapTextWhenSelected { get; set; } = true;

        #endregion

        #region Caching

        [XmlAttribute]
        public int CacheImageExpiry { get; set; } = 518400;

        [XmlAttribute]
        public int CacheSoundExpiry { get; set; } = 518400;

        [XmlAttribute]
        public int CacheJsonExpiry { get; set; } = 10080;

        [XmlAttribute]
        public int CacheRepoExpiry { get; set; } = 518400;

        [XmlAttribute]
        public int CacheFileExpiry { get; set; } = 518400;

        #endregion

        #region Endpoint

        [XmlAttribute]
        public string HttpEndpoint { get; set; } = "http://localhost:51423/";

        [XmlAttribute]
        public bool StartEndpointOnLaunch { get; set; } = true;

        [XmlAttribute]
        public bool LogEndpoint { get; set; } = true;

        #endregion

        #region FFXIV

        [XmlAttribute]
        public bool FfxivLogNetwork { get; set; } = false;

        public enum FfxivPartyOrderingEnum
        {
            Legacy,
            CustomSelfFirst,
            CustomFull
        }

        [XmlAttribute]
        public FfxivPartyOrderingEnum FfxivPartyOrdering { get; set; } = FfxivPartyOrderingEnum.CustomSelfFirst;
        private string _FfxivCustomPartyOrder;
        [XmlAttribute]
        public string FfxivCustomPartyOrder
        {
            get
            {
                return _FfxivCustomPartyOrder;
            }
            set
            {
                _FfxivCustomPartyOrder = value;
                _FfxivCustomPartyOrderLookup.Clear();
                string[] ex = value.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                int subn = 1;
                foreach (string e in ex)
                {
                    string et = e.Trim();
                    int valn = 0;
                    if (Int32.TryParse(et, out valn) == true)
                    {
                        if (_FfxivCustomPartyOrderLookup.ContainsKey(valn) == false)
                        {
                            _FfxivCustomPartyOrderLookup[valn] = subn;
                            subn++;
                        }
                    }
                }
            }
        }

        internal int GetPartyOrderValue(int job)
        {
            if (_FfxivCustomPartyOrderLookup.ContainsKey(job) == true)
            {
                return _FfxivCustomPartyOrderLookup[job];
            }
            return 9999;
        }

        internal int GetPartyOrderValue(string job)
        {
            int ex = 0;
            if (Int32.TryParse(job, out ex) == true)
            {
                return GetPartyOrderValue(ex);
            }
            return 999;
        }

        private Dictionary<int, int> _FfxivCustomPartyOrderLookup { get; set; } = new Dictionary<int, int>();

        #endregion

        #region Substitutions

        public List<Substitution> Substitutions { get; set; } = new List<Substitution>();

        public class Substitution : IComparable
        {

            [Flags]
            public enum SubstitutionScopeEnum
            {
                CaptureGroup = 1,
                NumericExpression = 2,
                StringExpression = 4,
                TextToSpeech = 8
            }

            [XmlAttribute]
            public string SearchFor { get; set; }

            [XmlAttribute]
            public string ReplaceWith { get; set; }

            [XmlAttribute]
            public SubstitutionScopeEnum Scope { get; set; }

            public string Replace(string input)
            {
                return input.Replace(SearchFor, ReplaceWith);
            }

            public int CompareTo(object obj)
            {
                Substitution b = (Substitution)obj;
                int x = SearchFor.CompareTo(b.SearchFor);
                if (x != 0)
                {
                    return x;
                }
                x = ReplaceWith.CompareTo(b.ReplaceWith);
                if (x != 0)
                {
                    return x;
                }
                return Scope.CompareTo(b.Scope);
            }
        }

        public string PerformSubstitution(string input, Substitution.SubstitutionScopeEnum scope)
        {
            if (Substitutions.Count > 0)
            {
                var reps = from ix in Substitutions where (ix.Scope & scope) == scope select ix;
                if (reps.Count() > 0)
                {
                    foreach (Configuration.Substitution rep in reps)
                    {
                        input = rep.Replace(input);
                    }
                }
            }
            return input;
        }

        #endregion

        #region Constants

        public SerializableDictionary<string, VariableScalar> Constants { get; set; } = new SerializableDictionary<string, VariableScalar>();

        #endregion

        #region Security

        public class APIUsage
        {

            [XmlAttribute]
            public string Name { get; set; }

            [XmlAttribute]
            public bool AllowLocal { get; set; }

            [XmlAttribute]
            public bool AllowRemote { get; set; }

            [XmlAttribute]
            public bool AllowAdmin { get; set; }

        }

        [Flags]
        public enum UnsafeUsageEnum
        {
            None = 0,
            AllowLocal = 1,
            AllowRemote = 2,
            AllowAdmin = 4
        }

        private bool SecuritySettingsLocked { get; set; } = false;

        private List<APIUsage> _APIUsages { get; set; } = new List<APIUsage>();
        public List<APIUsage> APIUsages
        {
            get
            {
                return SecuritySettingsLocked == false ? _APIUsages : null;
            }
            set
            {
                if (SecuritySettingsLocked == false)
                {
                    _APIUsages = value;
                }
            }
        }

        [XmlAttribute]
        private UnsafeUsageEnum _UnsafeUsage = UnsafeUsageEnum.None;
        public UnsafeUsageEnum UnsafeUsage
        {
            get
            {
                return _UnsafeUsage;
            }
            set
            {
                if (SecuritySettingsLocked == false)
                {
                    _UnsafeUsage = value;
                }
            }
        }

        internal List<APIUsage> GetAPIUsages()
        {
            List<APIUsage> l = new List<APIUsage>();
            foreach (APIUsage a in _APIUsages)
            {
                l.Add(new APIUsage() { Name = a.Name, AllowLocal = a.AllowLocal, AllowRemote = a.AllowRemote, AllowAdmin = a.AllowAdmin });
            }
            return l;
        }

        private void AddAPIUsage(APIUsage au, bool overwrite)
        {
            var ax = (from aus in _APIUsages where aus.Name.CompareTo(au.Name) == 0 select aus).FirstOrDefault();
            if (ax == null)
            {
                _APIUsages.Add(au);
            }
            else if (overwrite == true)
            {
                ax.AllowLocal = au.AllowLocal;
                ax.AllowRemote = au.AllowRemote;
                ax.AllowAdmin = au.AllowAdmin;
            }
        }

        private void SetUnsafeUsage(UnsafeUsageEnum us)
        {
            _UnsafeUsage = us;
        }

        #endregion

        #region Miscellaneous

        // Default Settings

        public Trigger TemplateTrigger = new Trigger() { Enabled = true, Conditions = null, _Condition = new ConditionGroup() { Grouping = ConditionGroup.CndGroupingEnum.Or, Enabled = false } };

        [XmlAttribute]
        public bool UseTemplateTrigger { get; set; } = false;

        // User Interface

        [XmlAttribute]
        public bool UiFontDefault { get; set; } = true;

        [XmlAttribute]
        public string UiFontName { get; set; } = null;

        [XmlAttribute]
        public float UiFontSize { get; set; } = 10.0f;

        [XmlAttribute]
        public Action.TextAuraEffectEnum UiFontEffect { get; set; } = Action.TextAuraEffectEnum.None;

        [XmlAttribute]
        public bool TestLiveByDefault { get; set; } = true;

        [XmlAttribute]
        public bool TestIgnoreConditionsByDefault { get; set; } = true;

        [XmlAttribute]
        public bool ActionAsyncByDefault { get; set; } = true;

        [XmlAttribute]
        public bool DeveloperMode { get; set; } = false;

        [XmlAttribute]
        public bool AutoComplete { get; set; } = true;

        [XmlAttribute]
        public bool AutosaveEnabled { get; set; } = false;

        [XmlAttribute]
        public int AutosaveInterval { get; set; } = 5;

        // Aura control

        [XmlAttribute]
        public string WindowToMonitor { get; set; } = "FINAL FANTASY XIV";

        [XmlAttribute]
        public bool UseScarborough { get; set; } = true;

        #endregion

        // Others

        #region Test Input

        [XmlAttribute]
        public int TestInputDestination { get; set; } = -1;

        [XmlAttribute]
        public int TestInputZoneType { get; set; } = -1;

        #endregion

        #region Main UI / Others

        public Folder Root = new Folder { 
            Name = I18n.Translate("internal/Configuration/local", "Local triggers") 
        };

        public RepositoryFolder RepositoryRoot = new RepositoryFolder { 
            Name = I18n.Translate("internal/Configuration/remote", "Remote triggers") 
        };

        public VariableStore PersistentVariables { get; set; } = new VariableStore();

        public enum UpdateNotificationsEnum
        {
            Undefined,
            Yes,
            No
        }

        [XmlAttribute]
        public UpdateNotificationsEnum DefaultRepository { get; set; } = UpdateNotificationsEnum.Undefined;

        [XmlAttribute]
        public string Language { get; set; }

        #endregion

        [XmlAttribute]
        public int Version { get; set; } = 1;

        [XmlAttribute]
        public string PluginVersion { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        [XmlIgnore]
        public string PrevPluginVersion { get; set; }

        internal bool isnew = true;
        internal DateTime lastWrite = DateTime.Now;
        internal string corruptRecoveryError = "";

        public Configuration()
        {
            FfxivCustomPartyOrder = "19, 1, 21, 3, 32, 37, 24, 6, 28, 33, 40, 20, 2, 22, 4, 30, 29, 34, 39, 23, 5, 31, 38, 25, 7, 27, 26, 35, 36";
            Constants["TelestoEndpoint"] = new VariableScalar() { Value = "localhost" };
            Constants["TelestoPort"] = new VariableScalar() { Value = "45678" };
            Constants["OBSWebsocketEndpoint"] = new VariableScalar() { Value = "localhost" };
            Constants["OBSWebsocketPort"] = new VariableScalar() { Value = "4455" };
            Constants["OBSWebsocketPassword"] = new VariableScalar() { Value = "" };
            Constants["TriggernometryEndpoint"] = new VariableScalar() { Value = "http://localhost:51423/" };           
        }

        /*
        Paladin		19
        Gladiator	1
        Warrior		21
        Marauder	3
        Dark Knight	32
        Gunbreaker  37
        White Mage	24
        Conjurer	6
        Scholar		28
        Astrologian	33
        Sage        40
        Monk		20
        Pugilist	2
        Dragoon		22
        Lancer		4
        Ninja		30
        Rogue		29
        Samurai		34
        Reaper      39
        Viper       41
        Bard		23
        Archer		5
        Machinist	31
        Dancer      38
        Black Mage	25
        Pictomancer 42
        Thaumaturge	7
        Summoner	27
        Arcanist	26
        Red Mage	35
        Blue Mage	36
         */

    }

}
