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
    public class HuffmanDecoderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void Decode_TwoSymbols()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('x', 'a');
            var decoder = new HuffmanDecoder<char>(tree);
            var input = new MockDecoderInput(new List<int> { 1, 0 });
            var output = new MockDecoderOutput(new List<char> { 'a', 'x'});
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        [TestMethod]
        public void Decode_ThreeSymbols_TwoSymbolsAreLeft()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('#', 'x', 'a', 'c');
            var decoder = new HuffmanDecoder<char>(tree);
            var input = new MockDecoderInput(new List<int> { 1, 0, 1, 0, 0 });
            var output = new MockDecoderOutput(new List<char> { 'x', 'c', 'a' });
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        [TestMethod]
        public void Decode_ThreeSymbols_TwoAreRight()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('c', '#', 'x', 'a');
            var decoder = new HuffmanDecoder<char>(tree);
            var input = new MockDecoderInput(new List<int> { 0, 1, 1, 1, 0 });
            var output = new MockDecoderOutput(new List<char> { 'c', 'a', 'x' });
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        [TestMethod]
        public void Decode_FourSymbols_BalancedTree()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('#', '#', 'a', 'b', 'c', 'd');
            var decoder = new HuffmanDecoder<char>(tree);
            var input = new MockDecoderInput(new List<int> { 0, 0, 0, 1, 1, 0, 1, 1 });
            var output = new MockDecoderOutput(new List<char> { 'a', 'b', 'c', 'd' });
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        [TestMethod]
        public void Decode_FourSymbols_DeepTree()
        {
            //given
            var tree = MockHuffmanTreeBuilder.Build('a', '#', 'b', '#', 'c', 'd');
            var decoder = new HuffmanDecoder<char>(tree);
            var input = new MockDecoderInput(new List<int> { 0, 1, 0, 1, 1, 0, 1, 1, 1 });
            var output = new MockDecoderOutput(new List<char> { 'a', 'b', 'c', 'd' });
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        private class MockDecoderInput : IHuffmanDecoderInput
        {
            private List<int> bits;
            private int i = 0;

            public MockDecoderInput(List<int> bits)
            {
                this.bits = bits;
            }

            public bool Read()
            {
                return bits[i++] == 1 ? true : false;
            }
        }

        private class MockDecoderOutput : IHuffmanDecoderOutput<char>
        {
            private List<char> expected;
            private int i = 0;
            private bool foundIncorrectSymbol = false;

            public MockDecoderOutput(List<char> expected)
            {
                this.expected = expected;
            }

            public bool IsEnd()
            {
                return foundIncorrectSymbol || expected.Count == i;
            }

            public void Write(char symbol)
            {
                if (!foundIncorrectSymbol && expected[i] != symbol)
                {
                    foundIncorrectSymbol = true;
                }
                else
                {
                    ++i;
                }
            }
            
            public void AssertCorrectOutput()
            {
                if(foundIncorrectSymbol)
                {
                    throw new AssertFailedException($"Expected a different symbol than received");
                }
                if(expected.Count != i)
                {
                    throw new AssertFailedException("Not all expected symbols have been read");
                }
            }
        }
    }
}