using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MimicMuseAI
{
    public class IniFileHelper
    {
        private string path;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnValue, int size, string filePath);

        public IniFileHelper(string iniPath)
        {
            path = iniPath;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        public void Write(string section, string key, string value)
        {
            long result = WritePrivateProfileString(section, key, value, path);
            if (result == 0)
            {
                MessageBox.Show($"Failed to write to INI file: {path}\nSection: {section}\nKey: {key}\nValue: {value}");
            }
        }

        public string Read(string section, string key, string defaultValue = "")
        {
            var returnValue = new StringBuilder(255);
            int size = GetPrivateProfileString(section, key, defaultValue, returnValue, 255, path);
            if (size == 0)
            {
                MessageBox.Show($"Failed to read from INI file: {path}\nSection: {section}\nKey: {key}\nDefault Value: {defaultValue}");
            }
            return returnValue.ToString();
        }

        public bool KeyExists(string section, string key)
        {
            return Read(section, key).Length > 0;
        }
    }
}
