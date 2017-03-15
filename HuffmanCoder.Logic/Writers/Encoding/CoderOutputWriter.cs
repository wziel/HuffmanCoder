using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Writers.Encoding
{
    public interface ICoderOutputWriter
    {
        void Write(bool bit);
        void CreateFileBytes(Dictionary<string, OutputValues> map);
        Dictionary<string, OutputValues> SymbolMap { get; }
        uint Size { get; }
        byte[] FileBytes { get; }
    }
    public class CoderOutputWriter : ICoderOutputWriter
    {
        private uint currentSize = 0;
        private List<Byte> data = new List<byte>();
        private IByteCreator byteCreator;
        private Dictionary<string, OutputValues> symbolMap;
        private List<Byte> header = new List<byte>();
        private uint bitsAmount = 0;
        private byte[] fileBytes;
        private IHeaderCreator headerCreator;

        public CoderOutputWriter(IByteCreator byteCreator, IHeaderCreator headerCreator)
        {
            this.byteCreator = byteCreator;
            this.headerCreator = headerCreator;
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
                return fileBytes;
            }
        }

        public uint Size
        {
            get
            {
                return currentSize;
            }
        }

        public void Write(bool bit)
        {
            if (byteCreator.IsReady)
            {
                ++currentSize;
                data.Add(byteCreator.Data);
            }
            else
                byteCreator.Add(bit);
            ++bitsAmount;
        }

        public void CreateFileBytes(Dictionary<string, OutputValues> map)
        {
            byte[] header = headerCreator.Create(bitsAmount, map);
            this.symbolMap = map;
            if (byteCreator.IsEmpty == false)
            {
                ++currentSize;
                data.Add(byteCreator.CurrentByteAligned);
            }
            fileBytes = header.Concat(data).ToArray();
        }
    }
}
