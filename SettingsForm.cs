﻿using System;
using System.Windows.Forms;

namespace MimicMuseAI
{
    public partial class SettingsForm : Form
    {
        private SettingsManager _settingsManager;

        public SettingsForm()
        {
            InitializeComponent();
            _settingsManager = SettingsManager.Instance;
            LoadSettings();
        }

        private void InitializeComponent()
        {
            openAPIUrl = new TextBox();
            label1 = new Label();
            label2 = new Label();
            openAPIModel = new TextBox();
            label3 = new Label();
            openAPIKey = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // openAPIUrl
            // 
            openAPIUrl.Location = new Point(69, 34);
            openAPIUrl.Name = "openAPIUrl";
            openAPIUrl.Size = new Size(380, 27);
            openAPIUrl.TabIndex = 0;
            openAPIUrl.Leave += new EventHandler(TextBox_Leave);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 37);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 1;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 70);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 3;
            label2.Text = "Model";
            // 
            // openAPIModel
            // 
            openAPIModel.Location = new Point(69, 67);
            openAPIModel.Name = "openAPIModel";
            openAPIModel.Size = new Size(380, 27);
            openAPIModel.TabIndex = 2;
            openAPIModel.Leave += new EventHandler(TextBox_Leave);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 97);
            label3.Name = "label3";
            label3.Size = new Size(268, 20);
            label3.TabIndex = 5;
            label3.Text = "API key (USE ENVIRONMENT VARIABLE)";
            // 
            // openAPIKey
            // 
            openAPIKey.Location = new Point(287, 97);
            openAPIKey.Name = "openAPIKey";
            openAPIKey.Size = new Size(162, 27);
            openAPIKey.TabIndex = 4;
            openAPIKey.Leave += new EventHandler(TextBox_Leave);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(124, 11);
            label4.Name = "label4";
            label4.Size = new Size(169, 20);
            label4.TabIndex = 6;
            label4.Text = "OpenAI compatible API";
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(openAPIUrl);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(openAPIKey);
            panel1.Controls.Add(openAPIModel);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 144);
            panel1.TabIndex = 7;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(791, 489);
            Controls.Add(panel1);
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            openAPIUrl.Text = _settingsManager.OpenAPIUrl;
            openAPIModel.Text = _settingsManager.OpenAPIModel;
            openAPIKey.Text = _settingsManager.OpenAPIKey;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender == openAPIUrl)
            {
                _settingsManager.SaveSetting("URL", openAPIUrl.Text);
            }
            else if (sender == openAPIModel)
            {
                _settingsManager.SaveSetting("Model", openAPIModel.Text);
            }
            else if (sender == openAPIKey)
            {
                _settingsManager.SaveSetting("APIKey", openAPIKey.Text);
            }
        }

        private TextBox openAPIUrl;
        private Label label1;
        private Label label2;
        private TextBox openAPIModel;
        private Label label3;
        private TextBox openAPIKey;
        private Panel panel1;
        private Label label4;
    }
}