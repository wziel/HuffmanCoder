using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HuffmanCoder.Logic.Readers.Encoding;
using HuffmanCoder.Logic.Writers.Encoding;
using System.Collections;
using HuffmanCoder.Logic.Entities;
using HuffmanCoder.Logic.CodecInterfaces.Coder.StandardHuffmanCoder;
using HuffmanCoder.Logic.CodecInterfaces.Coder.PairHuffmanCoder;
using HuffmanCoder.Logic.CodecInterfaces.Coder.MarkowHuffmanCoder;

namespace HuffmanCoder.UnitTests.Logic.CoderInterfaces
{
    [TestClass]
    public class HuffmanCoderInterfacesTests
    {
        [TestMethod]
        public void StandardCoderEncodeInput()
        {
            //given
            byte[] input = new byte[] { (byte) 'A', (byte) 'B', (byte) 'C', (byte) 'A', (byte) 'B', (byte) 'D', (byte)'A', (byte)'B', (byte)'C', (byte)'A'};
            MockInputReader inputReader = new MockInputReader(input);
            MockCoderOutputWriter outputWriter = new MockCoderOutputWriter();

            //when
            StandardHuffmanCoderInterface standardHuffmanCoderInterface = new StandardHuffmanCoderInterface(inputReader, outputWriter);
            standardHuffmanCoderInterface.Encode();

            //then
            outputWriter.AssertEquals(new List<int>() { 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0 });
        }

        [TestMethod]
        public void PairCoderEncodeInput()
        {
            //given
            byte[] input = new byte[] { (byte)'A', (byte)'B', (byte)'C', (byte)'A', (byte)'B', (byte)'D', (byte)'A', (byte)'B', (byte)'C', (byte)'A' };
            MockInputReader inputReader = new MockInputReader(input);
            MockCoderOutputWriter outputWriter = new MockCoderOutputWriter();

            //when
            PairHuffmanCoderInterface pairHuffmanCoderInterface = new PairHuffmanCoderInterface(inputReader, outputWriter);
            pairHuffmanCoderInterface.Encode();

            //then
            outputWriter.AssertEquals(new List<int>() { 1, 1, 0, 1, 0, 1, 1, 0 });
        }

        [TestMethod]
        public void MarkowCoderEncodeInput()
        {
            //given
            byte[] input = new byte[] { (byte)'A', (byte)'A', (byte)'B', (byte)'C', (byte)'A', (byte)'C', (byte)'D', (byte)'B', (byte)'A', (byte)'A' };
            MockInputReader inputReader = new MockInputReader(input);
            MockCoderOutputWriter outputWriter = new MockCoderOutputWriter();

            //when
            MarkowHuffmanCoderInterface markowHuffmanCoderInterface = new MarkowHuffmanCoderInterface(inputReader, outputWriter);
            markowHuffmanCoderInterface.Encode();

            //then
            outputWriter.AssertSize(12);


        }

        private class MockInputReader : IInputReader
        {
            private byte[] input;
            private int index = 0;

            internal MockInputReader(byte[] input)
            {
                this.input = input;
            }
            public byte Current
            {
                get
                {
                    return input[index];
                }
            }

            public uint Size
            {
                get
                {
                    return (uint)input.Length;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return input[index];
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                index++;
                if(index < input.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                index = 0;
            }
        }

        private class MockCoderOutputWriter : ICoderOutputWriter
        {
            private uint size = 0;
            public Dictionary<string, OutputValues> symbolMap;
            public List<int> output = new List<int>();
            public uint Size
            {
                get
                {
                    return size;
                }
            }

            public Dictionary<string, OutputValues> SymbolMap
            {
                get
                {
                    return symbolMap;
                }
            }

            public byte[] FileBytes
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Save(Dictionary<string, OutputValues> map)
            {
                this.symbolMap = map;
            }

            public void Write(bool bit)
            {
                this.output.Add(bit ? 1 : 0);
                ++size;
            }

            public void AssertEquals(List<int> expected)
            {
                if (expected.Count != output.Count)
                {
                    Fail(expected);
                }
                for (int i = 0; i < expected.Count; ++i)
                {
                    if (output[i] != expected[i])
                    {
                        Fail(expected);
                    }
                }
            }

            public void AssertSize(int expected)
            {
                if (size != expected)
                {
                    throw new AssertFailedException($"Size of output doesn't equals expected size.");
                }
            }

            public void Fail(List<int> expected)
            {
                throw new AssertFailedException($"Expected is not equal to received");
            }

            public void CreateFileBytes(HuffmanEncodeModel huffmanEncodeMode, bool specialSymbol, Dictionary<string, OutputValues> map)
            {
                throw new NotImplementedException();
            }
        }
    }
}
