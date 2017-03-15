using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Writers.Decoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Decoder.StandardHuffmanDecoder
{
    class StandardHuffmanDecoderOutput : IHuffmanDecoderOutput<byte>
    {
        private IDecoderFileWriter decoderFileWriter;

        public StandardHuffmanDecoderOutput(IDecoderFileWriter decoderFileWriter)
        {
            this.decoderFileWriter = decoderFileWriter;
        }
        public bool IsEnd()
        {
            throw new NotImplementedException();
        }

        public void Write(byte symbol)
        {
            decoderFileWriter.Write(symbol);
        }
    }
}
