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

    public partial class SubstitutionForm : MemoryForm<SubstitutionForm>
    {

        public SubstitutionForm()
        {
            InitializeComponent();
            RestoredSavedDimensions();
            Shown += SubstitutionForm_Shown;
        }

        private void SubstitutionForm_Shown(object sender, EventArgs e)
        {
            txtSearchFor.Focus();
        }

        internal void SettingsFromSubstitution(Configuration.Substitution sub)
        {
            if (sub == null)
            {
                txtReplaceWith.Text = "";
                txtSearchFor.Text = "";
                clbScope.ClearSelected();
            }
            else
            {
                txtReplaceWith.Text = sub.ReplaceWith;
                txtSearchFor.Text = sub.SearchFor;
                if ((sub.Scope & Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup) == Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup)
                {
                    clbScope.SetItemChecked(0, true);
                }
                if ((sub.Scope & Configuration.Substitution.SubstitutionScopeEnum.NumericExpression) == Configuration.Substitution.SubstitutionScopeEnum.NumericExpression)
                {
                    clbScope.SetItemChecked(1, true);
                }
                if ((sub.Scope & Configuration.Substitution.SubstitutionScopeEnum.StringExpression) == Configuration.Substitution.SubstitutionScopeEnum.StringExpression)
                {
                    clbScope.SetItemChecked(2, true);
                }
                if ((sub.Scope & Configuration.Substitution.SubstitutionScopeEnum.TextToSpeech) == Configuration.Substitution.SubstitutionScopeEnum.TextToSpeech)
                {
                    clbScope.SetItemChecked(3, true);
                }
            }
        }

        internal void SettingsToSubstitution(Configuration.Substitution sub)
        {
            sub.ReplaceWith = txtReplaceWith.Text;
            sub.SearchFor = txtSearchFor.Text;
            Configuration.Substitution.SubstitutionScopeEnum scope = 0;
            if (clbScope.GetItemChecked(0) == true)
            {
                scope |= Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup;
            }
            if (clbScope.GetItemChecked(1) == true)
            {
                scope |= Configuration.Substitution.SubstitutionScopeEnum.NumericExpression;
            }
            if (clbScope.GetItemChecked(2) == true)
            {
                scope |= Configuration.Substitution.SubstitutionScopeEnum.StringExpression;
            }
            if (clbScope.GetItemChecked(3) == true)
            {
                scope |= Configuration.Substitution.SubstitutionScopeEnum.TextToSpeech;
            }
            sub.Scope = scope;
        }

        private void txtSearchFor_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = (txtSearchFor.Text.Length > 0);
        }

    }

}
