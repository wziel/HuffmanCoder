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
            byte[] header = headerCrator.Create(30, new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>());
            Assert.AreEqual(8, header.Length);
        }

        [TestMethod]
        public void OneSymbolInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(10, map);
            Assert.AreEqual(13, header.Length);
        }

        [TestMethod]
        public void TwoSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("B", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 3 });
            byte[] header = headerCrator.Create(10, map);
            Assert.AreEqual(18, header.Length);
        }

        [TestMethod]
        public void ThreeSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("A", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("B", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 3 });
            map.Add("C", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 7 });
            byte[] header = headerCrator.Create(10, map);
            Assert.AreEqual(23, header.Length);
        }

        [TestMethod]
        public void OneDoubleSymbolInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("AA", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(10, map);
            Assert.AreEqual(14, header.Length);
        }

        [TestMethod]
        public void TwoDoubleSymbolsInMap()
        {
            var headerCrator = new HeaderCreator();
            var map = new Dictionary<string, HuffmanCoder.Logic.Entities.OutputValues>();
            map.Add("AA", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            map.Add("BC", new HuffmanCoder.Logic.Entities.OutputValues { Counts = 5 });
            byte[] header = headerCrator.Create(10, map);
            Assert.AreEqual(20, header.Length);
        }
    }
}
