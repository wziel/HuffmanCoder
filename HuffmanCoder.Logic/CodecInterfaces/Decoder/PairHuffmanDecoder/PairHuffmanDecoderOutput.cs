using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Writers.Decoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Decoder.PairHuffmanDecoder
{
    class PairHuffmanDecoderOutput : IHuffmanDecoderOutput<Tuple<byte, byte>>
    {
        private IDecoderFileWriter decoderFileWriter;
        private int symbolsCount;
        private int symbolsDecoded = 0;
        private bool isEnd = false;

        public PairHuffmanDecoderOutput(IDecoderFileWriter decoderFileWriter, int symbolsCount)
        {
            this.decoderFileWriter = decoderFileWriter;
            this.symbolsCount = symbolsCount;
        }
        public bool IsEnd()
        {
            return isEnd;
        }

        public void Write(Tuple<byte, byte> symbol)
        {
            decoderFileWriter.Write(symbol.Item1);
            decoderFileWriter.Write(symbol.Item2);
            ++symbolsDecoded;
            if (symbolsDecoded == symbolsCount)
                isEnd = true;
        }
    }
}
