using System;
using System.Windows.Forms;

namespace MimicMuseAI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            if (promptInput != null)
            {
                promptInput.TextChanged += new EventHandler(PromptInput_TextChanged);
            }

        }

        private void MainScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Logic to switch to the main screen
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the settings form
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private string getLoreData(string content, string prompt)
        {
            string toTest = content + ":" + prompt;
            string additional = "";
            Dictionary<string, string> loreData = LoreBook.GetInstance().GetStoredData();
            foreach (var entry in loreData)
            {
                // Split the key string into separate words (handle commas and whitespace)
                string[] keyWords = entry.Key.Split(',', StringSplitOptions.TrimEntries);

                // Check if ANY of the words in the key list exist in context
                if (keyWords.Any(keyWord => toTest.Contains(keyWord)))
                {
                    additional += $"{entry.Key}:{{{entry.Value}}}\n";
                }
            }

            return "";
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
            Dictionary<string, string> loreData = LoreBook.GetInstance().GetStoredData();
            // Get the additional lore content
            string additionalLoreContent = GetAdditionalLoreContent(context, loreData);

            // Count the tokens in each section
            int mainTextTokens = CountTokens(mainTextContent);
            int additionalLoreTokens = CountTokens(additionalLoreContent);
            MessageBox.Show(additionalLoreContent);
            // Display or use the results as needed
            MessageBox.Show($"Main Text Tokens: {mainTextTokens}\nContent: {mainTextContent}\nAdditional Lore Tokens: {additionalLoreTokens}\nContent: {additionalLoreContent}\n");

        }

        private void PromptInput_TextChanged(object sender, EventArgs e)
        {
            //   ButtonSubmit.Text = string.IsNullOrEmpty(promptInput.Text) ? "Continue" : "Submit";
        }

        private void loreBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoreBook loreBookForm = new LoreBook();
            LoreBook.GetInstance().Show();
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
                //MessageBox.Show(keyWords.ToString());
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
            // Tried tiktoke for counting tokens, however that caused a massive hang in the program
            return (int)(text.Length / 4.0); //This is a roughly accurate way to count tokens apparently.... i mean its just char count diveded by 4
        }
    }
}
