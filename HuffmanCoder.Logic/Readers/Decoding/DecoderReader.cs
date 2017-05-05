using HuffmanCoder.Logic.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Readers.Decoding
{
    public interface IDecoderReader : IDisposable
    {
        Dictionary<string, ushort> SymbolCounts { get; }
        bool ReadBit();
        HuffmanEncodeModel HuffmanEncodeModel { get; }
        bool IsByteCountEven { get; }
    }
    public sealed class DecoderReader : IDecoderReader, IDisposable
    {
        private FileStream fileStream;
        private BinaryReader binaryReader;
        private Dictionary<string, ushort> symbolCounts;
        private byte huffmanEncodeModel;
        private byte specialSymbolByte;

        private short positionInByte=7;
        private int bitsAmount = 0;
        private BitArray currentBitArray;
        public DecoderReader(string inputPath)
        {
            this.fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            this.binaryReader = new BinaryReader(fileStream);
            InitHeader();
            byte[] firstByte = binaryReader.ReadBytes(1);
            currentBitArray = new BitArray(firstByte);
        }

        private void InitHeader()
        {
            bool specialSymbol = true;
            uint headerSize = binaryReader.ReadUInt32();
            this.huffmanEncodeModel = binaryReader.ReadByte();
            this.specialSymbolByte = binaryReader.ReadByte();
            if (specialSymbolByte == 0)
                specialSymbol = false;
            byte[] map = binaryReader.ReadBytes((int)headerSize - 6);
            HeaderReader headerReader = new HeaderReader();
            headerReader.Read(map, specialSymbol, (HuffmanEncodeModel)huffmanEncodeModel);
            this.symbolCounts = headerReader.symbolCounts;
        }

        public Dictionary<string, ushort> SymbolCounts
        {
            get
            {
                return symbolCounts;
            }
        }

        public HuffmanEncodeModel HuffmanEncodeModel
        {
            get
            {
                return (HuffmanEncodeModel)huffmanEncodeModel;
            }
        }

        public bool IsByteCountEven
        {
            get
            {
                return specialSymbolByte == 0;
            }
        }

        public void Dispose()
        {
            fileStream.Dispose();
            binaryReader.Dispose();
        }

        public bool ReadBit()
        {
            bool bit=false;
            if (positionInByte == -1)
            {
                positionInByte = 7;
                currentBitArray = new BitArray(binaryReader.ReadBytes(1));
            }
            bit = currentBitArray[positionInByte];
            --positionInByte;
            ++bitsAmount;
            return bit;
        }
    }
}
