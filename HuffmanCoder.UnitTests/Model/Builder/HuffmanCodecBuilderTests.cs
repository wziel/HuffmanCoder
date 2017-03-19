using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Builder
{
    [TestClass]
    public class HuffmanCodecBuilderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }
        
        [ExpectedException(typeof(Exception))]
        public void BuildTree_WhenOneSymbolIsAdded()
        {
            //given when
            var tree = new HuffmanCodecBuilder<char>().BuildTree(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'c', 2 }
            });
            //then - sukces
        }

        [TestMethod]
        public void BuildTree_WhenMoreThanOneSymbolsAdded()
        {
            //given when
            var tree = new HuffmanCodecBuilder<char>().BuildTree(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'c', 2 },
                { 'd', 1 }
            });
            //then - sukces
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BuildTree_ExceptionWhenNoSymbolsAdded()
        {
            //given when
            var tree = new HuffmanCodecBuilder<char>().BuildTree(Comparer<char>.Default, new Dictionary<char, int>());
            //then - no exception, fail
            throw new AssertFailedException();
        }

        [TestMethod]
        public void BuildTree_LessProbableIsLeft()
        {
            //given when
            var treeRoot = new HuffmanCodecBuilder<char>().BuildTree(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 10 },//1
                { 'b', 5 },//0
            });
            //then
            Assert.AreEqual('a', treeRoot.RightChild.Value);
            Assert.AreEqual('b', treeRoot.LeftChild.Value);
        }

        [TestMethod]
        public void BuildTree_WhenEqualyProbable_BigIsRight_BecauseComparator()
        {
            //given when
            var treeRoot = new HuffmanCodecBuilder<char>().BuildTree(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 10 },//0
                { 'b', 10 },//1
            });
            //then
            Assert.AreEqual('a', treeRoot.LeftChild.Value);
            Assert.AreEqual('b', treeRoot.RightChild.Value);
        }

        [TestMethod]
        public void BuildTree_TwoSmallAreLessProbableThanBig_BigIsRight_BecauseMoreProbable()
        {
            //given when
            var treeRoot = new HuffmanCodecBuilder<char>().BuildTree(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 2 },//01
                { 'b', 1 },//00
                { 'c', 10 },//1
            });
            //then
            Assert.AreEqual('a', treeRoot.LeftChild.RightChild.Value);
            Assert.AreEqual('b', treeRoot.LeftChild.LeftChild.Value);
            Assert.AreEqual('c', treeRoot.RightChild.Value);
        }

        [TestMethod]
        public void BuildTree_TwoSmallAreMoreProbableThanBig_BigIsLeft_BecauseLessProbable()
        {
            //given when
            var treeRoot = new HuffmanCodecBuilder<char>().BuildTree(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 8 },//11
                { 'b', 7 },//10
                { 'c', 10 },//0
            });
            //then
            Assert.AreEqual('a', treeRoot.RightChild.RightChild.Value);
            Assert.AreEqual('b', treeRoot.RightChild.LeftChild.Value);
            Assert.AreEqual('c', treeRoot.LeftChild.Value);
        }

        [TestMethod]
        public void BuildTree_TwoSmallAreEqualyProbableToBig_BigIsRLeft_BecauseLessSubtreeDepth()
        {
            //given when
            var treeRoot = new HuffmanCodecBuilder<char>().BuildTree(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 5 },//10
                { 'b', 5 },//11
                { 'c', 10 },//0
            });
            //then
            Assert.AreEqual('a', treeRoot.RightChild.LeftChild.Value);
            Assert.AreEqual('b', treeRoot.RightChild.RightChild.Value);
            Assert.AreEqual('c', treeRoot.LeftChild.Value);
        }

        [TestMethod]
        public void GetCoder_ReturnsOneSymbolCoder_WhenOneSymbolOnly()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>();
            var treeRoot = new HuffmanTreeNode<char>(value: 'a', quantity: 1);
            //when
            var coder = builder.GetCoder(treeRoot);
            //then
            Assert.IsInstanceOfType(coder, typeof(OneSymbolCoder<char>));
        }

        [TestMethod]
        public void GetCoder_ReturnsHuffmanCoder_WhenMoreThanOneSymbol()
        {
            //given when
            var builder = new HuffmanCodecBuilder<char>();
            var treeRoot = new HuffmanTreeNode<char>(value: 'a', quantity: 1);
            var leftChild = new HuffmanTreeNode<char>(value: 'b', quantity: 1);
            var rightChild = new HuffmanTreeNode<char>(value: 'c', quantity: 1);
            treeRoot.LeftChild = leftChild;
            treeRoot.RightChild = rightChild;
            leftChild.Parent = rightChild.Parent = treeRoot;
            //when
            var coder = builder.GetCoder(treeRoot);
            //then
            Assert.IsInstanceOfType(coder, typeof(HuffmanCoder<char>));
        }

        [TestMethod]
        public void GetDecoder_ReturnsOneSymbolDecoder_WhenOneSymbolOnly()
        {
            //given
            var builder = new HuffmanCodecBuilder<char>();
            var treeRoot = new HuffmanTreeNode<char>(value: 'a', quantity: 1);
            //when
            var decoder = builder.GetDecoder(treeRoot);
            //then
            Assert.IsInstanceOfType(decoder, typeof(OneSymbolDecoder<char>));
        }

        [TestMethod]
        public void GetCoder_ReturnsHuffmanDecoder_WhenMoreThanOneSymbol()
        {
            //given when
            var builder = new HuffmanCodecBuilder<char>();
            var treeRoot = new HuffmanTreeNode<char>(value: 'a', quantity: 1);
            var leftChild = new HuffmanTreeNode<char>(value: 'b', quantity: 1);
            var rightChild = new HuffmanTreeNode<char>(value: 'c', quantity: 1);
            treeRoot.LeftChild = leftChild;
            treeRoot.RightChild = rightChild;
            leftChild.Parent = rightChild.Parent = treeRoot;
            //when
            var decoder = builder.GetDecoder(treeRoot);
            //then
            Assert.IsInstanceOfType(decoder, typeof(HuffmanDecoder<char>));
        }
    }
}