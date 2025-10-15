namespace MainForm
{
    using System;
    using System.IO;
    using TextEditor;

    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public bool IsDirty { get; set; }

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void OpenFile()
        {
            if (IsDirty && MessageBox.Show("Do you want to open a new file without saving your current changes?",
                "You may lose unsaved changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) { return; }

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = dlgOpenFile.FileName;

                try
                {
                    txtBoxBody.Text = File.ReadAllText(filePath);
                    IsDirty = false;
                    dlgSaveFile.FileName = dlgOpenFile.FileName;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error opening the file '{filePath}'. " +
                        $"Error was '{e.Message}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SaveFile()
        {
            string filePath = dlgSaveFile.FileName;

            if (!File.Exists(filePath) || (File.Exists(filePath) &&
                MessageBox.Show($"File '{filePath}' exists... overwrite?") == DialogResult.OK))
            {
                try
                {
                    File.WriteAllText(filePath, txtBoxBody.Text);
                    IsDirty = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error saving to the file '{filePath}'. " +
                        $"Error was '{e.Message}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CloseFile()
        {
            if (IsDirty && MessageBox.Show("Do you want to close the file without saving your changes?",
                "You may lose unsaved changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                txtBoxBody.Text = "";
                IsDirty = false;
            }
        }
        private void Exit()
        {
            if (IsDirty && MessageBox.Show("Do you want to close the file without saving your changes?",
                "You may lose unsaved changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void Cut()
        {
            Clipboard.SetText(txtBoxBody.SelectedText);
            txtBoxBody.SelectedText = "";
        }
        private void Copy()
        {
            Clipboard.SetText(txtBoxBody.SelectedText);
        }
        private void Paste()
        {
            txtBoxBody.SelectedText = Clipboard.GetText();
        }
        private void Uppercase()
        {
            txtBoxBody.SelectedText = txtBoxBody.SelectedText.ToUpper();
        }
        private void Lowercase()
        {
            txtBoxBody.SelectedText = txtBoxBody.SelectedText.ToLower();
        }
        private void InsertDate()
        {
            txtBoxBody.SelectedText = DateTime.Now.ToShortDateString();
        }
        private void About()
        {
            new AboutForm().ShowDialog();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            stringOperationsToolStripMenuItem = new ToolStripMenuItem();
            uppercaseToolStripMenuItem = new ToolStripMenuItem();
            lowercaseToolStripMenuItem = new ToolStripMenuItem();
            insertToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutCoolEditToolStripMenuItem = new ToolStripMenuItem();
            txtBoxBody = new TextBox();
            dlgOpenFile = new OpenFileDialog();
            dlgSaveFile = new SaveFileDialog();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, closeToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(168, 22);
            openToolStripMenuItem.Text = "Open file";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(168, 22);
            saveToolStripMenuItem.Text = "Save file";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F4;
            closeToolStripMenuItem.Size = new Size(168, 22);
            closeToolStripMenuItem.Text = "Close file";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(168, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, stringOperationsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(180, 22);
            cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(180, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(180, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // stringOperationsToolStripMenuItem
            // 
            stringOperationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uppercaseToolStripMenuItem, lowercaseToolStripMenuItem, insertToolStripMenuItem });
            stringOperationsToolStripMenuItem.Name = "stringOperationsToolStripMenuItem";
            stringOperationsToolStripMenuItem.Size = new Size(180, 22);
            stringOperationsToolStripMenuItem.Text = "String operations";
            stringOperationsToolStripMenuItem.Click += stringOperationsToolStripMenuItem_Click;
            // 
            // uppercaseToolStripMenuItem
            // 
            uppercaseToolStripMenuItem.Name = "uppercaseToolStripMenuItem";
            uppercaseToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.U;
            uppercaseToolStripMenuItem.Size = new Size(204, 22);
            uppercaseToolStripMenuItem.Text = "Uppercase";
            uppercaseToolStripMenuItem.Click += uppercaseToolStripMenuItem_Click;
            // 
            // lowercaseToolStripMenuItem
            // 
            lowercaseToolStripMenuItem.Name = "lowercaseToolStripMenuItem";
            lowercaseToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.L;
            lowercaseToolStripMenuItem.Size = new Size(204, 22);
            lowercaseToolStripMenuItem.Text = "Lowercase";
            lowercaseToolStripMenuItem.Click += lowercaseToolStripMenuItem_Click;
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.D;
            insertToolStripMenuItem.Size = new Size(204, 22);
            insertToolStripMenuItem.Text = "Insert Date";
            insertToolStripMenuItem.Click += insertToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutCoolEditToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutCoolEditToolStripMenuItem
            // 
            aboutCoolEditToolStripMenuItem.Name = "aboutCoolEditToolStripMenuItem";
            aboutCoolEditToolStripMenuItem.Size = new Size(180, 22);
            aboutCoolEditToolStripMenuItem.Text = "About CoolEdit";
            aboutCoolEditToolStripMenuItem.Click += aboutCoolEditToolStripMenuItem_Click;
            // 
            // txtBoxBody
            // 
            txtBoxBody.Dock = DockStyle.Fill;
            txtBoxBody.Font = new Font("Consolas", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxBody.Location = new Point(0, 24);
            txtBoxBody.Multiline = true;
            txtBoxBody.Name = "txtBoxBody";
            txtBoxBody.Size = new Size(800, 426);
            txtBoxBody.TabIndex = 1;
            txtBoxBody.Text = "No file opened yet... Press \"CTRL + O\" to open a text file.\"";
            txtBoxBody.TextChanged += txtBoxBody_TextChanged;
            // 
            // dlgOpenFile
            // 
            dlgOpenFile.Filter = "Text files|*.txt|All files|*.*";
            dlgOpenFile.Title = "Open file...";
            // 
            // dlgSaveFile
            // 
            dlgSaveFile.Filter = "Text files|*.txt|All files|*.*";
            dlgSaveFile.Title = "Save file...";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBoxBody);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "TextEditor";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem stringOperationsToolStripMenuItem;
        private ToolStripMenuItem uppercaseToolStripMenuItem;
        private ToolStripMenuItem lowercaseToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripMenuItem aboutCoolEditToolStripMenuItem;
        private TextBox txtBoxBody;
        private OpenFileDialog dlgOpenFile;
        private SaveFileDialog dlgSaveFile;
    }

    
}
