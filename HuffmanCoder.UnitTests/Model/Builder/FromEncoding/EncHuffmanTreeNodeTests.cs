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
    public class EncHuffmanTreeNodeTests
    {
        [TestMethod]
        public void IsAssignedValue_FalseWhenValueNotChanged()
        {
            //given
            var node = new EncHuffmanTreeNode<char>();
            //when
            //then
            Assert.IsFalse(node.IsAssignedValue);
        }

        [TestMethod]
        public void IsAssignedValue_TrueWhenValueChanged()
        {
            //given
            var node = new EncHuffmanTreeNode<char>();
            //when
            node.Value = 'a';
            //then
            Assert.IsTrue(node.IsAssignedValue);
        }
    }
}
