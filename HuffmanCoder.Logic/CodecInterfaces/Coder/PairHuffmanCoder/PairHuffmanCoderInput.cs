using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Readers.Encoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.PairHuffmanCoder
{
    class PairHuffmanCoderInput : ICoderInput<Tuple<byte, byte>>
    {
        private bool isEnd = false;

        private IInputReader inputReader;

        public PairHuffmanCoderInput(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }
        public bool IsEnd()
        {
            return isEnd;
        }

        public Tuple<byte, byte> Read()
        {
            byte firstSymbol = inputReader.Current;
            isEnd = !inputReader.MoveNext();
            if(isEnd)
            {
                return new Tuple<byte, byte>(firstSymbol, (byte)0);
            }
            else
            {
                byte secondSymbol = inputReader.Current;
                isEnd = !inputReader.MoveNext();
                return new Tuple<byte, byte>(firstSymbol, secondSymbol);
            }
        }
    }
}
