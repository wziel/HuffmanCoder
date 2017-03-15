using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Readers.Encoding;
using HuffmanCoder.Logic.Writers.Encoding;
using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.PairHuffmanCoder
{
    class PairHuffmanCoderInterface : IHuffmanCoderInterface
    {
        private IInputReader inputReader;
        private ICoderOutputWriter coderOutputWriter;
        public PairHuffmanCoderInterface(IInputReader inputReader, ICoderOutputWriter coderOutputWriter)
        {
            this.inputReader = inputReader;
            this.coderOutputWriter = coderOutputWriter;
        }
        public void Encode()
        {
            HuffmanTreeBuilder<Tuple<byte, byte>> huffmanTreeBuilder = new HuffmanTreeBuilder<Tuple<byte, byte>>(Comparer<Tuple<byte, byte>>.Default, createDictionary());
            IHuffmanCoder<Tuple<byte, byte>> huffmanCoder = new HuffmanCoder<Tuple<byte, byte>>(huffmanTreeBuilder.BuildTree());
            huffmanCoder.Encode(new PairHuffmanCoderInput(inputReader), new HuffmanCoderOutput(coderOutputWriter));
        }

        private Dictionary<Tuple<byte, byte>, int> createDictionary()
        {
            Dictionary<Tuple<byte, byte>, int> symbolQuantityDic = new Dictionary<Tuple<byte, byte>, int>();
            PairHuffmanCoderInput coderInput = new PairHuffmanCoderInput(inputReader);
            do
            {
                Tuple<byte, byte> symbol = coderInput.Read();
                if (symbolQuantityDic.ContainsKey(symbol))
                {
                    ++symbolQuantityDic[symbol];
                }
                else
                {
                    symbolQuantityDic.Add(symbol, 1);
                }
            } while (!coderInput.IsEnd());

            inputReader.Reset();

            return symbolQuantityDic;
        }

    }
}
