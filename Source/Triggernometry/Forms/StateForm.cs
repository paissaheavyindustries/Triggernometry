using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Triggernometry.Variables;

namespace Triggernometry.Forms
{

    public partial class StateForm : MemoryForm<StateForm>
    {

        internal RealPlugin plug;

        public StateForm()
        {
            InitializeComponent();
            Shown += VariableForm_Shown;
            RestoredSavedDimensions();
        }

        private void VariableForm_Shown(object sender, EventArgs e)
        {
            RefreshScalarVariables();
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcMain.SelectedIndex)
            {
                case 0:
                    RefreshScalarVariables();
                    break;
                case 1:
                    RefreshListVariables();
                    break;
                case 2:
                    RefreshTableVariables();
                    break;
                case 3:
                    RefreshMutexes();
                    break;
                case 4:
                    RefreshImageAuras();
                    break;
                case 5:
                    RefreshTextAuras();
                    break;
                case 6:
                    RefreshNamedCallbacks();
                    break;
            }
        }

        #region Generic

        private Variable OpenVariableEditor(Variable v, ref string name, bool isNew)
        {
            using (VariableEditorForm vef = new VariableEditorForm())
            {
                vef.VariableName = name;
                vef.VariableToEdit = v.Duplicate();
                vef.IsNew = isNew;
                if (vef.ShowDialog() == DialogResult.OK)
                {
                    name = vef.VariableName;
                    vef.VariableToEdit.LastChanged = DateTime.Now;
                    vef.VariableToEdit.LastChanger = I18n.Translate("internal/VariableForm/variableeditortag", "Variable editor");
                    return vef.VariableToEdit;
                }
            }
            return null;
        }

        #endregion

        #region Scalar variables

