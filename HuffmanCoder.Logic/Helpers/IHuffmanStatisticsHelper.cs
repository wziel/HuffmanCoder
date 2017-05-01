using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Helpers
{
    public interface IHuffmanStatisticsHelper
    {
        List<SymbolStatistics> CreateSymbolStatisticsListFromDictionary(Dictionary<string, OutputValues> symbolsMap);
        double EvaluateEntropy(List<SymbolStatistics> symbolStatisticsList);
        BitRateStatistics EvaluateBitRateStatistics(List<SymbolStatistics> symbolStatisticsList);
        FileSizeStatistics EvaluateFileSizeStatistics(uint inputFileSize, uint outputFileSize, uint headerSize);
    }
}