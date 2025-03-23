using System;
using System.IO;

namespace MimicMuseAI
{
    public class SettingsManager
    {
        private static SettingsManager _instance;
        private IniFileHelper _iniFileHelper;
        private const string iniFilePath = "settings.ini";
        private const string sectionName = "Settings";

        public string OpenAPIUrl { get; private set; }
        public string OpenAPIModel { get; private set; }
        public string OpenAPIKey { get; private set; }
        public string ActualAPIKey { get; private set; }
        public int ContextTokenLimit { get; private set; }
        public int LoreBookBudget { get; private set; }
        public int MaxReplyTokens { get; private set; }


        private SettingsManager()
        {
            _iniFileHelper = new IniFileHelper(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iniFilePath));
            LoadSettings();
        }

        public static SettingsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SettingsManager();
                }
                return _instance;
            }
        }

        public void LoadSettings()
        {
            if (!File.Exists(iniFilePath))
            {
                // Create the file with default settings if it doesn't exist
                _iniFileHelper.Write(sectionName, "URL", "https://api.featherless.ai/v1");
                _iniFileHelper.Write(sectionName, "Model", "deepseek-ai/DeepSeek-R1");
                _iniFileHelper.Write(sectionName, "APIKey", "LLM_Key");
                _iniFileHelper.Write(sectionName, "ContextTokenLimit", "14000");
                _iniFileHelper.Write(sectionName, "LoreBookBudget", "20");
                _iniFileHelper.Write(sectionName, "MaxReplyTokens", "2096");
            }

            // Load settings from the INI file
            OpenAPIUrl = _iniFileHelper.Read(sectionName, "URL", "https://api.featherless.ai/v1");
            OpenAPIModel = _iniFileHelper.Read(sectionName, "Model", "deepseek-ai/DeepSeek-R1");
            OpenAPIKey = _iniFileHelper.Read(sectionName, "APIKey", "LLM_Key");
            ContextTokenLimit = int.Parse(_iniFileHelper.Read(sectionName, "ContextTokenLimit", "14000"));
            LoreBookBudget = int.Parse(_iniFileHelper.Read(sectionName, "LoreBookBudget", "20"));
            MaxReplyTokens = int.Parse(_iniFileHelper.Read(sectionName, "MaxReplyTokens", "2096"));
            // Load the actual API key from the environment variable
            LoadActualAPIKey();
        }

        public void SaveSetting(string key, string value)
        {
            _iniFileHelper.Write(sectionName, key, value);
            LoadSettings(); // Reload settings to update the values
        }
        private void LoadActualAPIKey()
        {
            ActualAPIKey = Environment.GetEnvironmentVariable(OpenAPIKey);
            if (string.IsNullOrEmpty(ActualAPIKey))
            {
                MessageBox.Show($"Your environment variable: {OpenAPIKey} is not set. You may need to reboot after using the setx command to set it.");
            }
        }
    }
}
