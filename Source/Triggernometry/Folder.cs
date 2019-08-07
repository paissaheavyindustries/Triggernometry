using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Triggernometry
{

    public class Folder
    {

		private Regex rexz;
		private string _ZoneFilterRegularExpression;
        [XmlAttribute]
        public bool FFXIVJobFilterEnabled;
        [XmlAttribute]
        public Int64 FFXIVJobFilter;
        [XmlAttribute]
		public bool ZoneFilterEnabled;

        [XmlAttribute]
        public Guid Id { get; set; }

        [XmlAttribute]
        public string ZoneFilterRegularExpression
		{
			get
			{
				if (_ZoneFilterRegularExpression == "")
                {
                    return null;
                }
                return _ZoneFilterRegularExpression;
            }
			set
			{
				if (_ZoneFilterRegularExpression != value)
				{
					_ZoneFilterRegularExpression = value;
					try
					{
						rexz = new Regex(_ZoneFilterRegularExpression);
					}
					catch (Exception)
					{
						rexz = null;
					}
				}
			}
		}
		
		private Regex rexe;
		private string _EventFilterRegularExpression;
        [XmlAttribute]
		public bool EventFilterEnabled;
		[XmlAttribute]
        public string EventFilterRegularExpression
		{
			get
			{
				if (_EventFilterRegularExpression == "")
                {
                    return null;
                }
                return _EventFilterRegularExpression;
            }
			set
			{
				if (_EventFilterRegularExpression != value)
				{
					_EventFilterRegularExpression = value;
					try
					{
						rexe = new Regex(_EventFilterRegularExpression);
					}
					catch (Exception)
					{
						rexe = null;
					}
				}
			}
		}		

		internal Folder Parent { get; set; }
        public List<Folder> Folders { get; set; }
        public List<Trigger> Triggers { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool Enabled { get; set; }

        internal Repository Repo { get; set; } = null;

        public Folder()
        {
            Folders = new List<Folder>();
            Triggers = new List<Trigger>();
            Enabled = true;
            Id = Guid.NewGuid();
        }

        public enum FilterFailReason
        {
            Passed,
            Failed,
            NotEnabled,
            Exception
        }

        public bool ParentsEnabled()
        {
            Folder f = this;
            while (f != null)
            {
                if (f.Enabled == false)
                {
                    return false;
                }
                f = f.Parent;
            }
            return true;
        }
		
		public FilterFailReason PassesFilter(string zone, string evtext)
		{
			bool ret = true;
			Folder f = this;
			while (f != null && ret == true)
			{
                if (f.Enabled == false)
                {
                    return FilterFailReason.NotEnabled;
                }
                if (ret == true && f.ZoneFilterEnabled == true)
				{
					ret = f.rexz != null ? f.rexz.IsMatch(zone) : false;
				}		
				if (ret == true && f.EventFilterEnabled == true)
				{
					ret = f.rexe != null ? f.rexe.IsMatch(evtext) : false;
				}
                if (ret == true && f.FFXIVJobFilterEnabled == true)
                {
                    VariableClump vc = PluginBridges.BridgeFFXIV.GetMyself();
                    if (vc != null)
                    {
                        Int64 currentJob = 0;
                        Int64.TryParse(vc.GetValue("jobid"), out currentJob);
                        Int64 shifted = ((Int64)1) << ((int)currentJob - 1);
                        ret = ((f.FFXIVJobFilter & shifted) != 0);
                    }
                    else
                    {
                        ret = false;
                    }
                }
                f = f.Parent;
			}
			return ret == true ? FilterFailReason.Passed : FilterFailReason.Failed;
		}

    }

}
