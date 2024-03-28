﻿using System;
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

namespace Triggernometry.Forms
{

    public partial class TriggerForm : MemoryForm<TriggerForm>
    {

        private bool IsReadonly { get; set; } = false;

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

        private Context _fakectx;
        internal Context fakectx
        {
            get
            {
                return _fakectx;
            }
            set
            {
                _fakectx = value;
            }
        }

        internal List<Action> Actions;

        internal bool AllowAnonymousTrigger { get; set; } = false;

        internal string initialDescriptions;
        private string closeReason;

        public TriggerForm() : base()
        {
            InitializeComponent();
            initialDescriptions = "";
            this.KeyPreview = true;
            this.FormClosing += TriggerForm_FormClosing;
            CancelDgvSelectionAttachToAll(this);
            btnOk.Click += btnOk_Click;
            closeReason = "";
            Actions = new List<Action>();
            actionViewer1.Actions = Actions;
            fakectx = new Context();
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
            RestoredSavedDimensions();
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
            IsReadonly = true;
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
            if (t == null)
            {
                txtName.Text = "";
                txtRegexp.Text = "";                
                cbxRefireOption1.SelectedIndex = 1;
                cbxRefireOption2.SelectedIndex = 0;
                cbxScheduleFrom.SelectedIndex = 0;
                cbxTriggerSource.SelectedIndex = 0;
                cbxRefireWithinPeriod.SelectedIndex = 0;
                expRefirePeriod.Expression = "0";
                cbxEditAutofire.Checked = false;
                cbxEditAutofireAllowCondition.Checked = false;
                cbxSequential.Checked = false;
                cbxLoggingLevel.SelectedIndex = (int)RealPlugin.DebugLevelEnum.Inherit;
                txtDescription.Text = "";
                txtEvent.Text = "";
                cndCondition.ConditionToEdit = new ConditionGroup() { Enabled = false };
                expMutexName.Expression = "";
                chkReadmeTrigger.Checked = false;
            }
            else
            {
                txtName.Text = t.Name;
                txtRegexp.Text = t.RegularExpression;
                txtDescription.Text = t._Description;
                txtEvent.Text = t._TestInput;
                switch (t._PrevActions)
                {
                    case Trigger.PrevActionsEnum.Interrupt:
                        cbxRefireOption1.SelectedIndex = 0;
                        break;
                    case Trigger.PrevActionsEnum.Keep:
                        cbxRefireOption1.SelectedIndex = 1;
                        break;
                }
                switch (t._PrevActionsRefire)
                {
                    case Trigger.RefireEnum.Allow:
                        cbxRefireOption2.SelectedIndex = 0;
                        break;
                    case Trigger.RefireEnum.Deny:
                        cbxRefireOption2.SelectedIndex = 1;
                        break;
                }
                switch (t._Scheduling)
                {
                    case Trigger.SchedulingEnum.FromFire:
                        cbxScheduleFrom.SelectedIndex = 0;
                        break;
                    case Trigger.SchedulingEnum.FromLastAction:
                        cbxScheduleFrom.SelectedIndex = 1;
                        break;
                    case Trigger.SchedulingEnum.FromRefirePeriod:
                        cbxScheduleFrom.SelectedIndex = 2;
                        break;
                }
                switch (t._PeriodRefire)
                {
                    case Trigger.RefireEnum.Allow:
                        cbxRefireWithinPeriod.SelectedIndex = 0;
                        break;
                    case Trigger.RefireEnum.Deny:
                        cbxRefireWithinPeriod.SelectedIndex = 1;
                        break;
                }
                switch (t._Source)
                {
                    case Trigger.TriggerSourceEnum.Log:
                        cbxTriggerSource.SelectedIndex = 0;
                        break;
                    case Trigger.TriggerSourceEnum.FFXIVNetwork:
                        cbxTriggerSource.SelectedIndex = 1;
                        break;
                    case Trigger.TriggerSourceEnum.None:
                        cbxTriggerSource.SelectedIndex = 2;
                        break;
                    case Trigger.TriggerSourceEnum.ACT:
                        cbxTriggerSource.SelectedIndex = 3;
                        break;
                    case Trigger.TriggerSourceEnum.Endpoint:
                        cbxTriggerSource.SelectedIndex = 4;
                        break;
                }
                expRefirePeriod.Expression = t._RefirePeriodExpression;
                cbxEditAutofire.Checked = t._EditAutofire;
                cbxEditAutofireAllowCondition.Checked = t._EditAutofireAllowCondition;
                cbxSequential.Checked = t._Sequential;
                cbxLoggingLevel.SelectedIndex = (int)t._DebugLevel;
                var ix = from tx in t.Actions
                         orderby tx.OrderNumber ascending
                         select tx;
                foreach (Action a in ix)
                {
                    Action b = new Action();
                    a.CopySettingsTo(b);
                    Actions.Add(b);
                }
                ConditionGroup cx;
                if (t.Condition != null)
                {
                    cx = (ConditionGroup)t.Condition.Duplicate();
                }
                else
                {
                    cx = new ConditionGroup();
                    cx.Grouping = ConditionGroup.CndGroupingEnum.Or;
                    cx.Enabled = false;
                }
                cndCondition.ConditionToEdit = cx;
                expMutexName.Expression = t._MutexToCapture;
                chkReadmeTrigger.Checked = t._IsReadme;
            }
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
            switch (cbxRefireOption1.SelectedIndex)
            {
                case 0:
                    t._PrevActions = Trigger.PrevActionsEnum.Interrupt;
                    break;
                case 1:
                    t._PrevActions = Trigger.PrevActionsEnum.Keep;
                    break;
            }
            switch (cbxRefireOption2.SelectedIndex)
            {
                case 0:
                    t._PrevActionsRefire = Trigger.RefireEnum.Allow;
                    break;
                case 1:
                    t._PrevActionsRefire = Trigger.RefireEnum.Deny;
                    break;
            }
            switch (cbxScheduleFrom.SelectedIndex)
            {
                case 0:
                    t._Scheduling = Trigger.SchedulingEnum.FromFire;
                    break;
                case 1:
                    t._Scheduling = Trigger.SchedulingEnum.FromLastAction;
                    break;
                case 2:
                    t._Scheduling = Trigger.SchedulingEnum.FromRefirePeriod;
                    break;
            }
            switch (cbxRefireWithinPeriod.SelectedIndex)
            {
                case 0:
                    t._PeriodRefire = Trigger.RefireEnum.Allow;
                    break;
                case 1:
                    t._PeriodRefire = Trigger.RefireEnum.Deny;
                    break;
            }
            switch (cbxTriggerSource.SelectedIndex)
            {
                case 0:
                    t._Source = Trigger.TriggerSourceEnum.Log;
                    break;
                case 1:
                    t._Source = Trigger.TriggerSourceEnum.FFXIVNetwork;
                    break;
                case 2:
                    t._Source = Trigger.TriggerSourceEnum.None;
                    break;
                case 3:
                    t._Source = Trigger.TriggerSourceEnum.ACT;
                    break;
                case 4:
                    t._Source = Trigger.TriggerSourceEnum.Endpoint;
                    break;
            }
            t._RefirePeriodExpression = expRefirePeriod.Expression;
            t._DebugLevel = (RealPlugin.DebugLevelEnum)cbxLoggingLevel.SelectedIndex;
            t.Actions.Clear();
            var ix = from tx in Actions
                     orderby tx.OrderNumber ascending
                     select tx;
            t.Actions.AddRange(ix);
            t.Condition = cndCondition.ConditionToEdit;
            t._MutexToCapture = expMutexName.Expression;
            t._IsReadme = chkReadmeTrigger.Checked;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = true; // (AllowAnonymousTrigger == true) || (txtName.TextLength > 0);
        }

