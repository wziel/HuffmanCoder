using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UI
{
    public class UIDecoder
    {
        public void Decode(string inputFilePath, string outputFilePath)
        {
            IHuffmanCoderInterface huffmanCoderInterface;
            IStatisticsBuilder statiscsGenerator = new StatisticsBuilder();
            IInputReader input = new InputReader(inputFilePath);
            ICoderOutputWriter output = new CoderOutputWriter(new ByteCreator(), new HeaderCreator());
            if (huffmanEncodeModel == HuffmanEncodeModel.Standard)
                huffmanCoderInterface = new StandardHuffmanDecoderInterface(input, output);
            else if (huffmanEncodeModel == HuffmanEncodeModel.Block)
                huffmanCoderInterface = new PairHuffmanDecoderInterface(input, output);
            else
                huffmanCoderInterface = new MarkowHuffmanDecoderInterface(input, output);
            huffmanCoderInterface.Encode();
            System.IO.File.WriteAllBytes(outputFilePath, output.FileBytes);
            statiscs = statiscsGenerator.BuildStatistics(output.SymbolMap, input.Size, output.Size);
            return statiscs;
        }
    }
}
