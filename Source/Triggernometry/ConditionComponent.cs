using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Threading;

namespace Triggernometry
{

    [XmlInclude(typeof(ConditionSingle))]
    [XmlInclude(typeof(ConditionGroup))]    
    public abstract class ConditionComponent
    {

        public delegate void ChangeDelegate(ConditionComponent re);
        public event ChangeDelegate OnPropertyChange;

        private static object lobject = new object();
        private static Int64 IdCounter = 1;
        internal Int64 Id { get; set; }

        [XmlAttribute]
        public bool Enabled { get; set; } = true;

        internal ConditionGroup Parent { get; set; } = null;

        protected void TriggerOnPropertyChange()
        {
            if (OnPropertyChange != null)
            {
                OnPropertyChange(this);
            }
        }

        internal abstract bool CheckCondition(Context ctx, Context.LoggerDelegate logger, object o);
        internal abstract ConditionComponent Duplicate();

        public ConditionComponent()
        {
            lock (lobject)
            {
                Id = IdCounter;
                IdCounter++;
            }
        }

    }

}
