﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert
{
    public class Pandoc
    {
        private Process process;

        public Pandoc() : this(null, null, "-v") { }

        public Pandoc(string inputFile, string outputFile, string arguments)
        {
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "pandoc",
                    UseShellExecute = false,
                    WorkingDirectory = @"C:\Users\Thomas\Onedrive\Documents\Verdant",
                    Arguments = arguments,
                    RedirectStandardOutput = true
                }
            };
        }

        public void Start()
        {
            process.Start();
        }

        public string[] GetOutput()
        {
            List<string> result = new List<string>();
            while (!process.StandardOutput.EndOfStream)
            {
                result.Add(process.StandardOutput.ReadLine());
            }
            return result.ToArray();
        }
    }
}