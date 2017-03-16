using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Readers.Decoding;
using HuffmanCoder.Logic.Writers.Decoding;
using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Logic.CodecInterfaces.Decoder.PairHuffmanDecoder
{
    class PairHuffmanDecoderInterface : IHuffmanDecoderInterface
    {
        private IDecoderReader decoderReader;
        private IDecoderFileWriter decoderFileWriter;
        private Dictionary<Tuple<byte, byte>, int> symbolQuantityDic;


        public PairHuffmanDecoderInterface(IDecoderReader decoderReader, IDecoderFileWriter decoderFileWriter, Dictionary<Tuple<byte, byte>, int> symbolQuantityDic)
        {
            this.decoderReader = decoderReader;
            this.decoderFileWriter = decoderFileWriter;
            this.symbolQuantityDic = symbolQuantityDic;
        }

        public void Decode()
        {
            HuffmanTreeBuilder<Tuple<byte, byte>> huffmanTreeBuilder = new HuffmanTreeBuilder<Tuple<byte, byte>>(Comparer<Tuple<byte, byte>>.Default, symbolQuantityDic);
            IHuffmanDecoder<Tuple<byte, byte>> huffmanDecoder = new HuffmanDecoder<Tuple<byte, byte>>(huffmanTreeBuilder.BuildTree());
            int symbolsCount = symbolQuantityDic.Sum(x => x.Value);
            huffmanDecoder.Decode(new HuffmanDecoderInput(decoderReader), new PairHuffmanDecoderOutput(decoderFileWriter, symbolsCount));
        }
    }
}
