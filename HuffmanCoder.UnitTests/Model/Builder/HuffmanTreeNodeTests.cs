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
    public class HuffmanTreeNodeTests
    {
        [TestMethod]
        public void IsLeaf_trueWhenOnlyNode()
        {
            //given
            //when
            var node = new HuffmanTreeNode<char>(value: 'a', quantity: 3);
            //then
            Assert.IsTrue(node.IsLeaf);
        }

        [TestMethod]
        public void IsLeaf_FalseWhenHasRightChild()
        {
            //given
            //when
            var node = new HuffmanTreeNode<char>(value: 'a', quantity: 3);
            node.RightChild = new HuffmanTreeNode<char>(value: 'b', quantity: 4);
            //then
            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        public void IsLeaf_FalseWhenHasLeftChild()
        {
            //given
            //when
            var node = new HuffmanTreeNode<char>(value: 'a', quantity: 3);
            node.LeftChild = new HuffmanTreeNode<char>(value: 'b', quantity: 4);
            //then
            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        public void IsLeaf_TrueWhenHasParent()
        {
            //given
            //when
            var node = new HuffmanTreeNode<char>(value: 'a', quantity: 3);
            node.Parent = new HuffmanTreeNode<char>(value: 'b', quantity: 4);
            //then
            Assert.IsTrue(node.IsLeaf);
        }
    }
}
