using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Readers.Decoding;
using HuffmanCoder.Logic.Writers.Decoding;
using HuffmanCoder.Model.Builder;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Logic.CodecInterfaces.Decoder.StandardHuffmanDecoder
{
    public class StandardHuffmanDecoderInterface : IHuffmanDecoderInterface
    {
        private IDecoderReader decoderReader;
        private IDecoderFileWriter decoderFileWriter;
        private Dictionary<byte, int> symbolQuantityDic;
        

        public StandardHuffmanDecoderInterface(IDecoderReader decoderReader, IDecoderFileWriter decoderFileWriter, Dictionary<byte, int> symbolQuantityDic)
        {
            this.decoderReader = decoderReader;
            this.decoderFileWriter = decoderFileWriter;
            this.symbolQuantityDic = symbolQuantityDic;
        }
            
        public void Decode()
        {
            HuffmanTreeBuilder<byte> huffmanTreeBuilder = new HuffmanTreeBuilder<byte>(Comparer<byte>.Default, symbolQuantityDic);
            IHuffmanDecoder<byte> huffmanDecoder = new HuffmanDecoder<byte>(huffmanTreeBuilder.BuildTree());
            huffmanDecoder.Decode(new HuffmanDecoderInput(decoderReader), new StandardHuffmanDecoderOutput(decoderFileWriter));
        }
    }
}
