using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Triggernometry.Variables;
using System.Runtime.InteropServices;
using System.Globalization;
using System.ComponentModel;

namespace Triggernometry.CustomControls
{
    public partial class ExpressionTextBox : UserControl
    {

        #region Autofill Text

        public static List<string> math = new List<string>()
        {
            // numeric const
            "pi", "π", "pi2", "pi05", "pi025", "pi0125", "pitorad", "piofrad",
            "phi", "major", "minor", "ETmin2sec", "semitone", "cent",

            // numeric func: basic
            "sqrt(x)", "pow(x, y)", "root(x, y)", "exp(x)", "log(x, base=e)",
            "abs(x)", "sign(x)", "rem(x, y)", "mod(x, y)", "random(start, end)",
            "truncate(x)", "floor(x)", "ceiling(x)", "round(x, digits=0)",
            "max(...)", "min(...)", "or(...)", "and(...)", "if(condition, trueVal, falseVal)",

            // numeric func: trigonometric 
            "sin(x)", "cos(x)", "tan(x)", "cot(x)", "cotan(x)", "sec(x)", "csc(x)", "cosec(x)",
            "arcsin(x)", "arccos(x)", "arctan(x)", "atan2(x, y)", "arctan2(x, y)",
            "sinh(x)", "cosh(x)", "tanh(x)",

            // numeric func: distance
            "distance(x0, y0, x1, y1)", "distance(x0, y0, z0..., x1, y1, z1...)",
            "d(x0, y0, x1, y1)", "d(x0, y0, z0..., x1, y1, z1...)",
            "l1d(x0, y0, z0..., x1, y1, z1...)", "l∞d(x0, y0, z0..., x1, y1, z1...)",
            "manhattandistance(x0, y0, z0..., x1, y1, z1...)", "chebyshevdistance(x0, y0, z0..., x1, y1, z1...)",
            "projd(srcX, srcY, θ, tgtX, tgtY)", "projh(srcX, srcY, θ, tgtX, tgtY)", "ispointinray(srcX, srcY, θ, width, tgtX, tgtY)",
            "projectdistance(srcX, srcY, θ, tgtX, tgtY)", "projectheight(srcX, srcY, θ, tgtX, tgtY)",

            // numeric func: angle
            "radtodeg(rad)", "degtorad(deg)",
            "angle(srcX, srcY, tgtX, tgtY)", "θ(srcX, srcY, tgtX, tgtY)", "relangle(srcθ, tgtθ)", "relθ(srcθ, tgtθ)",
            "roundir(θ, ±n, digits=0)", "roundvec(dx, dy, ±n, digits=0)", "dir2rad(direction, ±n)",
            "isanglebetween(θ, minθ, maxθ)", "isθbetween(θ, minθ, maxθ)",

            // numeric string func
            "hex2dec(hex)", "hex2float(hex)", "hex2double(hex)", "X8float(hex)", "parsedmg(hex)", "len(alphanumstr)",
            "freq(note, semitones=0)", "nextETms(XX:XX)", "nextETms(ETmin)",
        };

        public static List<string> prefixes = new List<string>() // right after "${"
        {
            "numeric:", "n:", "string:", "s:", "func:", "f:", "if:",
            "var:", "pvar:", "evar:", "epvar:", "v:", "pv:", "ev:", "epv:",
            "lvar:", "plvar:", "elvar:", "eplvar:", "l:", "pl:", "el:", "epl:",
            "tvar:", "ptvar:", "etvar:", "eptvar:", "t:", "pt:", "et:", "ept:",
            "dvar:", "pdvar:", "edvar:", "epdvar:", "d:", "pd:", "ed:", "epd:",
            "tvarcl:", "ptvarcl:", "tvarrl:", "ptvarrl:", "tvardl:", "ptvardl:",
            "?l:", "?lvar:", "?t:", "?tvar:", "?d:", "?dvar:",
            "etext:", "eimage:", "ecallback:", "estorage:",
            "env:",

            // special variables
            "_incombat", "_lastencounter", "_activeencounter", "_configpath", "_pluginpath", "_pluginversion",
            "_duration", "_event", "_since", "_sincems", "_triggerid", "_triggername", "_triggerpath", "_zone",
            "_response", "_responsecode", "_jsonresponse[x]",
            "_timestamp", "_timestampms", "_systemtime", "_systemtimems", "_clipboard",
            "_screenwidth", "_screenheight", "_textaura[x]", "_imageaura[x]",
            "_x", "_y", "_w", "_width", "_h", "_height", "_opacity",
            "_ffxivparty[x]", "_party[x]", "_ffxiventity[x]", "_entity[x]", "_ffxivplayer", "_me", "_me.id",
            "_job[jobid/jobName/jobAbbrev]", "_tm2id[markType]", "_targetmarker2id[markType]", "_wm[markType]", "_waymark[markType]",
            "_ffxivtime", "_ET", "_ETprecise", "_ffxivpartyorder", "_ffxivprocid", "_ffxivprocname", "_ffxivzoneid",
            "_ffxivversion", "_ffxivincombat", "_ffxivisglobal",
            "_env[x]", "_const[x]", "_config[x]", "_storage[x]", "_actionhistory[i/previous]",
            "_this", "_idx", "_col", "_row", "_col[i]", "_row[i]", "_colrl[...]", "_rowcl[...]", "_key", "_val",
            "_loopiterator", "_i",
        };

        public static List<string> funcs = new List<string>()
        {
            "toupper", "tolower", "tofullwidth", "tohalfwidth", "toblackchar(combineDigits=false)", "towhitechar", "length",
            "dec2hex", "dec2hex2", "dec2hex4", "dec2hex8", "float2hex", "double2hex",
            "hex2dec", "hex2float", "hex2double", "parsedmg",
            "substring(index)", "substring(index, len)", "slice(slices)", "pick(index, separator=',')",
            "indexof(str)", "lastindexof(str)", "i(str)", "indicesof(str, joiner=',', slices='::')",
            "padleft(char, len)", "padright(char, len)", "chr(separator=',')", "ord(joiner=',')",
            "trim()", "trim(char, char, ...)", "trimleft()", "trimleft(char, char, ...)", "trimright()", "trimright(char, char, ...)",
            "repeat(times, joiner=',')", "replace(oldStr, newStr='', isLooped=false)",
            "format(type, format)", "compare(str, ignorecase=true)", "versioncompare(tgtVersion)",
            "contain(str)", "ifcontain(str, t, f)", "equal(str)", "ifequal(str, t, f)",
            "startwith(str)", "ifstartwith(str, t, f)", "endwith(str)", "ifendwith(str, t, f)",
            "match(str)", "ifmatch(str, t, f)", "capture(str, groupName)", "capture(str, groupIndex)",
            "utctime(format)", "localtime(format)"
        };

