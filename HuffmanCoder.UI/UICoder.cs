using HuffmanCoder.Logic.Entities;
using HuffmanCoder.Logic.Helpers;
using HuffmanCoder.Logic.Readers.Encoding;
using HuffmanCoder.Logic.Writers.Encoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UI
{
    public enum HuffmanEncodeModel
    {
        Standard,
        Block,
        Markov
    }

    public class UICoder
    {
        public Statistics Encode(string inputFilePath, string outputFilePath, HuffmanEncodeModel huffmanEncodeModel)
        {
            Statistics statiscs;
            IStatisticsBuilder statiscsGenerator = new StatisticsBuilder();
            IInputReader input = new InputReader(inputFilePath);
            ICoderOutputWriter output = new CoderOutputWriter(new ByteCreator(), new HeaderCreator());
            //ToDo Michal depends on enum
            System.IO.File.WriteAllBytes(outputFilePath, output.FileBytes);
            statiscs = statiscsGenerator.BuildStatistics(output.SymbolMap, input.Size, output.Size);
            return statiscs;
        }
    }
}
