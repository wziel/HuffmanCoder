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
        private Dictionary<byte, Dictionary<byte, int>> symbolQuantityDic;


        public MarkowHuffmanDecoderInterface(IDecoderReader decoderReader, IDecoderFileWriter decoderFileWriter, Dictionary<byte, Dictionary<byte, int>> symbolQuantityDic)
        {
            this.decoderReader = decoderReader;
            this.decoderFileWriter = decoderFileWriter;
            this.symbolQuantityDic = symbolQuantityDic;
        }

        public void Decode()
        {
            HuffmanTreeBuilder<byte> huffmanTreeBuilder = new HuffmanTreeBuilder<byte>(Comparer<byte>.Default, symbolQuantityDic);
            IHuffmanDecoder<byte> huffmanDecoder = new HuffmanDecoder<byte>(huffmanTreeBuilder.BuildTree());
            huffmanDecoder.Decode(new HuffmanDecoderInput(decoderReader), new MarkowHuffmanDecoderOutput(decoderFileWriter));
        }
    }
}