        public static List<string> lvarProps = new List<string>()
        {
            "size", "length", "indexof(str)", "i(str)", "lastindexof(str)",
            "indicesof(str, joiner=',', slices='::')",
            "sum(slices='::')", "count(str, slices='::')",
            "join(joiner=',', slices='::')",
            "randjoin(joiner=',', slices='::')",
            "contain(str, slices='::')", "ifcontain(str, t, f)",
            "max(type='n', slices='::')", "min(type='n', slices='::')",
        };

        public static List<string> tvarProps = new List<string>()
        {
            "w", "width", "h", "height",
            "hjoin()", "hjoin(joiner1=',', joiner2='⏎', colSlices='::', rowSlices='::')",
            "vjoin()", "vjoin(joiner1=',', joiner2='⏎', colSlices='::', rowSlices='::')",
            "hlookup(str, rowIndex, colSlices='::')",
            "vlookup(str, colIndex, rowSlices='::')",
            "hl(str, rowIndex, colSlices='::')",
            "vl(str, colIndex, rowSlices='::')",
            "count(str, colSlices='::', rowSlices='::')",
            "sum(colSlices='::', rowSlices='::')",
            "max()", "max(type='n', colSlices='::', rowSlices='::')",
            "min()", "min(type='n', colSlices='::', rowSlices='::')",
            "contain(str, colSlices='::', rowSlices='::')", "ifcontain(str, t, f)",
        };

        public static List<string> dvarProps = new List<string>()
        {
            "size", "length", "ekey(key)", "evalue(value)", "ifekey(key, t, f)", "ifevalue(value, t, f)",
            "keyof(value)", "keysof(value, joiner=',')",
            "joinall(kvjoiner='=', pairjoiner=',')",
            "joinkeys(joiner=',')", "joinvalues(joiner=',')",
            "sumkeys", "sum", "count(value)",
            "max(type='n')", "min(type='n')", "maxkey(type='n')", "minkey(type='n')",
        };

        public static List<string> textAuraProps = new List<string>()
        {
            "x", "y", "w", "h", "opacity", "text",
        };

        public static List<string> imageAuraProps = new List<string>()
        {
            "x", "y", "w", "h", "opacity"
        };

        // Name, X, Job, Role, etc.
        public static List<string> XivEntityProps = new List<string> { 
            "HasStatus(statusId)", "StatusTimer(statusId)", "StatusStack(statusId)",
        }.Concat(FFXIV.Entity.LegalEntityPropNames).Concat(FFXIV.Job.LegalJobPropNames).ToList();
        
        // Job, Role, etc.
        public static List<string> XivJobProps = FFXIV.Job.LegalJobPropNames.ToList();

        public static List<string> configurations = new List<string>()
        {
            "DebugLevel", "UseACTForSound", "UseACTForTTS", "FfxivLogNetwork", "UseOsClipboard", "DeveloperMode", "Autosave", "Language", "UnsafeUsage",
            "Microsoft.CodeAnalysis", "Microsoft.Win32", "System.CodeDom.Compiler", "System.Diagnostics", "Triggernometry.Utilities",
            "System.IO", "System.Net", "System.Reflection", "System.Runtime", "System.Security", "System.Web",
        };

        #endregion

        public enum SupportedExpressionTypeEnum
        {
            String, Numeric, Regex, Color
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

