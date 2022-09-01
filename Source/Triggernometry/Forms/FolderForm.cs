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

namespace Triggernometry.Forms
{

    public partial class FolderForm : MemoryForm<FolderForm>
    {

        public RealPlugin plug;

        public class ClassLink
        {

            public string name;
            public Int64 id;

            public ClassLink(string name, Int64 id)
            {
                this.name = name;
                this.id = id;
            }

            public override string ToString()
            {
                return name;
            }

        }

        private void AddClass(string name, Int64 id)
        {
            ClassLink cl = new ClassLink(name, id);
            chkFfxivClassFilter.Items.Add(cl);
        }

        public FolderForm()
        {
            InitializeComponent();
            AddClass("Job: Astrologian", 33);
            AddClass("Job: Bard", 23);
            AddClass("Job: Black Mage", 25);
            AddClass("Job: Blue Mage", 36);
            AddClass("Job: Dancer", 38);
            AddClass("Job: Dark Knight", 32);
            AddClass("Job: Dragoon", 22);
            AddClass("Job: Gunbreaker", 37);
            AddClass("Job: Machinist", 31);
            AddClass("Job: Monk", 20);
            AddClass("Job: Ninja", 30);
            AddClass("Job: Paladin", 19);
            AddClass("Job: Reaper", 39);
            AddClass("Job: Red Mage", 35);
            AddClass("Job: Sage", 40);
            AddClass("Job: Samurai", 34);
            AddClass("Job: Scholar", 28);
            AddClass("Job: Summoner", 27);
            AddClass("Job: Warrior", 21);
            AddClass("Job: White Mage", 24);
            AddClass("Crafter: Alchemist", 14);
            AddClass("Crafter: Armorer", 10);
            AddClass("Crafter: Blacksmith", 9);
            AddClass("Crafter: Carpenter", 8);
            AddClass("Crafter: Culinarian", 15);
            AddClass("Crafter: Goldsmith", 11);
            AddClass("Crafter: Leatherworker", 12);
            AddClass("Crafter: Weaver", 13);
            AddClass("Gatherer: Botanist", 17);
            AddClass("Gatherer: Fisher", 18);
            AddClass("Gatherer: Miner", 16);
            AddClass("Class: Arcanist", 26);
            AddClass("Class: Archer", 5);
            AddClass("Class: Conjurer", 6);
            AddClass("Class: Gladiator", 1);
            AddClass("Class: Lancer", 4);
            AddClass("Class: Marauder", 3);
            AddClass("Class: Pugilist", 2);
            AddClass("Class: Rogue", 29);
            AddClass("Class: Thaumaturge", 7);
            RestoredSavedDimensions();
        }

        internal void SetReadOnly()
        {
            btnOk.Enabled = false;
            btnOk.Visible = false;
            btnCancel.Dock = DockStyle.Fill;
            panel5.Visible = true;
            txtFolderName.ReadOnly = true;
            chkZoneFilter.Enabled = false;
            btnGetCurZone.Enabled = false;
            chkEventFilter.Enabled = false;
            chkFfxivClassFilter.SelectionMode = SelectionMode.None;
            chkFfxivClassFilterEnabled.Enabled = false;
            txtZoneFilterRegex.ReadOnly = true;
            txtEventFilterRegex.ReadOnly = true;
            chkFfxivZoneFilter.Enabled = false;
            txtFfxivZoneFilterRegex.Enabled = false;
        }

        internal void JobFilterFromInt(Int64 val)
        {
            //System.Diagnostics.Debug.WriteLine("opening filter = " + val);
            List<int> indices = new List<int>();
            for (int id = 1; id < 60; id++)
            {
                Int64 shifted = ((Int64)1) << (id - 1);
                if ((val & shifted) != 0)
                {
                    int listidx = 0;
                    foreach (object ob in chkFfxivClassFilter.Items)
                    {
                        ClassLink cl = (ClassLink)ob;
                        if (cl.id == id)
                        {
                            //System.Diagnostics.Debug.WriteLine(shifted + " --> " + cl.id + " = " + cl.name);
                            indices.Add(listidx);
                        }
                        listidx++;
                    }
                }
            }
            foreach (int index in indices)
            {
                chkFfxivClassFilter.SetItemChecked(index, true);
            }
        }

