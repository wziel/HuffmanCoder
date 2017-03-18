using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Readers.Encoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.MarkowHuffmanCoder
{
    class MarkowHuffmanCoderInput : IHuffmanCoderInput<byte>
    {
        private byte symbol;
        bool isEnd = false;

        public MarkowHuffmanCoderInput(byte symbol)
        {
            this.symbol = symbol;
        }
        public bool IsEnd()
        {
            return isEnd;
        }

        public byte Read()
        {
            isEnd = true;
            return symbol;
        }
    }
}
