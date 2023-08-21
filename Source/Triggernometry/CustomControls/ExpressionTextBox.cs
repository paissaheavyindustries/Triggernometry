using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Triggernometry.Variables;

namespace Triggernometry.CustomControls
{
    public partial class ExpressionTextBox : UserControl
    {

        public static List<string> terms = new List<string>()
        {
            // numeric const
            "pi", "π", "pi2", "pi05", "pi025", "pi0125", "pitorad", "piofrad", 
            "phi", "major", "minor", "ETmin2sec", "semitone", "cent",

            // numeric func: basic
            "sqrt(x)", "pow(x, y)", "root(x, y)", "exp(x)", "log(x)", "log(x, base)",
            "abs(x)", "sign(x)", "rem(x, y)", "mod(x, y)", "random(x, y)",
            "truncate(x)", "floor(x)", "ceiling(x)", "round(x)", "round(x, digits)",
            "max(...)", "min(...)", "or(...)", "and(...)", "if(cond, x, y)",

            // numeric func: trigonometric 
            "sin(x)", "cos(x)", "tan(x)", "cot(x)", "cotan(x)", "sec(x)", "csc(x)", "cosec(x)",
            "arcsin(x)", "arccos(x)", "arctan(x)", "atan2(x, y)", "arctan2(x, y)", 
            "sinh(x)", "cosh(x)", "tanh(x)",

            // numeric func: distance
            "distance(x1, y1, x2, y2)", "d(x1, y1, ..., x2, y2, ...)",
            "projd(x1, y1, θ, x2, y2)", "projh(x1, y1, θ, x2, y2)",
            "projectdistance(x1, y1, θ, x2, y2)", "projectheight(x1, y1, θ, x2, y2)",

            // numeric func: angle
            "radtodeg(rad)", "degtorad(deg)",
            "angle(x1, y1, x2, y2)", "θ(x1, y1, x2, y2)", "relangle(θ1, θ2)", "relθ(θ1, θ2)",
            "roundir(θ, ±n)", "roundir(θ, ±n, digits)", "roundvec(x, y, ±n)", "roundvec(x, y, ±n, digits)",

            // numeric string func
            "hex2dec(hex)", "hex2float(hex)", "hex2double(hex)", "X8float(hex)", "parsedmg(hex)", "len(alphanumstr)",
            "freq(note)", "freq(note, semitones)",

            // special variables
            "_incombat", "_lastencounter", "_activeencounter",
            "_duration", "_event", "_since", "_sincems", "_triggerid", "_triggername", "_zone",
            "_response", "_responsecode", "_jsonresponse[x]",
            "_timestamp", "_timestampms", "_systemtime", "_systemtimems",  
            "_screenwidth", "_screenheight", "_textaura[x]", "_imageaura[x]",
            "_x", "_y", "_w", "_width", "_h", "_height", "_opacity",
            "_ffxivparty[x]", "_party[x]", "_ffxiventity[x]", "_entity[x]", "_ffxivplayer", "_me", "_job[jobid]", "_job[XXX]",
            "_ffxivtime", "_ET", "_ETprecise", "_ffxivpartyorder", "_ffxivprocid", "_ffxivprocname", "_ffxivzoneid",
            "_env[x]", "_const[x]", "_loopiterator", "_this", "_index", "_col", "_row",
        };

        public static List<string> prefixes = new List<string>()
        {
            "numeric:", "n:", "string:", "s:", "func:", "f:",
            "var:", "pvar:", "evar:", "epvar:",
            "lvar:", "plvar:", "elvar:", "eplvar:",
            "tvar:", "ptvar:", "etvar:", "eptvar:",
            "tvarcl:", "ptvarcl:", "tvarrl:", "ptvarrl:", "tvardl:", "ptvardl:",
        };

        public static List<string> funcs = new List<string>()
        {
            "toupper", "tolower", "length",
            "dec2hex", "dec2hex2", "dec2hex4", "dec2hex8", "float2hex", "double2hex",
            "hex2dec", "hex2float", "hex2double", "parsedmg",
            "substring(index)", "substring(index, len)", "slice(slices)", "pick(index)", "pick(index, splitter)", 
            "indexof(x)", "lastindexof(x)", "i(x)", "li(x)",
            "padleft(char, len)", "padright(char, len)",
            "trim", "trim(chars ...)", "trimleft", "trimleft(chars ...)", "trimright", "trimright(chars ...)", 
            "repeat(times)", "repeat(times, joiner)", 
            "replace(oldStr)", "replace(oldStr, newStr)", "replace(oldStr, newStr, isLooped)",
            "format(x, y)", "compare(str)", "compare(str, ignorecase)", 
            "utctime(format)", "localtime(format)", "nextETms:XX:XX.xx", "nextETms:minutes"
        };