        private void TriggerForm_Shown(object sender, EventArgs e)
        {
            actionViewer1.RefreshDgv();
            txtName_TextChanged(null, null);
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

        internal void BtnOkSetText()
        {
            btnOk.Text = (!cbxEditAutofire.Checked) ? I18n.Translate("TriggerForm/btnOk", "Save Changes")
                       : (cbxEditAutofireAllowCondition.Checked) ? I18n.Translate("TriggerForm/btnOkAutofire", "Save and Fire")
                       : I18n.Translate("TriggerForm/btnOkAutofireForce", "Save and Fire (Force)");
        }

        private void cbxEditAutofire_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Text != I18n.Translate("ConfigurationForm/btnTriggerTemplate", "Edit template trigger"))
                BtnOkSetText();
        }

        private void cbxEditAutofireAllowCondition_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Text != I18n.Translate("ConfigurationForm/btnTriggerTemplate", "Edit template trigger"))
                BtnOkSetText();
        }

        internal double totalDelay;
        internal int rootConditionCount;
        internal CndGroupingEnum rootConditionType;
        internal bool interrupt;
        internal double cooldown;

        internal void GetDescInterrupt()
        {
            interrupt = (cbxRefireOption1.SelectedIndex != 1 || cbxRefireOption2.SelectedIndex != 0) ;
        }

        internal void GetDescCooldown()
        {
            try 
            { 
                cooldown = (cbxRefireWithinPeriod.SelectedIndex == 0) ? 0
                         : Math.Round(fakectx.EvaluateNumericExpression(null, null, expRefirePeriod.Text)); 
            }
            catch { cooldown = double.NaN; }
        }

        private void actionViewer1_ActionsUpdated(object sender, EventArgs e)
        {
            totalDelay = actionViewer1.GetActionTotalDelay();
            SetTriggerDescription();
        }

        private void cndCondition_ConditionsUpdated(object sender, EventArgs e)
        {
            rootConditionCount = cndCondition.CountRootConditions();
            rootConditionType = cndCondition.RootConditionType();
            SetTriggerDescription();
        }

        private void interrupt_Changed(object sender, EventArgs e)
        {
            GetDescInterrupt();
            SetTriggerDescription();
        }
        private void cooldown_Changed(object sender, EventArgs e)
        {
            GetDescCooldown();
            SetTriggerDescription();
        }

        private void UpdateTriggerDescription(object sender, EventArgs e)
        {
            SetTriggerDescription();
        }

        internal void GetTriggerDescription()
        {
            totalDelay = actionViewer1.GetActionTotalDelay();
            rootConditionCount = cndCondition.CountRootConditions();
            rootConditionType = cndCondition.RootConditionType();
            GetDescInterrupt();
            GetDescCooldown();
        }

        internal void SetTriggerDescription()
        {
            lblTriggerDesc.Text = "";
            string desc = "";

            // Line 1:
            // [Actions: 3]
            if (actionViewer1.Actions.Count != 0)
            {
                desc += I18n.Translate("TriggerForm/descActionCnt", "[Actions: {0}]  ", actionViewer1.Actions.Count);
            }

            // [Delay 8.5 s]
            if (totalDelay != 0)
            {
                desc += (totalDelay > 0)
                      ? I18n.Translate("TriggerForm/descDelayNum", "[Delay {0}]  ", I18n.TrlTriggerDescTime(totalDelay))  // > 0: all numeric
                      : I18n.Translate("TriggerForm/descDelay", "[Delay: active]  ");                                     // NaN: contains expressions
            }

            // [Conditions: 2 (OR)]
            if (rootConditionCount != 0)
            {
                string count = (rootConditionCount > 0) 
                             ? rootConditionCount.ToString()                             // > 0: active nodes are all triggers
                             : I18n.Translate("TriggerForm/descCndGrouped", "Grouped");  // -1: contains active group folder
                if (rootConditionCount > 1)
                {
                    string type = "";
                    switch (rootConditionType)
                    {
                        case CndGroupingEnum.And: type = I18n.Translate("TriggerForm/descCndTypeAnd", "AND"); break;
                        case CndGroupingEnum.Not: type = I18n.Translate("TriggerForm/descCndTypeNot", "NOT"); break;
                        case CndGroupingEnum.Or: type = I18n.Translate("TriggerForm/descCndTypeOr", "OR"); break;
                        case CndGroupingEnum.Xor: type = I18n.Translate("TriggerForm/descCndTypeXor", "XOR"); break;
                    }
                    desc += I18n.Translate("TriggerForm/descCndCntLogic", "[Conditions: {0} ({1})]  ", count, type);
                }
                else 
                {
                    desc += I18n.Translate("TriggerForm/descCndCnt", "[Conditions: {0}]  ", count);
                }
            }

            desc = desc.Trim(' ', ';', '；', ',', '，', '、', '　'); // Common I18n separators
            desc += Environment.NewLine + Environment.NewLine;       // will be trimmed next time if the first line is empty

            // Line 2:
            // [Network Event]
            switch (cbxTriggerSource.SelectedIndex)
            {
                case 3: desc += I18n.Translate("TriggerForm/descSrcTypeActEvent", "[ACT Event]  "); break;
                case 4: desc += I18n.Translate("TriggerForm/descSrcTypeEndpoint", "[Endpoint]  "); break;
                case 1: desc += I18n.Translate("TriggerForm/descSrcTypeNetwork", "[Network Event]  "); break;
                case 2: desc += I18n.Translate("TriggerForm/descSrcTypeNone", "[Inactive]  "); break;
                case 0: desc += I18n.Translate("TriggerForm/descSrcTypeNormalLog", "[Normal Log]  "); break;
            }

            // [Interrupt]
            if (interrupt)
                desc += I18n.Translate("TriggerForm/descInterrupt", "[Interrupt] ");

            // [Schedule]
            if (cbxScheduleFrom.SelectedIndex != 0)
                desc += I18n.Translate("TriggerForm/descSchedule", "[Schedule] ");

            // [Cooldown 50 s]
            if (cooldown != 0)
                desc += (cooldown > 0)
                      ? I18n.Translate("TriggerForm/descCooldownNum", "[Cooldown {0}] ", I18n.TrlTriggerDescTime(cooldown))
                      : I18n.Translate("TriggerForm/descCooldown", "[Cooldown] ");

            // [Mutex]
            if (expMutexName.Text != "") 
                desc += I18n.Translate("TriggerForm/descMutex", "[Mutex] ");

            // [Sequential]
            if (cbxSequential.Checked)
                desc += I18n.Translate("TriggerForm/descSequential", "[Sequential] ");

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
