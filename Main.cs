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

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // Logic to handle the submit button click
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
    }
}
