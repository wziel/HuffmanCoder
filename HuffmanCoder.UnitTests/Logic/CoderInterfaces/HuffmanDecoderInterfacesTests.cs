using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HuffmanCoder.Logic.Readers.Decoding;
using HuffmanCoder.Logic.Writers.Decoding;
using System.Collections;
using HuffmanCoder.Logic.Entities;
using HuffmanCoder.Logic.CodecInterfaces.Decoder.StandardHuffmanDecoder;
using HuffmanCoder.Logic.CodecInterfaces.Decoder.PairHuffmanDecoder;
using HuffmanCoder.Logic.CodecInterfaces.Decoder.MarkowHuffmanDecoder;
using HuffmanCoder.Logic.CodecInterfaces;

namespace HuffmanCoder.UnitTests.Logic.CoderInterfaces
{
    [TestClass]
    public class HuffmanDecoderInterfacesTests
    {
        [TestMethod]
        public void StandardDecoderDecodeOutput()
        {
            //given
            int[] input = new int[] { 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            MockDecoderFileWriter mockDecoderFileWriter = new MockDecoderFileWriter();
            var symbolQuantityDic = new Dictionary<string, ushort>()
            {
                {"A", 4 },
                {"B", 3 },
                {"C", 2 },
                {"D", 1 }
            };
            MockDecoderReader mockDecoderReader = new MockDecoderReader(input, symbolQuantityDic);

            //when
            StandardHuffmanDecoderInterface standardHuffmanDecoder = new StandardHuffmanDecoderInterface(mockDecoderReader, mockDecoderFileWriter);
            standardHuffmanDecoder.Decode();

            //then
            mockDecoderFileWriter.AssertEquals(new List<byte>() { (byte)'A', (byte)'B', (byte)'C', (byte)'A', (byte)'B', (byte)'D', (byte)'A', (byte)'B', (byte)'C', (byte)'A' });

        }

        [TestMethod]
        public void PairDecoderDecodeOutput()
        {
            //given
            int[] input = new int[] { 1, 1, 0, 1, 0, 1, 1, 0 };
            MockDecoderFileWriter mockDecoderFileWriter = new MockDecoderFileWriter();
            var symbolQuantityDic = new Dictionary<string, ushort>()
            {
                {"AB", 2 },
                {"CA", 2 },
                {"BD", 1 }
            };
            MockDecoderReader mockDecoderReader = new MockDecoderReader(input, symbolQuantityDic);

            //when
            PairHuffmanDecoderInterface pairHuffmanDecoder = new PairHuffmanDecoderInterface(mockDecoderReader, mockDecoderFileWriter, true);
            pairHuffmanDecoder.Decode();

            //then
            mockDecoderFileWriter.AssertEquals(new List<byte>() { (byte)'A', (byte)'B', (byte)'C', (byte)'A', (byte)'B', (byte)'D', (byte)'A', (byte)'B', (byte)'C', (byte)'A' });

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void MarkowDecoderDecodeOutput()
        {
            //given
            int[] input = new int[] { 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0 };
            MockDecoderFileWriter mockDecoderFileWriter = new MockDecoderFileWriter();
            var symbolQuantityDic = new Dictionary<string, ushort>()
            {
                {"A", 1 },
                {"AA", 2 },
                {"AB", 1 },
                {"AC", 1 },
                {"BC", 1 },
                {"BA", 1 },
                {"CA", 1 },
                {"CD", 1 },
                {"DB", 1 }
            };
            //{
            //    { new DefaultableSymbol<byte>(true), new Dictionary<byte, int>()
            //        {
            //            {(byte) 'A', 1}
            //        }
            //    },
            //    { new DefaultableSymbol<byte>((byte) 'A'), new Dictionary<byte, int>()
            //        {
            //            {(byte) 'A', 2},
            //            {(byte) 'B', 1},
            //            {(byte) 'C', 1}
            //        }
            //    },
            //    { new DefaultableSymbol<byte>((byte) 'B'), new Dictionary<byte, int>()
            //        {
            //            {(byte) 'C', 1},
            //            {(byte) 'A', 1}
            //        }
            //    },
            //    { new DefaultableSymbol<byte>((byte) 'C'), new Dictionary<byte, int>()
            //        {
            //            {(byte) 'A', 1},
            //            {(byte) 'D', 1}
            //        }
            //    },
            //    { new DefaultableSymbol<byte>((byte) 'D'), new Dictionary<byte, int>()
            //        {
            //            {(byte) 'B', 1}
            //        }
            //    },
            //};

            MockDecoderReader mockDecoderReader = new MockDecoderReader(input, symbolQuantityDic);

            //when
            MarkowHuffmanDecoderInterface markowHuffmanDecoder = new MarkowHuffmanDecoderInterface(mockDecoderReader, mockDecoderFileWriter);
            markowHuffmanDecoder.Decode();

            //then
            mockDecoderFileWriter.AssertEquals(new List<byte>() { (byte)'A', (byte)'A', (byte)'B', (byte)'C', (byte)'A', (byte)'C', (byte)'D', (byte)'B', (byte)'A', (byte)'A' });

        }
        private class MockDecoderReader : IDecoderReader
        {
            private int[] bits;
            private int index = 0;
            private Dictionary<string, ushort> symbolCounts;

            public MockDecoderReader(int[] bits, Dictionary<string, ushort> symbolCounts)
            {
                this.bits = bits;
                this.symbolCounts = symbolCounts;
            }

            public HuffmanEncodeModel HuffmanEncodeModel
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public bool IsByteCountEven
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Dictionary<string, ushort> SymbolCounts
            {
                get
                {
                    return this.symbolCounts;
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool ReadBit()
            {
                return bits[index++] != 0;               
            }
        }

        private class MockDecoderFileWriter : IDecoderFileWriter
        {
            private List<byte> output = new List<byte>();
            public void Save()
            {
                throw new NotImplementedException();
            }

            public void Write(byte data)
            {
                output.Add(data);
            }

            public List<char> getOutput()
            {
                List<char> charOutput = new List<char>();
                foreach(byte data in output)
                {
                    charOutput.Add((char)data);
                }
                return charOutput;
            }

            public void AssertEquals(List<byte> expected)
            {
                if (expected.Count != output.Count)
                {
                    Fail(expected);
                }
                for (int i = 0; i < output.Count; ++i)
                {
                    if (expected[i] != output[i])
                    {
                        Fail(expected);
                    }
                }
            }

            public void Fail(List<byte> expected)
            {
                throw new AssertFailedException($"Expected is not equal to received");
            }
        }
    }
}
