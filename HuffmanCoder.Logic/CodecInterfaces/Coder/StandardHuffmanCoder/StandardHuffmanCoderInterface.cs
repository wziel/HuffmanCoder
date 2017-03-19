using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Readers.Encoding;
using HuffmanCoder.Logic.Writers.Encoding;
using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.StandardHuffmanCoder
{
    public class StandardHuffmanCoderInterface : IHuffmanCoderInterface
    {
        private IInputReader inputReader;
        private ICoderOutputWriter coderOutputWriter;
        public StandardHuffmanCoderInterface(IInputReader inputReader, ICoderOutputWriter coderOutputWriter)
        {
            this.inputReader = inputReader;
            this.coderOutputWriter = coderOutputWriter;
        }
        public void Encode()
        {
            var builder = new HuffmanCodecBuilder<byte>();
            var tree = builder.BuildTree(Comparer<byte>.Default, createDictionary());
            ICoder<byte> huffmanCoder = builder.GetCoder(tree);
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
