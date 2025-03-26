using System;
using System.Drawing;
using System.Windows.Forms;

public partial class ChatControl : UserControl
{
    private TextBox responseTextBox;
    private TextBox promptTextBox;
    private Button submitButton;
    private PictureBox characterPictureBox;
    private TextBox characterDescriptionTextBox;
    private Button saveButton;
    private Button loadButton;
    private Button slideOutButton;
    private Panel slideOutPanel;
    private TextBox authorsNotesTextBox;
    private TextBox greetingMessageTextBox;
    private TextBox instructionsTextBox;

    public ChatControl()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        responseTextBox = new TextBox();
        promptTextBox = new TextBox();
        submitButton = new Button();
        characterPictureBox = new PictureBox();
        characterDescriptionTextBox = new TextBox();
        saveButton = new Button();
        loadButton = new Button();
        slideOutButton = new Button();
        slideOutPanel = new Panel();
        authorsNotesTextBox = new TextBox();
        greetingMessageTextBox = new TextBox();
        instructionsTextBox = new TextBox();
        ((System.ComponentModel.ISupportInitialize)characterPictureBox).BeginInit();
        slideOutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // responseTextBox
        // 
        responseTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        responseTextBox.Location = new Point(10, 10);
        responseTextBox.Multiline = true;
        responseTextBox.Name = "responseTextBox";
        responseTextBox.Size = new Size(420, 331);
        responseTextBox.TabIndex = 0;
        // 
        // promptTextBox
        // 
        promptTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        promptTextBox.Location = new Point(10, 347);
        promptTextBox.Multiline = true;
        promptTextBox.Name = "promptTextBox";
        promptTextBox.Size = new Size(354, 50);
        promptTextBox.TabIndex = 1;
        // 
        // submitButton
        // 
        submitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        submitButton.Location = new Point(370, 347);
        submitButton.Name = "submitButton";
        submitButton.Size = new Size(60, 50);
        submitButton.TabIndex = 2;
        submitButton.Text = "Submit";
        // 
        // characterPictureBox
        // 
        characterPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        characterPictureBox.BorderStyle = BorderStyle.FixedSingle;
        characterPictureBox.Location = new Point(440, 10);
        characterPictureBox.Name = "characterPictureBox";
        characterPictureBox.Size = new Size(150, 209);
        characterPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        characterPictureBox.TabIndex = 3;
        characterPictureBox.TabStop = false;
        characterPictureBox.Click += CharacterPictureBox_Click;
        // 
        // characterDescriptionTextBox
        // 
        characterDescriptionTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        characterDescriptionTextBox.Location = new Point(440, 221);
        characterDescriptionTextBox.Multiline = true;
        characterDescriptionTextBox.Name = "characterDescriptionTextBox";
        characterDescriptionTextBox.Size = new Size(150, 105);
        characterDescriptionTextBox.TabIndex = 4;
        // 
        // saveButton
        // 
        saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        saveButton.Location = new Point(440, 332);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(75, 30);
        saveButton.TabIndex = 5;
        // 
        // loadButton
        // 
        loadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        loadButton.Location = new Point(515, 332);
        loadButton.Name = "loadButton";
        loadButton.Size = new Size(75, 30);
        loadButton.TabIndex = 6;
        // 
        // slideOutButton
        // 
        slideOutButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        slideOutButton.Location = new Point(440, 368);
        slideOutButton.Name = "slideOutButton";
        slideOutButton.Size = new Size(150, 30);
        slideOutButton.TabIndex = 7;
        slideOutButton.Text = "-->";
        slideOutButton.Click += SlideOutButton_Click;
        // 
        // slideOutPanel
        // 
        slideOutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        slideOutPanel.Controls.Add(authorsNotesTextBox);
        slideOutPanel.Controls.Add(greetingMessageTextBox);
        slideOutPanel.Controls.Add(instructionsTextBox);
        slideOutPanel.Location = new Point(596, 10);
        slideOutPanel.Name = "slideOutPanel";
        slideOutPanel.Size = new Size(200, 388);
        slideOutPanel.TabIndex = 8;
        slideOutPanel.Visible = false;
        // 
        // authorsNotesTextBox
        // 
        authorsNotesTextBox.Location = new Point(10, 10);
        authorsNotesTextBox.Multiline = true;
        authorsNotesTextBox.Name = "authorsNotesTextBox";
        authorsNotesTextBox.Size = new Size(180, 80);
        authorsNotesTextBox.TabIndex = 0;
        // 
        // greetingMessageTextBox
        // 
        greetingMessageTextBox.Location = new Point(10, 100);
        greetingMessageTextBox.Multiline = true;
        greetingMessageTextBox.Name = "greetingMessageTextBox";
        greetingMessageTextBox.Size = new Size(180, 80);
        greetingMessageTextBox.TabIndex = 1;
        // 
        // instructionsTextBox
        // 
        instructionsTextBox.Location = new Point(10, 190);
        instructionsTextBox.Multiline = true;
        instructionsTextBox.Name = "instructionsTextBox";
        instructionsTextBox.Size = new Size(180, 80);
        instructionsTextBox.TabIndex = 2;
        // 
        // ChatControl
        // 
        Controls.Add(responseTextBox);
        Controls.Add(promptTextBox);
        Controls.Add(submitButton);
        Controls.Add(characterPictureBox);
        Controls.Add(characterDescriptionTextBox);
        Controls.Add(saveButton);
        Controls.Add(loadButton);
        Controls.Add(slideOutButton);
        Controls.Add(slideOutPanel);
        Name = "ChatControl";
        Size = new Size(820, 401);
        ((System.ComponentModel.ISupportInitialize)characterPictureBox).EndInit();
        slideOutPanel.ResumeLayout(false);
        slideOutPanel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private void CharacterPictureBox_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                characterPictureBox.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }

    private void SlideOutButton_Click(object sender, EventArgs e)
    {
        if (slideOutPanel.Visible)
        {
            slideOutPanel.Visible = false;
            slideOutButton.Text = "-->";
        }
        else
        {
            slideOutPanel.Visible = true;
            slideOutButton.Text = "<--";
        }
    }
}
