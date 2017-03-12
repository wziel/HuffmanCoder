using HuffmanCoder.Model.Entities;
using HuffmanCoder.Model.Readers;
using HuffmanCoder.Model.Writers;
using HuffmanCoder.UnitTests.Model.Helpers;
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
            IStatisticsGenerator statiscsGenerator = new StatisticsGenerator();
            using (IInputReader input = new InputReader(inputFilePath))
            using (ICoderOutputWriter output = new CoderOutputWriter(outputFilePath))
            {
                //ToDo Michal depends on enum
                statiscs = statiscsGenerator.GenerateStatistics(output.map, input.Size, output.Size);
            }
            return statiscs;
        }
    }
}
