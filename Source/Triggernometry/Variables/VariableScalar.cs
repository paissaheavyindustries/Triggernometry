using System;
using System.Xml.Serialization;

namespace Triggernometry.Variables
{

    [XmlRoot(ElementName = "VariableScalar")]
    public class VariableScalar : Variable
    {

        public string Value { get; set; } = "";

        public override string ToString()
        {
            return Value;
        }

        public override int CompareTo(object o)
        {
            if ((o is Variable) == false)
            {
                throw new InvalidOperationException();
            }
            if (o is VariableScalar)
            {
                VariableScalar v = (VariableScalar)o;
                return Value.CompareTo(v.Value);
            }
            return -1;
        }

        public override Variable Duplicate()
        {
            VariableScalar v = new VariableScalar();
            v.Value = Value;
            v.LastChanger = LastChanger;
            v.LastChanged = LastChanged;
            return v;
        }

    }

}
