using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    internal class Pandoc
    {
        private Process process;

        internal Pandoc() : this(null, null, "-v", Environment.CurrentDirectory) { }

        internal Pandoc(string inputFile, string outputFile, string arguments, string workingDirectory)
        {
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "pandoc",
                    UseShellExecute = false,
                    WorkingDirectory = workingDirectory,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
        }

        internal void Start()
        {
            process.Start();
        }

        internal string[] GetOutput()
        {
            List<string> result = new List<string>();
            while (!process.StandardOutput.EndOfStream)
            {
                result.Add(process.StandardOutput.ReadLine());
            }
            return result.ToArray();
        }

        internal int GetExitCode()
        {
            process.WaitForExit();
            return process.ExitCode;
        }
    }
}