        internal Int64 JobfilterToInt()
        {
            Int64 fifi = 0;
            foreach (int ci in chkFfxivClassFilter.CheckedIndices)
            {
                object ob = chkFfxivClassFilter.Items[ci];
                ClassLink cl = (ClassLink)ob;
                Int64 num = ((Int64)1) << (int)(cl.id - 1);
                //System.Diagnostics.Debug.WriteLine(cl.name + " = " + cl.id + " --> " + num);
                fifi |= num;
            }
            //System.Diagnostics.Debug.WriteLine("final filter = " + fifi);
            return fifi;
        }        

        internal void SettingsFromFolder(Folder f)
        {
            if (f == null)
            {
				txtFolderName.Text = "";
                chkZoneFilter.Checked = false;
                chkEventFilter.Checked = false;
                txtZoneFilterRegex.Text = "";
                txtEventFilterRegex.Text = "";
                chkFfxivClassFilterEnabled.Checked = false;
                chkFfxivClassFilter.ClearSelected();
                chkFfxivZoneFilter.Checked = false;
                txtFfxivZoneFilterRegex.Text = "";
            }
            else
            { 
                txtFolderName.Text = f.Name;
				chkZoneFilter.Checked = f._ZoneFilterEnabled;
				chkEventFilter.Checked = f._EventFilterEnabled;
				txtZoneFilterRegex.Text = f.ZoneFilterRegularExpression;
				txtEventFilterRegex.Text = f.EventFilterRegularExpression;
                chkFfxivClassFilterEnabled.Checked = f._FFXIVJobFilterEnabled;
                chkFfxivZoneFilter.Checked = f._FFXIVZoneFilterEnabled;
                JobFilterFromInt(f._FFXIVJobFilter);
                txtFfxivZoneFilterRegex.Text = f.FfxivZoneFilterRegularExpression;
            }
        }

        internal void SettingsToFolder(Folder f)
        {
            f.Name = txtFolderName.Text;
			f._ZoneFilterEnabled = chkZoneFilter.Checked;
			f._EventFilterEnabled = chkEventFilter.Checked;
			f.ZoneFilterRegularExpression = txtZoneFilterRegex.Text;
			f.EventFilterRegularExpression = txtEventFilterRegex.Text;
            f._FFXIVJobFilterEnabled = chkFfxivClassFilterEnabled.Checked;
            f._FFXIVJobFilter = JobfilterToInt();
            f._FFXIVZoneFilterEnabled = chkFfxivZoneFilter.Checked;
            f.FfxivZoneFilterRegularExpression = txtFfxivZoneFilterRegex.Text;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = (txtFolderName.TextLength > 0);
        }

        private void chkZoneFilter_CheckedChanged(object sender, EventArgs e)
        {
            txtZoneFilterRegex.Enabled = chkZoneFilter.Checked;
            btnGetCurZone.Enabled = chkZoneFilter.Checked;
        }

        private void chkEventFilter_CheckedChanged(object sender, EventArgs e)
        {
            txtEventFilterRegex.Enabled = chkEventFilter.Checked;
        }

        private void chkFfxivClassFilterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            chkFfxivClassFilter.SelectionMode = chkFfxivClassFilterEnabled.Checked ? SelectionMode.One : SelectionMode.None;
        }

        private void btnGetCurZone_Click(object sender, EventArgs e)
        {
            txtZoneFilterRegex.Text = "^" + Regex.Escape(plug.CurrentZoneHook()) + "$";
        }

        private void chkFfxivClassFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkFfxivClassFilter.ClearSelected();
        }

        private void btnGetCurFfxivZone_Click(object sender, EventArgs e)
        {
            txtFfxivZoneFilterRegex.Text = "^" + PluginBridges.BridgeFFXIV.ZoneID.ToString() + "$";
        }

        private void chkFfxivZoneFilter_CheckedChanged(object sender, EventArgs e)
        {
            txtFfxivZoneFilterRegex.Enabled = chkFfxivZoneFilter.Checked;
            btnGetCurFfxivZone.Enabled = chkFfxivZoneFilter.Checked;
        }

    }

}
