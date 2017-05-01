using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuffmanCoder.Logic.Helpers
{
    public interface IStatisticsBuilder
    {
        Statistics BuildStatistics(Dictionary<string, OutputValues> symbolsMap, Header header, 
            uint inputFileSize, uint outputFileSize);
    }

    public class StatisticsBuilder : IStatisticsBuilder
    {
        public Statistics BuildStatistics(Dictionary<string, OutputValues> symbolsMap, Header header, 
            uint inputFileSize, uint outputFileSize)
        {
            IHuffmanStatisticsHelper helper = new HuffmanStatisticsHelper();
            Statistics statistics = new Statistics();

            List<SymbolStatistics> symbolStatisticsList = helper.CreateSymbolStatisticsListFromDictionary(symbolsMap);
            statistics.Entropy = helper.EvaluateEntropy(symbolStatisticsList);
            statistics.BitRateStatistics = helper.EvaluateBitRateStatistics(symbolStatisticsList);
            statistics.FileSizeStatistics = helper.EvaluateFileSizeStatistics(inputFileSize, outputFileSize, header.Size);

            return statistics;
        }
    }

}