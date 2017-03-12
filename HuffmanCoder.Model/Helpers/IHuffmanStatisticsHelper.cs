using HuffmanCoder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Helpers
{
    public interface IHuffmanStatisticsHelper
    {
        List<SymbolStatistics> CreateSymbolStatisticsListFromDictionary(Dictionary<string, OutputValues> symbolsMap);
        double EvaluateEntropy(List<SymbolStatistics> symbolStatisticsList);
        BitsMeanStatistics EvaluateBitsMeanStatistics(List<SymbolStatistics> symbolStatisticsList);
        FilesSizeStatistics EvaluateFilesSizeStatistics(uint inputFileSize, uint outputFileSize);
    }
}