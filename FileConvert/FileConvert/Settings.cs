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
        public string[] WorkingFolder { get; set; }
        public bool UseWorkingFolder { get; set; }
        public string[] OutputFolder { get; set; }
        public int SelectedOutput { get; set; }
        public bool PromptSave { get; set; }

        /// <summary>
        /// Initialise the application default settings
        /// </summary>
        public Settings()
        {
            InputFormat = string.Empty;
            OutputFormat = string.Empty;
            WorkingFolder = new string[] { string.Empty };
            OutputFolder = new string[] { string.Empty };
            SelectedOutput = -1;
            PromptSave = true;
        }

        /// <summary>
        /// Init the app with the user saved settings
        /// </summary>
        /// <param name="useUserSettings">true to use the settings, false to use the program arguments</param>
        /// <param name="args">Launch arguments</param>
        public Settings(bool useUserSettings, string[] args) : this()
        {
            if (useUserSettings && File.Exists(SettingsPath))
            {
                Settings fromFile = XmlHelper.FromXmlFile<Settings>(SettingsPath);
                this.InputFormat = fromFile.InputFormat;
                this.OutputFormat = fromFile.OutputFormat;
                this.WorkingFolder = fromFile.WorkingFolder;
                this.UseWorkingFolder = fromFile.UseWorkingFolder;
                this.OutputFolder = fromFile.OutputFolder;
                this.SelectedOutput = fromFile.SelectedOutput;
                this.PromptSave = fromFile.PromptSave;
            }
            else
            {
                ParseArguments(args);
            }
        }

        private void ParseArguments(string[] args)
        {
            WorkingFolder[0] = Environment.CurrentDirectory;
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
                        OutputFolder = new string[] { args[i] };
                        SelectedOutput = 0;
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
            Display.SettingsSavedSuccess();
        }

        public void SelectOutput()
        {
            if (OutputFolder.Length > 1)
            {
                Display.MultipleOutputs(OutputFolder);
                string selection = Console.ReadLine();
                int temp = int.Parse(selection) - 1;
                if (temp >= 0 && temp < OutputFolder.Length)
                {
                    SelectedOutput = temp;
                    Console.WriteLine("Selected output : " + OutputFolder[SelectedOutput]);
                }
            }
            else
            {
                SelectedOutput = 0;
            }
        }

        public bool AreSettingsSet()
        {
            return (InputFormat != string.Empty && OutputFolder[0] == string.Empty && OutputFormat != string.Empty);
        }

        public void SetMissingSettings()
        {
            if(InputFormat == string.Empty)
            {
                Display.SetInputFormat();
                InputFormat = Console.ReadLine();
            }
            if(OutputFolder[0] == string.Empty)
            {
                Display.SetOutputFolder();
                OutputFolder[0] = Console.ReadLine();
            }
            if(OutputFormat == string.Empty)
            {
                Display.SetOutputFormat();
                OutputFormat = Console.ReadLine();
            }
        }
    }
}
