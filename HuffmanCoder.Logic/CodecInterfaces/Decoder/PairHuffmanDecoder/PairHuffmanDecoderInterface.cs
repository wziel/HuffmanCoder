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
    public class PairHuffmanDecoderInterface : IHuffmanDecoderInterface
    {
        private IDecoderReader decoderReader;
        private IDecoderFileWriter decoderFileWriter;
        private Dictionary<Tuple<byte, DefaultableSymbol<byte>>, int> symbolQuantityDic;
        private bool isByteCountEven;


        public PairHuffmanDecoderInterface(IDecoderReader decoderReader, IDecoderFileWriter decoderFileWriter, bool isByteCountEven)
        {
            this.decoderReader = decoderReader;
            this.decoderFileWriter = decoderFileWriter;
            this.symbolQuantityDic = SymbolQuantityMapConverter.PairExtToIntConvert(decoderReader.SymbolCounts);
            this.isByteCountEven = isByteCountEven;
        }

        public void Decode()
        {
            var builder = new HuffmanCodecBuilder<Tuple<byte, DefaultableSymbol<byte>>>();
            var tree = builder.BuildTree(Comparer<Tuple<byte, DefaultableSymbol<byte>>>.Default, symbolQuantityDic);
            var decoder = builder.GetDecoder(tree);
            int symbolsCount = symbolQuantityDic.Sum(x => x.Value);
            decoder.Decode(new HuffmanDecoderInput(decoderReader), new PairHuffmanDecoderOutput(decoderFileWriter, symbolsCount, isByteCountEven));
        }
    }
}
