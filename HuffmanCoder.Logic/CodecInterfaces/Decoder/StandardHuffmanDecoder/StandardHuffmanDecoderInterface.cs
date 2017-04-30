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
        

        public StandardHuffmanDecoderInterface(IDecoderReader decoderReader, IDecoderFileWriter decoderFileWriter)
        {
            this.decoderReader = decoderReader;
            this.decoderFileWriter = decoderFileWriter;
            this.symbolQuantityDic = SymbolQuantityMapConverter.StandardExtToIntConvert(decoderReader.SymbolCounts);
        }
            
        public void Decode()
        {
            var builder = new HuffmanCodecBuilder<byte>();
            var tree = builder.BuildTree(Comparer<byte>.Default, symbolQuantityDic);
            var decoder = builder.GetDecoder(tree);
            var symbolsCount = symbolQuantityDic.Sum(x => x.Value);
            decoder.Decode(new HuffmanDecoderInput(decoderReader), new StandardHuffmanDecoderOutput(decoderFileWriter, symbolsCount));
        }
    }
}
