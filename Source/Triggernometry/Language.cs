using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Triggernometry
{

    public sealed class Language
    {

        public enum MissingHandlingEnum
        {
            DefaultLanguage,
            DefaultString,
            OutputKey
        }

        [XmlAttribute]
        public string LanguageName { get; set; }
        [XmlAttribute]
        public MissingHandlingEnum MissingKeyHandling { get; set; }

        internal Dictionary<string, string> TranslationsLookup { get; set; }

        internal bool IsDefault { get; set; }

        public class TranslationEntry
        {

            [XmlAttribute]
            public string Key { get; set; }
            [XmlAttribute]
            public string Translation { get; set; }

            public TranslationEntry()
            {
            }

        }

        public List<TranslationEntry> Translations = new List<TranslationEntry>();

        public Language()
        {
            IsDefault = true;
            LanguageName = "(undefined)";
            TranslationsLookup = new Dictionary<string, string>();
            MissingKeyHandling = MissingHandlingEnum.DefaultLanguage;
        }

        internal void BuildLookup()
        {
            foreach (TranslationEntry te in Translations)
            {
                TranslationsLookup[te.Key] = te.Translation;
            }
            Translations.Clear();
        }

        internal void BuildList()
        {
            Translations.Clear();
            foreach (KeyValuePair<string, string> kp in TranslationsLookup)
            {
                Translations.Add(new TranslationEntry() { Key = kp.Key, Translation = kp.Value });
            }
            Translations.Sort((a, b) => { return a.Key.CompareTo(b.Key); });
        }

        public string Lookup(string key)
        {
            if (TranslationsLookup.ContainsKey(key) == true)
            {
                return TranslationsLookup[key];
            }
            return null;
        }

        public string Translate(string key, string text, params object[] args)
        {
            if (IsDefault == true)
            {
                if (TranslationsLookup.ContainsKey(key) == false)
                {
                    TranslationsLookup[key] = text;
                }
            }
            if (TranslationsLookup.ContainsKey(key) == true)
            {
                string data = TranslationsLookup[key];
                return String.Format(data, args);
            }
            switch (MissingKeyHandling)
            {
                case MissingHandlingEnum.DefaultString:
                    {
                        if (TranslationsLookup.ContainsKey("internal/default") == true)
                        {
                            return String.Format(TranslationsLookup["internal/default"], key);
                        }
                        else
                        {
                            return String.Format(text, args);
                        }
                    }
                case MissingHandlingEnum.OutputKey:
                    return key;
            }
            return String.Format(text, args);
        }

    }

}
