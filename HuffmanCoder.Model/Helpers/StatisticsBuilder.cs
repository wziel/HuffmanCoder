using HuffmanCoder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Helpers
{
    public interface IStatisticsBuilder
    {
        Statistics BuildStatistics(Dictionary<string, OutputValues> symbolsMap, uint inputFileSize, uint outputFileSize);
    }

    public class StatisticsBuilder : IStatisticsBuilder
    {
        public Statistics BuildStatistics(Dictionary<string, OutputValues> symbolsMap, uint inputFileSize, uint outputFileSize)
        {
            IHuffmanStatisticsHelper helper = new HuffmanStatisticsHelper();
            Statistics statistics = new Statistics();

            List<SymbolStatistics> symbolStatisticsList = helper.CreateSymbolStatisticsListFromDictionary(symbolsMap);
            statistics.Entropy = helper.EvaluateEntropy(symbolStatisticsList);
            statistics.BitsMeanStatistics = helper.EvaluateBitsMeanStatistics(symbolStatisticsList);
            statistics.FileSizeStatistics = helper.EvaluateFilesSizeStatistics(inputFileSize, outputFileSize);

            return statistics;
        }
    }

}
