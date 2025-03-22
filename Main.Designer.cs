using System;
using System.Windows.Forms;

namespace MimicMuseAI
{
    public partial class Main : Form
    {
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TextBox MainTextDisplay;
        private System.Windows.Forms.TextBox promptInput;
        private System.Windows.Forms.Button buttonSubmit;

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            MainTextDisplay = new TextBox();
            promptInput = new TextBox();
            buttonSubmit = new Button();
            loreBookToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, loreBookToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // MainTextDisplay
            // 
            MainTextDisplay.Dock = DockStyle.Fill;
            MainTextDisplay.Location = new Point(0, 24);
            MainTextDisplay.Multiline = true;
            MainTextDisplay.Name = "MainTextDisplay";
            MainTextDisplay.Size = new Size(800, 373);
            MainTextDisplay.TabIndex = 1;
            // 
            // promptInput
            // 
            promptInput.Dock = DockStyle.Bottom;
            promptInput.Location = new Point(0, 397);
            promptInput.Name = "promptInput";
            promptInput.Size = new Size(800, 23);
            promptInput.TabIndex = 2;
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
            // loreBookToolStripMenuItem
            // 
            loreBookToolStripMenuItem.Name = "loreBookToolStripMenuItem";
            loreBookToolStripMenuItem.Size = new Size(180, 22);
            loreBookToolStripMenuItem.Text = "LoreBook";
            loreBookToolStripMenuItem.Click += loreBookToolStripMenuItem_Click;
            // 
            // Main
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(MainTextDisplay);
            Controls.Add(promptInput);
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
        private ToolStripMenuItem loreBookToolStripMenuItem;
    }
}
