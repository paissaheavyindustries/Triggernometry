using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Triggernometry
{

    public class Configuration
    {

        public Folder Root;
        public RepositoryFolder RepositoryRoot;

        [XmlAttribute]
        public int Version { get; set; }

        [XmlAttribute]
        public string PluginVersion { get; set; }

        public enum UpdateNotificationsEnum
        {
            Undefined,
            Yes,
            No
        }

        [XmlAttribute]
        public UpdateNotificationsEnum UpdateNotifications { get; set; }

        [XmlAttribute]
        public UpdateNotificationsEnum DefaultRepository { get; set; }

        [XmlAttribute]
        public string Language { get; set; }

        internal bool _ShowWelcomeHasBeenSet = false;

        private bool _ShowWelcome { get; set; }
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
        public int SfxVolumeAdjustment { get; set; }

        [XmlAttribute]
        public bool UseOsClipboard { get; set; }

        [XmlAttribute]
        public int TtsVolumeAdjustment { get; set; }

        [XmlAttribute]
        public RealPlugin.DebugLevelEnum DebugLevel { get; set; }

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

        [XmlAttribute]
        public string VerboseDebug
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
        public bool UseACTForTTS { get; set; }

        [XmlAttribute]
        public bool UseACTForSound { get; set; }

        [XmlAttribute]
        public bool WarnAdmin { get; set; }

        [XmlAttribute]
        public string EventSeparator { get; set; }

        [XmlAttribute]
        public Guid StartupTriggerId { get; set; }

        [XmlAttribute]
        public bool UseScarborough { get; set; }

        public enum StartupTriggerTypeEnum
        {
            Trigger,
            Folder
        }

        [XmlAttribute]
        public StartupTriggerTypeEnum StartupTriggerType { get; set; }

        [XmlAttribute]
        public bool LogNormalEvents { get; set; }

        [XmlAttribute]
        public bool FfxivLogNetwork { get; set; }

        [XmlAttribute]
        public bool TestLiveByDefault { get; set; }

        [XmlAttribute]
        public string WindowToMonitor { get; set; }

        [XmlAttribute]
        public bool DeveloperMode { get; set; }

        [XmlAttribute]
        public int CacheImageExpiry { get; set; }

        [XmlAttribute]
        public int CacheSoundExpiry { get; set; }

        [XmlAttribute]
        public int CacheJsonExpiry { get; set; }

        [XmlAttribute]
        public int CacheRepoExpiry { get; set; }

        [XmlAttribute]
        public int CacheFileExpiry { get; set; }

        internal bool isnew;
        internal DateTime lastWrite;

        public Configuration()
        {
            Version = 1;
            UpdateNotifications = UpdateNotificationsEnum.Undefined;
            DefaultRepository = UpdateNotificationsEnum.Undefined;
            Root = new Folder();
            Root.Name = I18n.Translate("internal/Configuration/local", "Local triggers");
            RepositoryRoot = new RepositoryFolder();
            RepositoryRoot.Name = I18n.Translate("internal/Configuration/remote", "Remote triggers");
            SfxVolumeAdjustment = 100;
            TtsVolumeAdjustment = 100;
            DebugLevel = RealPlugin.DebugLevelEnum.Info;
            UseACTForTTS = false;
            UseACTForSound = false;
            UseOsClipboard = true;
            LogNormalEvents = true;
            FfxivLogNetwork = false;
            TestLiveByDefault = false;
            UseScarborough = true;
            WarnAdmin = true;
            DeveloperMode = false;
            StartupTriggerType = StartupTriggerTypeEnum.Trigger;
            EventSeparator = "";
            StartupTriggerId = Guid.Empty;
            isnew = true;
            lastWrite = DateTime.Now;
            FfxivPartyOrdering = FfxivPartyOrderingEnum.Legacy;
            FfxivCustomPartyOrder = "19, 1, 21, 3, 32, 37, 24, 6, 28, 33, 20, 2, 22, 4, 30, 29, 34, 23, 5, 31, 38, 25, 7, 27, 26, 35, 36";
            ShowWelcome = true;
            WindowToMonitor = "FINAL FANTASY XIV";
            CacheImageExpiry = 518400;
            CacheSoundExpiry = 518400;
            CacheJsonExpiry = 10080;
            CacheRepoExpiry = 518400;
            CacheFileExpiry = 518400;
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
        Monk		20
        Pugilist	2
        Dragoon		22
        Lancer		4
        Ninja		30
        Rogue		29
        Samurai		34
        Bard		23
        Archer		5
        Machinist	31
        Dancer      38
        Black Mage	25
        Thaumaturge	7
        Summoner	27
        Arcanist	26
        Red Mage	35
        Blue Mage	36
         */

    }

}
