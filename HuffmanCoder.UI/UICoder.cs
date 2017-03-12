using HuffmanCoder.Model.Entities;
using HuffmanCoder.Model.Readers;
using HuffmanCoder.Model.Writers;
using HuffmanCoder.Model.Helpers;
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
            using (IInputReader input = new InputReader(inputFilePath))
            using (ICoderOutputWriter output = new CoderOutputWriter(outputFilePath))
            {
                //ToDo Michal depends on enum
                statiscs = statiscsGenerator.BuildStatistics(output.map, input.Size, output.Size);
            }
            return statiscs;
        }
    }
}
