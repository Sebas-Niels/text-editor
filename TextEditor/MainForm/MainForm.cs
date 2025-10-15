using TextEditor;

namespace MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            new SplashForm().ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void stringOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxBody_TextChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void uppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uppercase();
        }

        private void lowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lowercase();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertDate();
        }

        private void aboutCoolEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About();
        }
    }
}
