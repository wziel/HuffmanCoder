﻿using HuffmanCoder.Model.Codec;
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
        void CreateFileBytes(HuffmanEncodeModel huffmanEncodeModel, bool specialSymbol, Dictionary<string, OutputValues> map);
        Dictionary<string, OutputValues> SymbolMap { get; }
        uint Size { get; }
        byte[] FileBytes { get; }
        Header Header { get;  }
    }
    public class CoderOutputWriter : ICoderOutputWriter
    {
        private uint currentSize = 0;
        private List<Byte> data = new List<byte>();
        private IByteCreator byteCreator;
        private Dictionary<string, OutputValues> symbolMap;
        private uint bitsAmount = 0;
        private byte[] fileBytes;
        private Header header;
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

        public Header Header
        {
            get
            {
                return header;
            }
        }

        public void Write(bool bit)
        {
            if (byteCreator.IsReady)
            {
                ++currentSize;
                data.Add(byteCreator.Data);
            }
            byteCreator.Add(bit);
            ++bitsAmount;
        }

        public void CreateFileBytes(HuffmanEncodeModel huffmanEncodeModel, bool specialSymbol, Dictionary<string, OutputValues> map)
        {
            Header header = headerCreator.Create(huffmanEncodeModel, specialSymbol, map);
            this.header = header;
            this.symbolMap = map;

            if (byteCreator.IsEmpty == false)
            {
                ++currentSize;
                data.Add(byteCreator.Data);
            } 
            fileBytes = header.Content.Concat(data).ToArray();
        }
    }
}
