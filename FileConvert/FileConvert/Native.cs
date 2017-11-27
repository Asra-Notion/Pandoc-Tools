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

        public Native(string pathToScan, string inputFormat, string outputFolder, string outputFormat) : this()
        {
            string[] list = Directory.GetFiles(pathToScan, "*" + inputFormat, SearchOption.AllDirectories);
            foreach (var item in list)
            {
                PandocFile inputFile = new PandocFile(item, inputFormat);
                PandocFile outputFile = new PandocFile(inputFile);
                outputFile.ChangeFileExtension(outputFormat);
                outputFile.ModifyFilePathRelative(outputFolder, pathToScan);
                Tuple<PandocFile, PandocFile> tuple = new Tuple<PandocFile, PandocFile>(inputFile, outputFile);
                files.Add(tuple);
                Console.WriteLine(item);
            }
        }

        public static bool TestPandocPresent()
        {
            Pandoc test = new Pandoc();
            test.Start();
            return test.GetExitCode() == 0;
        }

    }
}
