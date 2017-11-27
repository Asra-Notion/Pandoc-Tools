using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    public class Program
    {
        public static Settings AppSettings;
        public static Native Panodoc;

        static void Main(string[] args)
        {
            Display.DisplayWelcome();
            if (!Native.TestPandocPresent())
            {
                Display.PandocNotFound();
                Environment.Exit(1);
            }
            AppSettings = new Settings(true, args);
            if (!AppSettings.AreSettingsSet())
            {
                AppSettings.SetMissingSettings();
            }
            AppSettings.SelectOutput();
            UserSelectSave();
            System.Threading.Thread.Sleep(5000);
        }

        public static void UserSelectSave()
        {
            if (AppSettings.PromptSave)
            {
                Display.SaveSettings();
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "Y")
                {
                    AppSettings.SaveSettings();
                }
            }
        }
    }
}
