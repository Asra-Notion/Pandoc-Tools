using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileConvert
{
    internal class Settings
    {
        private readonly static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Asra-Notion\FileConvert\settings.xml";
        internal string InputFormat { get; set; }
        internal string OutputFormat { get; set; }
        internal string WorkingFolder { get; set; }
        internal bool UseWorkingFolder { get; set; }
        internal string[] OutputFolder { get; set; }
        internal int SelectedOutput { get; set; }
        internal bool PromptSave { get; set; }

        /// <summary>
        /// Initialise the application default settings
        /// </summary>
        internal Settings()
        {
            InputFormat = string.Empty;
            OutputFormat = string.Empty;
            WorkingFolder = string.Empty;
            OutputFolder = new string[] { string.Empty };
            SelectedOutput = -1;
            PromptSave = true;
        }

        /// <summary>
        /// Init the app with the user saved settings
        /// </summary>
        /// <param name="useUserSettings">true to use the settings, false to use the program arguments</param>
        /// <param name="args">Launch arguments</param>
        internal Settings(bool useUserSettings, string[] args) : this()
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

        internal void SaveSettings()
        {
            XmlHelper.ToXmlFile(this, SettingsPath);
            Display.SettingsSavedSuccess();
        }

        internal void SelectOutput()
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

        internal bool AreSettingsSet()
        {
            return (InputFormat != string.Empty && OutputFolder.Length > 0 && OutputFormat != string.Empty);
        }

        internal void SetMissingSettings()
        {
            if(InputFormat == string.Empty)
            {
                Display.SetInputFormat();
                InputFormat = Console.ReadLine();
            }
        }
    }
}
