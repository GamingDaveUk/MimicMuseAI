using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MimicMuseAI
{
    public class SettingsManager
    {
        private static SettingsManager _instance;
        public static SettingsManager Instance => _instance ??= new SettingsManager();

        private readonly string settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.ini");
        private readonly IniFileHelper iniFileHelper;

        private SettingsManager()
        {
            iniFileHelper = new IniFileHelper(settingsFilePath);
            InitializeDefaultValues();
        }

        private void InitializeDefaultValues()
        {
            if (!iniFileHelper.KeyExists("OpenAPI", "Url"))
            {
                OpenAPIUrl = "https://api.openai.com";
            }
            if (!iniFileHelper.KeyExists("OpenAPI", "Model"))
            {
                OpenAPIModel = "text-davinci-003";
            }
            if (!iniFileHelper.KeyExists("OpenAPI", "Key"))
            {
                OpenAPIKey = "YOUR_API_KEY";
            }
            if (!iniFileHelper.KeyExists("Tokens", "ContextTokenLimit"))
            {
                ContextTokenLimit = 14000;
            }
            if (!iniFileHelper.KeyExists("Tokens", "LoreBookBudget"))
            {
                LoreBookBudget = 20;
            }
            if (!iniFileHelper.KeyExists("Tokens", "MaxReplyTokens"))
            {
                MaxReplyTokens = 2096;
            }
        }

        public string OpenAPIUrl
        {
            get => GetSetting("OpenAPI", "Url");
            set => SaveSetting("OpenAPI", "Url", value);
        }

        public string OpenAPIModel
        {
            get => GetSetting("OpenAPI", "Model");
            set => SaveSetting("OpenAPI", "Model", value);
        }

        public string OpenAPIKey
        {
            get => GetSetting("OpenAPI", "Key");
            set => SaveSetting("OpenAPI", "Key", value);
        }

        public int ContextTokenLimit
        {
            get => int.TryParse(GetSetting("Tokens", "ContextTokenLimit"), out var value) ? value : 0;
            set => SaveSetting("Tokens", "ContextTokenLimit", value.ToString());
        }

        public int LoreBookBudget
        {
            get => int.TryParse(GetSetting("Tokens", "LoreBookBudget"), out var value) ? value : 0;
            set => SaveSetting("Tokens", "LoreBookBudget", value.ToString());
        }

        public int MaxReplyTokens
        {
            get => int.TryParse(GetSetting("Tokens", "MaxReplyTokens"), out var value) ? value : 0;
            set => SaveSetting("Tokens", "MaxReplyTokens", value.ToString());
        }

        private string GetSetting(string section, string key)
        {
            try
            {
                return iniFileHelper.Read(section, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading setting from INI file: {ex.Message}");
                return string.Empty;
            }
        }

        public void SaveSetting(string section, string key, string value)
        {
            try
            {
                iniFileHelper.Write(section, key, value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving setting to INI file: {ex.Message}");
            }
        }
    }
}