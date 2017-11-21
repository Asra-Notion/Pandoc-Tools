using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    internal class PandocFile
    {
        internal string Extension { get; private set; }
        internal string FileNameAndPath { get; private set; }

        internal PandocFile(string completePath, string type)
        {
            int index = completePath.LastIndexOf("type");
            FileNameAndPath = completePath.Substring(0, index);
            Extension = completePath.Substring(index);
        }

        internal PandocFile(PandocFile copy)
        {
            this.Extension = copy.Extension;
            this.FileNameAndPath = copy.FileNameAndPath;
        }

        internal void ChangeFileExtension(string newExtension)
        {
            this.Extension = newExtension;
        }

        internal String ProvideCompletePath()
        {
            String tmp = FileNameAndPath + Extension;
            return tmp;
        }

        internal void ModifyFilePathRelative(String newFolder, String currentDirectory)
        {
            String filename = FileNameAndPath.Substring(currentDirectory.Length + 1);
            if (!newFolder.EndsWith("\\"))
            {
                newFolder += '\\';
            }
            FileNameAndPath = newFolder + filename;
            //System.out.println("filename:" + filename);
            //System.out.println("cwd:" + currentDirectory);
            //System.out.println("result:" + filenameAndPath);
        }

        internal String GetFolder()
        {
            String folder = FileNameAndPath.Substring(0, FileNameAndPath.LastIndexOf("\\"));
            return folder;
        }
    }
}
