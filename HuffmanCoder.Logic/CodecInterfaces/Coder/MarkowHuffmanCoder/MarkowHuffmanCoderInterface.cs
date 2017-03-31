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

namespace HuffmanCoder.Logic.CodecInterfaces.Coder.MarkowHuffmanCoder
{
    public class MarkowHuffmanCoderInterface : IHuffmanCoderInterface
    {
        private IInputReader inputReader;
        private ICoderOutputWriter coderOutputWriter;
        private Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> symbolDictionary;
        public MarkowHuffmanCoderInterface(IInputReader inputReader, ICoderOutputWriter coderOutputWriter)
        {
            this.inputReader = inputReader;
            this.coderOutputWriter = coderOutputWriter;
        }
        public void Encode()
        {
            DefaultableSymbol<byte> previousSymbol;
            Dictionary<DefaultableSymbol<byte>, ICoder<byte>> coderDictionary = createCoderDictionary();
            coderDictionary[new DefaultableSymbol<byte>(true)].Encode(new MarkowHuffmanCoderInput(inputReader.Current), new HuffmanCoderOutput(coderOutputWriter));
            previousSymbol = new DefaultableSymbol<byte>(inputReader.Current);
            while(inputReader.MoveNext())
            {
                coderDictionary[previousSymbol].Encode(new MarkowHuffmanCoderInput(inputReader.Current), new HuffmanCoderOutput(coderOutputWriter));
                previousSymbol = new DefaultableSymbol<byte>(inputReader.Current);
            }
            coderOutputWriter.CreateFileBytes(HuffmanEncodeModel.Markov, true, SymbolQuantityMapConverter.MarkowIntToExtConvert(this.symbolDictionary, CreateEncodingDictionaries(coderDictionary)));
        }

        private Dictionary<DefaultableSymbol<byte>, ICoder<byte>> createCoderDictionary()
        {
            Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> perSymbolDictionary = createSymbolDictionary();
            Dictionary<DefaultableSymbol<byte>, ICoder<byte>> coderDictionary = new Dictionary<DefaultableSymbol<byte>, ICoder<byte>>();
            foreach(DefaultableSymbol<byte> key in perSymbolDictionary.Keys)
            {
                var builder = new HuffmanCodecBuilder<byte>();
                var tree = builder.BuildTree(Comparer<byte>.Default, perSymbolDictionary[key]);
                ICoder<byte> huffmanCoder = builder.GetCoder(tree);
                coderDictionary.Add(key, huffmanCoder);
            }
            return coderDictionary;
        }

        private Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> createSymbolDictionary()
        {
            var perSymbolDictionary = new Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>>();
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
            this.symbolDictionary = perSymbolDictionary;
            return perSymbolDictionary;
        }

        private Dictionary<DefaultableSymbol<byte>, Dictionary<byte, bool[]>> CreateEncodingDictionaries(Dictionary<DefaultableSymbol<byte>, ICoder<byte>> coderDictionary)
        {
            var encodingDictionaries = new Dictionary<DefaultableSymbol<byte>, Dictionary<byte, bool[]>>();
            foreach (KeyValuePair<DefaultableSymbol<byte>, ICoder<byte>> entry in coderDictionary)
            {
                encodingDictionaries.Add(entry.Key, entry.Value.GetEncodingDictionary());
            }
            return encodingDictionaries;
        }
    }
}
