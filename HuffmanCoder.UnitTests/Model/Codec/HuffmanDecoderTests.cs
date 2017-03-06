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
        private HuffmanCodecBuilder<char> builder;

        [TestInitialize]
        public void TestInitialize()
        {
            builder = new HuffmanCodecBuilder<char>(Comparer<char>.Default);
        }

        [TestMethod]
        public void Decode_TwoSymbols_LeastProbableIs0()
        {
            //given
            builder.Add('a', 2); //1
            builder.Add('x', 1); //0
            var decoder = builder.GetDecoder();
            var input = new MockDecoderInput(new List<int> { 1, 0 });
            var output = new MockDecoderOutput(new List<char> { 'a', 'x'});
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        [TestMethod]
        public void Decode_TwoSymbolsAndSameProbability__LexicographicallyFirstIs0()
        {
            //given
            builder.Add('x', 1); //1
            builder.Add('a', 1); //0
            var decoder = builder.GetDecoder();
            var input = new MockDecoderInput(new List<int> { 1, 0 });
            var output = new MockDecoderOutput(new List<char> { 'x', 'a' });
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        [TestMethod]
        public void Decode_ThreeSymbols_TwoSummedAreLessProbableThanThird_ThirdIs1_BecauseMoreProbable()
        {
            //given
            builder.Add('x', 1); //00
            builder.Add('a', 2); //01
            builder.Add('c', 10); //1
            var decoder = builder.GetDecoder();
            var input = new MockDecoderInput(new List<int> { 1, 0, 1, 0, 0 });
            var output = new MockDecoderOutput(new List<char> { 'c', 'a', 'x' });
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        [TestMethod]
        public void Decode_ThreeSymbols_TwoSummedAreEquallyProbableToThird_ThirdIs0_BecauseLessSubtreeLength()
        {
            //given
            builder.Add('x', 1); //10
            builder.Add('a', 9); //11
            builder.Add('c', 10); //0
            var decoder = builder.GetDecoder();
            var input = new MockDecoderInput(new List<int> { 0, 1, 1, 1, 0 });
            var output = new MockDecoderOutput(new List<char> { 'c', 'a', 'x' });
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }

        [TestMethod]
        public void Decode_ThreeSymbols_TwoSummedAreMoreProbableThanThird_ThirdIs0_BecauseLessProbable()
        {
            //given
            builder.Add('x', 4); //10
            builder.Add('a', 9); //11
            builder.Add('c', 10); //0
            var decoder = builder.GetDecoder();
            var input = new MockDecoderInput(new List<int> { 0, 1, 1, 1, 0 });
            var output = new MockDecoderOutput(new List<char> { 'c', 'a', 'x' });
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