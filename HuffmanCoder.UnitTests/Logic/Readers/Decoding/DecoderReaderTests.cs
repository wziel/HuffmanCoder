using HuffmanCoder.Logic.Readers.Decoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        public void DecoderReader_HeaderSize()
        {
            DecoderReader decoderReader = new DecoderReader(System.IO.Path.Combine(GetExecDirectory(), "TestFiles/encoded_file.txt"));
            Assert.AreEqual(235, decoderReader.SymbolCounts.Count);
        }

        [TestMethod]
        public void DecoderReader_FirstByteRead()
        {
            var firstByte = new bool[8] { true, false, false, false, true, true, false, false};
            DecoderReader decoderReader = new DecoderReader(System.IO.Path.Combine(GetExecDirectory(), "TestFiles/encoded_file.txt"));
            for (int i=0; i< firstByte.Length; ++i)
            {
                Assert.AreEqual(firstByte[i],decoderReader.ReadBit());
            }
        }
    }
}
