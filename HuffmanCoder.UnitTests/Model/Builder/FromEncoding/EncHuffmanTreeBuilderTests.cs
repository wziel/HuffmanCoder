using HuffmanCoder.Model.Builder.FromEncoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Builder.FromEncoding
{
    [TestClass]
    public class EncHuffmanTreeBuilderTests
    {
        [TestMethod]
        public void Constructor_EmptyDictioanry()
        {
            //given
            //when
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>() { });
            //then sukces
        }

        [TestMethod]
        public void Constructor_OneSymbol()
        {
            //given
            //when
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { true, false } }
            });
            //then sukces
        }

        [TestMethod]
        public void Constructor_MoreSymbols()
        {
            //given
            //when
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { true, false } },
                { 'b', new bool[] { true, false } },
                { 'c', new bool[] { } }
            });
            //then sukces
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Build_NoSymbols_Exception()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
            });
            //when
            var tree = builder.BuildTree();
            //then oczekiwano wyjątku
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Build_OneSymbol_Exception()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { true } },
            });
            //when
            var tree = builder.BuildTree();
            //then oczekiwano wyjątku
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Build_TwoSymbolsWithTheSameBits_Exception()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { true } },
                { 'b', new bool[] { true } },
            });
            //when
            var tree = builder.BuildTree();
            //then oczekiwano wyjątku
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Build_OneNodeHasOnlyOneChild_Exception()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { true, false } },
                { 'b', new bool[] { true, true } },
            });
            //when
            var tree = builder.BuildTree();
            //then oczekiwano wyjątku
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Build_OneSymbolIsNotALeaf_Exception()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { false, } },
                { 'b', new bool[] { true } },
                { 'c', new bool[] { true, false } },
                { 'd', new bool[] { true, true } },
            });
            //when
            var tree = builder.BuildTree();
            //then oczekiwano wyjątku
        }

        [TestMethod]
        public void Build_TwoSymbols_FalseIsLeft_TrueIsRight()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { false, } },
                { 'b', new bool[] { true } },
            });
            //when
            var tree = builder.BuildTree();
            //then
            Assert.AreEqual('a', tree.LeftChild.Value);
            Assert.AreEqual('b', tree.RightChild.Value);
        }

        [TestMethod]
        public void Build_ThreeSymbols()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { false, } },
                { 'b', new bool[] { true, true } },
                { 'c', new bool[] { true, false } },
            });
            //when
            var tree = builder.BuildTree();
            //then
            Assert.AreEqual('a', tree.LeftChild.Value);
            Assert.AreEqual('b', tree.RightChild.RightChild.Value);
            Assert.AreEqual('c', tree.RightChild.LeftChild.Value);
        }

        [TestMethod]
        public void Build_FourSymbols_DeepTree()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { false, } },
                { 'b', new bool[] { true, false } },
                { 'c', new bool[] { true, true, false } },
                { 'd', new bool[] { true, true, true } },
            });
            //when
            var tree = builder.BuildTree();
            //then
            Assert.AreEqual('a', tree.LeftChild.Value);
            Assert.AreEqual('b', tree.RightChild.LeftChild.Value);
            Assert.AreEqual('c', tree.RightChild.RightChild.LeftChild.Value);
            Assert.AreEqual('d', tree.RightChild.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void Build_FourSymbols_ShallowTree()
        {
            //given
            var builder = new EncHuffmanTreeBuilder<char>(new Dictionary<char, bool[]>()
            {
                { 'a', new bool[] { false, true } },
                { 'b', new bool[] { false, false } },
                { 'c', new bool[] { true, true,} },
                { 'd', new bool[] { true, false } },
            });
            //when
            var tree = builder.BuildTree();
            //then
            Assert.AreEqual('a', tree.LeftChild.RightChild.Value);
            Assert.AreEqual('b', tree.LeftChild.LeftChild.Value);
            Assert.AreEqual('c', tree.RightChild.RightChild.Value);
            Assert.AreEqual('d', tree.RightChild.LeftChild.Value);
        }
    }
}