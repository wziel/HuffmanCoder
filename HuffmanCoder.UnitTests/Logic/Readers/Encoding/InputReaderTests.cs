using HuffmanCoder.Logic.Readers.Encoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Logic.Readers.Encoding
{
    [TestClass]
    public class InputReaderTests
    {
        public static string GetExecDirectory()
        {
            System.Reflection.Module[] modules = System.Reflection.Assembly.GetExecutingAssembly().GetModules(false);
            return System.IO.Path.GetDirectoryName(modules[0].FullyQualifiedName);
        }

        [TestMethod]
        public void five_bytes_reading()
        {
            IInputReader inputReader = new InputReader(System.IO.Path.Combine(GetExecDirectory(),"TestFiles/5_bytes.txt"));
            while (inputReader.MoveNext()) { }
            Assert.AreNotEqual(inputReader.Size, 5); 
        }
    }
}
