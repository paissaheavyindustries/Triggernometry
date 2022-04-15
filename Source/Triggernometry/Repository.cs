using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Triggernometry
{

    public class Repository
    {

        public class RepositoryItem
        {

            [XmlAttribute]
            public Guid Id;

            [XmlAttribute]
            public bool Enabled;

        }

        public enum NewBehaviorEnum
        {
            AsDefined,
            AlwaysEnable,
            AlwaysDisable
        }

        public enum UpdatePolicyEnum
        {
            Startup,
            Manual
        }

        public enum AudioOutputEnum
        {
            AsDefined,
            AlwaysOverride,
            NeverOverride
        }

        [XmlAttribute]
        public bool Enabled
        {
            get
            {
                return Root.Enabled;
            }
            set
            {
                Root.Enabled = value;
            }
        }

        [XmlAttribute]
        public string Name
        {
            get
            {
                return Root.Name;
            }
            set
            {
                Root.Name = value;
            }
        }

        internal RepositoryFolder Parent { get; set; }

        internal List<Trigger> ReadmeTriggers = new List<Trigger>();

        [XmlAttribute]
        public string Address { get; set; }
        [XmlAttribute]
        public bool KeepLocalBackup { get; set; }

        [XmlAttribute]
        public DateTime LastUpdated { get; set; }

        public DateTime LastUpdatedTrig { get; set; }

        [XmlAttribute]
        public bool AutoUpdate { get; set; }
        [XmlAttribute]
        public int UpdateInterval { get; set; }

        [XmlAttribute]
        public bool AllowScriptExecution { get; set; }
        [XmlAttribute]
        public bool AllowProcessLaunch { get; set; }
        [XmlAttribute]
        public bool AllowWindowMessages { get; set; }
        [XmlAttribute]
        public bool AllowObsControl { get; set; }
        [XmlAttribute]
        public bool AllowDiskOperations { get; set; }

        [XmlAttribute]
        public NewBehaviorEnum NewBehavior { get; set; }
        [XmlAttribute]
        public UpdatePolicyEnum UpdatePolicy { get; set; }
        [XmlAttribute]
        public AudioOutputEnum AudioOutput { get; set; }

        internal long ContentSize { get; set; } = 0;

        public List<RepositoryItem> FolderStates { get; set; }
        public List<RepositoryItem> TriggerStates { get; set; }

        internal Folder Root { get; set; }

        internal List<string> UpdateLog { get; set; } = new List<string>();

        public Repository()
        {
            Root = new Folder();
            AllowObsControl = false;
            AllowProcessLaunch = false;
            AllowScriptExecution = false;
            AllowWindowMessages = false;
            AllowDiskOperations = false;
            KeepLocalBackup = true;
            AutoUpdate = false;
            UpdateInterval = 5;
            LastUpdatedTrig = DateTime.MinValue;
            TriggerStates = new List<RepositoryItem>();
            FolderStates = new List<RepositoryItem>();
        }

        public void AddToLog(string s)
        {
            lock (UpdateLog)
            {
                UpdateLog.Add(RealPlugin.FormatDateTime(DateTime.Now) + " - " + s);
            }
        }

        public void ClearLog()
        {
            lock (UpdateLog)
            {
                UpdateLog.Clear();
            }
        }

    }

}