        public static List<string> lvarProps = new List<string>()
        {
            "size", "length", "indexof(str)", "i(str)", "lastindexof(str)", "li(str)",
            "sum", "sum(slices)", "count(str)", "count(str, slices)", 
            "join", "join(joiner)", "join(joiner, slices)", 
            "randjoin", "randjoin(joiner)", "randjoin(joiner, slices)",
        };

        public static List<string> tvarProps = new List<string>()
        {
            "w", "width", "h", "height",
            "hjoin", "hjoin(joiner1, joiner2, colSlices, rowSlices)",
            "vjoin", "vjoin(joiner1, joiner2, colSlices, rowSlices)",
            "hlookup(str, rowIndex)", "hlookup(str, rowIndex, colSlices)",
            "vlookup(str, rowIndex)", "vlookup(str, rowIndex, colSlices)",
            "hl(str, rowIndex)", "hl(str, rowIndex, colSlices)",
            "vl(str, rowIndex)", "vl(str, rowIndex, colSlices)",
        };

        public static List<string> textAuraProps = new List<string>()
        {
            "x", "y", "w", "h", "opacity", "text",
        };

        public static List<string> imageAuraProps = new List<string>()
        {
            "x", "y", "w", "h", "opacity"
        };

        public static List<string> ffxivProps = new List<string>()
        {
            "name", "job", "jobid", "role", "id", "ownerid", "bnpcid", "bnpcnameid", "type",
            "currenthp", "currentmp", "currentcp", "currentgp", "maxhp", "maxmp", "maxcp", "maxgp", "level",
            "x", "y", "z", "heading", "h", "distance", "iscasting", "casttime", "maxcasttime", "castid",
            "inparty", "order", "worldid", "worldname", "currentworldid", "targetid", "casttargetid", 
            "isT", "isH", "isD", "isM", "isR", "isC", "isG", "isTH", "isCG", 
            "jobCN", "jobDE", "jobEN", "jobFR", "jobJP", "jobKR", "jobCN1", "jobCN2", "jobEN3", "jobJP1"
        };

        public static List<string> jobProps = new List<string>()
        {
            "role", "isT", "isH", "isD", "isM", "isR", "isC", "isG", "isTH", "isCG",
            "jobCN", "jobDE", "jobEN", "jobFR", "jobJP", "jobKR", "jobCN1", "jobCN2", "jobEN3", "jobJP1"
        };

        public enum SupportedExpressionTypeEnum
        {
            String,
            Numeric,
            Regex
        }

        public bool ReadOnly
        {
            get
            {
                return textBox1.ReadOnly;
            }
            set
            {
                textBox1.ReadOnly = value;
            }
        }

        public string Expression
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        public override string Text
        {
            get
            {
                return Expression;
            }
            set
            {
                Expression = value;
            }
        }

        public bool AutocompleteAvailable { get; set; } = true;

        private SupportedExpressionTypeEnum _ExpressionType;
        public SupportedExpressionTypeEnum ExpressionType
        {
            get
            {
                return _ExpressionType;
            }
            set
            {
                if (value != _ExpressionType)
                {
                    _ExpressionType = value;
                    ResetTooltip();
                }
            }
        }

        private void ResetTooltip()
        {
            switch (ExpressionType)
            {
                case SupportedExpressionTypeEnum.Numeric:
                    string temp = I18n.Translate("internal/ExpressionTextBox/numeric1", "This field supports numeric expressions; references to named regular expression groups will be expanded, after which the result will be evaluated as a mathematic expression.");
                    temp += Environment.NewLine;
                    temp += I18n.Translate("internal/ExpressionTextBox/numeric2", "The color of the field will also change depending on whether the numeric expression appears to be valid (green) or not (red).");
                    toolTip1.SetToolTip(panel1, temp);
                    break;
                case SupportedExpressionTypeEnum.String:
                    toolTip1.SetToolTip(panel1, I18n.Translate("internal/ExpressionTextBox/string", "This field supports string expressions; references to named regular expression groups will be expanded."));
                    break;
                case SupportedExpressionTypeEnum.Regex:
                    toolTip1.SetToolTip(panel1, I18n.Translate("internal/RegexTextBox", "This field supports regular expressions; the color of the field will change depending on whether the regular expression is valid (green) or not (red)."));
                    break;
            }
            UpdateBackground();
        }

