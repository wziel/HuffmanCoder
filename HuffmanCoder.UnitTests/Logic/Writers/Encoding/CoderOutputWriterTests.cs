using HuffmanCoder.Logic.Entities;
using HuffmanCoder.Logic.Writers.Encoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Logic.Writers.Encoding
{
    [TestClass]
    public class CoderOutputWriterTests
    {
        [TestMethod]
        public void OneBitWritten()
        {
            var mockByteCreator = new Mock<IByteCreator>();
            var mockHeaderCreator = new Mock<IHeaderCreator>();
            var coderOutputWriter = new CoderOutputWriter(mockByteCreator.Object, mockHeaderCreator.Object);
            mockHeaderCreator.Setup(headerCreator => headerCreator.Create(0, new Dictionary<string, OutputValues>())).Returns(new byte[0]);
            mockByteCreator.SetupGet(byteCreator => byteCreator.IsReady).Returns(false);
            coderOutputWriter.Write(true);
            mockByteCreator.SetupGet(byteCreator => byteCreator.IsEmpty).Returns(false);
            coderOutputWriter.CreateFileBytes(new Dictionary<string, OutputValues>());
            Assert.AreEqual(1, coderOutputWriter.FileBytes.Length);
        }

        [TestMethod]
        public void OneByteWritten()
        {
            var mockByteCreator = new Mock<IByteCreator>();
            var mockHeaderCreator = new Mock<IHeaderCreator>();
            var coderOutputWriter = new CoderOutputWriter(mockByteCreator.Object, mockHeaderCreator.Object);
            mockHeaderCreator.Setup(headerCreator => headerCreator.Create(0, new Dictionary<string, OutputValues>())).Returns(new byte[0]);
            mockByteCreator.SetupGet(byteCreator => byteCreator.IsReady).Returns(false);
            for (int i=0; i<8; ++i)
                coderOutputWriter.Write(true);
            mockByteCreator.SetupGet(byteCreator => byteCreator.IsEmpty).Returns(false);
            coderOutputWriter.CreateFileBytes(new Dictionary<string, OutputValues>());
            Assert.AreEqual(1, coderOutputWriter.FileBytes.Length);
        }

        [TestMethod]
        public void OneByteOneBitWritten()
        {
            var mockByteCreator = new Mock<IByteCreator>();
            var mockHeaderCreator = new Mock<IHeaderCreator>();
            var coderOutputWriter = new CoderOutputWriter(mockByteCreator.Object, mockHeaderCreator.Object);
            mockHeaderCreator.Setup(headerCreator => headerCreator.Create(0, new Dictionary<string, OutputValues>())).Returns(new byte[0]);
            mockByteCreator.SetupGet(byteCreator => byteCreator.IsReady).Returns(false);
            for (int i = 0; i < 8; ++i)
                coderOutputWriter.Write(true);
            mockByteCreator.SetupGet(byteCreator => byteCreator.IsReady).Returns(true);
            coderOutputWriter.Write(true);
            mockByteCreator.SetupGet(byteCreator => byteCreator.IsEmpty).Returns(false);
            coderOutputWriter.CreateFileBytes(new Dictionary<string, OutputValues>());
            Assert.AreEqual(2, coderOutputWriter.FileBytes.Length);
        }
    }
}
