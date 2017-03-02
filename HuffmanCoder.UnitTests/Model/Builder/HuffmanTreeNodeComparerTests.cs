using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Builder
{
    [TestClass]
    public class HuffmanTreeNodeComparerTests
    {
        private HuffmanTreeNodeComparer<char> comparer;

        [TestInitialize]
        public void TestInitialize()
        {
            this.comparer = new HuffmanTreeNodeComparer<char>(Comparer<char>.Default);
        }

        [TestMethod]
        public void Compare_ComparesByQuantitiyFirst()
        {
            //given
            var a = new HuffmanTreeNode<char>('a', 10, 1);
            var b = new HuffmanTreeNode<char>('b', 4, 2);
            var c = new HuffmanTreeNode<char>('c', 15, 0);
            var orderedList = new List<HuffmanTreeNode<char>>(){ b, a, c };
            //then
            AssertOrderCompareByPairs(orderedList);
        }

        [TestMethod]
        public void Compare_ComparesBySubTreeLengthSecond()
        {
            //given
            var a = new HuffmanTreeNode<char>('a', 10, 1);
            var b = new HuffmanTreeNode<char>('b', 10, 2);
            var c = new HuffmanTreeNode<char>('c', 10, 0);
            var orderedList = new List<HuffmanTreeNode<char>>() { c, a, b };
            //then
            AssertOrderCompareByPairs(orderedList);
        }

        [TestMethod]
        public void Compare_ComparesByCustomCompareLast()
        {
            //given
            var a = new HuffmanTreeNode<char>('a', 10, 0);
            var b = new HuffmanTreeNode<char>('b', 10, 0);
            var c = new HuffmanTreeNode<char>('c', 10, 0);
            var orderedList = new List<HuffmanTreeNode<char>>() { a, b, c};
            //then
            AssertOrderCompareByPairs(orderedList);
        }

        private void AssertOrderCompareByPairs(List<HuffmanTreeNode<char>> orderedList)
        {
            for(int i = 0; i < orderedList.Count; ++i)
            for(int j = 0; j < orderedList.Count; ++j)
            if(i != j)
            {
                        var result = comparer.Compare(orderedList[i], orderedList[j]);
                        Assert.AreEqual(Math.Sign(i - j), Math.Sign(result));
            }
        }
    }
}
