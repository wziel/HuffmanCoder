using HuffmanCoder.Logic.Readers.Decoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Logic.Readers.Decoding
{
    [TestClass]
    public class DecoderReaderTests
    {
        public static string GetExecDirectory()
        {
            System.Reflection.Module[] modules = System.Reflection.Assembly.GetExecutingAssembly().GetModules(false);
            return System.IO.Path.GetDirectoryName(modules[0].FullyQualifiedName);
        }

        [TestMethod]
        public void CheckHeaderTests()
        {
            DecoderReader decoderReader = new DecoderReader(System.IO.Path.Combine(GetExecDirectory(), "TestFiles/encoded_file.txt"));
            decoderReader.ReadBit();
        }
    }
}
