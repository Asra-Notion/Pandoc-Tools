using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    internal class Native
    {
        private List<PandocFile> filesToConvert;
        private List<PandocFile> outputFiles;

        internal Native() { }

        internal Native(string pathToScan)
        {
            string[] list = Directory.GetFiles(@"C:\Users\Thomas\Onedrive\Documents\Verdant", "*.docx", SearchOption.AllDirectories);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        internal bool TestPandocPresent()
        {
            Pandoc test = new Pandoc();
            test.Start();
            return test.GetExitCode() == 0;
        }
        
    }
}
