using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Readers.Encoding;
using HuffmanCoder.Logic.Writers.Encoding;
using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Logic.CoderInterfaces.StandardHuffmanCoder
{
    class StandardHuffmanCoderInterface : IHuffmanCoderInterface
    {
        private IInputReader inputReader;
        private ICoderOutputWriter coderOutputWriter;
        private IComparer<byte> comparer;
        public StandardHuffmanCoderInterface(IInputReader inputReader, ICoderOutputWriter coderOutputWriter, IComparer<byte> comparer)
        {
            this.inputReader = inputReader;
            this.coderOutputWriter = coderOutputWriter;
            this.comparer = comparer;
        }
        public void Encode()
        {
            HuffmanTreeBuilder<byte> huffmanTreeBuilder = new HuffmanTreeBuilder<byte>(comparer, createDictionary());
            IHuffmanCoder<byte> huffmanCoder = new HuffmanCoder<byte>(huffmanTreeBuilder.BuildTree());
            huffmanCoder.Encode(new StandardHuffmanCoderInput(inputReader), new HuffmanCoderOutput(coderOutputWriter));
        }

        private Dictionary<byte, int> createDictionary()
        {
            Dictionary<byte, int> symbolQuantityDic = new Dictionary<byte, int>();
            do
            {
                if (symbolQuantityDic.ContainsKey(inputReader.Current))
                {
                    ++symbolQuantityDic[inputReader.Current];
                }
                else
                {
                    symbolQuantityDic.Add(inputReader.Current, 1);
                }
            } while (inputReader.MoveNext());

            inputReader.Reset();

            return symbolQuantityDic;
        }
    }
}
