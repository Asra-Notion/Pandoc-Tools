using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileConvert
{
    public class Settings
    {
        private readonly static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Asra-Notion\FileConvert\settings.xml";
        public string InputFormat { get; set; }
        public string OutputFormat { get; set; }
        public string WorkingFolder { get; set; }
        public bool UseWorkingFolder { get; set; }
        public string OutputFolder { get; set; }

        /// <summary>
        /// Initialise the application default settings
        /// </summary>
        public Settings()
        {
            InputFormat = string.Empty;
            OutputFormat = string.Empty;
            WorkingFolder = string.Empty;
            OutputFolder = string.Empty;
        }

        /// <summary>
        /// Init the app with the user saved settings
        /// </summary>
        /// <param name="useUserSettings">true to use the settings, false to use the program arguments</param>
        /// <param name="args">Launch arguments</param>
        public Settings(bool useUserSettings, string[] args)
        {
            if (useUserSettings && File.Exists(SettingsPath))
            {
                Settings fromFile = XmlHelper.FromXmlFile<Settings>(SettingsPath);
                this.InputFormat = fromFile.InputFormat;
                this.OutputFormat = fromFile.OutputFormat;
                this.WorkingFolder = fromFile.WorkingFolder;
                this.UseWorkingFolder = fromFile.UseWorkingFolder;
                this.OutputFolder = fromFile.OutputFolder;
            }
            else
            {
                ParseArguments(args);
            }
        }

        private void ParseArguments(string[] args)
        {
            InputFormat = string.Empty;
            OutputFormat = string.Empty;
            OutputFolder = string.Empty;
            WorkingFolder = Environment.CurrentDirectory;
            UseWorkingFolder = true;
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-i":
                        i++;
                        InputFormat = args[i];
                        break;
                    case "-f":
                        i++;
                        OutputFolder = args[i];
                        break;
                    case "-o":
                        i++;
                        OutputFormat = args[i];
                        break;
                    default:
                        break;
                }
            }
        }

        public void SaveSettings()
        {
            XmlHelper.ToXmlFile(this, SettingsPath);
        }
    }
}
