using System;
using System.Windows.Forms;

namespace MimicMuseAI
{
    public partial class Main : Form
    {
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.Button buttonSubmit;

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            textBoxMain = new TextBox();
            textBoxPrompt = new TextBox();
            buttonSubmit = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(224, 26);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // textBoxMain
            // 
            textBoxMain.Dock = DockStyle.Fill;
            textBoxMain.Location = new Point(0, 28);
            textBoxMain.Multiline = true;
            textBoxMain.Name = "textBoxMain";
            textBoxMain.Size = new Size(800, 365);
            textBoxMain.TabIndex = 1;
            // 
            // textBoxPrompt
            // 
            textBoxPrompt.Dock = DockStyle.Bottom;
            textBoxPrompt.Location = new Point(0, 393);
            textBoxPrompt.Name = "textBoxPrompt";
            textBoxPrompt.Size = new Size(800, 27);
            textBoxPrompt.TabIndex = 2;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Dock = DockStyle.Bottom;
            buttonSubmit.Location = new Point(0, 420);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(800, 30);
            buttonSubmit.TabIndex = 3;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += ButtonSubmit_Click;
            // 
            // Main
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxMain);
            Controls.Add(textBoxPrompt);
            Controls.Add(buttonSubmit);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "MimicMuseAI";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
