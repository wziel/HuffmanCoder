using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Readers.Encoding;

namespace HuffmanCoder.Logic.CoderInterfaces.StandardHuffmanCoder
{
    class StandardHuffmanCoderInput : IHuffmanCoderInput<byte>
    {

        private IInputReader inputReader;

        public StandardHuffmanCoderInput(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }
        public bool IsEnd()
        {
            return inputReader.MoveNext();
        }

        public byte Read()
        {
            byte symbol = inputReader.Current;
            inputReader.MoveNext();
            return symbol;
        }
    }
}
