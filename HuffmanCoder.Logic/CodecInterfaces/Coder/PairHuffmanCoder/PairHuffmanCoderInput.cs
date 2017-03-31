using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Readers.Encoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.PairHuffmanCoder
{
    class PairHuffmanCoderInput : ICoderInput<Tuple<byte, DefaultableSymbol<byte>>>
    {
        private bool isEnd = false;

        public bool isSpecialSymbol
        {
            get; set;
        } = false;

        private IInputReader inputReader;

        public PairHuffmanCoderInput(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }
        public bool IsEnd()
        {
            return isEnd;
        }

        public Tuple<byte, DefaultableSymbol<byte>> Read()
        {
            byte firstSymbol = inputReader.Current;
            isEnd = !inputReader.MoveNext();
            if(isEnd)
            {
                isSpecialSymbol = true;
                return new Tuple<byte, DefaultableSymbol<byte>>(firstSymbol, new DefaultableSymbol<byte>(true));
            }
            else
            {
                byte secondSymbol = inputReader.Current;
                isEnd = !inputReader.MoveNext();
                return new Tuple<byte, DefaultableSymbol<byte>>(firstSymbol, new DefaultableSymbol<byte>(secondSymbol));
            }
        }
    }
}
