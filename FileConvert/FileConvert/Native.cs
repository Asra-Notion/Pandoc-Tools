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

        public Native() { }

        public Native(string pathToScan)
        {
            string[] list = Directory.GetFiles(@"C:\Users\Thomas\Onedrive\Documents\Verdant", "*.docx", SearchOption.AllDirectories);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
