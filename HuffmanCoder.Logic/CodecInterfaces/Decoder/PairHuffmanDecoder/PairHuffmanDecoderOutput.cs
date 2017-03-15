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

        public PairHuffmanDecoderOutput(IDecoderFileWriter decoderFileWriter)
        {
            this.decoderFileWriter = decoderFileWriter;
        }
        public bool IsEnd()
        {
            throw new NotImplementedException();
        }

        public void Write(Tuple<byte, byte> symbol)
        {
            decoderFileWriter.Write(symbol.Item1);
            decoderFileWriter.Write(symbol.Item2);
        }
    }
}
