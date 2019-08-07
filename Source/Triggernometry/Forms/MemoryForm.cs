using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public class MemoryForm<T> : Form
    {

        internal static bool SavedSet { get; set; } = false;
        internal static int SavedWidth { get; set; }
        internal static int SavedHeight { get; set; }

        public MemoryForm()
        {
            FormClosing += MemoryForm_FormClosing;
        }

        protected void RestoredSavedDimensions()
        {
            I18n.TranslateForm(this);
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
