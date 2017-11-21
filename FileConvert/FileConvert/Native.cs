using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    public class Native
    {
        private List<PandocFile> filesToConvert;
        private List<PandocFile> outputFiles;

        public Native() { }

        public Native(string pathToScan)
        {
            string[] list = Directory.GetFiles(@"C:\Users\Thomas\Onedrive\Documents\Verdant", "*.docx", SearchOption.AllDirectories);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public bool TestPandocPresent()
        {
            Pandoc test = new Pandoc();
            test.Start();
            return test.GetExitCode() == 0;
        }
    }
}
