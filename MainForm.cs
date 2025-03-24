using System;
using System.Windows.Forms;

namespace MimicMuseAI
{
    public partial class MainForm : Form
    {
        private Panel mainPanel;

        public MainForm()
        {
            InitializeComponent();
            InitializeMenu();
            InitializeMainPanel();
        }

        private void InitializeComponent()
        {
            this.mainPanel = new Panel();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "MainForm";
            this.Text = "MimicMuseAI";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem bookWriterMenuItem = new ToolStripMenuItem("Book Writer");
            ToolStripMenuItem chatMenuItem = new ToolStripMenuItem("Chat");
            ToolStripMenuItem loreBookMenuItem = new ToolStripMenuItem("LoreBook");
            ToolStripMenuItem settingsMenuItem = new ToolStripMenuItem("Settings");

            bookWriterMenuItem.Click += (sender, e) => ShowControl(new BookWriterControl());
            chatMenuItem.Click += (sender, e) => ShowControl(new ChatControl());
            loreBookMenuItem.Click += (sender, e) => ShowControl(new LoreBookControl());
            settingsMenuItem.Click += (sender, e) => ShowControl(new SettingsControl());

            menuStrip.Items.Add(bookWriterMenuItem);
            menuStrip.Items.Add(chatMenuItem);
            menuStrip.Items.Add(loreBookMenuItem);
            menuStrip.Items.Add(settingsMenuItem);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void InitializeMainPanel()
        {
            ShowControl(new GreetingControl()); // Show greeting control by default
        }

        private void ShowControl(UserControl control)
        {
            mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }
    }
}