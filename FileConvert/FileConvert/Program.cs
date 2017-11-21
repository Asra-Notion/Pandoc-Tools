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
            System.Threading.Thread.Sleep(5000);
        }
    }
}
