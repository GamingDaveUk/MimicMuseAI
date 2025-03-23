using System;
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
            panel2 = new Panel();
            replyTokenLimit = new TextBox();
            label9 = new Label();
            label8 = new Label();
            LoreBookbudget = new TextBox();
            label7 = new Label();
            contextTokenLimit = new TextBox();
            label6 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // openAPIUrl
            // 
            openAPIUrl.Location = new Point(69, 34);
            openAPIUrl.Name = "openAPIUrl";
            openAPIUrl.Size = new Size(380, 23);
            openAPIUrl.TabIndex = 0;
            openAPIUrl.Leave += TextBox_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 37);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 1;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 70);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 3;
            label2.Text = "Model";
            // 
            // openAPIModel
            // 
            openAPIModel.Location = new Point(69, 67);
            openAPIModel.Name = "openAPIModel";
            openAPIModel.Size = new Size(380, 23);
            openAPIModel.TabIndex = 2;
            openAPIModel.Leave += TextBox_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 97);
            label3.Name = "label3";
            label3.Size = new Size(217, 15);
            label3.TabIndex = 5;
            label3.Text = "API key (USE ENVIRONMENT VARIABLE)";
            // 
            // openAPIKey
            // 
            openAPIKey.Location = new Point(287, 97);
            openAPIKey.Name = "openAPIKey";
            openAPIKey.Size = new Size(162, 23);
            openAPIKey.TabIndex = 4;
            openAPIKey.Leave += TextBox_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(124, 11);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
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
            // panel2
            // 
            panel2.Controls.Add(replyTokenLimit);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(LoreBookbudget);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(contextTokenLimit);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(12, 162);
            panel2.Name = "panel2";
            panel2.Size = new Size(465, 148);
            panel2.TabIndex = 7;
            // 
            // replyTokenLimit
            // 
            replyTokenLimit.Location = new Point(127, 104);
            replyTokenLimit.Name = "replyTokenLimit";
            replyTokenLimit.Size = new Size(103, 23);
            replyTokenLimit.TabIndex = 12;
            replyTokenLimit.Text = "2096";
            replyTokenLimit.TextChanged += replyTokenLimit_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 107);
            label9.Name = "label9";
            label9.Size = new Size(101, 15);
            label9.TabIndex = 13;
            label9.Text = "Max Reply Tokens";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(236, 74);
            label8.Name = "label8";
            label8.Size = new Size(17, 15);
            label8.TabIndex = 11;
            label8.Text = "%";
            // 
            // LoreBookbudget
            // 
            LoreBookbudget.Location = new Point(127, 71);
            LoreBookbudget.Name = "LoreBookbudget";
            LoreBookbudget.Size = new Size(103, 23);
            LoreBookbudget.TabIndex = 9;
            LoreBookbudget.Text = "20";
            LoreBookbudget.TextChanged += LoreBookbudget_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 74);
            label7.Name = "label7";
            label7.Size = new Size(98, 15);
            label7.TabIndex = 10;
            label7.Text = "Lorebook Budget";
            // 
            // contextTokenLimit
            // 
            contextTokenLimit.Location = new Point(127, 39);
            contextTokenLimit.Name = "contextTokenLimit";
            contextTokenLimit.Size = new Size(103, 23);
            contextTokenLimit.TabIndex = 7;
            contextTokenLimit.Text = "14000";
            contextTokenLimit.TextChanged += contextTokenLimit_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 42);
            label6.Name = "label6";
            label6.Size = new Size(113, 15);
            label6.TabIndex = 8;
            label6.Text = "Context Token Limit";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(149, 10);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 7;
            label5.Text = "Tokens";
            label5.Click += label5_Click;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(791, 489);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
            contextTokenLimit.Text = _settingsManager.ContextTokenLimit.ToString();
            LoreBookbudget.Text = _settingsManager.LoreBookBudget.ToString();
            replyTokenLimit.Text = _settingsManager.MaxReplyTokens.ToString();

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
            else if (sender == replyTokenLimit) 
            { 
                _settingsManager.SaveSetting("MaxReplyTokens", replyTokenLimit.Text); 
            }
            else if (sender == contextTokenLimit) 
            { 
                _settingsManager.SaveSetting("ContextTokenLimit", contextTokenLimit.Text); 
            }
            else if (sender == LoreBookbudget) 
            { 
                _settingsManager.SaveSetting("LoreBookBudget", LoreBookbudget.Text); 
            }
        }

        private TextBox openAPIUrl;
        private Label label1;
        private Label label2;
        private TextBox openAPIModel;
        private Label label3;
        private TextBox openAPIKey;
        private Panel panel1;
        private Panel panel2;
        private Label label5;
        private Label label8;
        private TextBox LoreBookbudget;
        private Label label7;
        private TextBox contextTokenLimit;
        private Label label6;
        private TextBox replyTokenLimit;
        private Label label9;
        private Label label4;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void contextTokenLimit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(contextTokenLimit.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number");
                contextTokenLimit.Text = "0";
            }
        }

        private void LoreBookbudget_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(LoreBookbudget.Text);
                if (int.Parse(LoreBookbudget.Text) > 90)
                {
                    MessageBox.Show("Please enter a valid number Between 0 and 90");
                    LoreBookbudget.Text = "0";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number Between 0 and 90");
                LoreBookbudget.Text = "0";
            }
        }

        private void replyTokenLimit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(replyTokenLimit.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number");
                replyTokenLimit.Text = "0";
            }
        }
    }
}