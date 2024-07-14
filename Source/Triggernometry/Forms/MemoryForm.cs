using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Triggernometry.CustomControls;

namespace Triggernometry.Forms
{

    public class MemoryForm<T> : Form
    {

        internal static bool SavedSet { get; set; } = false;
        internal static int SavedWidth { get; set; }
        internal static int SavedHeight { get; set; }

        private Font _FontOverride = null;

        public MemoryForm()
        {
            FormClosing += MemoryForm_FormClosing;
            Disposed += MemoryForm_Disposed;
        }

        private void MemoryForm_Disposed(object sender, EventArgs e)
        {
            if (_FontOverride != null)
            {
                _FontOverride.Dispose();
                _FontOverride = null;
            }
        }

        protected void RestoredSavedDimensions()
        {
            I18n.TranslateForm(this);
            Configuration cfg = RealPlugin.plug.cfg;
            if (cfg.UiFontDefault == false)
            {
                try
                {
                    _FontOverride = RealPlugin.CreateFontFromDefinition(cfg.UiFontName, cfg.UiFontSize, cfg.UiFontEffect);
                    RealPlugin.ApplyFontOverrideToForm(this, _FontOverride);
                }
                catch (Exception)
                {
                }
            }
            MaximizeBox = false;
            MinimizeBox = false;
            if (SavedSet == true)
            {
                Width = SavedWidth;
                Height = SavedHeight;
            }
        }

        private void MemoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavedSet = true;
            SavedWidth = Width;
            SavedHeight = Height;
        }

    }

}
