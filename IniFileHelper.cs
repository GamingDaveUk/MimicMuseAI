using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

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
        }

        public void Write(string section, string key, string value)
        {
            long result = WritePrivateProfileString(section, key, value, path);
            if (result == 0)
            {
                MessageBox.Show($"Failed to write to INI file: {path}");
            }
        }

        public string Read(string section, string key, string defaultValue = "")
        {
            var returnValue = new StringBuilder(255);
            int size = GetPrivateProfileString(section, key, defaultValue, returnValue, 255, path);
            if (size == 0)
            {
                MessageBox.Show($"Failed to read from INI file: {path}");
            }
            return returnValue.ToString();
        }

        public bool KeyExists(string section, string key)
        {
            return Read(section, key).Length > 0;
        }
    }
}