using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Speech.Synthesis;
using System.Xml.Serialization;
using System.IO;
using static Triggernometry.ConditionGroup;
using Triggernometry.CustomControls;

namespace Triggernometry.Forms
{

    public partial class TriggerForm : MemoryForm<TriggerForm>
    {
        public Trigger trig;

        private bool _isReadOnly = false;

        private WMPLib.WindowsMediaPlayer _wmp;
        internal WMPLib.WindowsMediaPlayer wmp
        {
            get
            {
                return _wmp;
            }
            set
            {
                _wmp = value;
                actionViewer1.wmp = value;
            }
        }

        private SpeechSynthesizer _tts;
        internal SpeechSynthesizer tts
        {
            get
            {
                return _tts;
            }
            set
            {
                _tts = value;
                actionViewer1.tts = value;
            }
        }

        private RealPlugin _plug;
        internal RealPlugin plug
        {
            get
            {
                return _plug;
            }
            set
            {
                _plug = value;
                cndCondition.plug = value;
                actionViewer1.plug = value;
            }
        }

        private ImageList _imgs;
        internal ImageList imgs
        {
            get
            {
                return _imgs;
            }
            set
            {
                _imgs = value;
                actionViewer1.imgs = value;
            }
        }

        private TreeView _trv;
        internal TreeView trv
        {
            get
            {
                return _trv;
            }
            set
            {
                _trv = value;
                actionViewer1.trv = value;
            }
        }

        internal Context fakectx { get; set; } = new Context();

        internal List<Action> Actions => actionViewer1.Actions;

        internal string initialDescriptions;
        private string closeReason;

        public TriggerForm(Trigger t, bool readOnly = false, bool readMe = false) : base()
        {
            _isInitializing = true;
            InitializeComponent();
            initialDescriptions = "";

            this.KeyPreview = true;
            this.FormClosing += TriggerForm_FormClosing;
            CancelDgvSelectionAttachToAll(this);
            btnOk.Click += btnOk_Click;
            closeReason = "";
            actionViewer1.fakectx = fakectx;
            actionViewer1.ActionsUpdated += actionViewer1_ActionsUpdated;
            cndCondition.ConditionsUpdated += cndCondition_ConditionsUpdated;
            cbxTriggerSource.SelectedIndexChanged += UpdateTriggerDescription;
            cbxRefireOption1.SelectedIndexChanged += interrupt_Changed;
            cbxRefireOption2.SelectedIndexChanged += interrupt_Changed;
            cbxRefireWithinPeriod.SelectedIndexChanged += cooldown_Changed;
            expRefirePeriod.textBox1.TextChanged += cooldown_Changed;
            cbxScheduleFrom.SelectedIndexChanged += UpdateTriggerDescription;
            expMutexName.textBox1.TextChanged += UpdateTriggerDescription;
            cbxSequential.CheckedChanged += UpdateTriggerDescription;
            cbxEditAutofire.CheckedChanged += cbxEditAutofire_CheckedChanged;
            cbxEditAutofireAllowCondition.CheckedChanged += cbxEditAutofireAllowCondition_CheckedChanged;
            txtDescription.GotFocus += ExpressionTextBox.ReplaceIncompleteLineBreaksInClipboard;
            txtEvent.GotFocus += ExpressionTextBox.ReplaceIncompleteLineBreaksInClipboard;
            txtName.GotFocus += ExpressionTextBox.ReplaceIncompleteLineBreaksInClipboard;
            RestoredSavedDimensions();

            plug = RealPlugin.plug;
            trig = t;
            actionViewer1.trig = t;
            SettingsFromTrigger(trig);
            fakectx.plug = plug;
            fakectx.trig = trig;
            foreach (Action action in Actions)
            {
                action.ParentTrigger = trig;
            }

            if (readOnly) SetReadOnly();
            if (readMe) EnterReadmeMode();
            else BtnOkUpdateText();

            _isInitializing = false;
            initialDescriptions = GetAllDescriptionsStr();
            SetTriggerDescription();

            txtRegexp.TextChanged += (s, e) => ExpressionTextBox.CurrentTriggerRegexStr = txtRegexp.Text;
            Shown += (s, e) => ExpressionTextBox.CurrentTriggerRegexStr = txtRegexp.Text;
            Closed += (s, e) => ExpressionTextBox.CurrentTriggerRegexStr = "";
        }

