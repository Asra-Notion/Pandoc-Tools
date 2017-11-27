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
        private List<Tuple<PandocFile, PandocFile>> files;

        public Native()
        {
            files = new List<Tuple<PandocFile, PandocFile>>();
        }

        public Native(string pathToScan) : this()
        {
            string[] list = Directory.GetFiles(@"C:\Users\Thomas\Onedrive\Documents\Verdant", "*.docx", SearchOption.AllDirectories);
            foreach (var item in list)
            {
                PandocFile inputFile = new PandocFile(item, ".docx");
                PandocFile outputFile = new PandocFile(inputFile);
                outputFile.ChangeFileExtension(".md");
                outputFile.ModifyFilePathRelative(@"L:\GitHub\Verdant-Project", @"C:\Users\Thomas\Onedrive\Documents\Verdant");
                Tuple<PandocFile, PandocFile> tuple = new Tuple<PandocFile, PandocFile>(inputFile,outputFile);
                files.Add(tuple);
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
