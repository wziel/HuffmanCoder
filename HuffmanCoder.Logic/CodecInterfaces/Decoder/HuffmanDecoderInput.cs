using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Readers.Decoding;

namespace HuffmanCoder.Logic.CodecInterfaces.Decoder
{
    class HuffmanDecoderInput : IDecoderInput
    {
        private IDecoderReader decoderReader;

        public HuffmanDecoderInput(IDecoderReader decoderReader)
        {
            this.decoderReader = decoderReader;
        }
        public bool Read()
        {
            return decoderReader.ReadBit();
        }
    }
}
