using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triggernometry.CustomControls;

namespace Triggernometry.Forms
{

    public partial class TestInputForm : MemoryForm<TestInputForm>
    {

        public RealPlugin plug;

        public TestInputForm()
        {
            InitializeComponent();
            Shown += TestInputForm_Shown;
            cbxEventDestination.SelectedIndex = 0;
            cbxZoneType.SelectedIndex = 0;
            txtEvent.GotFocus += ExpressionTextBox.ReplaceIncompleteLineBreaksInClipboard;
            txtZoneName.GotFocus += ExpressionTextBox.ReplaceIncompleteLineBreaksInClipboard;
            RestoredSavedDimensions();
        }

        private void TestInputForm_Shown(object sender, EventArgs e)
        {
            txtEvent.Focus();
        }

        private void btnGetCurZone_Click(object sender, EventArgs e)
        {
            if (cbxZoneType.SelectedIndex == 0)
            {
                txtZoneName.Text = plug.CurrentZoneHook();
            }
            else
            {
                txtZoneName.Text = PluginBridges.BridgeFFXIV.ZoneID.ToString();
            }
        }

        private void txtEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                txtEvent.SelectAll();
            }
        }

        private void cbxZoneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxZoneType.SelectedIndex == 0)
            {
                lblZoneName.Text = I18n.Translate("TestInputForm/lblZoneName", "Zone name");
            }
            else
            {
                lblZoneName.Text = I18n.Translate("TestInputForm/ffxivzoneid", "Zone ID");
            }
        }

        private void btnCopyDebugTrigger_Click(object sender, EventArgs e)
        {
            var src = (LogEvent.SourceEnum)cbxEventDestination.SelectedIndex;
            
            double? speed = DebugTriggerGenerator.AskForSpeed();
            if (!speed.HasValue) return;
            DebugTriggerGenerator debug = new DebugTriggerGenerator(txtEvent.Text, src, speed.Value);
            Clipboard.SetText(new TriggernometryExport { 
                PluginVersion = RealPlugin.plug.cfg.PluginVersion, 
                ExportedTrigger = debug.Trig 
            }.Serialize());
            string info = I18n.Translate("internal/TestInputForm/debugcopied", "Debug trigger has been copied to clipboard.");
            if (debug.shouldWarn)
            {
                info += Environment.NewLine + Environment.NewLine
                      + I18n.Translate("internal/TestInputForm/debugwarning", "Warning:")
                      + Environment.NewLine + Environment.NewLine + debug.WarningText();
            }
            MessageBox.Show(info, "Triggernometry", MessageBoxButtons.OK, debug.shouldWarn ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        private void btnFireDebugTrigger_Click(object sender, EventArgs e)
        {
            var src = (LogEvent.SourceEnum)cbxEventDestination.SelectedIndex;

            double? speed = DebugTriggerGenerator.AskForSpeed();
            if (!speed.HasValue) return;
            DebugTriggerGenerator debug = new DebugTriggerGenerator(txtEvent.Text, src, speed.Value);
            
            string info = I18n.Translate("internal/TestInputForm/debugfire", "Debug trigger will be fired after clicking OK.");
            if (debug.shouldWarn)
            {
                info += Environment.NewLine + Environment.NewLine
                      + I18n.Translate("internal/TestInputForm/debugwarning", "Warning:")
                      + Environment.NewLine + debug.WarningText();
            }
            var result = MessageBox.Show(info, "Triggernometry", MessageBoxButtons.OKCancel, debug.shouldWarn ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                debug.Trig.Fire(RealPlugin.plug, new Context(), null);
            }
        }

        public class DebugTriggerGenerator
        {
            public LogEvent.SourceEnum DefaultSource { get; set; }
            public double Speed { get; set; }
            public static string PreviousSpeed { get; set; }
            public string RawData { get; set; }
            public Trigger Trig { get; } = new Trigger { _Source = Trigger.TriggerSourceEnum.None };

            private List<(Logline, string)> _warnings = new List<(Logline, string)>();

            public bool shouldWarn => _warnings.Any();

            public DebugTriggerGenerator(string rawData, LogEvent.SourceEnum source = LogEvent.SourceEnum.ACT, double speed = 1)
            {
                RawData = rawData;
                DefaultSource = source;
                Speed = speed;
                Trig.Name = "Debug Log " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                BuildTrigger();
            }

            private void BuildTrigger()
            {
                string rawData = RawData;

                // To-do: replace the names / ids for other players
                // Replace the current player's name/id for privacy
                string myId = PluginBridges.BridgeFFXIV.PlayerHexId ?? "";
                if (myId.Length == 8)
                {
                    rawData = rawData.Replace(myId, "${_me.id}");
                    string myName = PluginBridges.BridgeFFXIV.GetMyself()?.GetValue("name")?.ToString() ?? "";
                    if (myName.Length > 0)
                    {
                        rawData = rawData.Replace(myName, "${_me}");
                    }
                }

                var loglines = rawData.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select((line, idx) => new Logline(this, line, idx + 1)).ToList();
                if (!loglines.Any()) return;

                // This section below intentionally traverses the list multiple times,
                // with each iteration focusing on a specific task to keep the logic clear,
                // since performance is not a primary concern for this purpose.

                // Fix the negative delay from 23:xx to 00:xx
                bool has0h = false, has23h = false, hasOthers = false;
                foreach (var logline in loglines)
                {
                    switch (logline.Time?.Hour ?? -1)
                    {
                        case -1: break;
                        case 0: has0h = true; break;
                        case 23: has23h = true; break;
                        default: hasOthers = true; break;
                    }
                }
                if (has0h && has23h && !hasOthers)
                {
                    foreach (var logline in loglines)
                    {
                        if ((logline.Time?.Hour ?? -1) == 0)
                        {
                            logline.Time = logline.Time?.AddDays(1);
                        }
                    }
                }

                // Apply DateTime to the lines without a given time
                DateTime prevTime = loglines.FirstOrDefault(line => line.Time.HasValue)?.Time ?? new DateTime();
                foreach (var logline in loglines)
                {
                    if (logline.Time.HasValue)
                    {
                        prevTime = logline.Time.Value;
                    }
                    else
                    {
                        _warnings.Add((logline, I18n.Translate("internal/TestInputForm/debugnotime", 
                            "No logline time format detected, considered as no delay.")));
                        logline.Time = prevTime;
                    }
                }

                // check/fix improper delays
                prevTime = loglines[0].Time.Value;
                foreach (var logline in loglines)
                {
                    if (logline == loglines[0]) continue;
                    double delay = (logline.Time.Value - prevTime).TotalSeconds;
                    if (delay < -1)
                    {
                        _warnings.Add((logline, I18n.Translate("internal/TestInputForm/debugdelay--", 
                            "Significantly earlier than the previous line. Adjusted to the correct position based on time.")));
                    }
                    else if (-1 <= delay && delay < 0)
                    {
                        _warnings.Add((logline, I18n.Translate("internal/TestInputForm/debugdelay-", 
                            "Slightly earlier than the previous line, might due to inaccurate log time. Adjusted to the previous line's time.")));
                        logline.Time = prevTime;
                    }
                    else if (delay > 180 * Speed)
                    {
                        _warnings.Add((logline, I18n.Translate("internal/TestInputForm/debugdelay++", 
                            "Significantly later than the previous line.")));
                    }
                    prevTime = logline.Time.Value;
                }

                // Sort
                loglines = loglines.OrderBy(line => line.Time.Value).ToList();

                // Calculate delays and generate actions
                DateTime initTime = loglines[0].Time.Value;
                double delaySum = 0; // Record cumulative delay to prevent accumulation of rounding errors
                foreach (var logline in loglines)
                {
                    double delay = Math.Round((logline.Time.Value - initTime).TotalSeconds / Speed - delaySum, 2);
                    if (delay > 0.1)
                    {
                        AddDelayAction(delay);
                        delaySum += delay;
                    }
                    AddLogMsgAction(logline);
                }
            }

            private void AddDelayAction(double seconds) => Trig.Actions.Add(new Action
            {
                _ActionType = Action.ActionTypeEnum.Placeholder,
                OrderNumber = Trig.Actions.Count() + 1,
                _ExecutionDelayExpression = $"{seconds.ToString("F2", CultureInfo.InvariantCulture)} * 1000",
            });

            private void AddLogMsgAction(Logline logline) => Trig.Actions.Add(new Action
            {                
                _ActionType = Action.ActionTypeEnum.LogMessage,
                OrderNumber = Trig.Actions.Count() + 1,
                _LogMessageText = logline.Data,
                _LogMessageTarget = DefaultSource,
                _LogProcess = true,
                _LogProcessACT = true,
            });

            public string WarningText()
            {   // Item1: logline  Item2: text
                var warnings = _warnings.OrderBy(o => o.Item1.OriginalIndex).Select(o => 
                    I18n.Translate("internal/TestInputForm/debugwarningformat", 
                        "Logline #{0}: {1}" + Environment.NewLine + "Data: {2}",
                        o.Item1.OriginalIndex, o.Item2, o.Item1.Data));
                return string.Join(Environment.NewLine + Environment.NewLine, warnings);
            }

            public static double? AskForSpeed()
            {
                string inputSpeed = new SimpleInputForm(
                    I18n.Translate("internal/TestInputForm/debugspeed", "Enter a positive number for the speed:"),
                    ExpressionTextBox.SupportedExpressionTypeEnum.Numeric,
                    PreviousSpeed ?? "1"
                    ).GetInput();
                if (inputSpeed == null) // cancel
                    return null;
                double speed;
                try
                {
                    speed = MathParser.Parse(inputSpeed);
                    if (speed <= 0) throw new Exception();
                    PreviousSpeed = inputSpeed;
                    return speed;
                }
                catch
                {
                    MessageBox.Show(I18n.Translate("internal/TestInputForm/debugspeedex", "The given value is not a positive number."),
                        "Triggernometry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            private class Logline
            {
                public DateTime? Time;
                public string Data;
                public int OriginalIndex;
                public LogEvent.SourceEnum Source;
                private DebugTriggerGenerator Parent;
                public double Delay = 0;

                public Logline(DebugTriggerGenerator parent, string logline, int index)
                {
                    Parent = parent;
                    Data = logline;
                    OriginalIndex = index;
                    Time = ParseActTimestamp(logline) ?? ParseNetworkTimestamp(logline);
                    if (!Time.HasValue)
                    {
                        Source = Parent.DefaultSource;
                    }
                }

                private static readonly Regex _rexTimestampACT = new Regex(@"^\[(\d{2}:\d{2}:\d{2}\.\d{3})\]");

                private DateTime? ParseActTimestamp(string logline)
                {
                    Match match = _rexTimestampACT.Match(logline);
                    if (match.Success)
                    {
                        string dateTimeStr = "2000-01-01T" + match.Groups[1].Value;
                        Source = LogEvent.SourceEnum.ACT;
                        return DateTime.ParseExact(dateTimeStr, "yyyy-MM-dd'T'HH:mm:ss.fff", CultureInfo.InvariantCulture);
                    }
                    return null;
                }
                                
                private static readonly Regex _rexTimestampNetwork = new Regex(@"^\d+\|(\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3})");

                private DateTime? ParseNetworkTimestamp(string logline)
                {
                    Match match = _rexTimestampNetwork.Match(logline);
                    if (match.Success)
                    {
                        Source = LogEvent.SourceEnum.NetworkFFXIV;
                        return DateTime.ParseExact(match.Groups[1].Value, "yyyy-MM-dd'T'HH:mm:ss.fff", CultureInfo.InvariantCulture);
                    }
                    return null;
                }

            }

        }

    }

}