        private bool _IsPersistent = false;
        public bool IsPersistent
        {
            get { return _IsPersistent; }
            set
            {
                _IsPersistent = value;
                UpdateBackground();
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

        internal Context ctx;
        private Context fakectx;

        // record all the capture groups and combine with prefixes
        // when entering a trigger or editing the trigger regex

        private static string _currentTriggerRegexStr = "";
        internal static string CurrentTriggerRegexStr
        {
            get => _currentTriggerRegexStr;
            set
            {   
                _currentTriggerRegexStr = value;
                _currentRegexGroupsAndPrefixes = null;
            }
        }

        private static HashSet<string> _currentRegexGroupsAndPrefixes = null;
        private static HashSet<string> CurrentRegexGroupsAndPrefixes
        {
            get // lazy loading
            {
                if (_currentRegexGroupsAndPrefixes == null)
                {
                    List<string> groups;
                    try
                    {
                        Regex regex = new Regex(_currentTriggerRegexStr);
                        groups = regex.GetGroupNames().ToList();
                        groups.AddRange(prefixes);
                    }
                    catch
                    {
                        _currentTriggerRegexStr = "";
                        groups = prefixes;
                    }
                    _currentRegexGroupsAndPrefixes = new HashSet<string>(groups);
                }
                return _currentRegexGroupsAndPrefixes;
            }
        }

        private string suffix = "";  // to do

        public delegate void EnterDelegate();
        public event EnterDelegate OnEnterKeyHit;
        public IButtonControl AcceptButton;
        public IButtonControl CancelButton;

        public static readonly Regex rexPrefix
            = new Regex(@"[$¤]\{(?<prefix>[^[$}:.]*)$", RegexOptions.Compiled);
        public static readonly Regex rexFunc
            = new Regex(@"[$¤]\{f(?:unc)?:(?<funcid>[^(:]*)$", RegexOptions.Compiled);
        public static readonly Regex rexVarName
            = new Regex(@"[$¤]\{(?<e>e?)(?<persist>p?)(?<type>[vltd]|text|image|callback|storage)(?:v?ar)?(?:[cdr]l)?:(?<name>[^$¤.[]*)$", RegexOptions.Compiled);
        public static readonly Regex rexColHeader
            = new Regex(@"[$¤]\{(?<persist>p?)t(?:var)?[cd]l:(?<name>[^$¤[]+)\[(?<key>[^$¤\]]*)$", RegexOptions.Compiled);
        public static readonly Regex rexRowHeader
            = new Regex(@"[$¤]\{(?<persist>p?)t(?:var)?(?:rl:(?<name1>[^$¤[]+)|dl:(?<name2>[^$¤[]+)\[.*\])\[(?<key>[^$¤\]]*)$", RegexOptions.Compiled);
        public static readonly Regex rexDictKey
            = new Regex(@"[$¤]\{(?<persist>p?)d(?:var)?:(?<name>[^$¤[]+)\[(?<key>[^$¤\]]*)$", RegexOptions.Compiled);
        public static readonly Regex rexStructKey
            = new Regex(@"[$¤]\{_(?<struct>const|textaura|imageaura|config|storage)\[(?<key>[^$¤\]]*)$", RegexOptions.Compiled);
        // The regexes "rex...Prop" and "rexMath" are matched after looking for the previous unclosed '{'
        public static readonly Regex rexVarProp
            = new Regex(@"^[p?]?(?<type>[ltd])(?:var)?:.*\.(?<prop>[^.(]*)$", RegexOptions.Compiled);
        public static readonly Regex rexMeProp
            = new Regex(@"^_me\.(?<prop>.*)$", RegexOptions.Compiled);
        public static readonly Regex rexStructProp
            = new Regex(@"_(?<struct>[^[]+)\[.*\]\.(?<prop>[^.]*)$", RegexOptions.Compiled);
        public static readonly Regex rexMath
            = new Regex(@"(?<![[$¤.])\b[\p{L}\w]+$", RegexOptions.Compiled);

        private static readonly Regex rexDynamicNames // capture the names in the expressions and store into lists for autofill
            = new Regex(@"[$¤]\{e?(?<persist>p?)(?<type>[vltd]|text|image)(?:v?ar)?(?:[cdr]l)?:(?<name>[^$¤.[{}\n]*)[^\${}]*\}", RegexOptions.Compiled);

        private string CurrentMatch;
        private Timer acfDebounceTimer = new Timer();

        public Forms.AutoCompleteForm acf = null;

        // unhide TextChanged on base class
        private EventHandler _TextChanged;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new event EventHandler TextChanged
        {
            add
            {
                _TextChanged += value;
            }
            remove
            {
                _TextChanged -= value;
            }
        }

        public ExpressionTextBox()
        {
            InitializeComponent();
            ctx = new Context();
            fakectx = new Context();
            fakectx.testByPlaceholder = true;
            ResetTooltip();            
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox1.KeyPress += TextBox1_KeyPress;
            textBox1.KeyDown += TextBox1_KeyDown;
            textBox1.MaxLength = 10000000; // for scripts
            textBox1.GotFocus += ReplaceIncompleteLineBreaksInClipboard;
            Disposed += ExpressionTextBox_Disposed;
            Leave += ExpressionTextBox_Leave;
            LostFocus += ExpressionTextBox_LostFocus;
            acfDebounceTimer.Interval = 100; // debounce timer for autocomplete
            acfDebounceTimer.Tick += (sender, e) => ProcessAutocomplete();
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

        [DllImport("user32.dll")]
        static extern bool GetCaretPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        private void ShowAutocomplete(IEnumerable<string> strs)
        {
            if (AutocompleteAvailable == false)
            {
                return;
            }
            lock (this)
            {
                bool refresh = acf != null;
                if (!refresh)
                {
                    acf = new Forms.AutoCompleteForm();
                }

                // show acf beneath the start of the matched string
                GetCaretPos(out POINT cursorPoint);
                Size size = TextRenderer.MeasureText(CurrentMatch, textBox1.Font);
                Point parent = Parent.PointToScreen(Location);
                double lineHeight = textBox1.Font.Height * 4 / 3;
                acf.Left = parent.X + panel1.Width + cursorPoint.X - size.Width + 4;
                acf.Top = parent.Y + cursorPoint.Y + (int)lineHeight;

                if (refresh)
                {
                    RefreshAutocomplete(strs);
                    return;
                }

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
                int pIndex = ac.IndexOf('(');
                int bIndex = ac.IndexOf("[");

                if (pIndex >= 0)
                {
                    textBox1.Paste(ac.Substring(0, pIndex) + "()");
                    textBox1.SelectionStart--;
                }
                else if (bIndex >= 0)
                {
                    textBox1.Paste(ac.Substring(0, bIndex) + "]");
                    textBox1.SelectionStart--;
                    textBox1.Paste("[");
                    // trigger the TextChanged event with the correct cursor position
                }
                else
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
            acfDebounceTimer.Stop();
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
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                HideAutocomplete();
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
                e.Handled = true;
                if (AutocompleteActive() == true)
                {
                    string ac = GetChosenAutocomplete();
                    int cursorPos = textBox1.SelectionStart;

                    // remove the existing part to fix the capitalization typos
                    if (CurrentMatch.Length > 0 && cursorPos >= CurrentMatch.Length)
                    {
                        textBox1.Text = textBox1.Text.Remove(cursorPos - CurrentMatch.Length, CurrentMatch.Length);
                        textBox1.SelectionStart = cursorPos - CurrentMatch.Length;
                    }

                    /* To do: 
                     * close () [] {} automatically and 
                     * moves the cursor to the correct position
                    string currentSuffix = suffix;
                    if (currentSuffix == "matchPrefix")
                    {   // variable prefix or regex group (could not decide previously)
                        currentSuffix = (ac.EndsWith(":")) ? "" : "}";
                    }
                    // remove the existing suffix (e.g. "${_const[xxx]}" / "${_const[xxx]" => "${_const[xxx")
                    int cursorPos = textBox1.SelectionStart;
                    string strAfterCursor = textBox1.Text.Substring(cursorPos);
                    if (strAfterCursor.Length >= 2 && strAfterCursor.Substring(0, 2) == currentSuffix)
                    {
                        textBox1.Text = textBox1.Text.Remove(cursorPos, 2);
                        textBox1.SelectionStart = cursorPos;
                    }
                    else if (strAfterCursor.Length >= 1 && currentSuffix.Length >= 1
                        && strAfterCursor.Substring(0, 1) == currentSuffix.Substring(0, 1))
                    {
                        textBox1.Text = textBox1.Text.Remove(cursorPos, 1);
                        textBox1.SelectionStart = cursorPos;
                    }

                    ac += currentSuffix;
                    textBox1.Paste(ac);
                    */

                    // when the autofilled string contains '(' or '[', e.g. method(arg1, arg2)
                    // remove the parameters, and trigger the TextChanged event with the correct cursor position
                    int pIndex = ac.IndexOf('(');
                    int bIndex = ac.IndexOf("[");
                    if (pIndex >= 0)
                    {
                        textBox1.Paste(ac.Substring(0, pIndex) + ")");
                        textBox1.SelectionStart--;
                        textBox1.Paste("(");
                    }
                    else if (bIndex >= 0)
                    {
                        textBox1.Paste(ac.Substring(0, bIndex) + "]");
                        textBox1.SelectionStart--;
                        textBox1.Paste("[");
                    }
                    else
                        textBox1.Paste(ac);
                }
                else if (OnEnterKeyHit != null)
                {
                    OnEnterKeyHit();
                }
                else
                {
                    if (!textBox1.Multiline) // switch to multiline mode
                    {
                        ToggleExpand();
                    }
                    else // input linebreaks (+ indent), instead of closing the form
                    {
                        int currentPosition = textBox1.SelectionStart;
                        int currentLineIndex = textBox1.GetLineFromCharIndex(currentPosition);
                        int lineStartIndex = textBox1.GetFirstCharIndexOfCurrentLine();
                        string currentLineText = textBox1.Text.Substring(lineStartIndex, currentPosition - lineStartIndex);

                        string indent = new string(currentLineText.TakeWhile(c => c == ' ' || c == '　').ToArray());
                        textBox1.Paste(Environment.NewLine + indent);
                    }
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

        private static Regex reCaptureGroups = new Regex(@"\$\{(?<capture>[\p{L}\d_]+?)\}");
        /// <summary> Check if the pure alphanumeric ${...} expressions are all capture groups or special variables (like _since) </summary>
        internal static bool CheckValidBasicExpression(string expression)
        {
            var matches = reCaptureGroups.Matches(expression);
            return matches.Cast<Match>().All(
                m => CurrentRegexGroupsAndPrefixes.Contains(m.Groups["capture"].Value)
                );
        }

        internal static Color BgRed    = Color.FromArgb(255, 225, 225);        // invalid expression
        internal static Color BgYellow = Color.FromArgb(255, 240, 210);        // capture group not found
        internal static Color BgGreen  = Color.FromArgb(225, 255, 225);        // correct
        internal static Color BgBlue   = Color.FromArgb(210, 240, 255);        // persistent variable
        
        private void UpdateBackground()
        {
            if (!Enabled && !IsPersistent)
            {
                textBox1.BackColor = SystemColors.Window;
                textBox1.ForeColor = SystemColors.WindowText;
                return;
            }
            if (ExpressionType == SupportedExpressionTypeEnum.Numeric)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.BackColor = SystemColors.Window;
                    return;
                }
                try
                {
                    fakectx.EvaluateNumericExpression(null, null, textBox1.Text);
                    textBox1.BackColor = BgGreen;
                    if (!CheckValidBasicExpression(Expression))
                    {
                        textBox1.BackColor = BgYellow;
                    }
                }
                catch (Exception)
                {
                    textBox1.BackColor = BgRed;
                }
            }
            else if (ExpressionType == SupportedExpressionTypeEnum.String)
            {
                if (!CheckValidBasicExpression(Expression))
                {
                    textBox1.BackColor = BgYellow;
                }
                else if (IsPersistent)
                {
                    textBox1.BackColor = BgBlue;
                }
                else if (textBox1.BackColor != SystemColors.Window)
                {
                    textBox1.BackColor = SystemColors.Window;
                }
            }
            else if (ExpressionType == SupportedExpressionTypeEnum.Regex)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.BackColor = IsPersistent ? BgBlue : SystemColors.Window;
                    return;
                }
                try
                {
                    Regex rex = new Regex(textBox1.Text);
                    textBox1.BackColor = IsPersistent ? BgBlue : BgGreen;
                }
                catch (Exception)
                {
                    textBox1.BackColor = BgRed;
                }
            }
            else if (ExpressionType == SupportedExpressionTypeEnum.Color)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.BackColor = SystemColors.Window;
                    textBox1.ForeColor = SystemColors.WindowText;
                }
                else
                {
                    Color color = Color.Empty;
                    try
                    {
                        string rawColor = ctx.ExpandVariables(null, null, false, textBox1.Text);
                        color = ParseColor(rawColor, Color.Empty);
                    }
                    catch { color = Color.Empty; }

                    if (color == Color.Empty)
                    {
                        textBox1.BackColor = SystemColors.Window;
                        textBox1.ForeColor = SystemColors.WindowText;
                    }
                    else
                    {
                        textBox1.BackColor = color != Color.Transparent ? color : SystemColors.Window;
                        double brightness = 0.299 * color.R + 0.587 * color.G + 0.114 * color.B;
                        textBox1.ForeColor = (brightness > 128) ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    }
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateBackground();
            if (textBox1.Multiline) { MultiLineAdjustHeight(); }
            if (RealPlugin.plug.cfg.AutoComplete == true)
            {
                if (ExpressionType != SupportedExpressionTypeEnum.Regex && textBox1.Focused)
                {
                    acfDebounceTimer.Stop();
                    acfDebounceTimer.Start();
                }
            }
            _TextChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ProcessAutocomplete()
        {
            acfDebounceTimer.Stop();

            if (!textBox1.Focused) return;

            string temp = textBox1.Text.Substring(0, textBox1.SelectionStart);
            IEnumerable<string> matchedStrings = null;
            suffix = "";

            // string after "${" : match prefixes (e.g. "${func:...}") and regex capture groups
            Match m = rexPrefix.Match(temp);
            if (m.Success)
            {
                matchedStrings = GetAutocompleteSuggestions(CurrentRegexGroupsAndPrefixes, m.Groups["prefix"].Value);
                if (matchedStrings.Count() > 0)
                {
                    CurrentMatch = m.Groups["prefix"].Value;
                    suffix = "matchPrefix"; // decide after selected
                    ShowAutocomplete(matchedStrings);
                }
                else
                {
                    HideAutocomplete();
                }
                return;
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

            // match variable names:
            m = rexVarName.Match(temp);
            if (m.Success)
            {
                bool isPersist = m.Groups["persist"].Value == "p";
                string typeString = m.Groups["type"].Value;
                if (!StringToAutofillEnum.TryGetValue(typeString, out AutofillTypeEnum type))
                {
                    type = AutofillTypeEnum.None;
                }

                // combine the existing and dynamic variable names
                HashSet<string> varNames = new HashSet<string>(GetExistingAutofillNameList(type, isPersist));
                varNames.UnionWith(GetDynamicAutofillNameList(type, isPersist) ?? Enumerable.Empty<string>());

                matchedStrings = GetAutocompleteSuggestions(varNames, m.Groups["name"].Value);
                if (matchedStrings.Count() > 0)
                {
                    CurrentMatch = m.Groups["name"].Value;
                    if (m.Groups["type"].Value == "v" || m.Groups["e"].Value == "e")
                    {
                        suffix = "}";
                    }
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
                VariableStore vs = m.Groups["persist"].Value == "p" ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
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
                    suffix = (m.Groups["name1"].Value != "") ? "][" : "]}";
                    ShowAutocomplete(matchedStrings);
                }
                else
                {
                    HideAutocomplete();
                }
                return;
            }

            // match table col headers "${(p)tvarcl:...[xxx" or "${(p)tvardl:...[xxx":
            m = rexColHeader.Match(temp);
            if (m.Success)
            {
                VariableStore vs = m.Groups["persist"].Value == "p" ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
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
                    suffix = "][";
                    ShowAutocomplete(matchedStrings);
                }
                else
                {
                    HideAutocomplete();
                }
                return;
            }

            // match dict keys
            m = rexDictKey.Match(temp);
            if (m.Success)
            {
                VariableStore vs = m.Groups["persist"].Value == "p" ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                VariableDictionary vd;
                string varName = m.Groups["name"].Value;
                if (vs.Dict.ContainsKey(varName) && vs.Dict[varName].Size > 0)
                {
                    vd = vs.Dict[varName];
                }
                else
                {
                    HideAutocomplete();
                    return;
                }

                List<string> keys = vd.Values.Keys.ToList();
                matchedStrings = GetAutocompleteSuggestions(keys, m.Groups["key"].Value);
                if (matchedStrings.Count() > 0)
                {
                    CurrentMatch = m.Groups["key"].Value;
                    suffix = "]}";
                    ShowAutocomplete(matchedStrings);
                }
                else
                {
                    HideAutocomplete();
                }
                return;
            }

            // match "_xxx[xxx"
            m = rexStructKey.Match(temp);
            if (m.Success)
            {
                List<string> keys = null;
                switch (m.Groups["struct"].Value)
                {
                    case "const": keys = RealPlugin.plug.cfg.Constants.Keys.ToList(); break;
                    case "textaura":
                        {
                            keys = (RealPlugin.plug.sc != null) ? RealPlugin.plug.sc.textitems.Keys.ToList() : RealPlugin.plug.textauras.Keys.ToList();
                            keys.AddRange(tmpTextNames);
                            break;
                        }
                    case "imageaura":
                        {
                            keys = (RealPlugin.plug.sc != null) ? RealPlugin.plug.sc.imageitems.Keys.ToList() : RealPlugin.plug.imageauras.Keys.ToList();
                            keys.AddRange(tmpImageNames);
                            break;
                        }
                    case "config": keys = configurations; break;
                    case "storage": keys = RealPlugin.plug.scriptingStorage.Keys.ToList(); break;
                }
                matchedStrings = GetAutocompleteSuggestions(keys, m.Groups["key"].Value);
                if (matchedStrings.Count() > 0)
                {
                    CurrentMatch = m.Groups["key"].Value;
                    suffix = "]}";
                    ShowAutocomplete(matchedStrings);
                }
                else
                {
                    HideAutocomplete();
                }
                return;
            }

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
                // match numeric:
                if (currentExpr.StartsWith("n:") || currentExpr.StartsWith("numeric:") || currentExpr.StartsWith("if:"))
                {
                    m = rexMath.Match(currentExpr);
                    if (m.Success)
                    {
                        matchedStrings = GetAutocompleteSuggestions(math, m.Value);
                        if (matchedStrings != null && matchedStrings.Count() > 0)
                        {
                            CurrentMatch = m.Value;
                            ShowAutocomplete(matchedStrings);
                        }
                        else
                        {
                            HideAutocomplete();
                        }
                        return;
                    }
                }
                // match (p)[ltd](var):name.prop
                m = rexVarProp.Match(currentExpr);
                if (m.Success)
                {
                    List<string> varProps = null;
                    switch (m.Groups["type"].Value)
                    {
                        case "l": varProps = lvarProps; break;
                        case "t": varProps = tvarProps; break;
                        case "d": varProps = dvarProps; break;
                    }
                    matchedStrings = GetAutocompleteSuggestions(varProps, m.Groups["prop"].Value);
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
                    matchedStrings = GetAutocompleteSuggestions(XivEntityProps, m.Groups["prop"].Value);
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

                // match _xxx[xxx].prop
                m = rexStructProp.Match(currentExpr);
                if (m.Success)
                {
                    switch (m.Groups["struct"].Value)
                    {
                        case "ffxivparty":
                        case "ffxiventity":
                        case "party":
                        case "entity":
                            matchedStrings = GetAutocompleteSuggestions(XivEntityProps, m.Groups["prop"].Value);
                            break;
                        case "textaura":
                            matchedStrings = GetAutocompleteSuggestions(textAuraProps, m.Groups["prop"].Value);
                            break;
                        case "imageaura":
                            matchedStrings = GetAutocompleteSuggestions(imageAuraProps, m.Groups["prop"].Value);
                            break;
                        case "job":
                            matchedStrings = GetAutocompleteSuggestions(XivJobProps, m.Groups["prop"].Value);
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

            if (AutofillType != AutofillTypeEnum.None)
            {
                var names = GetExistingAutofillNameList(AutofillType, IsPersistent);
                names.AddRange(GetDynamicAutofillNameList(AutofillType, IsPersistent) ?? new List<string>());
                matchedStrings = GetAutocompleteSuggestions(names, temp);
                if (matchedStrings != null && matchedStrings.Count() > 0)
                {
                    CurrentMatch = temp;
                    ShowAutocomplete(matchedStrings);
                }
                else
                {
                    HideAutocomplete();
                }
                return;
            }

            if (ExpressionType == SupportedExpressionTypeEnum.Numeric)
            {
                m = rexMath.Match(currentExpr);
                if (m.Success)
                {
                    matchedStrings = GetAutocompleteSuggestions(math, m.Value);
                    if (matchedStrings != null && matchedStrings.Count() > 0)
                    {
                        CurrentMatch = m.Value;
                        ShowAutocomplete(matchedStrings);
                    }
                    else
                    {
                        HideAutocomplete();
                    }
                    return;
                }
            }
            HideAutocomplete();
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
                textBox1.MinimumSize = new Size(textBox1.MinimumSize.Width, 80);
                textBox1.MaximumSize = new Size(textBox1.MaximumSize.Width, 300);
                textBox1.ScrollBars = ScrollBars.Both;
                MultiLineAdjustHeight();
                Image tmp = panel1.BackgroundImage;
                panel1.BackgroundImage = panel2.BackgroundImage;
                panel2.BackgroundImage = tmp;
            }
        }

        private void MultiLineAdjustHeight()
        {
            using (Graphics g = textBox1.CreateGraphics())
            {
                SizeF size = g.MeasureString(textBox1.Text + "\n1", textBox1.Font); // add one more line
                textBox1.Height = (int)size.Height;
            }
        }

        // Prevent pasting a hidden \n (usually from ACT loglines) into the txtbox
        // Did not use WinProc since there are some regular TextBoxes in the forms besides ExpTxtBox.
        public static void ReplaceIncompleteLineBreaksInClipboard(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    string clipboardText = Clipboard.GetText();
                    Regex rexIncompleteLinebreaks = new Regex(@"\r(?!\n)|(?<!\r)\n");
                    if (rexIncompleteLinebreaks.IsMatch(clipboardText))
                    {
                        string replacedText = clipboardText.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
                        Clipboard.SetText(replacedText);
                    }
                }
            }
            catch { }
        }

        #region Color
        private static Regex regexHexColor = new Regex(@"^#? *(?<rgb>[\dA-Fa-f]{3}|[\dA-Fa-f]{6})$");
        private static Regex regexNumColor = new Regex(@"^(?<r>\d+(?:.\d+)?) *, *(?<g>\d+(?:.\d+)?) *, *(?<b>\d+(?:.\d+)?)$");

        /// <summary>
        /// Parse a user-input raw color string to a Color. <br />
        /// Input could be: <br />
        /// · Color names: white <br />
        /// · RGB: 192, 0, 18 <br />
        /// · Hex value: #acf / #aaccff / acf / aaccff <br />
        /// </summary>
        /// <param name="defaultColor">The default color returned if the string is invalid.</param>
        /// <returns>The representing Color</returns>
        public static Color ParseColor(string rawColor, Color defaultColor)
        {
            rawColor = rawColor.Trim();

            Color namedColor = Color.FromName(rawColor);
            if (namedColor.IsKnownColor)
            {   // "white"
                return namedColor;
            }

            int r, g, b;
            Match hexMatch = regexHexColor.Match(rawColor);
            if (hexMatch.Success)
            {
                string rgb = hexMatch.Groups["rgb"].Value;
                if (rgb.Length == 3)
                {   // "#acf" or "acf"
                    rgb = string.Concat(rgb[0], rgb[0], rgb[1], rgb[1], rgb[2], rgb[2]);
                }
                // "#aaccff" or "aaccff"
                r = Convert.ToInt32(rgb.Substring(0, 2), 16);
                g = Convert.ToInt32(rgb.Substring(2, 2), 16);
                b = Convert.ToInt32(rgb.Substring(4, 2), 16);
            }
            else
            {   // "192, 0, 18"
                Match numMatch = regexNumColor.Match(rawColor);
                if (numMatch.Success)
                {
                    r = (int)Math.Round(double.Parse(numMatch.Groups["r"].Value, CultureInfo.InvariantCulture));
                    g = (int)Math.Round(double.Parse(numMatch.Groups["g"].Value, CultureInfo.InvariantCulture));
                    b = (int)Math.Round(double.Parse(numMatch.Groups["b"].Value, CultureInfo.InvariantCulture));
                }
                else return defaultColor;
            }

            return Color.FromArgb(r < 0 ? 0 : r > 255 ? 255 : r,
                                  g < 0 ? 0 : g > 255 ? 255 : g,
                                  b < 0 ? 0 : b > 255 ? 255 : b);
        }

        public static string ColorToString(Color color, Color defaultColor)
        {
            if (color == Color.Empty || color == defaultColor)
            {
                return "";
            }
            else if (color.IsKnownColor)
            {
                return color.Name;
            }
            else
            {
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            }
        }
        #endregion

        #region Store Variable Names Dynamically

        private static List<string> tmpScalarNames = new List<string>();
        private static List<string> tmpListNames = new List<string>();
        private static List<string> tmpTableNames = new List<string>();
        private static List<string> tmpDictNames = new List<string>();
        private static List<string> tmpTextNames = new List<string>();
        private static List<string> tmpImageNames = new List<string>();

        private static List<string> prsScalarNames = new List<string>();
        private static List<string> prsListNames = new List<string>();
        private static List<string> prsTableNames = new List<string>();
        private static List<string> prsDictNames = new List<string>();

        public enum AutofillTypeEnum { None, Scalar, List, Table, Dict, Image, Text, Callback, Storage }

        public static Dictionary<string, AutofillTypeEnum> StringToAutofillEnum = new Dictionary<string, AutofillTypeEnum> {
            { "v", AutofillTypeEnum.Scalar },
            { "l", AutofillTypeEnum.List },
            { "t", AutofillTypeEnum.Table },
            { "d", AutofillTypeEnum.Dict },
            { "image",    AutofillTypeEnum.Image },
            { "text",     AutofillTypeEnum.Text },
            { "callback", AutofillTypeEnum.Callback },
            { "storage",  AutofillTypeEnum.Storage },
        };

        public AutofillTypeEnum AutofillType { get; set; } = AutofillTypeEnum.None;

        /// <summary> 
        /// Returns the list for dynamically storing the names in the expression textboxes, 
        /// based on the autofill type. 
        /// </summary>
        private static List<string> GetDynamicAutofillNameList(AutofillTypeEnum type, bool isPersistent)
        {
            switch (type)
            {
                case AutofillTypeEnum.Scalar: return isPersistent ? prsScalarNames : tmpScalarNames;
                case AutofillTypeEnum.List:   return isPersistent ? prsListNames   : tmpListNames;
                case AutofillTypeEnum.Table:  return isPersistent ? prsTableNames  : tmpTableNames;
                case AutofillTypeEnum.Dict:   return isPersistent ? prsDictNames   : tmpDictNames;
                case AutofillTypeEnum.Text:   return tmpTextNames;
                case AutofillTypeEnum.Image:  return tmpImageNames;
                default: return null;
            }
        }

        /// <summary> 
        /// Returns the list of existing variable/aura/... names corresponding to the autofill type.
        /// </summary>
        private static List<string> GetExistingAutofillNameList(AutofillTypeEnum type, bool isPersistent)
        {
            VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
            switch (type)
            {
                case AutofillTypeEnum.Scalar: return vs.Scalar.Keys.ToList();
                case AutofillTypeEnum.List: return vs.List.Keys.ToList();
                case AutofillTypeEnum.Table: return vs.Table.Keys.ToList();
                case AutofillTypeEnum.Dict: return vs.Dict.Keys.ToList();
                case AutofillTypeEnum.Text: return (RealPlugin.plug.sc != null) ? RealPlugin.plug.sc.textitems.Keys.ToList() : RealPlugin.plug.textauras.Keys.ToList();
                case AutofillTypeEnum.Image: return (RealPlugin.plug.sc != null) ? RealPlugin.plug.sc.imageitems.Keys.ToList() : RealPlugin.plug.imageauras.Keys.ToList();
                case AutofillTypeEnum.Callback: return RealPlugin.plug.callbacksByName.Keys.ToList();
                case AutofillTypeEnum.Storage: return RealPlugin.plug.scriptingStorage.Keys.ToList();
                default: return new List<string>();
            }
        }

        private void RegisterAutofillNames()
        {
            if (ExpressionType == SupportedExpressionTypeEnum.Regex)
                return;

            // search for all expressions like ${var:xxx}, ${l:xxx.prop}, ${pd:xxx[key]},
            // and add the names "xxx" to their corresponding namelist. 
            foreach (Match match in rexDynamicNames.Matches(Text))
            {
                bool isPersistent = match.Groups["persist"].ToString() == "p";
                string typeString = match.Groups["type"].ToString();
                if (!StringToAutofillEnum.TryGetValue(typeString, out AutofillTypeEnum type))
                {
                    type = AutofillTypeEnum.None;
                }
                string name = match.Groups["name"].ToString();
                RegisterDynamicVarName(name, type, isPersistent);
            }

            // If the textbox is used for entering variable names,
            // add the name to the corresponding namelist.
            if (Text.Count(c => c == '$') <= 1) // skip variable names with too many expressions
            {
                RegisterDynamicVarName(Text, AutofillType, IsPersistent);
            }
        }

        private static void RegisterDynamicVarName(string name, AutofillTypeEnum type, bool isPersistent)
        {
            List<string> dynamicNames = GetDynamicAutofillNameList(type, isPersistent);
            if (dynamicNames == null)
            {
                return;
            }
            dynamicNames.Remove(name);

            List<string> existingNames = GetExistingAutofillNameList(type, isPersistent);
            if (!existingNames.Contains(name))
            {
                dynamicNames.Add(name);
                if (dynamicNames.Count > 30)
                {
                    dynamicNames.RemoveAt(0);
                }
            }
        }

        internal static void RegisterAllDynamicVarNamesOnForm(Control parent)
        {
            if (parent is ExpressionTextBox exp)
            {
                exp.RegisterAutofillNames();
            }
            foreach (Control children in parent.Controls)
            {
                RegisterAllDynamicVarNamesOnForm(children);
            }
        }
        #endregion

        public class TextBox : System.Windows.Forms.TextBox
        {

            #region Enhanced Double-Click Selection

            private int clickCount = 0;
            private DateTime lastClickTime = DateTime.Now;
            private ExpressionTextBox ExpTextBox => Parent as ExpressionTextBox;

            protected override void WndProc(ref Message m)
            {
                const int WM_LBUTTONDOWN = 0x0201;
                const int WM_LBUTTONDBLCLK = 0x0203;

                if (m.Msg == WM_LBUTTONDBLCLK)
                {
                    clickCount = 2;
                    lastClickTime = DateTime.Now;

                    int x = m.LParam.ToInt32() & 0xFFFF;
                    int y = (m.LParam.ToInt32() >> 16) & 0xFFFF;
                    Point clickPoint = new Point(x, y);

                    int index = GetCharIndexFromPosition(clickPoint);
                    if (index < 0) return;

                    Point charPosition = GetPositionFromCharIndex(index);
                    if (clickPoint.X < charPosition.X && index > 0)
                    {
                        index--;
                    }

                    HandleDoubleClick(index);
                    return;
                }
                if (m.Msg == WM_LBUTTONDOWN)
                {
                    TimeSpan interval = DateTime.Now - lastClickTime;
                    if (interval.TotalMilliseconds > SystemInformation.DoubleClickTime || clickCount >= 3)
                    {
                        clickCount = 0;
                    }

                    clickCount++;
                    lastClickTime = DateTime.Now;
                    if (clickCount == 3)
                    {
                        if (Multiline)
                        {
                            int x = m.LParam.ToInt32() & 0xFFFF;
                            int y = (m.LParam.ToInt32() >> 16) & 0xFFFF;
                            int index = GetCharIndexFromPosition(new Point(x, y));
                            int lineIndex = GetLineFromCharIndex(index);
                            int lineStart = GetFirstCharIndexFromLine(lineIndex);
                            int lineEnd = GetFirstCharIndexFromLine(lineIndex + 1);
                            if (lineEnd == -1) lineEnd = Text.Length; // last line

                            Select(lineStart, lineEnd - lineStart);
                        }
                        else
                        {
                            Select(0, Text.Length);
                        }
                        clickCount = 0;
                        return;
                    }
                }

                base.WndProc(ref m);
            }

            private void HandleDoubleClick(int index)
            {
                if (index < 0 || index >= Text.Length)
                    return;

                char currentChar = Text[index];
                if (char.IsWhiteSpace(currentChar))
                {
                    SelectAdjacentChars(index, c => char.IsWhiteSpace(c) && c != '\n' && c != '\r');
                    return;
                }

                SupportedExpressionTypeEnum type = GetExpressionEnvironmentAt(index);

                if (_leftBracketChars.ContainsKey(currentChar) || _rightBracketChars.ContainsKey(currentChar) || currentChar == '$' || currentChar == '¤')
                {
                    SelectEnclosedBrackets(index);
                    return;
                }

                if (type == SupportedExpressionTypeEnum.Numeric)
                {
                    // select the adjacent alphanumeric chars
                    if (!MathParser.OperatorChar.Contains(currentChar))
                    {
                        SelectAdjacentChars(index, c => !MathParser.OperatorChar.Contains(c) && !char.IsWhiteSpace(c) && c != '}');
                        // if the prev char is a unary operator, select it
                        int prevIdx = SelectionStart - 1;
                        if (prevIdx < 0)
                        {
                            return;
                        }
                        char prevChar = Text[prevIdx];
                        if (prevChar != '+' && prevChar != '-')
                        {
                            return;
                        }
                        int i = prevIdx - 1;
                        // scan the prev char before +/- to check if it is really a unary op
                        while (true)
                        {
                            if (i < 0 || Text[i] == '\n' || MathParser.OperatorChar.Contains(Text[i]))
                            {
                                Select(prevIdx, SelectionLength + 1); return;
                            }
                            else if (char.IsWhiteSpace(Text[i--])) continue;
                            else return;
                        }
                    }
                    // select the current op
                    else
                    {
                        // if it is the 2nd char of an op
                        if (index > 0 && !char.IsWhiteSpace(Text[index - 1]))
                        {
                            string potentialOperator = Text.Substring(index - 1, 2);
                            if (MathParser.OperatorOrder.Contains(potentialOperator))
                            {
                                Select(index - 1, 2);
                                return;
                            }
                        }
                        // if it is the 1st char of an op
                        if (index < Text.Length - 1 && !char.IsWhiteSpace(Text[index + 1]))
                        {
                            string potentialOperator = Text.Substring(index, 2);
                            if (MathParser.OperatorOrder.Contains(potentialOperator))
                            {
                                Select(index, 2);
                                return;
                            }
                        }
                        // if it is a single-char op
                        Select(index, 1);
                    }
                }
                else if (type == SupportedExpressionTypeEnum.String || type == SupportedExpressionTypeEnum.Color
                      || type == SupportedExpressionTypeEnum.Regex) // To do: better logic for regexes
                {
                    HashSet<char> separators = new HashSet<char>("^$¤{}[](),.:;=|/\\'\"，。？！、：；（）《》「」『』【】“”‘’…" + Context.LINEBREAK_PLACEHOLDER);
                    if (type == SupportedExpressionTypeEnum.Regex)
                        separators.ExceptWith(".");
                    if (!separators.Contains(currentChar))
                    {
                        SelectAdjacentChars(index, c => !separators.Contains(c) && !char.IsWhiteSpace(c));
                    }
                    else
                    {
                        Select(index, 1);
                    }
                }
            }

            private void SelectAdjacentChars(int index, Func<char, bool> predicate)
            {
                int start = index;
                int end = index;

                while (start > 0 && predicate(Text[start - 1]))
                    start--;

                while (end < Text.Length - 1 && predicate(Text[end + 1]))
                    end++;

                Select(start, end - start + 1);
            }

            private SupportedExpressionTypeEnum GetExpressionEnvironmentAt(int position)
            {
                if (ExpTextBox?._ExpressionType == SupportedExpressionTypeEnum.Regex)
                    return SupportedExpressionTypeEnum.Regex;

                if (position > Text.Length)
                    return SupportedExpressionTypeEnum.String;

                string prevText = Text.Substring(0, position);
                int lBracketCount = 0;
                string afterLBracket = "";
                for (int i = prevText.Length - 1; i >= 0; i--)
                {
                    if (prevText[i] == '}')
                        lBracketCount--;
                    else if (prevText[i] == '{')
                        lBracketCount++;

                    if (lBracketCount == 1)
                    {
                        afterLBracket = prevText.Substring(i + 1);
                        break;
                    }
                }

                if (lBracketCount != 1) // not in {...}
                    return ExpTextBox?._ExpressionType ?? SupportedExpressionTypeEnum.String;

                if (afterLBracket.StartsWith("n:") || afterLBracket.StartsWith("numeric:"))
                    return SupportedExpressionTypeEnum.Numeric;
                else
                    return SupportedExpressionTypeEnum.String;
            }

            private static Dictionary<char, char> _leftBracketChars = new Dictionary<char, char> {
                { '(',  ')'  }, { '[',  ']'  }, { '{',  '}'  },
                { '【', '】' }, { '《', '》' }, { '（', '）' },
                { '“',  '”'  }, { '‘',  '’'  }, { '「', '」' },
                { '\"', '\"' }, { '\'', '\'' }, // too complicated to determine if a " or ' is left/right, so always consider it as left for now
            };

            private static Dictionary<char, char> _rightBracketChars = _leftBracketChars.ToDictionary(pair => pair.Value, pair => pair.Key);

            private void SelectEnclosedBrackets(int index)
            {
                char clicked = Text[index];
                char pair;
                int direction;
                if (_leftBracketChars.ContainsKey(clicked))
                {
                    pair = _leftBracketChars[clicked];
                    direction = 1;
                }
                else if (_rightBracketChars.ContainsKey(clicked))
                {
                    pair = _rightBracketChars[clicked];
                    direction = -1;
                }
                else if ((clicked == '$' || clicked == '¤') && index < Text.Length - 1 && Text[index + 1] == '{')
                {

                    SelectEnclosedBrackets(index + 1); return;
                }
                else
                {
                    Select(index, 1); return;
                }
               
                int count = 0; 
                int end = (direction == 1) ? Text.Length - 1 : 0;
                for (int i = index + direction; i >= 0 && i < Text.Length; i += direction)
                {
                    char c = Text[i];
                    if (c == pair)
                    {
                        count++;
                    }
                    else if (c == clicked)
                    {
                        count--;
                    }
                    if (count == 1)
                    {
                        end = i;  break;
                    }
                }

                int start = Math.Min(index, end);
                int length = Math.Abs(index - end) + 1;
                if (start >= 1 && Text[start] == '{' && (Text[start - 1] == '$' || Text[start - 1] == '¤'))
                {
                    start--;  length++;
                }
                Select(start, length);
            }

            #endregion

            #region Shortcuts

            private Keys prevKeyWithCtrlShift = Keys.None;

            protected override void OnKeyUp(KeyEventArgs e)
            {
                if (!e.Control || !e.Shift)
                {
                    prevKeyWithCtrlShift = Keys.None;
                }
                base.OnKeyUp(e);
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.Control && e.Shift && !e.Alt && RealPlugin.plug.cfg.EnableShortcutTemplates)
                {
                    bool handled = true;
                    bool shouldWrap = SelectionLength != 0 && RealPlugin.plug.cfg.WrapTextWhenSelected;
                    bool useAbbrev = RealPlugin.plug.cfg.UseAbbrevInTemplates;
                    switch (e.KeyCode)
                    {
                        // Ctrl + Shift + 4: ${}
                        case Keys.D4:
                            if (shouldWrap)
                                Paste($"${{{SelectedText}}}"); 
                            else
                                InsertStringOnBothSides("${", "}");
                            break;
                        // Ctrl + Shift + V/L/T/D: ${v/l/t/d:};
                        // Ctrl + Shift + P, V/L/T/D: ${pv/pl/pt/pd:};
                        case Keys.P:
                            break;
                        case Keys.V:
                        case Keys.L:
                        case Keys.T:
                        case Keys.D:
                            string varType = e.KeyCode.ToString().ToLower();
                            varType = useAbbrev ? varType : varType.Trim('v') + "var";
                            if (prevKeyWithCtrlShift == Keys.P)
                                varType = "p" + varType;
                            if (shouldWrap)
                                Paste($"${{{varType}:{SelectedText}}}");
                            else
                                InsertStringOnBothSides($"${{{varType}:", "}");
                            break;
                        // Ctrl + Shift + N: ${n:}
                        case Keys.N:
                            string numeric = useAbbrev ? "n" : "numeric";
                            if (shouldWrap)
                                Paste($"${{{numeric}: {SelectedText.TrimStart()}}}");
                            else
                                InsertStringOnBothSides($"${{{numeric}: ", "}");
                            break;
                        // Ctrl + Shift + F: ${f::}
                        case Keys.F:
                            string func = useAbbrev ? "f" : "func";
                            if (shouldWrap)
                                InsertStringOnBothSides($"${{{func}:", $":{SelectedText}}}");
                            else
                                InsertStringOnBothSides($"${{{func}:", ":}");
                            break;
                        // Ctrl + Shift + E: ${_entity[].}
                        case Keys.E:
                            string entity = useAbbrev ? "entity" : "ffxiventity";
                            if (shouldWrap)
                                InsertStringOnBothSides($"${{_{entity}[{SelectedText}].", "}");
                            else
                                InsertStringOnBothSides($"${{_{entity}[", "].}");
                            break;
                        // Ctrl + Shift + M: ${_me.id}
                        case Keys.M:
                            Paste(useAbbrev ? "${_me.id}" : "${_ffxiventity[${_ffxivplayer}].id}");
                            SelectionStart -= 3;
                            SelectionLength = 2; // select "id"
                            break;
                        // Ctrl + Shift + I: ${if: ? : }
                        case Keys.I:
                            if (shouldWrap)
                                InsertStringOnBothSides("${if: " + SelectedText.Trim() + " ? ", " :  }");
                            else
                                InsertStringOnBothSides("${if: ", " ?  :  }");
                            break;
                        // Ctrl + Shift + A: Select the next outer layer of brackets
                        case Keys.A:
                            SelectNextOuterBracket();
                            ExpTextBox?.HideAutocomplete();
                            break;
                        default:
                            handled = false;
                            break;
                    }
                    prevKeyWithCtrlShift = e.KeyCode;
                    if (handled)
                    {
                        e.SuppressKeyPress = true;
                        e.Handled = true;
                        return;
                    }
                }
                base.OnKeyDown(e);
            }

            public void InsertStringOnBothSides(string newTextBeforeCursor, string newTextAfterCursor = "")
            {
                Paste(newTextBeforeCursor + newTextAfterCursor);
                SelectionStart -= newTextAfterCursor.Length;
                ExpTextBox?.ProcessAutocomplete();
            }

            public void SelectNextOuterBracket()
            {
                bool hasOuterLayer = false;
                int index;
                Dictionary<char, int> counts = _leftBracketChars.ToDictionary(pair => pair.Key, pair => 0);
                for (index = SelectionStart - 1; index >= 0; index--)
                {
                    char c = Text[index];
                    if (c == '\"' || c == '\'')
                    {
                        continue;
                    }
                    if (_rightBracketChars.TryGetValue(c, out char pair))
                    {
                        counts[pair]--;
                    }
                    else if (_leftBracketChars.ContainsKey(c))
                    {
                        if (++counts[c] == 1)
                        {
                            hasOuterLayer = true;
                            break;
                        }
                    }
                }
                if (hasOuterLayer)
                {
                    SelectEnclosedBrackets(index);
                }
                else
                {
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
            #endregion

        }
    }
}