using HuffmanCoder.Model.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Builder
{
    [TestClass]
    public class HuffmanTreeBuilderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void BuildTree_WhenMoreThanOneSymbolsAdded()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'c', 2 },
                { 'd', 1 }
            });
            //when
            builder.BuildTree();
            //then - sukces
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BuildTree_ExceptionWhenNoSymbolsAdded()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>(Comparer<char>.Default, new Dictionary<char, int>());
            //when
            builder.BuildTree();
            //then - no exception, fail
            throw new AssertFailedException();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BuildTree_ExceptionWhenOneSymbolsAdded()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'c', 66 },
            });
            //when
            builder.BuildTree();
            //then - no exception, fail
            throw new AssertFailedException();
        }

        [TestMethod]
        public void BuildTree_LessProbableIsLeft()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 10 },//1
                { 'b', 5 },//0
            });
            //when
            var treeRoot = builder.BuildTree();
            //then
            Assert.AreEqual('a', treeRoot.RightChild.Value);
            Assert.AreEqual('b', treeRoot.LeftChild.Value);
        }

        [TestMethod]
        public void BuildTree_WhenEqualyProbable_BigIsRight_BecauseComparator()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 10 },//0
                { 'b', 10 },//1
            });
            //when
            var treeRoot = builder.BuildTree();
            //then
            Assert.AreEqual('a', treeRoot.LeftChild.Value);
            Assert.AreEqual('b', treeRoot.RightChild.Value);
        }

        [TestMethod]
        public void BuildTree_TwoSmallAreLessProbableThanBig_BigIsRight_BecauseMoreProbable()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 2 },//01
                { 'b', 1 },//00
                { 'c', 10 },//1
            });
            //when
            var treeRoot = builder.BuildTree();
            //then
            Assert.AreEqual('a', treeRoot.LeftChild.RightChild.Value);
            Assert.AreEqual('b', treeRoot.LeftChild.LeftChild.Value);
            Assert.AreEqual('c', treeRoot.RightChild.Value);
        }

        [TestMethod]
        public void BuildTree_TwoSmallAreMoreProbableThanBig_BigIsLeft_BecauseLessProbable()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 8 },//11
                { 'b', 7 },//10
                { 'c', 10 },//0
            });
            //when
            var treeRoot = builder.BuildTree();
            //then
            Assert.AreEqual('a', treeRoot.RightChild.RightChild.Value);
            Assert.AreEqual('b', treeRoot.RightChild.LeftChild.Value);
            Assert.AreEqual('c', treeRoot.LeftChild.Value);
        }

        [TestMethod]
        public void BuildTree_TwoSmallAreEqualyProbableToBig_BigIsRLeft_BecauseLessSubtreeDepth()
        {
            //given
            var builder = new HuffmanTreeBuilder<char>(Comparer<char>.Default, new Dictionary<char, int>()
            {
                { 'a', 5 },//10
                { 'b', 5 },//11
                { 'c', 10 },//0
            });
            //when
            var treeRoot = builder.BuildTree();
            //then
            Assert.AreEqual('a', treeRoot.RightChild.LeftChild.Value);
            Assert.AreEqual('b', treeRoot.RightChild.RightChild.Value);
            Assert.AreEqual('c', treeRoot.LeftChild.Value);
        }
    }
}