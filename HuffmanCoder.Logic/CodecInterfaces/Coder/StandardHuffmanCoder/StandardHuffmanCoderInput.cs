using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Readers.Encoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.StandardHuffmanCoder
{
    class StandardHuffmanCoderInput : ICoderInput<byte>
    {
        private bool isEnd = false;

        private IInputReader inputReader;

        public StandardHuffmanCoderInput(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }
        public bool IsEnd()
        {
            return isEnd;
        }

        public byte Read()
        {
            byte symbol = inputReader.Current;
            isEnd = !inputReader.MoveNext();
            return symbol;
        }
    }
}