        private void CloseTree(TreeNode tn)
        {
            if (tn.Tag is Folder)
            { 
                tn.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder((Folder)tn.Tag);
                tn.SelectedImageIndex = tn.ImageIndex;
            }
            foreach (TreeNode tc in tn.Nodes)
            {
                CloseTree(tc);
            }
        }

        internal void SetReadOnly()
        {
            _isReadOnly = true;
            txtName.ReadOnly = true;
            txtRegexp.ReadOnly = true;
            btnOk.Enabled = false;
            btnOk.Visible = false;
            lblTriggerDesc.Enabled = false;
            lblTriggerDesc.Visible = false;
            btnCancel.Dock = DockStyle.Fill;
            cbxLoggingLevel.Enabled = false;
            txtDescription.ReadOnly = true;
            txtEvent.ReadOnly = true;
            cbxTriggerSource.Enabled = false;
            cbxRefireOption1.Enabled = false;
            cbxRefireOption2.Enabled = false;
            cbxScheduleFrom.Enabled = false;
            cbxRefireWithinPeriod.Enabled = false;
            expRefirePeriod.Enabled = false;
            cbxEditAutofire.Enabled = false;
            cbxEditAutofireAllowCondition.Enabled = false;
            cbxSequential.Enabled = false;
            cndCondition.Enabled = false;
            panel5.Visible = true;
            expMutexName.Enabled = false;
            chkReadmeTrigger.Enabled = false;
            actionViewer1.SetReadOnly();
        }

        internal void SettingsFromTrigger(Trigger t)
        {
            t = t ?? new Trigger();

            txtName.Text = t.Name ?? "";
            txtRegexp.Text = t.RegularExpression ?? "";
            txtDescription.Text = t._Description;
            txtEvent.Text = t._TestInput;
            cbxRefireOption1.SelectedIndex = (int)t._PrevActions;
            cbxRefireOption2.SelectedIndex = (int)t._PrevActionsRefire;
            cbxScheduleFrom.SelectedIndex = (int)t._Scheduling;
            cbxRefireWithinPeriod.SelectedIndex = (int)t._PeriodRefire;
            cbxTriggerSource.SelectedIndex = (int)t._Source;
            expRefirePeriod.Expression = t._RefirePeriodExpression;
            cbxEditAutofire.Checked = t._EditAutofire;
            cbxEditAutofireAllowCondition.Checked = t._EditAutofireAllowCondition;
            cbxSequential.Checked = t._Sequential;
            cbxLoggingLevel.SelectedIndex = (int)t._DebugLevel;
            foreach (Action action in t.Actions.OrderBy(a => a.OrderNumber))
            {
                Action newAction = new Action();
                action.CopySettingsTo(newAction);
                Actions.Add(newAction);
            }
            cndCondition.ConditionToEdit = (ConditionGroup)t._Condition?.Duplicate() ?? new ConditionGroup
            {
                Grouping = CndGroupingEnum.Or,
                Enabled = false
            };
            expMutexName.Expression = t._MutexToCapture;
            chkReadmeTrigger.Checked = t._IsReadme;
        }

        internal void SettingsToTrigger(Trigger t)
        {
            t.Name = txtName.Text;
            t.RegularExpression = txtRegexp.Text;
            t._Description = txtDescription.Text;
            t._TestInput = txtEvent.Text;
            t._EditAutofire = cbxEditAutofire.Checked;
            t._EditAutofireAllowCondition = cbxEditAutofireAllowCondition.Checked;
            t._Sequential = cbxSequential.Checked;
            t._PrevActions = (Trigger.PrevActionsEnum)cbxRefireOption1.SelectedIndex;
            t._PrevActionsRefire = (Trigger.RefireEnum)cbxRefireOption2.SelectedIndex;
            t._Scheduling = (Trigger.SchedulingEnum)cbxScheduleFrom.SelectedIndex;
            t._PeriodRefire = (Trigger.RefireEnum)cbxRefireWithinPeriod.SelectedIndex; 
            t._Source = (Trigger.TriggerSourceEnum)cbxTriggerSource.SelectedIndex;
            t._RefirePeriodExpression = expRefirePeriod.Expression;
            t._DebugLevel = (RealPlugin.DebugLevelEnum)cbxLoggingLevel.SelectedIndex;
            t.Actions = Actions.OrderBy(tx => tx.OrderNumber).ToList();
            t._Condition = cndCondition.ConditionToEdit;
            t._MutexToCapture = expMutexName.Expression;
            t._IsReadme = chkReadmeTrigger.Checked;
        }

        private void TriggerForm_Shown(object sender, EventArgs e)
        {
            actionViewer1.RefreshDgv();
        }

