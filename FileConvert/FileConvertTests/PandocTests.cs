using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert.Tests
{
    [TestClass()]
    public class PandocTests
    {
        [TestMethod()]
        public void PandocTest()
        {
            Pandoc test = new Pandoc();
            test.Start();
            string[] result = test.GetOutput();
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}