        private Context ctx;

        public delegate void EnterDelegate();
        public event EnterDelegate OnEnterKeyHit;
        public IButtonControl AcceptButton;
        public IButtonControl CancelButton;

        public static readonly Regex rexPrefix = new Regex(@"\$\{(?<prefix>[^}:]*)$");
        public static readonly Regex rexFunc = new Regex(@"\$\{f(?:unc)?:(?<funcid>[^(:]*)$");
        public static readonly Regex rexVarName = new Regex(@"\$\{(?<prefix>e?p?[tl]?var|p?tvar(?:[cdr]l)?):(?<name>[^$.[{]*)$");
        public static readonly Regex rexColHeader = new Regex(@"\$\{(?<persist>p?)tvar[cd]l:(?<name>[^$.[{]+)\[(?<key>[^$.[\]{]*)$");
        public static readonly Regex rexRowHeader = new Regex(@"\$\{(?<persist>p?)tvar(?:rl:(?<name1>[^$.[{]+)|dl:(?<name2>[^$.[{]+)\[.*\])\[(?<key>[^$.[\]{]*)$");
        public static readonly Regex rexConst = new Regex(@"\$\{_const\[(?<key>[^$.[\]{]*)$");
        public static readonly Regex rexListProp = new Regex(@"^p?lvar:.*\.(?<prop>[^.(]*)$");
        public static readonly Regex rexTableProp = new Regex(@"^p?tvar:.*\.(?<prop>[^.(]*)$");
        public static readonly Regex rexMeProp = new Regex(@"^_me\.(?<prop>.*)$");
        public static readonly Regex rexStructProp = new Regex(@"_(?<struct>[^[]+)\[.*\]\.(?<prop>[^.]*)$");
        public static readonly Regex rexWord = new Regex(@"(?<![[$])\b[\p{L}\w_]+$");

        private string CurrentMatch;

        public Forms.AutoCompleteForm acf = null;

        public ExpressionTextBox()
        {
            InitializeComponent();
            ctx = new Context();
            ctx.testmode = true;
            ResetTooltip();
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox1.KeyPress += TextBox1_KeyPress;
            textBox1.KeyDown += TextBox1_KeyDown;
            Disposed += ExpressionTextBox_Disposed;
            Leave += ExpressionTextBox_Leave;
            LostFocus += ExpressionTextBox_LostFocus;
        }

        private void ExpressionTextBox_LostFocus(object sender, EventArgs e)
        {
            HideAutocomplete();
        }

        private void ExpressionTextBox_Leave(object sender, EventArgs e)
        {
            HideAutocomplete();
        }

        private void ExpressionTextBox_Disposed(object sender, EventArgs e)
        {
            HideAutocomplete();
        }

        private void RefreshAutocomplete(IEnumerable<string> strs)
        {
            lock (this)
            {
                if (acf == null)
                {
                    return;
                }
                acf.BuildList(strs);
            }
        }

