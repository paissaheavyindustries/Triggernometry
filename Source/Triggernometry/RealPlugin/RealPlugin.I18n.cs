using System;
using System.IO;
using System.Xml.Serialization;

namespace Triggernometry
{

    public partial class RealPlugin
    {
        private void InitLanguage()
        {
            Language ld = new Language();
            ld.LanguageName = "English (default)";
            ld.MissingKeyHandling = Language.MissingHandlingEnum.OutputKey;
            I18n.DefaultLanguage = ld;
            I18n.AddLanguage(ld);
            ChangeLanguage(null);
        }
        
        internal void ChangeLanguage(string langname)
        {
            FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/langchange", "Changing language from '{0}' to '{1}'",
                I18n.CurrentLanguage != null ? I18n.CurrentLanguage.LanguageName : "(not set)",
                (langname != null ? langname : "(default)")
            ));
            if (I18n.ChangeLanguage(langname) == true)
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/langchangeok", "Language is now '{0}'",
                    I18n.CurrentLanguage != null ? I18n.CurrentLanguage.LanguageName : "(not set)"
                ));
                if (cfg != null && I18n.CurrentLanguage != null)
                {
                    if (langname == null)
                    {
                        cfg.Language = null;
                    }
                    else
                    {
                        cfg.Language = I18n.CurrentLanguage.LanguageName;
                    }
                }
            }
            else
            {
                FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/langchangefail", "Couldn't change language from '{0}' to '{1}'",
                    I18n.CurrentLanguage != null ? I18n.CurrentLanguage.LanguageName : "(not set)",
                    (langname != null ? langname : "(default)")
                ));
            }
        }

        private Language LoadLanguage(string filename)
        {
            try
            {
                string x = I18n.Translate("internal/Plugin/langload", "Loading language from '{0}'", filename);
                FilteredAddToLog(DebugLevelEnum.Info, x);
                FileInfo fi = new FileInfo(filename);
                if (fi.Exists == false)
                {
                    FilteredAddToLog(DebugLevelEnum.Warning, I18n.Translate("internal/Plugin/langfilenotfound", "Language file '{0}' does not exist", filename));
                    return null;
                }
                XmlSerializer xs = new XmlSerializer(typeof(Language));
                using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    Language l = (Language)xs.Deserialize(fs);
                    l.IsDefault = false;
                    l.BuildLookup();
                    return l;
                }
            }
            catch (Exception ex)
            {
                FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/langloadfail", "Loading language file failed, make sure you are running the latest version"));
                GenericExceptionHandler(I18n.Translate("internal/Plugin/langloadex", "Loading the language file '{0}' failed due to an exception", filename), ex);
            }
            return null;
        }

        private void SaveDefaultLanguage(string filename)
        {
            Language l = I18n.DefaultLanguage;
            l.BuildList();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer xs = new XmlSerializer(typeof(Language));
            string test = "";
            using (MemoryStream ms = new MemoryStream())
            {
                xs.Serialize(ms, l, ns);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    test = sr.ReadToEnd();
                    test = SerializeInvalidXmlCharacters(test);
                }
            }
            using (FileStream fs = File.Open(filename, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(test);
                    sw.Flush();
                }
            }
        }

        private void LoadLanguages()
        {
            {
                string[] files = Directory.GetFiles(path, "*.triglations.xml", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    Language l = LoadLanguage(file);
                    if (l != null)
                    {
                        I18n.AddLanguage(l);
                    }
                }
            }
            if (path != pluginPath)
            {
                string[] files = Directory.GetFiles(pluginPath, "*.triglations.xml", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    Language l = LoadLanguage(file);
                    if (l != null)
                    {
                        I18n.AddLanguage(l);
                    }
                }
            }
        }

        /*private void CombobulateTranslations()
        {
            string[] ex = File.ReadAllLines(@"F:\Work\Programming\Net\Triggernometry\Triggernometry\newtranslations.txt");
            XmlDocument doc = new XmlDocument();
            XmlNode n = doc.CreateElement("bla");
            doc.AppendChild(n);
            string tag = "", trans = "";
            for (int i = 0; i < ex.Length; i++)
            {
                if ((i % 3) == 0)
                {
                    tag = ex[i];
                }
                if ((i % 3) == 1)
                {
                    trans = ex[i];
                    XmlNode sn = doc.CreateElement("TranslationEntry");
                    XmlAttribute a1 = doc.CreateAttribute("Key");
                    a1.Value = tag;
                    XmlAttribute a2 = doc.CreateAttribute("Translation");
                    a2.Value = trans;
                    sn.Attributes.Append(a1);
                    sn.Attributes.Append(a2);
                    n.AppendChild(sn);
                }
            }
            string docx = doc.InnerXml;
        }*/

        public string Translate(string key, string text, params object[] args)
        {
            return I18n.Translate(key, text, args);
        }
    }
}
