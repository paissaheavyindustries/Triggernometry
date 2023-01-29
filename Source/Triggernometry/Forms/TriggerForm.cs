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

        public TriggerForm() : base()
        {
            InitializeComponent();
            Actions = new List<Action>();
            actionViewer1.Actions = Actions;
            fakectx = new Context();
            actionViewer1.fakectx = fakectx;
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
            cbxSequential.Enabled = false;
            cndCondition.Enabled = false;
            panel5.Visible = true;
            expMutexName.Enabled = false;
            chkReadmeTrigger.Enabled = false;
            actionViewer1.SetReadOnly();
        }

        private void txtRegexp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Regex rex = new Regex(txtRegexp.Text);
                txtRegexp.BackColor = Color.FromArgb(200, 255, 200);
            }
            catch (Exception)
            {
                txtRegexp.BackColor = Color.FromArgb(255, 200, 200);
            }
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
                cbxSequential.Checked = false;
                cbxLoggingLevel.SelectedIndex = 5;
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
            btnOk.Enabled = (AllowAnonymousTrigger == true) || (txtName.TextLength > 0);
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

    }

}
