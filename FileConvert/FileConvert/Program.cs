using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    class Program
    {
        static Settings AppSettings;

        static void Main(string[] args)
        {
            Display.DisplayWelcome();
            AppSettings = new Settings(true, args);
            Display.SaveSettings();
            UserSelectSave();
            System.Threading.Thread.Sleep(5000);
        }

        private static void UserSelectSave()
        {
            string choice = Console.ReadLine();
            if (choice.ToUpper() == "Y")
            {
                AppSettings.SaveSettings();
            }
        }
    }
}
