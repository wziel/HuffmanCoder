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
    }
    public sealed class DecoderReader : IDecoderReader, IDisposable
    {
        private FileStream fileStream;
        private BinaryReader binaryReader;
        private Dictionary<string, ushort> symbolCounts;

        private byte positionInByte=0;
        private BitArray currentBitArray;
        public DecoderReader(string inputPath)
        {
            this.fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            this.binaryReader = new BinaryReader(fileStream);
            InitHeader();
            currentBitArray = new BitArray(binaryReader.ReadByte());
        }

        private void InitHeader()
        {
            bool specialSymbol = true;
            uint headerSize = binaryReader.ReadUInt32();
            byte huffmanEncodeModel = binaryReader.ReadByte();
            byte specialSymbolByte = binaryReader.ReadByte();
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

        public void Dispose()
        {
            fileStream.Dispose();
            binaryReader.Dispose();
        }

        public bool ReadBit()
        {
            bool bit;
            if (positionInByte == 8)
            {
                currentBitArray = new BitArray(binaryReader.ReadByte());
                positionInByte = 0;
            }
            bit = currentBitArray[positionInByte];
            ++positionInByte;
            return bit;
        }
    }
}
