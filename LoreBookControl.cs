using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace MimicMuseAI
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]

    public partial class LoreBookControl : UserControl
    {
        private static LoreBookControl _instance;
        private static Dictionary<string, string> savedData = new Dictionary<string, string>();

        private static readonly string lorebookFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lorebooks");
        private static readonly string defaultFilePath = Path.Combine(lorebookFolder, "default.json");
        private List<(TextBox keyBox, TextBox contentBox)> keyContentPairs = new List<(TextBox, TextBox)>();
        private TextBox txtName;

        public static LoreBookControl GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new LoreBookControl();
            }
            return _instance;
        }

        public LoreBookControl()
        {
            InitializeComponent();
            SetupForm();
            EnsureLorebookFolderExists();
            LoadData(defaultFilePath);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // LoreBookControl
            // 
            Name = "LoreBookControl";
            Size = new Size(1012, 543);
            ResumeLayout(false);
        }

        private void SetupForm()
        {
            Label lblName = new Label { Text = "Name:", AutoSize = true, Top = 10, Left = 10 };
            txtName = new TextBox { Name = "txtName", Width = 300, Top = lblName.Bottom + 5, Left = 10 };
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);

            FlowLayoutPanel pairPanel = new FlowLayoutPanel
            {
                Name = "pairPanel",
                Top = txtName.Bottom + 10,
                Left = 10,
                Width = 600,
                Height = 300,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            this.Controls.Add(pairPanel);

            Button btnSave = new Button { Text = "Save", Top = pairPanel.Bottom + 10, Left = 10 };
            btnSave.Click += (s, e) => SaveData(txtName.Text);
            this.Controls.Add(btnSave);

            Button btnLoad = new Button { Text = "Load", Top = pairPanel.Bottom + 10, Left = btnSave.Right + 10 };
            btnLoad.Click += (s, e) => OpenFileDialogAndLoad(txtName);
            this.Controls.Add(btnLoad);

            Button btnClear = new Button { Text = "Clear", Top = pairPanel.Bottom + 10, Left = btnLoad.Right + 10 };
            btnClear.Click += (s, e) => ClearData();
            this.Controls.Add(btnClear);

            AddNewPair(pairPanel);
        }

        private void AddNewPair(FlowLayoutPanel panel)
        {
            Panel pairContainer = new Panel { Width = panel.Width - 25, Height = 80 };

            TextBox txtKey = new TextBox { PlaceholderText = "Keys (comma-separated)", Left = 0, Top = 0, Width = 250 };
            TextBox txtContent = new TextBox
            {
                PlaceholderText = "Content",
                Left = txtKey.Right + 10,
                Top = 0,
                Width = 300,
                Height = 70,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            txtKey.TextChanged += (s, e) => CheckAndAddNewPair(panel);
            txtContent.TextChanged += (s, e) => CheckAndAddNewPair(panel);

            pairContainer.Controls.Add(txtKey);
            pairContainer.Controls.Add(txtContent);
            panel.Controls.Add(pairContainer);

            keyContentPairs.Add((txtKey, txtContent));
        }

        private void CheckAndAddNewPair(FlowLayoutPanel panel)
        {
            var lastPair = keyContentPairs[keyContentPairs.Count - 1];
            if (!string.IsNullOrWhiteSpace(lastPair.keyBox.Text) &&
                !string.IsNullOrWhiteSpace(lastPair.contentBox.Text))
            {
                AddNewPair(panel);
            }
        }

        private void SaveData(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name field must not be empty.");
                return;
            }

            string filePath = Path.Combine(lorebookFolder, $"{name}.json");

            Dictionary<string, object> loreBook = new Dictionary<string, object>
            {
                { "name", name },
                { "entries", new Dictionary<string, object>() }
            };

            int index = 0;
            foreach (var (keyBox, contentBox) in keyContentPairs)
            {
                if (!string.IsNullOrWhiteSpace(keyBox.Text) && !string.IsNullOrWhiteSpace(contentBox.Text))
                {
                    List<string> keyList = new List<string>(keyBox.Text.Split(','));
                    var entriesDict = (Dictionary<string, object>)loreBook["entries"];

                    entriesDict.Add(index.ToString(), new
                    {
                        uid = index,
                        key = keyList,
                        content = contentBox.Text
                    });
                    index++;
                }
            }

            string json = JsonSerializer.Serialize(loreBook, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            MessageBox.Show($"Data saved to {filePath}");
        }

        private void OpenFileDialogAndLoad(TextBox txtName)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = lorebookFolder,
                Filter = "JSON files (*.json)|*.json",
                Title = "Load JSON File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadData(openFileDialog.FileName);
            }
        }

        private void LoadData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, JsonSerializer.Serialize(new { name = "Default", entries = new Dictionary<string, object>() }));
            }

            string json = File.ReadAllText(filePath);
            Dictionary<string, JsonElement> loreBook = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            txtName.Text = loreBook["name"].GetString();

            FlowLayoutPanel pairPanel = this.Controls["pairPanel"] as FlowLayoutPanel;
            if (pairPanel != null)
            {
                pairPanel.Controls.Clear();
                keyContentPairs.Clear();

                Dictionary<string, JsonElement> entries = loreBook["entries"].Deserialize<Dictionary<string, JsonElement>>();

                foreach (var entry in entries)
                {
                    Dictionary<string, JsonElement> entryData = entry.Value.Deserialize<Dictionary<string, JsonElement>>();
                    List<string> keys = entryData["key"].Deserialize<List<string>>();
                    string content = entryData["content"].GetString();

                    Panel pairContainer = new Panel { Width = pairPanel.Width - 25, Height = 80 };

                    TextBox txtKey = new TextBox { Text = string.Join(",", keys), Left = 0, Top = 0, Width = 250 };
                    TextBox txtContent = new TextBox
                    {
                        Text = content,
                        Left = txtKey.Right + 10,
                        Top = 0,
                        Width = 300,
                        Height = 70,
                        Multiline = true,
                        ScrollBars = ScrollBars.Vertical
                    };

                    txtKey.TextChanged += (s, e) => CheckAndAddNewPair(pairPanel);
                    txtContent.TextChanged += (s, e) => CheckAndAddNewPair(pairPanel);

                    pairContainer.Controls.Add(txtKey);
                    pairContainer.Controls.Add(txtContent);
                    pairPanel.Controls.Add(pairContainer);
                    keyContentPairs.Add((txtKey, txtContent));
                }

                AddNewPair(pairPanel);
            }
        }

        private void ClearData()
        {
            FlowLayoutPanel pairPanel = this.Controls["pairPanel"] as FlowLayoutPanel;
            if (pairPanel != null)
            {
                pairPanel.Controls.Clear();
                keyContentPairs.Clear();
                AddNewPair(pairPanel);
            }
            File.WriteAllText(defaultFilePath, JsonSerializer.Serialize(new { name = "Default", entries = new Dictionary<string, object>() }));
        }

        private void EnsureLorebookFolderExists()
        {
            if (!Directory.Exists(lorebookFolder))
            {
                Directory.CreateDirectory(lorebookFolder);
            }
        }

        public Dictionary<string, string> GetSavedData()
        {
            SaveDataToMemory();
            return savedData;
        }

        public Dictionary<string, string> GetKeyContentPairs()
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            foreach (var (keyBox, contentBox) in keyContentPairs)
            {
                if (!string.IsNullOrWhiteSpace(keyBox.Text) && !string.IsNullOrWhiteSpace(contentBox.Text))
                {
                    foreach (var key in keyBox.Text.Split(','))
                    {
                        pairs[key.Trim()] = contentBox.Text;
                    }
                }
            }
            return pairs;
        }

        private void SaveDataToMemory()
        {
            savedData = GetKeyContentPairs();
        }
    }
}

