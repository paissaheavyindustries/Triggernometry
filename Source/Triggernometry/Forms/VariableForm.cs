using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Triggernometry.Variables;

namespace Triggernometry.Forms
{

    public partial class VariableForm : MemoryForm<VariableForm>
    {

        internal RealPlugin plug;

        public VariableForm()
        {
            InitializeComponent();
            Shown += VariableForm_Shown;
            RestoredSavedDimensions();
        }

        private void VariableForm_Shown(object sender, EventArgs e)
        {
            RefreshScalarVariables();
            RefreshListVariables();
            RefreshTableVariables();
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

    }

}