        private void dgvScalarVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnScalarRemove.Enabled == true)
                {
                    btnScalarRemove_Click(this, null);
                }
            }
        }

        private void dgvScalarVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvScalarVariables.ClearSelection();
            dgvScalarVariables.Rows[e.RowIndex].Selected = true;
            btnScalarEdit_Click(sender, null);
        }

        private void dgvScalarVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnScalarEdit.Enabled = (dgvScalarVariables.SelectedRows.Count == 1);
            btnScalarRemove.Enabled = (dgvScalarVariables.SelectedRows.Count > 0);
        }

        private void dgvScalarVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            lock (plug.scalarvariables)
            {
                if (e.RowIndex >= plug.scalarvariables.Count)
                {
                    return;
                }
                KeyValuePair<string, VariableScalar> kp = plug.scalarvariables.ElementAt(e.RowIndex);
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = kp.Key;
                        break;
                    case 1:
                        e.Value = kp.Value.Value;
                        break;
                    case 2:
                        e.Value = kp.Value.LastChanged.ToString();
                        break;
                    case 3:
                        e.Value = kp.Value.LastChanger;
                        break;
                }
            }
        }

        private void RefreshScalarVariables()
        {
            lock (plug.scalarvariables)
            {
                dgvScalarVariables.RowCount = plug.scalarvariables.Count;
            }
            Refresh();
        }

        private void btnScalarAdd_Click(object sender, EventArgs e)
        {
            VariableScalar v = new VariableScalar();
            string varname = "";
            v = (VariableScalar)OpenVariableEditor(v, ref varname, true);
            if (v != null)
            {
                lock (plug.scalarvariables)
                {
                    plug.scalarvariables[varname] = v;
                }
                RefreshScalarVariables();
            }
        }

        private void btnScalarEdit_Click(object sender, EventArgs e)
        {
            string varname = "";
            foreach (DataGridViewRow r in dgvScalarVariables.SelectedRows)
            {
                varname = r.Cells[0].Value.ToString();
            }
            VariableScalar v = null;
            lock (plug.scalarvariables)
            {
                if (plug.scalarvariables.ContainsKey(varname) == true)
                {
                    v = plug.scalarvariables[varname];
                }
            }
            if (v == null)
            {
                v = new VariableScalar();
            }
            string varname2 = varname;
            v = (VariableScalar)OpenVariableEditor(v, ref varname2, false);
            if (v != null)
            {
                lock (plug.scalarvariables)
                {
                    if (varname != varname2)
                    {
                        if (plug.scalarvariables.ContainsKey(varname) == true)
                        {
                            plug.scalarvariables.Remove(varname);
                        }
                    }
                    plug.scalarvariables[varname2] = v;
                }
                RefreshScalarVariables();
            }
        }

        private void btnScalarRemove_Click(object sender, EventArgs e)
        {
            string temp;
            if (dgvScalarVariables.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/VariableForm/areyousureplural", "Are you sure you want to remove the selected variables?");
            }
            else
            {
                temp = I18n.Translate("internal/VariableForm/areyousuresingular", "Are you sure you want to remove the selected variable?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/VariableForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<string> varnames = new List<string>();
                    foreach (DataGridViewRow r in dgvScalarVariables.SelectedRows)
                    {
                        varnames.Add(r.Cells[0].Value.ToString());
                    }
                    lock (plug.scalarvariables)
                    {
                        foreach (string varname in varnames)
                        {
                            if (plug.scalarvariables.ContainsKey(varname) == true)
                            {
                                plug.scalarvariables.Remove(varname);
                            }
                        }
                        dgvScalarVariables.RowCount = plug.scalarvariables.Count;
                    }
                    dgvScalarVariables.ClearSelection();
                    dgvScalarVariables.Refresh();
                    break;
            }
        }

        private void btnRefreshScalar_ButtonClick(object sender, EventArgs e)
        {
            RefreshScalarVariables();
        }

        private void btnRemoveAllScalar_Click(object sender, EventArgs e)
        {
            lock (plug.scalarvariables)
            {
                plug.scalarvariables.Clear();
            }
            RefreshScalarVariables();
        }

        #endregion

        #region List variables

        private void dgvListVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnListRemove.Enabled == true)
                {
                    btnListRemove_Click(this, null);
                }
            }
        }

        private void dgvListVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvListVariables.ClearSelection();
            dgvListVariables.Rows[e.RowIndex].Selected = true;
            btnListEdit_Click(sender, null);
        }

        private void dgvListVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            lock (plug.listvariables)
            {
                if (e.RowIndex >= plug.listvariables.Count)
                {
                    return;
                }
                KeyValuePair<string, VariableList> kp = plug.listvariables.ElementAt(e.RowIndex);
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = kp.Key;
                        break;
                    case 1:
                        e.Value = kp.Value.Size();
                        break;
                    case 2:
                        e.Value = kp.Value.Join(",");
                        break;
                    case 3:
                        e.Value = kp.Value.LastChanged.ToString();
                        break;
                    case 4:
                        e.Value = kp.Value.LastChanger;
                        break;
                }
            }
        }

        private void dgvListVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnListEdit.Enabled = (dgvListVariables.SelectedRows.Count == 1);
            btnListRemove.Enabled = (dgvListVariables.SelectedRows.Count > 0);
        }

        private void RefreshListVariables()
        {
            lock (plug.listvariables)
            {
                dgvListVariables.RowCount = plug.listvariables.Count;
            }
            Refresh();
        }

        private void btnListAdd_Click(object sender, EventArgs e)
        {
            VariableList v = new VariableList();
            string varname = "";
            v = (VariableList)OpenVariableEditor(v, ref varname, true);
            if (v != null)
            {
                lock (plug.listvariables)
                {
                    plug.listvariables[varname] = v;
                }
                RefreshListVariables();
            }
        }

        private void btnListEdit_Click(object sender, EventArgs e)
        {
            string varname = "";
            foreach (DataGridViewRow r in dgvListVariables.SelectedRows)
            {
                varname = r.Cells[0].Value.ToString();
            }
            VariableList v = null;
            lock (plug.listvariables)
            {
                if (plug.listvariables.ContainsKey(varname) == true)
                {
                    v = plug.listvariables[varname];
                }
            }
            if (v == null)
            {
                v = new VariableList();
            }
            string varname2 = varname;
            v = (VariableList)OpenVariableEditor(v, ref varname2, false);
            if (v != null)
            {
                lock (plug.listvariables)
                {
                    if (varname != varname2)
                    {
                        if (plug.listvariables.ContainsKey(varname) == true)
                        {
                            plug.listvariables.Remove(varname);
                        }
                    }
                    plug.listvariables[varname2] = v;
                }
                RefreshListVariables();
            }
        }

        private void btnListRemove_Click(object sender, EventArgs e)
        {
            string temp;
            if (dgvListVariables.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/VariableForm/areyousureplural", "Are you sure you want to remove the selected variables?");
            }
            else
            {
                temp = I18n.Translate("internal/VariableForm/areyousuresingular", "Are you sure you want to remove the selected variable?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/VariableForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<string> varnames = new List<string>();
                    foreach (DataGridViewRow r in dgvListVariables.SelectedRows)
                    {
                        varnames.Add(r.Cells[0].Value.ToString());
                    }
                    lock (plug.listvariables)
                    {
                        foreach (string varname in varnames)
                        {
                            if (plug.listvariables.ContainsKey(varname) == true)
                            {
                                plug.listvariables.Remove(varname);
                            }
                        }
                        dgvListVariables.RowCount = plug.listvariables.Count;
                    }
                    dgvListVariables.ClearSelection();
                    dgvListVariables.Refresh();
                    break;
            }
        }

        private void btnListRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshListVariables();
        }

        private void btnListRemoveAll_Click(object sender, EventArgs e)
        {
            lock (plug.listvariables)
            {
                plug.listvariables.Clear();
            }
            RefreshListVariables();
        }

        #endregion

        #region Table variables

        private void dgvTableVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnTableRemove.Enabled == true)
                {
                    btnTableRemove_Click(this, null);
                }
            }
        }

        private void dgvTableVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTableVariables.ClearSelection();
            dgvTableVariables.Rows[e.RowIndex].Selected = true;
            btnTableEdit_Click(sender, null);
        }

        private void dgvTableVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            lock (plug.tablevariables)
            {
                if (e.RowIndex >= plug.tablevariables.Count)
                {
                    return;
                }
                KeyValuePair<string, VariableTable> kp = plug.tablevariables.ElementAt(e.RowIndex);
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = kp.Key;
                        break;
                    case 1:
                        e.Value = kp.Value.Width;
                        break;
                    case 2:
                        e.Value = kp.Value.Height;
                        break;
                    case 3:
                        e.Value = kp.Value.LastChanged.ToString();
                        break;
                    case 4:
                        e.Value = kp.Value.LastChanger;
                        break;
                }
            }
        }

        private void dgvTableVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnTableEdit.Enabled = (dgvTableVariables.SelectedRows.Count == 1);
            btnTableRemove.Enabled = (dgvTableVariables.SelectedRows.Count > 0);
        }

        private void RefreshTableVariables()
        {
            lock (plug.tablevariables)
            {
                dgvTableVariables.RowCount = plug.tablevariables.Count;
            }
            Refresh();
        }

        private void btnTableAdd_Click(object sender, EventArgs e)
        {
            VariableTable v = new VariableTable();
            string varname = "";
            v = (VariableTable)OpenVariableEditor(v, ref varname, true);
            if (v != null)
            {
                lock (plug.tablevariables)
                {
                    plug.tablevariables[varname] = v;
                }
                RefreshTableVariables();
            }
        }

        private void btnTableEdit_Click(object sender, EventArgs e)
        {
            string varname = "";
            foreach (DataGridViewRow r in dgvTableVariables.SelectedRows)
            {
                varname = r.Cells[0].Value.ToString();
            }
            VariableTable v = null;
            lock (plug.tablevariables)
            {
                if (plug.tablevariables.ContainsKey(varname) == true)
                {
                    v = plug.tablevariables[varname];
                }
            }
            if (v == null)
            {
                v = new VariableTable();
            }
            string varname2 = varname;
            v = (VariableTable)OpenVariableEditor(v, ref varname2, false);
            if (v != null)
            {
                lock (plug.tablevariables)
                {
                    if (varname != varname2)
                    {
                        if (plug.tablevariables.ContainsKey(varname) == true)
                        {
                            plug.tablevariables.Remove(varname);
                        }
                    }
                    plug.tablevariables[varname2] = v;
                }
                RefreshTableVariables();
            }
        }

        private void btnTableRemove_Click(object sender, EventArgs e)
        {
            string temp;
            if (dgvTableVariables.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/VariableForm/areyousureplural", "Are you sure you want to remove the selected variables?");
            }
            else
            {
                temp = I18n.Translate("internal/VariableForm/areyousuresingular", "Are you sure you want to remove the selected variable?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/VariableForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<string> varnames = new List<string>();
                    foreach (DataGridViewRow r in dgvTableVariables.SelectedRows)
                    {
                        varnames.Add(r.Cells[0].Value.ToString());
                    }
                    lock (plug.tablevariables)
                    {
                        foreach (string varname in varnames)
                        {
                            if (plug.tablevariables.ContainsKey(varname) == true)
                            {
                                plug.tablevariables.Remove(varname);
                            }
                        }
                        dgvTableVariables.RowCount = plug.tablevariables.Count;
                    }
                    dgvTableVariables.ClearSelection();
                    dgvTableVariables.Refresh();
                    break;
            }
        }

        private void btnTableRefresh_ButtonClick(object sender, EventArgs e)
        {
            RefreshTableVariables();
        }

        private void btnTableRemoveAll_Click(object sender, EventArgs e)
        {
            lock (plug.tablevariables)
            {
                plug.tablevariables.Clear();
            }
            RefreshTableVariables();
        }

        #endregion

        #region Mutexes

        private void dgvMutexes_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            lock (plug.mutexes)
            {
                if (e.RowIndex >= plug.mutexes.Count)
                {
                    return;
                }
                KeyValuePair<string, RealPlugin.MutexInformation> kp = plug.mutexes.ElementAt(e.RowIndex);
                lock (kp.Value)
                {
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.heldBy != null ? kp.Value.heldBy.ToString() : "Not owned";
                            break;
                        case 2:
                            e.Value = kp.Value.refCount.ToString();
                            break;
                        case 3:
                            {
                                List<string> acx = new List<string>();
                                foreach (RealPlugin.MutexTicket m in kp.Value.acquireQueue)
                                {
                                    acx.Add(m.ctx.ToString());
                                }
                                e.Value = String.Join(", ", acx);
                            }
                            break;
                    }
                }
            }
        }

        private void RefreshMutexes()
        {
            lock (plug.mutexes)
            {
                dgvMutexes.RowCount = plug.mutexes.Count;
            }
            Refresh();
        }

        private void btnMutexRefresh_Click(object sender, EventArgs e)
        {
            RefreshMutexes();
        }

        private void btnMutexForce_Click(object sender, EventArgs e)
        {
            List<string> mnames = new List<string>();
            foreach (DataGridViewRow r in dgvMutexes.SelectedRows)
            {
                mnames.Add(r.Cells[0].Value.ToString());
            }
            lock (plug.mutexes)
            {
                foreach (string mname in mnames)
                {
                    if (plug.mutexes.ContainsKey(mname) == true)
                    {
                        plug.mutexes[mname].ForceRelease();
                    }
                }                
            }
            btnMutexRefresh_Click(sender, e);
        }

        private void dgvMutexes_SelectionChanged(object sender, EventArgs e)
        {
            btnMutexForce.Enabled = (dgvMutexes.SelectedRows.Count > 0);
        }

        #endregion

        #region Image auras
        private void RefreshImageAuras()
        {

            if (plug.sc != null)
            {
                lock (plug.sc.imageitems)
                {
                    dgvImage.RowCount = plug.sc.imageitems.Count;
                }
            }
            else
            {
                lock (plug.imageauras)
                {
                    dgvImage.RowCount = plug.imageauras.Count;
                }
            }
            Refresh();
        }

        private void btnImageRefresh_Click(object sender, EventArgs e)
        {
            dgvImage.ClearSelection();
            RefreshImageAuras();
        }

        private void dgvImage_SelectionChanged(object sender, EventArgs e)
        {
            btnImageForce.Enabled = (dgvImage.SelectedRows.Count > 0);
        }

        private void btnImageForce_Click(object sender, EventArgs e)
        {
            List<string> anames = new List<string>();
            foreach (DataGridViewRow r in dgvImage.SelectedRows)
            {
                anames.Add(r.Cells[0].Value.ToString());
            }
            if (plug.sc != null)
            {
                Scarborough.Scarborough.ItemAction ia = new Scarborough.Scarborough.ItemAction();
                ia.Action = Scarborough.Scarborough.ItemAction.ActionTypeEnum.Deactivate;
                ia.Item = null;
                ia.ItemType = Scarborough.Scarborough.ItemAction.ItemTypeEnum.Image;
                foreach (string aname in anames)
                {
                    ia.Id = aname;
                    plug.sc.ExecuteAction(ia);
                }
            }
            else
            {
                foreach (string aname in anames)
                {
                    lock (plug.imageauras)
                    {
                        if (plug.imageauras.ContainsKey(aname) == true)
                        {
                            Forms.AuraContainerForm acf = plug.imageauras[aname];
                            acf.AuraDeactivate();
                        }
                    }
                }
            }
            btnImageRefresh_Click(sender, e);
        }

        private void dgvImage_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (plug.sc != null)
            {
                lock (plug.sc.imageitems)
                {
                    if (e.RowIndex >= plug.sc.imageitems.Count)
                    {
                        return;
                    }
                    KeyValuePair<string, Scarborough.ScarboroughImage> kp = plug.sc.imageitems.ElementAt(e.RowIndex);
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.ctx != null ? kp.Value.ctx.ToString() : "(unknown)";
                            break;
                    }
                }
            }
            else
            {
                lock (plug.imageauras)
                {
                    if (e.RowIndex >= plug.imageauras.Count)
                    {
                        return;
                    }
                    KeyValuePair<string, AuraContainerForm> kp = plug.imageauras.ElementAt(e.RowIndex);
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.ctx != null ? kp.Value.ctx.ToString() : "(unknown)";
                            break;
                    }
                }
            }
        }
        #endregion

        #region Text auras
        private void RefreshTextAuras()
        {
            if (plug.sc != null)
            {
                lock (plug.sc.textitems)
                {
                    dgvText.RowCount = plug.sc.textitems.Count;
                }
            }
            else
            {
                lock (plug.textauras)
                {
                    dgvText.RowCount = plug.textauras.Count;
                }
            }
            Refresh();
        }

        private void btnTextRefresh_Click(object sender, EventArgs e)
        {
            dgvText.ClearSelection();
            RefreshTextAuras();
        }

        private void dgvText_SelectionChanged(object sender, EventArgs e)
        {
            btnTextForce.Enabled = (dgvText.SelectedRows.Count > 0);
        }

        private void btnTextForce_Click(object sender, EventArgs e)
        {
            List<string> anames = new List<string>();
            foreach (DataGridViewRow r in dgvText.SelectedRows)
            {
                anames.Add(r.Cells[0].Value.ToString());
            }
            if (plug.sc != null)
            {
                Scarborough.Scarborough.ItemAction ia = new Scarborough.Scarborough.ItemAction();
                ia.Action = Scarborough.Scarborough.ItemAction.ActionTypeEnum.Deactivate;
                ia.Item = null;
                ia.ItemType = Scarborough.Scarborough.ItemAction.ItemTypeEnum.Text;
                foreach (string aname in anames)
                {
                    ia.Id = aname;
                    plug.sc.ExecuteAction(ia);
                }
            }
            else
            {
                foreach (string aname in anames)
                {
                    lock (plug.textauras)
                    {
                        if (plug.textauras.ContainsKey(aname) == true)
                        {
                            Forms.AuraContainerForm acf = plug.textauras[aname];
                            acf.AuraDeactivate();
                        }
                    }
                }
            }
            btnTextRefresh_Click(sender, e);
        }

        private void dgvText_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (plug.sc != null)
            {
                lock (plug.sc.textitems)
                {
                    if (e.RowIndex >= plug.sc.textitems.Count)
                    {
                        return;
                    }
                    KeyValuePair<string, Scarborough.ScarboroughText> kp = plug.sc.textitems.ElementAt(e.RowIndex);
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.ctx != null ? kp.Value.ctx.ToString() : "(unknown)";
                            break;
                    }
                }
            }
            else
            {
                lock (plug.textauras)
                {
                    if (e.RowIndex >= plug.textauras.Count)
                    {
                        return;
                    }
                    KeyValuePair<string, AuraContainerForm> kp = plug.textauras.ElementAt(e.RowIndex);
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kp.Key;
                            break;
                        case 1:
                            e.Value = kp.Value.ctx != null ? kp.Value.ctx.ToString() : "(unknown)";
                            break;
                    }
                }
            }
        }
        #endregion

        #region Named callbacks
        private void RefreshNamedCallbacks()
        {
        }

        private void btnCallbackRefresh_Click(object sender, EventArgs e)
        {
            RefreshNamedCallbacks();
        }

        private void dgvCallback_SelectionChanged(object sender, EventArgs e)
        {
            dgvCallback.ClearSelection();
        }

        private void dgvCallback_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            lock (plug.callbacksById)
            {
                if (e.RowIndex >= plug.callbacksById.Count)
                {
                    return;
                }
                int cbid = plug.callbacksById.Keys.ElementAt(e.RowIndex);
                RealPlugin.NamedCallback cb = plug.callbacksById[cbid];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = cb.Id.ToString(CultureInfo.InvariantCulture);
                        break;
                    case 1:
                        e.Value = cb.Name;
                        break;
                }
            }
        }
        #endregion

    }

}
