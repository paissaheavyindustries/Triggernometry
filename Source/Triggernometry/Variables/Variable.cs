using System;
using System.Xml.Serialization;

namespace Triggernometry.Variables
{

    [XmlInclude(typeof(VariableScalar))]
    [XmlInclude(typeof(VariableList))]
    [XmlInclude(typeof(VariableTable))]    
    public abstract class Variable : IComparable
    {

        [XmlAttribute(AttributeName = "LastChanger")]
        public string LastChanger { get; set; } = "N/A";

        [XmlAttribute(AttributeName = "LastChanged")]
        public DateTime LastChanged { get; set; } = DateTime.Now;

        public abstract int CompareTo(object o);

        public abstract Variable Duplicate();

    }

}
