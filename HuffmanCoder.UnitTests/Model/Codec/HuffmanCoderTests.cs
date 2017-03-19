using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Codec
{
    [TestClass]
    public class HuffmanCoderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void Encode_TwoNodes()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('b', 'a');
            var coder = new HuffmanCoder<char>(tree);
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'a', 'b' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 1, 1, 0 });
        }

        [TestMethod]
        public void Encode_ThreeNodes_TwoAreLeft()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('#', 'b', 'a', 'c');
            var coder = new HuffmanCoder<char>(tree);
            var input = new MockCoderInput<char>(new List<char>() { 'c', 'a', 'b' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 0, 1, 0, 0, 1 });
        }

        [TestMethod]
        public void Encode_ThreeNodes_TwoAreRight()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('c', '#', 'b', 'a');
            var coder = new HuffmanCoder<char>(tree);
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'b', 'c' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 1, 1, 1, 0, 0 });
        }

        [TestMethod]
        public void Encode_FourNodes_BalancedTree()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('#', '#', 'a', 'b', 'c', 'd');
            var coder = new HuffmanCoder<char>(tree);
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'b', 'c', 'd' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 0, 0, 0, 1, 1, 0, 1, 1 });
        }

        [TestMethod]
        public void Encode_FourNodes_DeepTree()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('a', '#', 'b', '#', 'c', 'd');
            var coder = new HuffmanCoder<char>(tree);
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'b', 'c', 'd' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 0, 1, 0, 1, 1, 0, 1, 1, 1 });
        }
    }
}