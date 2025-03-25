using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace MimicMuseAI
{
    public partial class BookWriterControl : UserControl
    {
        private TextBox MainTextDisplay;
        private TextBox promptInput;
        private Button ButtonSubmit;
        private FeatherlessClient _client;

        public BookWriterControl()
        {
            InitializeComponent();
            _client = new FeatherlessClient(Environment.GetEnvironmentVariable("FEATHERLESS_KEY"));
            _client.OnStreamUpdate += AppendToMainTextDisplay; // Subscribe to streaming updates
        }

        private void InitializeComponent()
        {
            MainTextDisplay = new TextBox();
            promptInput = new TextBox();
            ButtonSubmit = new Button();
            SuspendLayout();
            // 
            // MainTextDisplay
            // 
            MainTextDisplay.Dock = DockStyle.Top;
            MainTextDisplay.Location = new Point(0, 0);
            MainTextDisplay.Multiline = true;
            MainTextDisplay.Name = "MainTextDisplay";
            MainTextDisplay.Size = new Size(475, 374);
            MainTextDisplay.TabIndex = 2;
            MainTextDisplay.ScrollBars = ScrollBars.Vertical; // Ensure scrolling
            // 
            // promptInput
            // 
            promptInput.Dock = DockStyle.Top;
            promptInput.Location = new Point(0, 374);
            promptInput.Name = "promptInput";
            promptInput.Size = new Size(475, 23);
            promptInput.TabIndex = 1;
            // 
            // ButtonSubmit
            // 
            ButtonSubmit.Dock = DockStyle.Top;
            ButtonSubmit.Location = new Point(0, 397);
            ButtonSubmit.Name = "ButtonSubmit";
            ButtonSubmit.Size = new Size(475, 31);
            ButtonSubmit.TabIndex = 0;
            ButtonSubmit.Text = "Submit";
            ButtonSubmit.Click += ButtonSubmit_Click;
            // 
            // BookWriterControl
            // 
            Controls.Add(ButtonSubmit);
            Controls.Add(promptInput);
            Controls.Add(MainTextDisplay);
            Name = "BookWriterControl";
            Size = new Size(475, 429);
            ResumeLayout(false);
            PerformLayout();
        }

        private async void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // Clear previous streaming response
            AppendToMainTextDisplay("\n---\n"); // Add a separator for clarity

            // Get context from MainTextDisplay and promptInput
            string context = GetMainTextDisplayContent() + " " + GetPromptInputContent();

            // Fetch lore data (if applicable)
            Dictionary<string, string> loreData = LoreBookControl.GetInstance().GetSavedData();
            string additionalLore = GetAdditionalLoreContent(context, loreData);

            // Create the full prompt
            string finalPrompt = context + "\n" + additionalLore;

            // Send the request to Featherless API
            await _client.SendMessageAsync(finalPrompt);
        }

        private void AppendToMainTextDisplay(string text)
        {
            if (MainTextDisplay.InvokeRequired)
            {
                MainTextDisplay.Invoke(new Action(() => MainTextDisplay.AppendText(text)));
            }
            else
            {
                MainTextDisplay.AppendText(text);
            }
        }

        private string GetMainTextDisplayContent()
        {
            return MainTextDisplay.Text ?? string.Empty;
        }

        private string GetPromptInputContent()
        {
            return promptInput.Text ?? string.Empty;
        }

        private string GetAdditionalLoreContent(string context, Dictionary<string, string> loreData)
        {
            string additional = "";

            foreach (var entry in loreData)
            {
                string[] keyWords = entry.Key.Split(',', StringSplitOptions.TrimEntries);
                if (keyWords.Any(keyWord => context.Contains(keyWord)))
                {
                    additional += $"{entry.Key}:{{{entry.Value}}}\n";
                }
            }

            return additional;
        }
    }
}
