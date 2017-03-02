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
        private HuffmanCodecBuilder<char> builder;

        [TestInitialize]
        public void TestInitialize()
        {
            builder = new HuffmanCodecBuilder<char>(Comparer<char>.Default);
        }

        [TestMethod]
        public void Encode_LessProbableIs0()
        {
            //given
            builder.Add('a', 10); //1
            builder.Add('b', 5); //0
            var coder = builder.GetCoder();
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'a', 'b' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 1, 1, 0 });
        }

        [TestMethod]
        public void Encode_WhenEqualyProbable_BigIs1_BecauseCustomComparator()
        {
            //given
            builder.Add('a', 10); //0
            builder.Add('b', 10); //1
            var coder = builder.GetCoder();
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'a', 'b' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 0, 0, 1 });
        }

        [TestMethod]
        public void Encode_TwoSmallAreLessProbableThanBig_BigIs1_BecauseMoreProbable()
        {
            //given
            builder.Add('a', 2); //01
            builder.Add('b', 1); //00
            builder.Add('c', 10); //1
            var coder = builder.GetCoder();
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'b', 'c' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 0, 1, 0, 0, 1 });
        }

        [TestMethod]
        public void Encode_TwoSmallAreMoreProbableThanBig_BigIs0_BecauseLessProbable()
        {
            //given
            builder.Add('a', 8); //11
            builder.Add('b', 7); //10
            builder.Add('c', 10); //0
            var coder = builder.GetCoder();
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'b', 'c' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 1, 1, 1, 0, 0 });
        }

        [TestMethod]
        public void Encode_TwoSmallAreEqualyProbableToBig_BigIs0_BecauseLessSubtreeDepth()
        {
            //given
            builder.Add('a', 5); //10
            builder.Add('b', 5); //11
            builder.Add('c', 10); //0
            var coder = builder.GetCoder();
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'b', 'c' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 1, 0, 1, 1, 0 });
        }

        private class MockCoderInput<T> : IHuffmanCoderInput<T>
        {
            private List<T> input = new List<T>();
            private int idx = 0;

            internal MockCoderInput(List<T> input)
            {
                this.input = input;
            }

            public bool IsEnd()
            {
                return idx == input.Count;
            }

            public T Read()
            {
                return input[idx++];
            }
        }

        private class MockCoderOutput : IHuffmanCoderOutput
        {
            private List<int> output = new List<int>();

            public void Write(bool bit)
            {
                output.Add(bit ? 1 : 0);
            }

            public void AssertEquals(List<int> expected)
            {
                if(expected.Count != output.Count)
                {
                    Fail(expected);
                }
                for(int i = 0; i < expected.Count; ++i)
                {
                    if(output[i] != expected[i])
                    {
                        Fail(expected);
                    }
                }
            }

            public void Fail(List<int> expected)
            {
                throw new AssertFailedException($"Expected is not equal to received");
            }
        }
    }
}