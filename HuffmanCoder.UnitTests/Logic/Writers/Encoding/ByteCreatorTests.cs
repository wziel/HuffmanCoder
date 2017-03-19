using HuffmanCoder.Logic.Writers.Encoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Writers
{
    [TestClass]
    public class ByteCreatorTests
    {
        [TestMethod]
        public void ZeroBits()
        {
            IByteCreator byteCreator = new ByteCreator();
            Assert.AreEqual(byteCreator.IsReady, false);
            Assert.AreEqual(byteCreator.IsEmpty, true);
        }

        [TestMethod]
        public void OneBit()
        {
            IByteCreator byteCreator = new ByteCreator();
            byteCreator.Add(true);
            Assert.AreEqual(byteCreator.IsReady, false);
            Assert.AreEqual(byteCreator.IsEmpty, false);
        }

        [TestMethod]
        public void OneByteOnlyTrue()
        {
            IByteCreator byteCreator = new ByteCreator();
            for (int i=0; i<8; ++i)
                byteCreator.Add(true);
            Assert.AreEqual(byteCreator.IsReady, true);
            Assert.AreEqual((byte)255, byteCreator.Data);
        }

        [TestMethod]
        public void OneByteOnlyTrue_OneBit()
        {
            IByteCreator byteCreator = new ByteCreator();
            for (int i = 0; i < 8; ++i)
                byteCreator.Add(true);
            Assert.AreEqual(byteCreator.IsReady, true);
            Assert.AreEqual((byte)255, byteCreator.Data);
            Assert.AreEqual(byteCreator.IsEmpty, true);
            byteCreator.Add(true);
            Assert.AreEqual((byte)128, byteCreator.Data);
            Assert.AreEqual(byteCreator.IsReady, false);
            Assert.AreEqual(byteCreator.IsEmpty, true);
        }

        [TestMethod]
        public void OneByteMixedValue()
        {
            IByteCreator byteCreator = new ByteCreator();
            byteCreator.Add(true);
            byteCreator.Add(true);
            byteCreator.Add(true);
            byteCreator.Add(true);
            byteCreator.Add(false);
            byteCreator.Add(false);
            byteCreator.Add(false);
            byteCreator.Add(false);
            Assert.AreEqual(byteCreator.IsReady, true);
            Assert.AreEqual((byte)240, byteCreator.Data);
            Assert.AreEqual(byteCreator.IsReady, false);
            Assert.AreEqual(byteCreator.IsEmpty, true);
        }
    }
}
