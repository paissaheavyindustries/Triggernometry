using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public partial class VariableForm : MemoryForm<VariableForm>
    {

        internal Plugin plug;

        public VariableForm()
        {
            InitializeComponent();
            Shown += VariableForm_Shown;
            RestoredSavedDimensions();
        }

        private void VariableForm_Shown(object sender, EventArgs e)
        {
            RefreshSimpleVariables();
            RefreshListVariables();
        }

        private void RefreshSimpleVariables()
        {
            lock (plug.simplevariables)
            {
                dgvScalarVariables.RowCount = plug.simplevariables.Count;
            }
            Refresh();
        }

        private void RefreshListVariables()
        {
            lock (plug.listvariables)
            {
                dgvListVariables.RowCount = plug.listvariables.Count;
            }
            Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RefreshSimpleVariables();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RefreshListVariables();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
            toolStripButton2_Click(sender, e);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dgvScalarVariables.ClearSelection();
        }

        private void dgvListVariables_SelectionChanged(object sender, EventArgs e)
        {
            dgvListVariables.ClearSelection();
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            lock (plug.simplevariables)
            {
                if (e.RowIndex >= plug.simplevariables.Count)
                {
                    return;
                }
                KeyValuePair<string, Variable> kp = plug.simplevariables.ElementAt(e.RowIndex);
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

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                return;
            }
            string newval = e.Value != null ? e.Value.ToString() : "";
            lock (plug.simplevariables)
            {
                string exname = dgvScalarVariables.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (plug.simplevariables.ContainsKey(exname) == true)
                {
                    Variable x = plug.simplevariables[exname];
                    x.Value = newval;
                    x.LastChanged = DateTime.Now;
                    x.LastChanger = I18n.Translate("internal/VariableForm/variableeditortag", "Variable editor");
                }
            }
            RefreshSimpleVariables();
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            lock (plug.simplevariables)
            {
                plug.simplevariables.Clear();
            }
            toolStripButton1_Click(sender, e);
        }

        private void btnRemoveAllList_Click(object sender, EventArgs e)
        {
            lock (plug.listvariables)
            {
                plug.listvariables.Clear();
            }
            toolStripButton2_Click(sender, e);
        }

    }

}
