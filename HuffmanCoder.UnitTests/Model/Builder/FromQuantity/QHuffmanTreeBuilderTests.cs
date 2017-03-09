using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Builder.FromQuantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Builder.FromQuantity
{
    [TestClass]
    public class QHuffmanTreeBuilderTests
    {
        QHuffmanTreeBuilder<char> builder;

        [TestInitialize]
        public void TestInitialize()
        {
            builder = new QHuffmanTreeBuilder<char>(Comparer<char>.Default);
        }

        [TestMethod]
        public void Add_CanAddValue()
        {
            //given
            //when
            builder.Add('c');
            //then - sukces
        }

        [TestMethod]
        public void BuildTree_WhenMoreThanOneSymbolsAdded()
        {
            //given
            builder.Add('c');
            builder.Add('c');
            builder.Add('d');
            //when
            builder.BuildTree();
            //then - sukces
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BuildTree_ExceptionWhenNoSymbolsAdded()
        {
            //given
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
            builder.Add('a');
            builder.Add('a');
            builder.Add('a', 4);
            //when
            builder.BuildTree();
            //then - no exception, fail
            throw new AssertFailedException();
        }

        [TestMethod]
        public void BuildTree_LessProbableIsLeft()
        {
            //given
            builder.Add('a', 10); //1
            builder.Add('b', 5); //0
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
            builder.Add('a', 10); //0
            builder.Add('b', 10); //1
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
            builder.Add('a', 2); //01
            builder.Add('b', 1); //00
            builder.Add('c', 10); //1
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
            builder.Add('a', 8); //11
            builder.Add('b', 7); //10
            builder.Add('c', 10); //0
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
            builder.Add('a', 5); //10
            builder.Add('b', 5); //11
            builder.Add('c', 10); //0
            //when
            var treeRoot = builder.BuildTree();
            //then
            Assert.AreEqual('a', treeRoot.RightChild.LeftChild.Value);
            Assert.AreEqual('b', treeRoot.RightChild.RightChild.Value);
            Assert.AreEqual('c', treeRoot.LeftChild.Value);
        }
    }
}