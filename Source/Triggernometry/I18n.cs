using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Triggernometry
{

    public static class I18n
    {

        internal static Dictionary<string, Language> RegisteredLanguages = new Dictionary<string, Language>();

        internal static Language BuiltInLanguage = null;
        internal static Language DefaultLanguage = null;
        internal static Language CurrentLanguage = null;

        internal static object DoNotTranslate = new object();

        internal static string ThingToString(int d)
        {   // minus signs could be different: "-" or "−"
            return d.ToString(CultureInfo.InvariantCulture);
        }

        internal static string ThingToString(float d)
        {
            return ((decimal)d).ToString(CultureInfo.InvariantCulture);
        }

        internal static string ThingToString(double d)
        {
            return ((decimal)d).ToString(CultureInfo.InvariantCulture);
        }

        internal static void AddLanguage(Language ld)
        {
            if (ld.IsDefault == true)
            {
                DefaultLanguage = ld;
            }
            if (RegisteredLanguages.ContainsKey(ld.LanguageName) == true)
            {
                string basename = ld.LanguageName;
                for (int i = 2; ; i++)
                {
                    string curname = basename + " #" + i;
                    if (RegisteredLanguages.ContainsKey(curname) == true)
                    {
                        continue;
                    }
                    ld.LanguageName = curname;
                    RegisteredLanguages[curname] = ld;
                    break;
                }
            }
            else
            {
                RegisteredLanguages[ld.LanguageName] = ld;
            }
            if (CurrentLanguage == null)
            {
                CurrentLanguage = ld;
            }
        }

        internal static string Lookup(string key, string defValue)
        {
            if (CurrentLanguage != null)
            {
                string ex = CurrentLanguage.Lookup(key);
                if (ex != null)
                {
                    return ex;
                }
            }
            return defValue;
        }

        public static string Translate(string key, string text, params object[] args)
        {
            if (BuiltInLanguage != null)
            {
                if (BuiltInLanguage.TranslationsLookup.ContainsKey(key) == false)
                {
                    BuiltInLanguage.TranslationsLookup[key] = text;
                }
            }
            if (CurrentLanguage != null)
            {
                try
                {
                    return CurrentLanguage.Translate(key, text, args);
                }
                catch (FormatException)
                {
                    RealPlugin.plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/I18n/formatex", 
                        "You might need to update your translation file (your_language_name.triglations.xml). \nFormatException occured during translating \"{0}\".",key));
                    return String.Format(text, args);
                }
            }
            else
            {
                return String.Format(text, args);
            }
        }

        internal static void TranslateSecondaryControl(string path, ToolStripItem tsi)
        {
            if (tsi.Text != null && tsi.Text != "" && tsi.Tag != DoNotTranslate)
            {
                tsi.Text = GetLocalizationFor(path + "/" + tsi.Name, tsi.Text);
            }
            if (tsi is ToolStripMenuItem)
            {
                ToolStripMenuItem x = (ToolStripMenuItem)tsi;
                foreach (ToolStripItem tsic in x.DropDownItems)
                {
                    TranslateSecondaryControl(path, tsic);
                }
            }
            else if (tsi is ToolStripDropDownButton)
            {
                ToolStripDropDownButton x = (ToolStripDropDownButton)tsi;
                foreach (ToolStripItem tsic in x.DropDownItems)
                {
                    TranslateSecondaryControl(path, tsic);
                }
            }
        }

        internal static string GetLocalizationFor(string path, string current)
        {
            return I18n.Translate(path, current);
        }

        internal static bool ChangeLanguage(string langname)
        {
            if (langname == null)
            {
                if (BuiltInLanguage == null)
                {
                    BuiltInLanguage = DefaultLanguage;
                }
                CurrentLanguage = DefaultLanguage;
                return true;
            }
            else
            {
                if (RegisteredLanguages.ContainsKey(langname) == true)
                {
                    CurrentLanguage = RegisteredLanguages[langname];
                    return true;
                }
                else
                {
                    CurrentLanguage = DefaultLanguage;
                    return false;
                }
            }
        }

        internal static void TranslateControl(string path, Control c)
        {
            if (c.Tag == I18n.DoNotTranslate)
            {
                return;
            }
            if (c is UserControl)
            {
                path += "/" + c.Name;
                foreach (Control cc in c.Controls)
                {
                    TranslateControl(path, cc);
                }
                return;
            }
            if (c is NumericUpDown)
            {
                return;
            }
            if (c.ContextMenuStrip != null)
            {
                ContextMenuStrip ctx = c.ContextMenuStrip;
                foreach (ToolStripItem tsi in ctx.Items)
                {
                    TranslateSecondaryControl(path, tsi);
                }
            }
            if (c.Text != null && c.Text != "")
            {
                if (c is TabPage)
                {
                    if (((TabControl)((TabPage)c).Parent).Appearance != TabAppearance.FlatButtons)
                    {
                        c.Text = GetLocalizationFor(path + "/" + c.Name, c.Text);
                    }
                }
                else
                {
                    c.Text = GetLocalizationFor(path + "/" + c.Name, c.Text);
                }
            }
            if (c is CheckedListBox)
            {
                CheckedListBox x = (CheckedListBox)c;
                for (int i = 0; i < x.Items.Count; i++)
                {
                    string o = x.Items[i].ToString();
                    if (x.Items[i] is Forms.FolderForm.ClassLink)
                    {
                        ((Forms.FolderForm.ClassLink)x.Items[i]).name = GetLocalizationFor(path + "/" + c.Name + "[" + o + "]", o);
                    }
                    else
                    {
                        x.Items[i] = GetLocalizationFor(path + "/" + c.Name + "[" + o + "]", o);
                    }
                }
            }
            else if (c is ListBox)
            {
                ListBox x = (ListBox)c;
                for (int i = 0; i < x.Items.Count; i++)
                {
                    string o = x.Items[i].ToString();
                    x.Items[i] = GetLocalizationFor(path + "/" + c.Name + "[" + o + "]", o);
                }
            }
            else if (c is ComboBox)
            {
                ComboBox x = (ComboBox)c;
                for (int i = 0; i < x.Items.Count; i++)
                {
                    string o = x.Items[i].ToString();
                    x.Items[i] = GetLocalizationFor(path + "/" + c.Name + "[" + o + "]", o);
                }
            }
            else if (c is DataGridView)
            {
                DataGridView x = (DataGridView)c;
                for (int i = 0; i < x.Columns.Count; i++)
                {
                    string hd = x.Columns[i].HeaderText.Trim();
                    if (hd.Length > 0)
                    {
                        x.Columns[i].HeaderText = GetLocalizationFor(path + "/" + x.Columns[i].Name, x.Columns[i].HeaderText);
                    }
                }
            }
            if (c is ToolStrip)
            {
                ToolStrip ts = (ToolStrip)c;
                foreach (ToolStripItem tsi in ts.Items)
                {
                    TranslateSecondaryControl(path, tsi);
                }
            }
            else
            {
                foreach (Control cc in c.Controls)
                {
                    TranslateControl(path, cc);
                }
            }
        }

        internal static void TranslateForm(Form f)
        {
            string basePath = f.GetType().Name;
            if (f.Text != null && f.Text != "")
            {
                f.Text = GetLocalizationFor(basePath, f.Text);
            }
            foreach (Control c in f.Controls)
            {
                I18n.TranslateControl(basePath, c);
            }
        }

        private static readonly HashSet<string> _wordsToTranslate = new HashSet<string> 
        {   // all lowercase
            "bool", "char", "charcode", "double", "float", "hex", "index", "int", "key",
            "length", "property", "slice", "startindex", "string", "time", "times", "type", "version"
        };

        internal static string TranslateWord(string key)
        {
            key = key.ToLower();
            if (_wordsToTranslate.Contains(key))
            {
                string path = $"internal/I18n/{key}";
                return Translate(path, key);
            }
            else
            {
                throw new Exception(Translate("internal/I18n/translatewordmissingkey", 
                    "The key {0} is not in I18n._wordsToTranslate. Please report the bug if you see this error.", key));
            }
        }

        internal static string TrlVarPersist(bool isPersist)
        {
            return isPersist ? Translate("internal/I18n/descpersistent", "persistent ") 
                             : "";
        }

        internal static string TrlExprType(bool isStringExpr)
        {
            return isStringExpr ? Translate("internal/I18n/descexprtypestring", "string")
                                : Translate("internal/I18n/descexprtypenumeric", "numeric");
        }

        internal static string TrlTableColOrRow(bool isCol)
        {
            return isCol ? Translate("internal/I18n/desctablelineopcol", "column")
                         : Translate("internal/I18n/desctablelineoprow", "row");
        }

        internal static string TrlCacheFile(bool cache)
        {
            return cache ? Translate("internal/I18n/desccachefile", ", caching the file on disk") : "";
        }

        internal static string TrlSortAscOrDesc(bool isAsc)
        {
            return isAsc ? Translate("internal/I18n/descsortasc", "ascending")
                         : Translate("internal/I18n/descsortdesc", "descending");
        }

        internal static string TrlAsync(bool isAsync)
        {
            return isAsync ? Translate("internal/I18n/descasynctrue", "")
                           : Translate("internal/I18n/descasyncfalse", "[Sync] ");
        }

        internal static string TranslateEnable(bool enable)
        {
            return enable ? Translate("internal/I18n/descenabletrue", "enable")
                          : Translate("internal/I18n/descenablefalse", "disable");
        }

        public static string TrlTriggerDescTime(double ms)
        {
            ms = Math.Round(ms);
            double s = ms / 1000;
            if (Math.Abs(s) >= 300 || s == Math.Round(s)) // > 5 min   or is integer
            {
                return I18n.Translate("internal/I18n/desctimesec", "{0} s", (int)s);
            }
            else if (Math.Abs(s) >= 10 || s == Math.Round(s, 1)) // > 10 s   or 1-digit decimal
            {
                return I18n.Translate("internal/I18n/desctimesec", "{0} s", s.ToString("F1", CultureInfo.InvariantCulture));
            }
            else if (Math.Abs(s) >= 0.1 || s == Math.Round(s, 2)) // > 0.1 s   or 2-digit decimal
            {
                return I18n.Translate("internal/I18n/desctimesec", "{0} s", s.ToString("F2", CultureInfo.InvariantCulture));
            }
            else    // < 0.1 s
            {
                return I18n.Translate("internal/I18n/desctimems", "{0} ms", ms);
            }
        }

        public static bool IsChineseEnvironment => (RealPlugin.plug.cfg.Language ?? "").Contains("zh") || CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "zh";

    }

}
