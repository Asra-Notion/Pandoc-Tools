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
    public class NativeTests
    {
        [TestMethod()]
        public void NativeTestPandocPresent()
        {
            Native test = new Native(@"C:\Users\Thomas\OneDrive\Documents\Verdant",".docx",@"L:\GitHub\Verdant-Project", ".md");
            Assert.AreEqual(true, Native.TestPandocPresent());
        }
    }
}