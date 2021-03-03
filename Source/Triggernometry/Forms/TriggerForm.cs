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

        internal WMPLib.WindowsMediaPlayer wmp;
        internal SpeechSynthesizer tts;
        internal List<Action> Actions;
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
            }
        }

        internal ImageList imgs;
        internal TreeView trv;
        internal Context fakectx;
        internal string ClipboardAction = "";

        public TriggerForm() : base()
        {
            InitializeComponent();
            Actions = new List<Action>();
            fakectx = new Context();
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

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            using (ActionForm af = new ActionForm())
            {
                af.plug = plug;
                af.wmp = wmp;
                af.tts = tts;
                af.trvTrigger.ImageList = imgs;
                af.trvTrigger.Nodes.Add((TreeNode)trv.Nodes[0].Clone());
                CloseTree(af.trvTrigger.Nodes[0]);
                af.trvFolder.ImageList = imgs;
                af.trvFolder.Nodes.Add((TreeNode)trv.Nodes[0].Clone());
                RemoveTriggerNodesFromTree(af.trvFolder.Nodes[0]);
                CloseTree(af.trvFolder.Nodes[0]);
                af.SettingsFromAction(null);
                if (panel5.Visible == true)
                {
                    af.SetReadOnly();
                }
                af.Text = I18n.Translate("internal/TriggerForm/addnewaction", "Add new action");
                af.btnOk.Text = I18n.Translate("internal/TriggerForm/add", "Add");
                if (af.ShowDialog() == DialogResult.OK)
                {
                    Action a = new Action();
                    af.SettingsToAction(a);
                    a._Enabled = true;                    
                    Actions.Add(a);
                    a.OrderNumber = Actions.Count;
                    dgvActions.RowCount = Actions.Count;
                    dgvActions.ClearSelection();
                    dgvActions.Rows[dgvActions.RowCount - 1].Selected = true;
                }
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
            cbxTriggerSource.Enabled = false;
            cbxRefireOption1.Enabled = false;
            cbxRefireOption2.Enabled = false;
            cbxScheduleFrom.Enabled = false;
            cbxRefireWithinPeriod.Enabled = false;
            expRefirePeriod.Enabled = false;
            cbxEditAutofire.Enabled = false;
            cbxSequential.Enabled = false;
            cndCondition.Enabled = false;
            btnAddAction.Enabled = false;
            btnActionUp.Enabled = false;
            btnActionDown.Enabled = false;
            btnRemoveAction.Enabled = false;
            panel5.Visible = true;
            expMutexName.Enabled = false;
            chkReadmeTrigger.Enabled = false;
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
                cndCondition.ConditionToEdit = new ConditionGroup() { Enabled = false };
                expMutexName.Expression = "";
                chkReadmeTrigger.Checked = false;
            }
            else
            {
                txtName.Text = t.Name;
                txtRegexp.Text = t.RegularExpression;
                txtDescription.Text = t._Description;            
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
            btnOk.Enabled = (txtName.TextLength > 0);
        }

        private void TriggerForm_Shown(object sender, EventArgs e)
        {
            dgvActions.RowCount = Actions.Count;
        }

        private void dgvActions_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Actions.Count)
            {
                return;
            }
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = Actions[e.RowIndex]._Enabled;
                    break;
                case 1:
                    e.Value = Actions[e.RowIndex].GetDescription(fakectx);
                    break;
            }
        }

        private void dgvActions_SelectionChanged(object sender, EventArgs e)
        {
            btnEditAction.Enabled = (dgvActions.SelectedRows.Count == 1);
            btnRemoveAction.Enabled = IsReadonly == false && (dgvActions.SelectedRows.Count > 0);
            btnActionUp.Enabled = IsReadonly == false && (dgvActions.SelectedRows.Count == 1 && dgvActions.SelectedRows[0].Index > 0);
            btnActionDown.Enabled = IsReadonly == false && (dgvActions.SelectedRows.Count == 1 && dgvActions.SelectedRows[0].Index < (Actions.Count - 1));
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

        private void btnEditAction_Click(object sender, EventArgs e)
        {
            Context ctx = new Context();
            ctx.plug = plug;
            ctx.trig = fakectx.trig;
            using (ActionForm af = new ActionForm())
            {
                Action a = Actions[dgvActions.SelectedRows[0].Index];
                af.plug = plug;
                af.wmp = wmp;
                af.trvTrigger.ImageList = imgs;
                af.trvTrigger.Nodes.Add((TreeNode)trv.Nodes[0].Clone());
                CloseTree(af.trvTrigger.Nodes[0]);
                af.trvFolder.ImageList = imgs;
                af.trvFolder.Nodes.Add((TreeNode)trv.Nodes[0].Clone());
                RemoveTriggerNodesFromTree(af.trvFolder.Nodes[0]);
                CloseTree(af.trvFolder.Nodes[0]);
                af.SettingsFromAction(a);
                if (panel5.Visible == true)
                {
                    af.SetReadOnly();
                }
                af.tts = tts;
                af.Text = I18n.Translate("internal/TriggerForm/editaction", "Edit action '{0}'", a.GetDescription(ctx));
                af.btnOk.Text = I18n.Translate("internal/TriggerForm/savechanges", "Save changes");
                if (af.ShowDialog() == DialogResult.OK)
                {
                    af.SettingsToAction(a);
                    dgvActions.Refresh();
                }
            }
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

        private void dgvActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Actions.Count)
            {
                return;
            }
            if (e.ColumnIndex != 0)
            {
                return;
            }
            Actions[e.RowIndex]._Enabled = (Actions[e.RowIndex]._Enabled == false);
        }

        private void dgvActions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Actions.Count)
            {
                return;
            }
            if (e.ColumnIndex == 1)
            {
                btnEditAction_Click(sender, null);
                return;
            }
            Actions[e.RowIndex]._Enabled = (Actions[e.RowIndex]._Enabled == false);
        }

        private void btnRemoveAction_Click(object sender, EventArgs e)
        {
            string temp;
            if (dgvActions.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/TriggerForm/areyousureplural", "Are you sure you want to remove the selected actions?");
            }
            else
            {
                temp = I18n.Translate("internal/TriggerForm/areyousuresingular", "Are you sure you want to remove the selected action?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/TriggerForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<Action> acts = new List<Action>();
                    foreach (DataGridViewRow r in dgvActions.SelectedRows)
                    {
                        acts.Add(Actions[r.Index]);
                    }                    
                    foreach (Action a in acts)
                    {
                        Actions.Remove(a);
                        List<Action> px = new List<Action>();
                        px.AddRange(from ax in Actions where ax.OrderNumber > a.OrderNumber select ax);
                        foreach (Action aaa in px)
                        {
                            aaa.OrderNumber--;
                        }
                    }
                    dgvActions.RowCount = Actions.Count;
                    dgvActions.ClearSelection();
                    dgvActions.Refresh();
                    break;
            }
        }

        private void dgvActions_Leave(object sender, EventArgs e)
        {
            dgvActions.ClearSelection();
        }

        private void btnActionUp_Click(object sender, EventArgs e)
        {
            int idx = dgvActions.SelectedRows[0].Index;
            Action ao = Actions[idx];
            Action an = Actions[idx - 1];
            ao.OrderNumber--;
            an.OrderNumber++;
            Actions.Sort((a, b) => a.OrderNumber.CompareTo(b.OrderNumber));
            dgvActions.Rows[idx].Selected = false;
            dgvActions.Rows[idx - 1].Selected = true;
        }

        private void btnActionDown_Click(object sender, EventArgs e)
        {
            int idx = dgvActions.SelectedRows[0].Index;
            Action ao = Actions[idx];
            Action an = Actions[idx + 1];
            ao.OrderNumber++;
            an.OrderNumber--;
            Actions.Sort((a, b) => a.OrderNumber.CompareTo(b.OrderNumber));
            dgvActions.Rows[idx].Selected = false;
            dgvActions.Rows[idx + 1].Selected = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxAddAction.Enabled = btnAddAction.Enabled;
            ctxEditAction.Enabled = btnEditAction.Enabled;
            ctxCopyAction.Enabled = btnEditAction.Enabled;
            ctxMoveUp.Enabled = btnActionUp.Enabled;
            ctxMoveDown.Enabled = btnActionDown.Enabled;
            ctxRemoveAction.Enabled = btnRemoveAction.Enabled;
            ctxPasteAction.Enabled = OkToPasteAction();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddAction_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEditAction_Click(sender, e);
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnActionUp_Click(sender, e);
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnActionDown_Click(sender, e);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRemoveAction_Click(sender, e);
        }

        private bool OkToPasteAction()
        {
            string data = null;
            if (plug.cfg.UseOsClipboard == true)
            {
                data = System.Windows.Forms.Clipboard.GetText(TextDataFormat.UnicodeText);
            }
            else
            {
                data = ClipboardAction;
            }
            return IsReadonly == false && (data != null && data.Length > 0);
        }

        private string ExportActionSelection()
        {
            int idx = dgvActions.SelectedRows[0].Index;
            Action ao = Actions[idx];
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");            
            XmlSerializer xs = new XmlSerializer(typeof(Action));
            string data = "";
            using (MemoryStream ms = new MemoryStream())
            {
                xs.Serialize(ms, ao, ns);                
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }

        private void CopySelectedAction()
        {
            try
            {
                if (btnEditAction.Enabled == true)
                {
                    if (plug.cfg.UseOsClipboard == true)
                    {
                        System.Windows.Forms.Clipboard.SetText(ExportActionSelection());
                    }
                    else
                    {
                        ClipboardAction = ExportActionSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/TriggerForm/actioncopyfail", "Action copy failed due to exception: {0}", ex.Message));
            }
        }

        private void PasteSelectedAction()
        {            
            if (OkToPasteAction() == false)
            {
                return;
            }
            string data = null;
            if (plug.cfg.UseOsClipboard == true)
            {
                data = System.Windows.Forms.Clipboard.GetText(TextDataFormat.UnicodeText);
            }
            else
            {
                data = ClipboardAction;
            }
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Action));
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                {
                    Action cx = (Action)xs.Deserialize(ms);
                    int idx = 0;
                    if (dgvActions.SelectedRows.Count > 0)
                    {
                        idx = dgvActions.SelectedRows[dgvActions.SelectedRows.Count - 1].Index;
                        Action origo = Actions[idx];
                        cx.OrderNumber = origo.OrderNumber + 1;
                        foreach (Action c in Actions)
                        {
                            if (c.OrderNumber >= cx.OrderNumber)
                            {
                                c.OrderNumber++;
                            }
                        }
                    }
                    else
                    {
                        cx.OrderNumber = 1;
                    }
                    Actions.Insert(cx.OrderNumber - 1, cx);
                    dgvActions.RowCount = Actions.Count;
                    dgvActions.Invalidate();
                }
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/TriggerForm/actionpastefail", "Action paste failed due to exception: {0}", ex.Message));
            }
        }

        private void dgvActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                CopySelectedAction();
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                PasteSelectedAction();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (btnRemoveAction.Enabled == true)
                {
                    btnRemoveAction_Click(this, null);
                }
            }
        }

        private void copyActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectedAction();
        }

        private void pasteActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteSelectedAction();
        }

        private void dgvActions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= Actions.Count)
            {
                return;
            }
            Action a = Actions[e.RowIndex];
            if (a.ActionType == Action.ActionTypeEnum.Placeholder)
            {
                e.CellStyle.BackColor = SystemColors.InactiveCaption;
                e.CellStyle.ForeColor = SystemColors.InactiveCaptionText;
            }
            else
            {
                e.CellStyle.BackColor = dgvActions.DefaultCellStyle.BackColor;
                e.CellStyle.ForeColor = dgvActions.DefaultCellStyle.ForeColor;
            }
        }

    }

}