        internal void EnterReadmeMode()
        {
            grpGeneral.Visible = false;
            chkReadmeTrigger.Visible = false;
            panel1.Visible = false;
            panel5.Visible = false;
            tbcMain.TabPages.RemoveAt(0);
            tbcMain.TabPages.RemoveAt(0);
            tbcMain.TabPages.RemoveAt(0);
            tbcMain.TabPages.RemoveAt(0);
        }

        private bool RemoveTriggerNodesFromTree(TreeNode tn)
        {
            if (tn == null)
            {
                return true;
            }
            if (tn.Tag is Trigger)
            {                                
                return true;
            }
            List<TreeNode> rems = new List<TreeNode>();
            foreach (TreeNode tnx in tn.Nodes)
            {
                if (RemoveTriggerNodesFromTree(tnx) == true)
                {
                    rems.Add(tnx);
                }
            }
            foreach (TreeNode tnr in rems)
            {
                tnr.Remove();
            }
            return false;
        }

        internal string GetAllDescriptionsStr()
        {   // record all textboxes and action descriptions
            // roughly check if it is changed when closing the trigger form
            return string.Join(",", actionViewer1.GetActionDescriptions()) + ","
                 + string.Join(",", GetAllTextBoxText(this));
        }

        private List<string> GetAllTextBoxText(Control parent)
        {   // get a list of the text of all text boxes in the form
            List<string> texts = new List<string>();
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox txt)
                {
                    texts.Add(txt.Text);
                }
                texts.AddRange(GetAllTextBoxText(control));
            }
            return texts;
        }

        private bool ConfirmDiscardChanges()
        {
            if (initialDescriptions != GetAllDescriptionsStr())
            {
                DialogResult result = MessageBox.Show(this,
                    I18n.Translate("internal/TriggerForm/triggerexitconfirm", "Are you sure you want to exit without saving?"),
                    I18n.Translate("internal/TriggerForm/triggerexitconfirmtitle", "Discard Changes"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private void TriggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeReason != "Ok")
            {
                closeReason = "";
                if (!ConfirmDiscardChanges())
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            closeReason = "Ok";
            Close();
        }

        internal void BtnOkUpdateText()
        {
            btnOk.Text = (!cbxEditAutofire.Checked) ? I18n.Translate("internal/TriggerForm/btnOk", "Save Changes")
                       : (cbxEditAutofireAllowCondition.Checked) ? I18n.Translate("internal/TriggerForm/btnOkAutofire", "Save and Fire")
                       : I18n.Translate("internal/TriggerForm/btnOkAutofireForce", "Save and Fire (Force)");
        }

        private void cbxEditAutofire_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Text != I18n.Translate("ConfigurationForm/btnTriggerTemplate", "Edit template trigger"))
                BtnOkUpdateText();
        }

        private void cbxEditAutofireAllowCondition_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Text != I18n.Translate("ConfigurationForm/btnTriggerTemplate", "Edit template trigger"))
                BtnOkUpdateText();
        }

        internal double totalDelay;
        internal int rootConditionCount;
        internal CndGroupingEnum rootConditionType;
        internal bool interrupt;
        internal double cooldown;
        private bool _isInitializing;

        internal void GetDescInterrupt()
        {
            if (_isInitializing) return; 
            interrupt = (cbxRefireOption1.SelectedIndex != (int)Trigger.PrevActionsEnum.Keep || cbxRefireOption2.SelectedIndex != (int)Trigger.RefireEnum.Allow) ;
        }

        internal void GetDescCooldown()
        {
            if (_isInitializing) return;
            try 
            { 
                cooldown = (cbxRefireWithinPeriod.SelectedIndex == 0) ? 0
                         : Math.Round(fakectx.EvaluateNumericExpression(null, null, expRefirePeriod.Text)); 
            }
            catch { cooldown = double.NaN; }
        }

        private void actionViewer1_ActionsUpdated(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            totalDelay = actionViewer1.GetActionTotalDelay();
            SetTriggerDescription();
        }

        private void cndCondition_ConditionsUpdated(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            rootConditionCount = cndCondition.CountRootConditions();
            rootConditionType = cndCondition.RootConditionType();
            SetTriggerDescription();
        }

        private void interrupt_Changed(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            GetDescInterrupt();
            SetTriggerDescription();
        }
        private void cooldown_Changed(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            GetDescCooldown();
            SetTriggerDescription();
        }

        private void UpdateTriggerDescription(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            SetTriggerDescription();
        }

        internal void SetTriggerDescription()
        {
            totalDelay = actionViewer1.GetActionTotalDelay();
            rootConditionCount = cndCondition.CountRootConditions();
            rootConditionType = cndCondition.RootConditionType();
            GetDescInterrupt();
            GetDescCooldown();

            lblTriggerDesc.Text = "";
            string desc = "";

            // Line 1:
            // [Actions: 3]
            if (actionViewer1.Actions.Count != 0)
            {
                desc += I18n.Translate("internal/TriggerForm/descActionCnt", "[Actions: {0}]  ", actionViewer1.Actions.Count);
            }

            // [Delay 8.5 s]
            if (totalDelay != 0)
            {
                desc += (totalDelay > 0)
                      ? I18n.Translate("internal/TriggerForm/descDelayNum", "[Delay {0}]  ", I18n.TrlTriggerDescTime(totalDelay))  // > 0: all numeric
                      : I18n.Translate("internal/TriggerForm/descDelay", "[Delay: active]  ");                                     // NaN: contains expressions
            }

            // [Conditions: 2 (OR)]
            if (rootConditionCount != 0)
            {
                string count = (rootConditionCount > 0) 
                             ? rootConditionCount.ToString()                             // > 0: active nodes are all triggers
                             : I18n.Translate("internal/TriggerForm/descCndGrouped", "Grouped");  // -1: contains active group folder
                if (rootConditionCount > 1)
                {
                    string logic = rootConditionType.ToString();
                    string logicDesc = I18n.Translate($"internal/TriggerForm/descCndType{logic}", logic.ToUpper());
                    desc += I18n.Translate("internal/TriggerForm/descCndCntLogic", "[Conditions: {0} ({1})]  ", count, logicDesc);
                }
                else 
                {
                    desc += I18n.Translate("internal/TriggerForm/descCndCnt", "[Conditions: {0}]  ", count);
                }
            }

            desc = desc.Trim(' ', ';', '；', ',', '，', '、', '　'); // Common I18n separators
            desc += Environment.NewLine;                             // will be trimmed next time if the first line is empty

            // Line 2:
            // [Network Event]
            switch (cbxTriggerSource.SelectedIndex)
            {
                case 3: desc += I18n.Translate("internal/TriggerForm/descSrcTypeActEvent", "[ACT Event]  "); break;
                case 4: desc += I18n.Translate("internal/TriggerForm/descSrcTypeEndpoint", "[Endpoint]  "); break;
                case 1: desc += I18n.Translate("internal/TriggerForm/descSrcTypeNetwork", "[Network Event]  "); break;
                case 2: desc += I18n.Translate("internal/TriggerForm/descSrcTypeNone", "[Inactive]  "); break;
                case 0: desc += I18n.Translate("internal/TriggerForm/descSrcTypeNormalLog", "[Normal Log]  "); break;
            }

            // [Interrupt]
            if (interrupt)
                desc += I18n.Translate("internal/TriggerForm/descInterrupt", "[Interrupt] ");

            // [Schedule]
            if (cbxScheduleFrom.SelectedIndex != 0)
                desc += I18n.Translate("internal/TriggerForm/descSchedule", "[Schedule] ");

            // [Cooldown 50 s]
            if (cooldown != 0)
                desc += (cooldown > 0)
                      ? I18n.Translate("internal/TriggerForm/descCooldownNum", "[Cooldown {0}] ", I18n.TrlTriggerDescTime(cooldown))
                      : I18n.Translate("internal/TriggerForm/descCooldown", "[Cooldown] ");

            // [Mutex]
            if (expMutexName.Text != "") 
                desc += I18n.Translate("internal/TriggerForm/descMutex", "[Mutex] ");

            // [Sequential]
            if (cbxSequential.Checked)
                desc += I18n.Translate("internal/TriggerForm/descSequential", "[Sequential] ");

            desc = desc.Trim().Trim(';', '；', ',', '，', '、', '　');
            lblTriggerDesc.Text = desc;
        }

        private void CancelDgvSelectionAttachToAll(Control parent)
        {
            parent.MouseDown += CancelDgvSelection;
            foreach (Control control in parent.Controls)
            {
                if (control is DataGridView)
                {
                    continue;
                }
                
                CancelDgvSelectionAttachToAll(control);
            }
        }

        private void CancelDgvSelection(object sender, MouseEventArgs e)
        {
            actionViewer1.dgvActions.ClearSelection();
        }
    }

}
