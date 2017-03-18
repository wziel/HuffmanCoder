using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Readers.Encoding;
using HuffmanCoder.Logic.Writers.Encoding;
using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.MarkowHuffmanCoder
{
    class MarkowHuffmanCoderInterface : IHuffmanCoderInterface
    {
        private IInputReader inputReader;
        private ICoderOutputWriter coderOutputWriter;
        public MarkowHuffmanCoderInterface(IInputReader inputReader, ICoderOutputWriter coderOutputWriter)
        {
            this.inputReader = inputReader;
            this.coderOutputWriter = coderOutputWriter;
        }
        public void Encode()
        {
            DefaultableSymbol<byte> previousSymbol;
            Dictionary<DefaultableSymbol<byte>, IHuffmanCoder<byte>> coderDictionary = createCoderDictionary();
            coderDictionary[new DefaultableSymbol<byte>(true)].Encode(new MarkowHuffmanCoderInput(inputReader.Current), new HuffmanCoderOutput(coderOutputWriter));
            previousSymbol = new DefaultableSymbol<byte>(inputReader.Current);
            while(inputReader.MoveNext())
            {
                coderDictionary[previousSymbol].Encode(new MarkowHuffmanCoderInput(inputReader.Current), new HuffmanCoderOutput(coderOutputWriter));
                previousSymbol = new DefaultableSymbol<byte>(inputReader.Current);
            }
        }

        private Dictionary<DefaultableSymbol<byte>, IHuffmanCoder<byte>> createCoderDictionary()
        {
            Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> perSymbolDictionary = createSymbolDictionary();
            Dictionary<DefaultableSymbol<byte>, IHuffmanCoder<byte>> coderDictionary = new Dictionary<DefaultableSymbol<byte>, IHuffmanCoder<byte>>();
            foreach(DefaultableSymbol<byte> key in perSymbolDictionary.Keys)
            {
                HuffmanTreeBuilder<byte> huffmanTreeBuilder = new HuffmanTreeBuilder<byte>(Comparer<byte>.Default, perSymbolDictionary[key]);
                IHuffmanCoder<byte> huffmanCoder = new HuffmanCoder<byte>(huffmanTreeBuilder.BuildTree());
                coderDictionary.Add(key, huffmanCoder);
            }
            return coderDictionary;
        }

        private Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> createSymbolDictionary()
        {
            Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> perSymbolDictionary = new Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>>();
            DefaultableSymbol<byte> previousSymbol;
            perSymbolDictionary.Add(new DefaultableSymbol<byte>(true), new Dictionary<byte, int>()
            {
                {inputReader.Current, 1}
            });
            previousSymbol = new DefaultableSymbol<byte>(inputReader.Current);
            while (inputReader.MoveNext())
            {
                if (!perSymbolDictionary.ContainsKey(previousSymbol))
                {
                    perSymbolDictionary.Add(previousSymbol, new Dictionary<byte, int>());
                }
                if (perSymbolDictionary[previousSymbol].ContainsKey(inputReader.Current))
                {
                    ++perSymbolDictionary[previousSymbol][inputReader.Current];
                }
                else
                {
                    perSymbolDictionary[previousSymbol].Add(inputReader.Current, 1);
                }
                previousSymbol = new DefaultableSymbol<byte>(inputReader.Current);
            };
            inputReader.Reset();
            return perSymbolDictionary;
        }
    }
}
