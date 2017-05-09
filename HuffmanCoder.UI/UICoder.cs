using HuffmanCoder.Logic.CodecInterfaces.Coder;
using HuffmanCoder.Logic.CodecInterfaces.Coder.MarkowHuffmanCoder;
using HuffmanCoder.Logic.CodecInterfaces.Coder.PairHuffmanCoder;
using HuffmanCoder.Logic.CodecInterfaces.Coder.StandardHuffmanCoder;
using HuffmanCoder.Logic.Entities;
using HuffmanCoder.Logic.Helpers;
using HuffmanCoder.Logic.Readers.Encoding;
using HuffmanCoder.Logic.Writers.Encoding;

namespace HuffmanCoder.UI
{
    public class UICoder
    {
        public Statistics Encode(string inputFilePath, string outputFilePath, HuffmanEncodeModel huffmanEncodeModel)
        {
            Statistics statiscs;
            IHuffmanCoderInterface huffmanCoderInterface;
            IStatisticsBuilder statisticsBuilder = new StatisticsBuilder();
            using (IInputReader input = new InputReader(inputFilePath))
            {
                ICoderOutputWriter output = new CoderOutputWriter(new ByteCreator(), new HeaderCreator());
                if (huffmanEncodeModel == HuffmanEncodeModel.Standard)
                    huffmanCoderInterface = new StandardHuffmanCoderInterface(input, output);
                else if (huffmanEncodeModel == HuffmanEncodeModel.Block)
                    huffmanCoderInterface = new PairHuffmanCoderInterface(input, output);
                else
                    huffmanCoderInterface = new MarkowHuffmanCoderInterface(input, output);
                huffmanCoderInterface.Encode();
                System.IO.File.WriteAllBytes(outputFilePath, output.FileBytes);
                statiscs = statisticsBuilder.BuildStatistics(output.SymbolMap, output.Header, input.Size, output.Size);

                if(huffmanEncodeModel == HuffmanEncodeModel.Standard)
                {
                    IHistogramBuilder histogramBuilder = new HistogramBuilder(); 
                    histogramBuilder.BuildHistogram(output.SymbolMap, outputFilePath);
                }
            }
            return statiscs;
        }
    }
}
