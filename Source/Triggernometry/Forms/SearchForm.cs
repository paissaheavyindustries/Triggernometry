using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public partial class SearchForm : MemoryForm<SearchForm>
    {

        internal RealPlugin plug;

        [Flags]
        public enum SearchFilterEnum
        {
            TriggerId = 0x01,
            TriggerName = 0x02,
            TriggerDescription = 0x04,
            TriggerCondition = 0x08,
            TriggerFullPath = 0x10,
            ActionDescription = 0x20,
            ActionCondition = 0x40,
            ActionDetails = 0x80,
            RepoName = 0x100,
            RepoAddress = 0x200,
            FolderName = 0x400,
            TriggerRegex = 0x800,
            IncludeDisabled = 0x100000,
            ScopeLocal = 0x1000000,
            Scoperemote = 0x2000000,
            Everything = 0xfffffff
        }

        public class SearchResult
        {

            public TreeNode Match { get; set; } = null;
            public string MatchItem { get; set; }
            public string MatchType { get; set; }

            public SearchResult(Folder f)
            {
                MatchItem = SearchForm.pathPrefix + f.FullPath;
            }

            public SearchResult(Repository r)
            {
                MatchItem = SearchForm.pathPrefix + r.Name;
            }

            public SearchResult(Trigger t)
            {
                MatchItem = SearchForm.pathPrefix + t.FullPath;
            }

        }

        public SearchForm()
        {
            InitializeComponent();
            expSearchTerm.OnEnterKeyHit += ExpSearchTerm_OnEnter;
            expSearchTerm.textBox1.TextChanged += TextBox1_TextChanged;
            Shown += SearchForm_Shown;
            RestoredSavedDimensions();
            ChangeAll(true);
        }

        private static string pathPrefix = "";

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = (expSearchTerm.Expression.Length > 0);
        }

        private void SearchForm_Shown(object sender, EventArgs e)
        {
            statusStrip1.Visible = false;
            lblResultInfo.Visible = false;
            expSearchTerm.Focus();
        }

        private void ExpSearchTerm_OnEnter()
        {
            if (btnSearch.Enabled == true)
            {
                btnSearch_Click(null, null);
            }
        }

        public bool ConditionMatches(Regex rex, ConditionGroup cg)
        {
            if (cg == null)
            {
                return false;
            }
            foreach (ConditionComponent cc in cg.Children)
            {
                if (cc is ConditionSingle)
                {
                    ConditionSingle cs = (ConditionSingle)cc;
                    if (RegexMatches(rex, cs.ExpressionL) == true)
                    {
                        return true;
                    }
                    if (RegexMatches(rex, cs.ExpressionR) == true)
                    {
                        return true;
                    }
                }
                if (cc is ConditionGroup)
                {
                    if (ConditionMatches(rex, (ConditionGroup)cc) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RegexMatches(Regex rex, string input)
        {
            if (input == null)
            {
                return false;
            }
            return rex.IsMatch(input);
        }

        internal List<SearchResult> SearchIn(Folder f, Context ctx, Regex rex, SearchFilterEnum filter)
        {
            List<SearchResult> results = new List<SearchResult>();
            if ((filter & SearchFilterEnum.IncludeDisabled) == 0 && f.Enabled == false)
            {
                return results;
            }
            if ((filter & SearchFilterEnum.FolderName) != 0)
            {                
                if (RegexMatches(rex, f.Name.ToString()) == true) results.Add(new SearchResult(f) { MatchType = I18n.Translate("internal/SearchForm/hitfoldername", "Folder name"), Match = plug.LocateNodeHostingFolder(f.Repo == null ? plug.ui.treeView1.Nodes[0] : plug.ui.treeView1.Nodes[1], f) });
            }
            foreach (Trigger t in f.Triggers)
            {                
                if ((filter & SearchFilterEnum.IncludeDisabled) == 0 && t.Enabled == false)
                {
                    continue;
                }
                TreeNode tn = plug.LocateNodeHostingTrigger(t.Repo == null ? plug.ui.treeView1.Nodes[0] : plug.ui.treeView1.Nodes[1], t);
                if ((filter & SearchFilterEnum.TriggerId) != 0)
                {
                    if (RegexMatches(rex, t.Id.ToString()) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittriggerid", "Trigger ID"), Match = tn });
                }
                if ((filter & SearchFilterEnum.TriggerName) != 0)
                {
                    if (RegexMatches(rex, t.Name) == true)
                    {
                        results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittriggername", "Trigger name"), Match = tn });
                    }
                    else if ((filter & SearchFilterEnum.TriggerFullPath) != 0)
                    {
                        if (RegexMatches(rex, t.FullPath) == true)
                        {
                            results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitfullpath", "Trigger full path"), Match = tn });
                        }
                    }
                }
                else if ((filter & SearchFilterEnum.TriggerFullPath) != 0)
                {
                    if (RegexMatches(rex, t.FullPath) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitfullpath", "Trigger full path"), Match = tn });
                }
                if ((filter & SearchFilterEnum.TriggerDescription) != 0)
                {
                    if (RegexMatches(rex, t._Description) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittriggerdesc", "Trigger description"), Match = tn });
                }
                if ((filter & SearchFilterEnum.TriggerCondition) != 0)
                {
                    if (ConditionMatches(rex, t._Condition) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittriggercond", "Trigger condition"), Match = tn });
                }
                if ((filter & SearchFilterEnum.TriggerRegex) != 0)
                {
                    if (RegexMatches(rex, t.RegularExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittriggerregex", "Trigger regular expression"), Match = tn });
                }
                int i = 1;
                foreach (Action a in t.Actions)
                {
                    if ((filter & SearchFilterEnum.ActionDescription) != 0)
                    {
                        if (RegexMatches(rex, a.GetDescription(ctx)) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitactiondesc", "Action #{0} description", i), Match = tn });
                    }
                    if ((filter & SearchFilterEnum.ActionCondition) != 0)
                    {
                        if (ConditionMatches(rex, a._Condition) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitactioncond", "Action #{0} condition", i), Match = tn });
                    }
                    if ((filter & SearchFilterEnum.ActionDetails) != 0)
                    {
                        if (RegexMatches(rex, a._ExecutionDelayExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitexecdelay", "Action #{0} execution delay", i), Match = tn });
                        if (a._ActionType == Action.ActionTypeEnum.Aura)
                        {
                            if (RegexMatches(rex, a._AuraImage) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitimgaurasrc", "Action #{0} image aura source", i), Match = tn });
                            if (RegexMatches(rex, a._AuraName) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitimgauraname", "Action #{0} image aura name", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.DiscordWebhook)
                        {
                            if (RegexMatches(rex, a._DiscordWebhookURL) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitdiscordurl", "Action #{0} Discord webhook URL", i), Match = tn });
                            if (RegexMatches(rex, a._DiscordWebhookMessage) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitdiscordmsg", "Action #{0} Discord webhook message", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.ExecuteScript)
                        {
                            if (RegexMatches(rex, a._ExecScriptAssembliesExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitscriptassy", "Action #{0} script assemblies", i), Match = tn });
                            if (RegexMatches(rex, a._ExecScriptExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitscriptcode", "Action #{0} script", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.Folder)
                        {
                            if (RegexMatches(rex, a._FolderId.ToString()) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitactionfolderid", "Action #{0} folder ID", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.GenericJson)
                        {
                            if (RegexMatches(rex, a._JsonEndpointExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitjsonendpoint", "Action #{0} JSON endpoint", i), Match = tn });
                            if (RegexMatches(rex, a._JsonFiringExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitjsonfiring", "Action #{0} JSON firing expression", i), Match = tn });
                            if (RegexMatches(rex, a._JsonPayloadExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitjsonpayload", "Action #{0} JSON payload expression", i), Match = tn });
                            if (RegexMatches(rex, a._JsonHeaderExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitjsonheaders", "Action #{0} JSON header expression", i), Match = tn });
                            if (RegexMatches(rex, a._JsonResultVariable) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitjsonvariable", "Action #{0} JSON result variable", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.KeyPress)
                        {
                            if (RegexMatches(rex, a._KeyPressCode) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitkeypresscode", "Action #{0} keypress code", i), Match = tn });
                            if (RegexMatches(rex, a._KeyPressExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitkeypressexpression", "Action #{0} keypress expression", i), Match = tn });
                            if (RegexMatches(rex, a._KeyPressWindow) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitkeypresswindow", "Action #{0} keypress window", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.LaunchProcess)
                        {
                            if (RegexMatches(rex, a._LaunchProcessCmdlineExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitproccmdline", "Action #{0} command line expression", i), Match = tn });
                            if (RegexMatches(rex, a._LaunchProcessPathExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitpathexpr", "Action #{0} command line path", i), Match = tn });
                            if (RegexMatches(rex, a._LaunchProcessWorkingDirExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitworkingdir", "Action #{0} working directory", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.ListVariable)
                        {
                            if (RegexMatches(rex, a._ListVariableExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitlistexpr", "Action #{0} list variable expression", i), Match = tn });
                            if (RegexMatches(rex, a._ListVariableIndex) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitlistindex", "Action #{0} list variable index", i), Match = tn });
                            if (RegexMatches(rex, a._ListVariableName) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitlistname", "Action #{0} list variable name", i), Match = tn });
                            if (RegexMatches(rex, a._ListVariableTarget) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitlisttarget", "Action #{0} list variable target", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.LogMessage)
                        {
                            if (RegexMatches(rex, a._LogMessageText) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitlogtext", "Action #{0} log text", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.MessageBox)
                        {
                            if (RegexMatches(rex, a._MessageBoxText) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitmsgboxtext", "Action #{0} message box text", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.ObsControl)
                        {
                            if (RegexMatches(rex, a._OBSSceneName) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitobsscene", "Action #{0} OBS scene name", i), Match = tn });
                            if (RegexMatches(rex, a._OBSSourceName) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitobssource", "Action #{0} OBS source name", i), Match = tn });
                            if (RegexMatches(rex, a._OBSEndPoint) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitobsendpoint", "Action #{0} OBS endpoint", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.PlaySound)
                        {
                            if (RegexMatches(rex, a._PlaySoundFileExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitsfxfile", "Action #{0} sound file", i), Match = tn });
                            if (RegexMatches(rex, a._PlaySoundVolumeExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitsfxvol", "Action #{0} sound volume", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.SystemBeep)
                        {
                            if (RegexMatches(rex, a._SystemBeepFreqExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitbeepfreq", "Action #{0} beep frequency", i), Match = tn });
                            if (RegexMatches(rex, a._SystemBeepLengthExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitbeeplen", "Action #{0} beep length", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.TextAura)
                        {
                            if (RegexMatches(rex, a._TextAuraExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittextauraexpr", "Action #{0} text aura expression", i), Match = tn });
                            if (RegexMatches(rex, a._TextAuraFontName) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittextaurafont", "Action #{0} text aura font", i), Match = tn });
                            if (RegexMatches(rex, a._TextAuraName) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittextauraname", "Action #{0} text aura name", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.Trigger)
                        {
                            if (RegexMatches(rex, a._TriggerId.ToString()) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitactiontriggerid", "Action #{0} trigger ID", i), Match = tn });
                            if (RegexMatches(rex, a._TriggerText) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitactiontriggertext", "Action #{0} trigger firing text", i), Match = tn });
                            if (RegexMatches(rex, a._TriggerZone) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hittriggerzone", "Action #{0} trigger firing zone", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.UseTTS)
                        {
                            if (RegexMatches(rex, a._UseTTSRateExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitttsexpr", "Action #{0} TTS rate", i), Match = tn });
                            if (RegexMatches(rex, a._UseTTSTextExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitttstext", "Action #{0} TTS text", i), Match = tn });
                            if (RegexMatches(rex, a._UseTTSVolumeExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitttsvol", "Action #{0} TTS volume", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.Variable)
                        {
                            if (RegexMatches(rex, a._VariableExpression) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitvarexpr", "Action #{0} variable expression", i), Match = tn });
                            if (RegexMatches(rex, a._VariableName) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitvarname", "Action #{0} variable name", i), Match = tn });
                            if (RegexMatches(rex, a._VariableJsonTarget) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitvarjsontarget", "Action #{0} variable JSON query target", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.WindowMessage)
                        {
                            if (RegexMatches(rex, a._WmsgTitle) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitwmsgtitle", "Action #{0} window message title", i), Match = tn });
                        }
                        if (a._ActionType == Action.ActionTypeEnum.DiskFile)
                        {
                            if (RegexMatches(rex, a._DiskFileOpName) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitdiskfilename", "Action #{0} disk operation file name", i), Match = tn });
                            if (RegexMatches(rex, a._DiskFileOpVar) == true) results.Add(new SearchResult(t) { MatchType = I18n.Translate("internal/SearchForm/hitdiskfilevar", "Action #{0} disk operation variable name", i), Match = tn });
                        }
                    }
                    i++;
                }
            }
            foreach (Folder sf in f.Folders)
            {
                results.AddRange(SearchIn(sf, ctx, rex, filter));
            }
            return results;
        }

        public List<SearchResult> Search(string text, SearchFilterEnum filter)
        {
            List<SearchResult> results = new List<SearchResult>();
            Context ctx = new Context();
            ctx.plug = plug;
            try
            {
                pathPrefix = I18n.Translate("internal/Configuration/local", "Local triggers") + @"\";
                Regex rex = new Regex(text, RegexOptions.IgnoreCase);
                if ((filter & SearchFilterEnum.ScopeLocal) != 0)
                {
                    results.AddRange(SearchIn(plug.cfg.Root, ctx, rex, filter));
                }
                if ((filter & SearchFilterEnum.Scoperemote) != 0)
                {
                    foreach (Repository r in plug.cfg.RepositoryRoot.Repositories)
                    {
                        pathPrefix = I18n.Translate("internal/Configuration/remote", "Remote triggers") + @"\" + r.Name + @"\";
                        if ((filter & SearchFilterEnum.IncludeDisabled) == 0 && r.Enabled == false)
                        {
                            continue;
                        }
                        if ((filter & SearchFilterEnum.RepoName) != 0)
                        {
                            if (RegexMatches(rex, r.Name) == true) results.Add(new SearchResult(r) { MatchType = I18n.Translate("internal/SearchForm/hitreponame", "Repository name") });
                        }
                        if ((filter & SearchFilterEnum.RepoAddress) != 0)
                        {
                            if (RegexMatches(rex, r.Address) == true) results.Add(new SearchResult(r) { MatchType = I18n.Translate("internal/SearchForm/hitrepoaddress", "Repository address") });
                        }
                        results.AddRange(SearchIn(r.Root, ctx, rex, filter));
                    }
                }
            }
            catch (Exception)
            {
            }
            return results;
        }

        private SearchFilterEnum GetFilter()
        {
            SearchFilterEnum filter = 0;
            foreach (int i in clbTriggers.CheckedIndices)
            {
                if (i == 0) filter |= SearchFilterEnum.TriggerId;
                if (i == 1) filter |= SearchFilterEnum.TriggerName;
                if (i == 2) filter |= SearchFilterEnum.TriggerDescription;
                if (i == 3) filter |= SearchFilterEnum.TriggerCondition;
                if (i == 4) filter |= SearchFilterEnum.TriggerFullPath;
                if (i == 5) filter |= SearchFilterEnum.TriggerRegex;
            }
            foreach (int i in clbActions.CheckedIndices)
            {
                if (i == 0) filter |= SearchFilterEnum.ActionDescription;
                if (i == 1) filter |= SearchFilterEnum.ActionCondition;
                if (i == 2) filter |= SearchFilterEnum.ActionDetails;
            }
            foreach (int i in clbRepos.CheckedIndices)
            {
                if (i == 0) filter |= SearchFilterEnum.RepoName;
                if (i == 1) filter |= SearchFilterEnum.RepoAddress;
            }
            foreach (int i in clbScope.CheckedIndices)
            {
                if (i == 0) filter |= SearchFilterEnum.ScopeLocal;
                if (i == 1) filter |= SearchFilterEnum.Scoperemote;
            }
            foreach (int i in clbMisc.CheckedIndices)
            {
                if (i == 0) filter |= SearchFilterEnum.FolderName;
                if (i == 1) filter |= SearchFilterEnum.IncludeDisabled;
            }
            return filter;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchFilterEnum filter = GetFilter();
            List<SearchResult> res = Search(expSearchTerm.Expression, filter);
            List<DataGridViewRow> rrs = new List<DataGridViewRow>();
            statusStrip1.Visible = false;
            lblResultInfo.Visible = false;
            dgvResults.Rows.Clear();
            foreach (SearchResult sr in res)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvResults, new object[] { sr.MatchItem, sr.MatchType });
                r.Tag = sr;
                rrs.Add(r);
            }
            dgvResults.Rows.AddRange(rrs.ToArray());
            switch (rrs.Count)
            {
                case 0:
                    lblResultInfo.Text = I18n.Translate("internal/SearchForm/noresults", "No results");
                    break;
                case 1:
                    lblResultInfo.Text = I18n.Translate("internal/SearchForm/oneresult", "One result");
                    break;
                default:
                    lblResultInfo.Text = I18n.Translate("internal/SearchForm/xresults", "{0} results", rrs.Count);
                    break;
            }
            lblResultInfo.Visible = true;
            statusStrip1.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clbTriggers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((CheckedListBox)sender).ClearSelected();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            ChangeAll(true);
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            ChangeAll(false);
        }

        private void ChangeAll(bool setting)
        {
            ChangeAll(clbActions, setting);
            ChangeAll(clbMisc, setting);
            ChangeAll(clbRepos, setting);
            ChangeAll(clbScope, setting);
            ChangeAll(clbTriggers, setting);
        }

        private void ChangeAll(CheckedListBox clb, bool setting)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, setting);
            }
        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgvResults.SelectedRows[0];
            SearchResult sr = (SearchResult)r.Tag;
            if (sr == null)
            {
                return;
            }
            if (sr.Match != null)
            {
                plug.ui.LocateTreeNode(sr.Match);
            }
        }

    }

}
