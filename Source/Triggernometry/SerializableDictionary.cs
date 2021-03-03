using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Triggernometry
{

    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader x)
        {
            if (x.IsEmptyElement == true)
            {
                return;
            }
            x.Read();
            XmlSerializer xsk = new XmlSerializer(typeof(TKey));
            XmlSerializer xsv = new XmlSerializer(typeof(TValue));
            while (x.NodeType != XmlNodeType.EndElement)
            {
                TKey key;
                TValue value;
                x.ReadStartElement("Item");
                x.ReadStartElement("Key");
                key = (TKey)xsk.Deserialize(x);
                x.ReadEndElement();
                x.ReadStartElement("Value");
                value = (TValue)xsv.Deserialize(x);
                x.ReadEndElement();
                x.ReadEndElement();
                this[key] = value;
                x.MoveToContent();
            }
            x.Read();
        }

        public void WriteXml(XmlWriter x)
        {
            XmlSerializer xsk = new XmlSerializer(typeof(TKey));
            XmlSerializer xsv = new XmlSerializer(typeof(TValue));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            foreach (TKey k in Keys)
            {
                x.WriteStartElement("Item");
                x.WriteStartElement("Key");
                xsk.Serialize(x, k, ns);
                x.WriteEndElement();
                x.WriteStartElement("Value");
                xsv.Serialize(x, this[k], ns);
                x.WriteEndElement();
                x.WriteEndElement();
            }
        }

    }

}