        private void ShowAutocomplete(IEnumerable<string> strs)
        {
            if (AutocompleteAvailable == false)
            {
                return;
            }
            lock (this)
            {
                if (acf != null)
                {
                    RefreshAutocomplete(strs);
                    return;
                }
                acf = new Forms.AutoCompleteForm();
                Point pt = Parent.PointToScreen(Location);
                acf.Left = pt.X + panel1.Width;
                acf.Top = pt.Y + Height;
                acf.GotFocus += Acf_GotFocus;
                acf.listBox1.MouseDown += ListBox1_MouseDown;
                acf.listBox1.DoubleClick += ListBox1_DoubleClick;
                RefreshAutocomplete(strs);
                acf.Show(this);
                AcceptButton = ParentForm.AcceptButton;
                CancelButton = ParentForm.CancelButton;
                ParentForm.AcceptButton = null;
                ParentForm.CancelButton = null;
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            if (AutocompleteActive() == true)
            {
                string ac = GetChosenAutocomplete().Substring(CurrentMatch.Length);
                textBox1.Paste(ac);
            }
        }

        private void ListBox1_MouseDown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void Acf_GotFocus(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void HideAutocomplete()
        {            
            lock (this)
            {
                if (acf != null)
                {
                    acf.Dispose();
                    acf = null;
                    if (ParentForm != null)
                    {
                        ParentForm.AcceptButton = AcceptButton;
                        ParentForm.CancelButton = CancelButton;
                    }
                }
            }
        }

        private bool AutocompleteActive()
        {
            lock (this)
            {
                return (acf != null);
            }
        }

        private string GetChosenAutocomplete()
        {
            lock (this)
            {
                string temp = acf.GetChosenAutocomplete();
                HideAutocomplete();
                return temp;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.PageDown || e.KeyData == Keys.PageUp)
            {
                if (AutocompleteActive() == true)
                {
                    if (e.KeyData == Keys.Up)
                    {
                        acf.PreviousAutocompleteItem();
                    }
                    if (e.KeyData == Keys.Down)
                    {
                        acf.NextAutocompleteItem();
                    }
                    if (e.KeyData == Keys.PageUp)
                    {
                        acf.PreviousAutocompletePage();
                    }
                    if (e.KeyData == Keys.PageDown)
                    {
                        acf.NextAutocompletePage();
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }            
        }

        private IEnumerable<string> GetAutocompleteSuggestions(IEnumerable<string> src, string str)
        {
            return (from ix in src 
                        where ix.StartsWith(str, StringComparison.OrdinalIgnoreCase) && string.Compare(str, ix, true) != 0 
                        select ix)
                            .OrderBy(a => a);
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (AutocompleteActive() == true)
                {
                    string ac = GetChosenAutocomplete().Substring(CurrentMatch.Length);
                    textBox1.Paste(ac);
                }
                else if (OnEnterKeyHit != null)
                {
                    OnEnterKeyHit();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                HideAutocomplete();
            }
            else if (char.IsControl(e.KeyChar) == true)
            {
                HideAutocomplete();
            }
        }

        private void UpdateBackground()
        {
            if (ExpressionType == SupportedExpressionTypeEnum.Numeric)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.BackColor = SystemColors.Window;
                    return;
                }
                try
                {
                    ctx.EvaluateNumericExpression(null, null, textBox1.Text);
                    textBox1.BackColor = Color.FromArgb(200, 255, 200);
                }
                catch (Exception)
                {
                    textBox1.BackColor = Color.FromArgb(255, 200, 200);
                }
            }
            else if (ExpressionType == SupportedExpressionTypeEnum.String)
            {
                if (textBox1.BackColor != SystemColors.Window)
                {
                    textBox1.BackColor = SystemColors.Window;
                }
            }
            else if (ExpressionType == SupportedExpressionTypeEnum.Regex)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.BackColor = SystemColors.Window;
                    return;
                }
                try
                {
                    Regex rex = new Regex(textBox1.Text);
                    textBox1.BackColor = Color.FromArgb(200, 255, 200);
                }
                catch (Exception)
                {
                    textBox1.BackColor = Color.FromArgb(255, 200, 200);
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateBackground();
            if (ExpressionType != SupportedExpressionTypeEnum.Regex)
            {
                string temp = textBox1.Text.Substring(0, textBox1.SelectionStart);
                IEnumerable<string> matchedStrings = null;

                // match prefixes (string after "${"): "func:" "numeric:" ...
                Match m = rexPrefix.Match(temp);
                if (m.Success)
                {
                    matchedStrings = GetAutocompleteSuggestions(prefixes, m.Groups["prefix"].Value);
                    if (matchedStrings.Count() > 0)
                    {
                        CurrentMatch = m.Groups["prefix"].Value;
                        ShowAutocomplete(matchedStrings);
                        return;
                    }
                }
                
                // match functions: "func:xxx" "f:xxx"
                m = rexFunc.Match(temp);
                if (m.Success)
                {
                    matchedStrings = GetAutocompleteSuggestions(funcs, m.Groups["funcid"].Value);
                    if (matchedStrings.Count() > 0)
                    {
                        CurrentMatch = m.Groups["funcid"].Value;
                        ShowAutocomplete(matchedStrings);
                    }
                    else
                    {
                        HideAutocomplete();
                    }
                    return;
                }
                
                /*
                // match variable names:
                m = rexVarName.Match(temp);
                if (m.Success)
                {
                    string prefix = m.Groups["prefix"].Value;

                    VariableStore vs = prefix.Contains("p") ? ctx.plug.cfg.PersistentVariables : ctx.plug.sessionvars;
                    List<string> varNames = prefix.Contains("tvar") ? vs.Table.Keys.ToList() :
                                            prefix.Contains("lvar") ? vs.List.Keys.ToList() :
                                                                      vs.Scalar.Keys.ToList() ; 
                    
                    matchedStrings = GetAutocompleteSuggestions(varNames, m.Groups["name"].Value);
                    if (matchedStrings.Count() > 0)
                    {
                        CurrentMatch = m.Groups["name"].Value;
                        ShowAutocomplete(matchedStrings);
                    }
                    else
                    {
                        HideAutocomplete();
                    }
                    return;
                }

                // match table row headers: "${(p)tvarrl:xxx[xxx" or "${(p)tvardl[xxx][xxx":
                m = rexRowHeader.Match(temp);
                if (m.Success)
                {
                    VariableStore vs = m.Groups["persist"].Value == "p" ? ctx.plug.cfg.PersistentVariables : ctx.plug.sessionvars;
                    VariableTable vt;
                    string varName = m.Groups["name1"].Value + m.Groups["name2"].Value;
                    if (vs.Table.ContainsKey(varName) && vs.Table[varName].Height > 0)
                    {
                        vt = vs.Table[varName];
                    }
                    else
                    {
                        HideAutocomplete();
                        return;
                    }
                    List<string> headers = new List<string>();
                    for (int index = 1; index <= vt.Height; index++)
                    {
                        headers.Add(vt.Peek(1, index).ToString());
                    }

                    matchedStrings = GetAutocompleteSuggestions(headers, m.Groups["key"].Value);
                    if (matchedStrings.Count() > 0)
                    {
                        CurrentMatch = m.Groups["key"].Value;
                        ShowAutocomplete(matchedStrings);
                    }
                    else
                    {
                        HideAutocomplete();
                    }
                    return;
                }

                // match table col headers "${(p)tvarcl:[xxx" or "${(p)tvardl:[xxx":
                m = rexColHeader.Match(temp);
                if (m.Success)
                {
                    VariableStore vs = m.Groups["persist"].Value == "p" ? ctx.plug.cfg.PersistentVariables : ctx.plug.sessionvars;
                    VariableTable vt;
                    string varName = m.Groups["name"].Value;
                    if (vs.Table.ContainsKey(varName) && vs.Table[varName].Width > 0)
                    {
                        vt = vs.Table[varName];
                    }
                    else
                    {
                        HideAutocomplete();
                        return;
                    }
                    List<string> headers = new List<string>();
                    for (int index = 1; index <= vt.Width; index++)
                    {
                        headers.Add(vt.Peek(index, 1).ToString());
                    }

                    matchedStrings = GetAutocompleteSuggestions(headers, m.Groups["key"].Value);
                    if (matchedStrings.Count() > 0)
                    {
                        CurrentMatch = m.Groups["key"].Value;
                        ShowAutocomplete(matchedStrings);
                    }
                    else
                    {
                        HideAutocomplete();
                    }
                    return;
                }
                
                // match "_const["
                m = rexConst.Match(temp);
                if (m.Success)
                {
                    List<string> constKeys = ctx.plug.cfg.Constants.Keys.ToList();
                    matchedStrings = GetAutocompleteSuggestions(constKeys, m.Groups["key"].Value);
                    if (matchedStrings.Count() > 0)
                    {
                        CurrentMatch = m.Groups["key"].Value;
                        ShowAutocomplete(matchedStrings);
                    }
                    else
                    {
                        HideAutocomplete();
                    }
                    return;
                }
                */

                // search for the previous unclosed '{'
                int leftBracketCount = 0;
                string currentExpr = null;
                for (int index = temp.Length - 1; index >= 0; index--)
                {   // search '{' '}' from the end of the string
                    if (temp[index] == '}')
                    {
                        leftBracketCount--;
                    }
                    else if (temp[index] == '{')
                    {
                        leftBracketCount++;
                    }
                    if (leftBracketCount == 1)
                    {   // get the string after the unclosed '{'
                        currentExpr = temp.Substring(index + 1);
                        break;
                    }
                }

                if (currentExpr == null)
                {   // parse later
                    currentExpr = temp;
                }
                else
                {   
                    if (currentExpr.Contains('}'))
                    {   // aaa{bbb{ccc}ddd{eee}fff}ggg.hhh => aaaggg.hhh
                        currentExpr = currentExpr.Substring(0, currentExpr.IndexOf('{'))
                                    + currentExpr.Substring(currentExpr.LastIndexOf('}') + 1);
                    }

                    // match (p)lvar:name.prop
                    m = rexListProp.Match(currentExpr);
                    if (m.Success)
                    {
                        matchedStrings = GetAutocompleteSuggestions(lvarProps, m.Groups["prop"].Value);
                        if (matchedStrings != null && matchedStrings.Count() > 0)
                        {
                            CurrentMatch = m.Groups["prop"].Value;
                            ShowAutocomplete(matchedStrings);
                        }
                        else
                        {
                            HideAutocomplete();
                        }
                        return;
                    }

                    // match (p)tvar:name.prop
                    m = rexTableProp.Match(currentExpr);
                    if (m.Success)
                    {
                        matchedStrings = GetAutocompleteSuggestions(tvarProps, m.Groups["prop"].Value);
                        if (matchedStrings != null && matchedStrings.Count() > 0)
                        {
                            CurrentMatch = m.Groups["prop"].Value;
                            ShowAutocomplete(matchedStrings);
                        }
                        else
                        {
                            HideAutocomplete();
                        }
                        return;
                    }


                    // match _me.prop
                    m = rexMeProp.Match(currentExpr);
                    if (m.Success)
                    {
                        matchedStrings = GetAutocompleteSuggestions(ffxivProps, m.Groups["prop"].Value);
                        if (matchedStrings != null && matchedStrings.Count() > 0)
                        {
                            CurrentMatch = m.Groups["prop"].Value;
                            ShowAutocomplete(matchedStrings);
                        }
                        else
                        {
                            HideAutocomplete();
                        }
                        return;
                    }

                    // match _xxx[xxx?].prop
                    m = rexStructProp.Match(currentExpr);
                    if (m.Success)
                    {
                        switch (m.Groups["struct"].Value)
                        {
                            case "ffxivparty":
                            case "ffxiventity":
                            case "party":
                            case "entity":
                                matchedStrings = GetAutocompleteSuggestions(ffxivProps, m.Groups["prop"].Value);
                                break;
                            case "textaura":
                                matchedStrings = GetAutocompleteSuggestions(textAuraProps, m.Groups["prop"].Value);
                                break;
                            case "imageaura":
                                matchedStrings = GetAutocompleteSuggestions(imageAuraProps, m.Groups["prop"].Value);
                                break;
                            case "job":
                                matchedStrings = GetAutocompleteSuggestions(jobProps, m.Groups["prop"].Value);
                                break;
                        }
                        if (matchedStrings != null && matchedStrings.Count() > 0)
                        {
                            CurrentMatch = m.Groups["prop"].Value;
                            ShowAutocomplete(matchedStrings);
                        }
                        else
                        {
                            HideAutocomplete();
                        }
                        return;
                    }
                }
                
                // all matches failed or temp contains no unclosed '{'
                m = rexWord.Match(currentExpr);
                if (m.Success == true)
                {
                    IEnumerable<string> strs = GetAutocompleteSuggestions(terms, m.Value);
                    if (strs.Count() > 0)
                    {
                        CurrentMatch = m.Value;
                        ShowAutocomplete(strs);
                    }
                    else
                    {
                        HideAutocomplete();
                    }
                    return;
                }
                
                HideAutocomplete();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ToggleExpand();
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            ToggleExpand();
        }

        private void ToggleExpand()
        {
            if (textBox1.Multiline == true)
            {
                textBox1.Multiline = false;
                textBox1.MinimumSize = new Size(textBox1.MinimumSize.Width, 0);
                textBox1.ScrollBars = ScrollBars.None;
                Image tmp = panel1.BackgroundImage;
                panel1.BackgroundImage = panel2.BackgroundImage;
                panel2.BackgroundImage = tmp;
            }
            else
            {
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(textBox1.MinimumSize.Width, 100);
                textBox1.ScrollBars = ScrollBars.Both;
                Image tmp = panel1.BackgroundImage;
                panel1.BackgroundImage = panel2.BackgroundImage;
                panel2.BackgroundImage = tmp;
            }
        }

    }

}
