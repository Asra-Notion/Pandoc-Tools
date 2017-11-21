using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    public static class Display
    {
        public static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Pandoc-Tools AutoConvert");
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Select an input format :");
            Console.WriteLine("1. .md");
            Console.WriteLine("2. .docx");
            Console.WriteLine("3. .pdf");
        }

        public static void SaveSettings()
        {
            Console.WriteLine("Do you want to save the current values for next time ? (y/n)");
        }

        public static void SettingsSavedSuccess()
        {
            Console.WriteLine("Settings saved successfully!");
        }

        public static void MultipleOutputs(string[] outputFolder)
        {
            Console.WriteLine("Multiple outputs folders defined, select one:");
            for (int i = 0; i < outputFolder.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + outputFolder[i]);
            }
            Console.WriteLine("Select between 1 and " + outputFolder.Length + " :");
        }

        public static void SetInputFormat()
        {
            Console.WriteLine("Set the input file format extension (ex. .md) :");
        }

        public static void SetOutputFolder()
        {
            Console.WriteLine("Where do you want to save the converted files (Full path to folder)?");
        }

        public static void SetOutputFormat()
        {
            Console.WriteLine("Set the output file format extension (ex. .docx) :");
        }
    }
}
