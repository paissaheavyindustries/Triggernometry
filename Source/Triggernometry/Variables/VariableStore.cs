using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Triggernometry.Variables
{

    public class VariableStore
    {
        
        public SerializableDictionary<string, VariableScalar> Scalar { get; set; } = new SerializableDictionary<string, VariableScalar>();

        public SerializableDictionary<string, VariableList> List { get; set; } = new SerializableDictionary<string, VariableList>();

        public SerializableDictionary<string, VariableTable> Table { get; set; } = new SerializableDictionary<string, VariableTable>();

        public SerializableDictionary<string, VariableDictionary> Dict { get; set; } = new SerializableDictionary<string, VariableDictionary>();

    }

}
