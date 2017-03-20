using HuffmanCoder.Logic.Entities;
using HuffmanCoder.Logic.Writers.Encoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Logic.Writers.Decoding
{
    [TestClass]
    public class HeaderCreatorTests
    {
        [TestMethod]
        public void WithoutMap()
        {
            var headerCrator = new HeaderCreator();
            byte[] header = headerCrator.Create(30, HuffmanEncodeModel.Standard, new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>());
            // Expected: header size - 4 bytes, huffmanEncodeModel - 4 bytes, bitAmount - 4 bytes
            Assert.AreEqual(12, header.Length);
        }

        [TestMethod]
        public void OneSymbolInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(10, HuffmanEncodeModel.Standard, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 4 bytes, bitAmount - 4 bytes, map (A:5) - 3 bytes
            Assert.AreEqual(15, header.Length);
        }

        [TestMethod]
        public void TwoSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("B", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 3 });
            byte[] header = headerCrator.Create(10, HuffmanEncodeModel.Standard, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 4 bytes, bitAmount - 4 bytes, map (A:5;B:3) - 7 bytes
            Assert.AreEqual(19, header.Length);
        }

        [TestMethod]
        public void ThreeSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("B", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 3 });
            map.Add("C", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 7 });
            byte[] header = headerCrator.Create(10, HuffmanEncodeModel.Standard, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 4 bytes, bitAmount - 4 bytes, map (A:5;B:3;C:7) - 11 bytes
            Assert.AreEqual(23, header.Length);
        }

        [TestMethod]
        public void OneDoubleSymbolInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("AA", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(10, HuffmanEncodeModel.Block, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 4 bytes, bitAmount - 4 bytes, map (AA:5) - 4 bytes
            Assert.AreEqual(16, header.Length);
        }

        [TestMethod]
        public void TwoDoubleSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("AA", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("BC", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(10, HuffmanEncodeModel.Block, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 4 bytes, bitAmount - 4 bytes, map (AA:5;BC:5) - 9 bytes
            Assert.AreEqual(21, header.Length);
        }
    }
}
