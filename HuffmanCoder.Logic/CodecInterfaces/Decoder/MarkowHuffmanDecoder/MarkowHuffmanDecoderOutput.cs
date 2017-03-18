using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Writers.Decoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Decoder.MarkowHuffmanDecoder
{
    class MarkowHuffmanDecoderOutput : IHuffmanDecoderOutput<byte>
    {
        private IDecoderFileWriter decoderFileWriter;
        private byte decodedSymbol;
        private bool isEnd = false;

        public MarkowHuffmanDecoderOutput(IDecoderFileWriter decoderFileWriter)
        {
            this.decoderFileWriter = decoderFileWriter;
        }

        public byte DecodedSymbol
        {
            get
            {
                return decodedSymbol;
            }
        }
        public bool IsEnd()
        {
            return isEnd;
        }

        public void Write(byte symbol)
        {
            decoderFileWriter.Write(symbol);
            this.decodedSymbol = symbol;
            isEnd = true;
        }
    }
}
