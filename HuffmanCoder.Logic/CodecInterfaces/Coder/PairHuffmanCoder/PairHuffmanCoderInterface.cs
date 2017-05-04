using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Readers.Encoding;
using HuffmanCoder.Logic.Writers.Encoding;
using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Entities;
using HuffmanCoder.Logic.CodecInterfaces.Comparers;

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.PairHuffmanCoder
{
    public class PairHuffmanCoderInterface : IHuffmanCoderInterface
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
            var symbolQuantityDic = createDictionary();
            var builder = new HuffmanCodecBuilder<Tuple<byte, DefaultableSymbol<byte>>>();
            var tree = builder.BuildTree(new PairComparer(), symbolQuantityDic);
            var coder = builder.GetCoder(tree);
            var coderInput = new PairHuffmanCoderInput(inputReader);
            coder.Encode(coderInput, new HuffmanCoderOutput(coderOutputWriter));
            coderOutputWriter.CreateFileBytes(HuffmanEncodeModel.Block, coderInput.isSpecialSymbol, SymbolQuantityMapConverter.PairIntToExtConvert(symbolQuantityDic, coder.GetEncodingDictionary()));
        }

        private Dictionary<Tuple<byte, DefaultableSymbol<byte>>, int> createDictionary()
        {
            var symbolQuantityDic = new Dictionary<Tuple<byte, DefaultableSymbol<byte>>, int>();
            PairHuffmanCoderInput coderInput = new PairHuffmanCoderInput(inputReader);
            do
            {
                Tuple<byte, DefaultableSymbol<byte>> symbol = coderInput.Read();
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
