using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace Triggernometry.CustomControls
{

    public partial class ExpressionTextBox : UserControl
    {

        public static List<string> terms = new List<string>()
        {
            // numeric
            "pi", "pi2", "pi05", "pi025", "pi0125", "pitorad", "piofrad", "phi", "major", "minor",
            "abs(x)", "cos(x)", "cosh(x)", "arccos(x)", "cosec(x)", "sin(x)", "sinh(x)", "arcsin(x)", "sec(x)", "tan(x)", "tanh(x)", "arctan(x)", "arctan2(x, y)",
            "cotan(x)", "distance(x1, y1, x2, y2)", "radtodeg(x)", "degtorad(x)", "max(...)", "min(...)", "random(x, y)", "sqrt(x)", "root(x, y)", "rem(x, y)", "mod(x, y)",
            "pow(x, y)", "exp(x)", "log(x)", "log(x, y)", "round(x)", "round(x, y)", "floor(x)", "ceiling(x)", "sign(x)", "hex2dec(x)", "or(...)", "and(...)", "if(x,y,z)",
            // expressions
            "numeric", "string", "var", "evar", "lvar", "elvar", "tvar", "tvarcl", "tvarrl", "etvar", "func", "pvar", "epvar", "plvar", "eplvar", "ptvar", "ptvarcl", "ptvarrl", "eptvar",
            // special variables
            "_duration", "_event", "_incombat", "_since", "_sincems", "_triggerid", "_triggername", "_timestamp", "_timestampms", "_systemtime", "_systemtimems", "_zone", "_response",
            "_responsecode", "_jsonresponse[x]", "_screenwidth", "_screenheight", "_lastencounter", "_activeencounter", "_env[x]", "_x", "_y", "_w", "_width", "_h", "_height", "_opacity",
            "_textaura[x]", "_imageaura[x]", "_ffxivparty[x]", "_ffxiventity[x]", "_ffxivplayer", "_ffxivtime", "_ffxivpartyorder", "_ffxivprocid", "_ffxivprocname", "_ffxivzoneid",
            "_const[x]", "_loopiterator",
        };

        public static List<string> funcs = new List<string>()
        {
            // functions
            "toupper", "tolower", "length", "dec2hex", "dec2hex2", "dec2hex4", "dec2hex8", "hex2float", "hex2double", "float2hex", "double2hex", "padleft(x, y)", "padright(x, y)",
            "substring(x)", "substring(x, y)", "indexof(x)", "lastindexof(x)", "trim", "trim(x, ...)", "trimleft", "trimleft(x, ...)", "trimright", "trimright(x, ...)", "format(x, y)", "compare(x)", "compare(x, y)",
            "utctime(format)", "localtime(format)",
        };

        public static List<string> propstextaura = new List<string>()
        {
            "x", "y", "w", "h", "opacity", "text",
        };

        public static List<string> propsimageaura = new List<string>()
        {
            "x", "y", "w", "h", "opacity"
        };

        public static List<string> propsffxiv = new List<string>()
        {
            "name", "job", "jobid", "currenthp", "currentmp", "currentcp", "currentgp", "maxhp", "maxmp", "maxcp", "maxgp", "level", "x", "y", "z",
            "inparty", "id", "order", "worldid", "worldname", "currentworldid", "heading", "targetid", "casttargetid", "distance", "role",
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
        public Regex WordCapture = new Regex(@"[_a-zA-Z0-9]+$");
        public Regex FuncCapture = new Regex(@"func:(?<funcid>[_a-zA-Z0-9]{0,})$");
        public Regex PropsCapture = new Regex(@"_(?<structid>[a-zA-Z0-9]+)\[.*\]\.(?<propid>.{0,})$");
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
            return (from ix in src where ix.IndexOf(str, StringComparison.OrdinalIgnoreCase) == 0 && string.Compare(str, ix, true) != 0 select ix).OrderBy(a => a);
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
                Match m = PropsCapture.Match(temp);
                if (m.Success == true)
                {
                    IEnumerable<string> strs = null;
                    switch (m.Groups["structid"].Value)
                    {
                        case "ffxivparty":
                        case "ffxiventity":
                            strs = GetAutocompleteSuggestions(propsffxiv, m.Groups["propid"].Value);
                            break;
                        case "textaura":
                            strs = GetAutocompleteSuggestions(propstextaura, m.Groups["propid"].Value);
                            break;
                        case "imageaura":
                            strs = GetAutocompleteSuggestions(propsimageaura, m.Groups["propid"].Value);
                            break;
                    }
                    if (strs != null && strs.Count() > 0)
                    {
                        CurrentMatch = m.Groups["propid"].Value;
                        ShowAutocomplete(strs);
                    }
                    else
                    {
                        HideAutocomplete();
                    }
                }
                else
                {
                    m = FuncCapture.Match(temp);
                    if (m.Success == true)
                    {
                        IEnumerable<string> strs = GetAutocompleteSuggestions(funcs, m.Groups["funcid"].Value);
                        if (strs.Count() > 0)
                        {
                            CurrentMatch = m.Groups["funcid"].Value;
                            ShowAutocomplete(strs);
                        }
                        else
                        {
                            HideAutocomplete();
                        }
                    }
                    else
                    {
                        m = WordCapture.Match(temp);
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
                        }
                    }
                }
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
