using HuffmanCoder.Logic.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Logic.Readers
{
    [TestClass]
    public class HeaderReaderTests
    {
        [TestMethod]
        public void HeaderReadOneElementInMapStandar_Tests()
        {
            HeaderReader headerReader = new HeaderReader();
            byte[] map = new Byte[] { 65, 3, 0 };
            headerReader.Read(map, true, HuffmanCoder.Logic.Entities.HuffmanEncodeModel.Standard);   
            Assert.AreEqual((uint)3, headerReader.symbolCounts["A"]);
        }


        [TestMethod]
        public void HeaderReadTwoElementsInMapStandard()
        {
            HeaderReader headerReader = new HeaderReader();
            byte[] map = new Byte[] { 65, 3, 0, 66, 4, 0 };
            headerReader.Read(map, true, HuffmanCoder.Logic.Entities.HuffmanEncodeModel.Standard);
            Assert.AreEqual((uint)3, headerReader.symbolCounts["A"]);
            Assert.AreEqual((uint)4, headerReader.symbolCounts["B"]);
        }

        [TestMethod]
        public void HeaderReadOnelementInMapMarkov()
        {
            HeaderReader headerReader = new HeaderReader();
            byte[] map = new Byte[] { 65, 66, 3, 0 };
            headerReader.Read(map, false, HuffmanCoder.Logic.Entities.HuffmanEncodeModel.Markov);
            Assert.AreEqual((uint)3, headerReader.symbolCounts["AB"]);
        }

        [TestMethod]
        public void HeaderReadTwoElementsInMapMarkovWithSpecialSymbol()
        {
            HeaderReader headerReader = new HeaderReader();
            byte[] map = new Byte[] { 65, 66, 3, 0, 66, 4, 0 };
            headerReader.Read(map, true, HuffmanCoder.Logic.Entities.HuffmanEncodeModel.Markov);
            Assert.AreEqual((uint)3, headerReader.symbolCounts["AB"]);
            Assert.AreEqual((uint)4, headerReader.symbolCounts["B"]);
        }

        [TestMethod]
        public void HeaderReadTwoElementsInMapBlockWithSpecialSymbol()
        {
            HeaderReader headerReader = new HeaderReader();
            byte[] map = new Byte[] { 65, 66, 3, 0, 66, 4, 0 };
            headerReader.Read(map, true, HuffmanCoder.Logic.Entities.HuffmanEncodeModel.Block);
            Assert.AreEqual((uint)3, headerReader.symbolCounts["AB"]);
            Assert.AreEqual((uint)4, headerReader.symbolCounts["B"]);
        }

        [TestMethod]
        public void HeaderReadTwoElementsInMapBlock()
        {
            HeaderReader headerReader = new HeaderReader();
            byte[] map = new Byte[] { 65, 66, 3, 0, 66, 67, 4, 0 };
            headerReader.Read(map, true, HuffmanCoder.Logic.Entities.HuffmanEncodeModel.Block);
            Assert.AreEqual((uint)3, headerReader.symbolCounts["AB"]);
            Assert.AreEqual((uint)4, headerReader.symbolCounts["BC"]);
        }
    }
}
