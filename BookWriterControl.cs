using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MimicMuseAI
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class BookWriterControl : UserControl
    {
        private TextBox MainTextDisplay;
        private TextBox promptInput;
        private Button ButtonSubmit;

        public BookWriterControl()
        {
            InitializeComponent();
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
            // 
            // promptInput
            // 
            promptInput.Dock = DockStyle.Top;
            promptInput.Location = new Point(0, 374);
            promptInput.Name = "promptInput";
            promptInput.Size = new Size(475, 23);
            promptInput.TabIndex = 1;
            promptInput.TextChanged += PromptInput_TextChanged;
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

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // Logic to handle the submit button click
            // Get the content of MainTextDisplay
            string mainTextContent = GetMainTextDisplayContent();

            // Get the content of promptInput
            string promptInputContent = GetPromptInputContent();

            // Combine the context
            string context = mainTextContent + " " + promptInputContent;

            // Get the lore data
            Dictionary<string, string> loreData = LoreBookControl.GetInstance().GetSavedData();

            // Get the additional lore content
            string additionalLoreContent = GetAdditionalLoreContent(context, loreData);

            // Count the tokens in each section
            int mainTextTokens = CountTokens(mainTextContent);
            int additionalLoreTokens = CountTokens(additionalLoreContent);

            // Display or use the results as needed
            MessageBox.Show($"Main Text Tokens: {mainTextTokens}\nAdditional Lore Tokens: {additionalLoreTokens}");
        }

        private void PromptInput_TextChanged(object sender, EventArgs e)
        {
            // ButtonSubmit.Text = string.IsNullOrEmpty(promptInput.Text) ? "Continue" : "Submit";
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
                // Split the key string into separate words (handle commas and whitespace)
                string[] keyWords = entry.Key.Split(',', StringSplitOptions.TrimEntries);

                // Check if ANY of the words in the key list exist in context
                if (keyWords.Any(keyWord => context.Contains(keyWord)))
                {
                    additional += $"{entry.Key}:{{{entry.Value}}}\n";
                }
            }

            return additional;
        }

        private int CountTokens(string text)
        {
            // Implement your token counting logic here
            // For example, you can use a library or a custom method to count tokens
            return text.Split(' ').Length; // Simple example, replace with actual token counting logic
        }
    }
}