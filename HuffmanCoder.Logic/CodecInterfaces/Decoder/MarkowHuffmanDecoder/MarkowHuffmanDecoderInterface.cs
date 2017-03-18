using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Readers.Decoding;
using HuffmanCoder.Logic.Writers.Decoding;
using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Logic.CodecInterfaces.Decoder.MarkowHuffmanDecoder
{
    class MarkowHuffmanDecoderInterface : IHuffmanDecoderInterface
    {
        private IDecoderReader decoderReader;
        private IDecoderFileWriter decoderFileWriter;
        private Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> perSymbolDictionary;
        private int symbolsCount = 0;


        public MarkowHuffmanDecoderInterface(IDecoderReader decoderReader, IDecoderFileWriter decoderFileWriter, Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> perSymbolDictionary)
        {
            this.decoderReader = decoderReader;
            this.decoderFileWriter = decoderFileWriter;
            this.perSymbolDictionary = perSymbolDictionary;
            foreach (DefaultableSymbol<byte> key in perSymbolDictionary.Keys)
            {
                this.symbolsCount += perSymbolDictionary[key].Sum(x => x.Value);
            }
        }

        public void Decode()
        {
            DefaultableSymbol<byte> previousSymbol;
            Dictionary<DefaultableSymbol<byte>, IHuffmanDecoder<byte>> decoderDictionary = createDecoderDictionary();
            MarkowHuffmanDecoderOutput markowHuffmanDecoderOutput = new MarkowHuffmanDecoderOutput(decoderFileWriter);
            decoderDictionary[new DefaultableSymbol<byte>(true)].Decode(new HuffmanDecoderInput(decoderReader), markowHuffmanDecoderOutput);
            previousSymbol = new DefaultableSymbol<byte>(markowHuffmanDecoderOutput.DecodedSymbol);
            int symbolsDecoded = 1;
            while (symbolsDecoded < symbolsCount)
            {
                markowHuffmanDecoderOutput = new MarkowHuffmanDecoderOutput(decoderFileWriter);
                decoderDictionary[previousSymbol].Decode(new HuffmanDecoderInput(decoderReader), markowHuffmanDecoderOutput);
                previousSymbol = new DefaultableSymbol<byte>(markowHuffmanDecoderOutput.DecodedSymbol);
                ++symbolsDecoded;
            }
        }

        private Dictionary<DefaultableSymbol<byte>, IHuffmanDecoder<byte>> createDecoderDictionary()
        {
            Dictionary<DefaultableSymbol<byte>, IHuffmanDecoder<byte>> coderDictionary = new Dictionary<DefaultableSymbol<byte>, IHuffmanDecoder<byte>>();
            foreach (DefaultableSymbol<byte> key in perSymbolDictionary.Keys)
            {
                HuffmanTreeBuilder<byte> huffmanTreeBuilder = new HuffmanTreeBuilder<byte>(Comparer<byte>.Default, perSymbolDictionary[key]);
                IHuffmanDecoder<byte> huffmanDecoder = new HuffmanDecoder<byte>(huffmanTreeBuilder.BuildTree());
                coderDictionary.Add(key, huffmanDecoder);
            }
            return coderDictionary;
        }
    }
}
