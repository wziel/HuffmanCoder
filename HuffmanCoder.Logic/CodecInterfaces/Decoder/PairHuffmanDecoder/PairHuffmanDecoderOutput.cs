using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Writers.Decoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Decoder.PairHuffmanDecoder
{
    class PairHuffmanDecoderOutput : IDecoderOutput<Tuple<byte, DefaultableSymbol<byte>>>
    {
        private IDecoderFileWriter decoderFileWriter;
        private int symbolsCount;
        private int symbolsDecoded = 0;
        private bool isEnd = false;
        private bool isByteCountEven;

        public PairHuffmanDecoderOutput(IDecoderFileWriter decoderFileWriter, int symbolsCount, bool isByteCountEven)
        {
            this.decoderFileWriter = decoderFileWriter;
            this.symbolsCount = symbolsCount;
            this.isByteCountEven = isByteCountEven;
        }
        public bool IsEnd()
        {
            return isEnd;
        }

        public void Write(Tuple<byte, DefaultableSymbol<byte>> symbol)
        {
            decoderFileWriter.Write(symbol.Item1);
            if(!isByteCountEven && symbolsDecoded == symbolsCount - 1)
            {
                ++symbolsDecoded;
                isEnd = true;
                return;
            }
            decoderFileWriter.Write(symbol.Item2.Value);
            ++symbolsDecoded;
            if (symbolsDecoded == symbolsCount)
                isEnd = true;
        }
    }
}
