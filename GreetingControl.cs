using System.Windows.Forms;

namespace MimicMuseAI
{
    public partial class GreetingControl : UserControl
    {
        public GreetingControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            TextBox greetingTextBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Text = "Welcome to MimicMuseAI!\n\nChangelog:\n- Feature 1\n- Feature 2\n..."
            };
            this.Controls.Add(greetingTextBox);
        }
    }
}
