using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    static class Display
    {
        public static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Pandoc-Tools AutoConvert");
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Select an input format:");
            Console.WriteLine("1. .md");
            Console.WriteLine("2. .docx");
            Console.WriteLine("3. .pdf");
        }
    }
}
