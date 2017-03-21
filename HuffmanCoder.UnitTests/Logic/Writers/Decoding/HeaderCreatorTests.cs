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
            byte[] header = headerCrator.Create(HuffmanEncodeModel.Standard, true, new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>());
            // Expected: header size - 4 bytes, huffmanEncodeModel - 1 byte, specialSymbol - 1 byte
            Assert.AreEqual(6, header.Length);
        }

        [TestMethod]
        public void OneSymbolInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(HuffmanEncodeModel.Standard, true, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 1 byte, specialSymbol - 1 byte, map (A5) - 3 bytes
            Assert.AreEqual(9, header.Length);
        }

        [TestMethod]
        public void TwoSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("B", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 3 });
            byte[] header = headerCrator.Create(HuffmanEncodeModel.Standard, true, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 1 byte, specialSymbol - 1 byte, map (A5B3) - 6 bytes
            Assert.AreEqual(12, header.Length);
        }

        [TestMethod]
        public void ThreeSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("B", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 3 });
            map.Add("C", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 7 });
            byte[] header = headerCrator.Create(HuffmanEncodeModel.Standard, true, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 1 byte, specialSymbol - 1 byte, map (A5B3C7) - 9 bytes
            Assert.AreEqual(15, header.Length);
        }

        [TestMethod]
        public void OneDoubleSymbolInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("AA", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(HuffmanEncodeModel.Block, true, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 1 byte, specialSymbol - 1 byte, map (AA5) - 4 bytes
            Assert.AreEqual(10, header.Length);
        }

        [TestMethod]
        public void TwoDoubleSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("AA", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("BC", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(HuffmanEncodeModel.Block, true, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 1 byte, specialSymbol - 1 byte, map (AA5BC5) - 8 bytes
            Assert.AreEqual(14, header.Length);
        }

        [TestMethod]
        public void SingleSymbolInMarkovModel()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("BC", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(HuffmanEncodeModel.Markov, true, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 1 byte, specialSymbol - 1 byte, map (A5BC5) - 8 bytes
            Assert.AreEqual(14, header.Length);
        }

        [TestMethod]
        public void SingleSymbolInBlockModel()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("BC", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(HuffmanEncodeModel.Block, true, map);
            // Expected: header size - 4 bytes, huffmanEncodeModel - 1 byte, specialSymbol - 1 byte, map (BC5A5) - 8 bytes
            Assert.AreEqual(14, header.Length);
        }
    }
}
