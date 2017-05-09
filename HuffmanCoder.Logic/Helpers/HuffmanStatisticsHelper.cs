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
        int CountSymbols(Dictionary<string, OutputValues> symbolsMap);

        List<SymbolStatistics> CreateSymbolStatisticsList(Dictionary<string, OutputValues> symbolsMap, int symbolsCount);

        double EvaluateEntropy(List<SymbolStatistics> symbolStatisticsList);

        BitRateStatistics EvaluateBitRateStatistics(int symbolsCount, uint inputFileSize, uint outputFileSize, uint headerSize);

        FileSizeStatistics EvaluateFileSizeStatistics(uint inputFileSize, uint outputFileSize, uint headerSize);
    }

    public class HuffmanStatisticsHelper : IHuffmanStatisticsHelper
    {
        private const int DECIMAL_DIGITS = 3;

        public int CountSymbols(Dictionary<string, OutputValues> symbolsMap)
        {
            int symbolsCount = 0;
            foreach (KeyValuePair<string, OutputValues> entry in symbolsMap)
            {
                symbolsCount += entry.Value.Counts;
            }

            return symbolsCount;
        }

        public List<SymbolStatistics> CreateSymbolStatisticsList(Dictionary<string, OutputValues> symbolsMap, int symbolsCount)
        {
            List<SymbolStatistics> symbolStatisticsList = new List<SymbolStatistics>();
            foreach (KeyValuePair<string, OutputValues> entry in symbolsMap)
            {
                SymbolStatistics symbol = new SymbolStatistics();
                symbol.Probability = (double)entry.Value.Counts / (double)symbolsCount;
                symbol.OutputFileBitsLength = entry.Value.BitsLength;
                symbol.InputFileBitsLength = GetBitsLengthFromStringSymbol(entry.Key);

                symbolStatisticsList.Add(symbol);
            }

            return symbolStatisticsList;
        }

        private int GetBitsLengthFromStringSymbol(string symbol)
        {
            int singleSymbolBitsLength = 8;
            return symbol.Length * singleSymbolBitsLength;
        }

        public double EvaluateEntropy(List<SymbolStatistics> symbolStatisticsList)
        {
            double entropy = 0;
            foreach (SymbolStatistics symbol in symbolStatisticsList)
            {
                entropy += symbol.Probability * Math.Log(symbol.Probability, 2);
            }
            entropy *= (-1);

            return Math.Round(entropy, DECIMAL_DIGITS);
        }

        public BitRateStatistics EvaluateBitRateStatistics(int symbolsCount, uint inputFileSize, uint outputFileSize, uint headerSize)
        {
            double inputFileBitRate = Math.Round((double)(inputFileSize * 8) / (double)symbolsCount, DECIMAL_DIGITS);
            double outputFileBitRate = Math.Round((double)(outputFileSize * 8) / (double)symbolsCount, DECIMAL_DIGITS);
            double outputFileBitRateWithHeader = Math.Round((double)((outputFileSize + headerSize) * 8) / (double)symbolsCount, DECIMAL_DIGITS);

            double bitRateProportion = Math.Round(outputFileBitRate / inputFileBitRate, DECIMAL_DIGITS);
            double bitRateProportionWithHeader = Math.Round(outputFileBitRateWithHeader / inputFileBitRate, DECIMAL_DIGITS);

            BitRateStatistics statistics = new BitRateStatistics();
            statistics.InputFileBitRate = inputFileBitRate;
            statistics.OutputFileBitRate = outputFileBitRate;
            statistics.OutputFileBitRateWithHeader = outputFileBitRateWithHeader;
            statistics.BitRateProportion = bitRateProportion;
            statistics.BitRateProportionWithHeader = bitRateProportionWithHeader;

            return statistics;
        }

        public FileSizeStatistics EvaluateFileSizeStatistics(uint inputFileSize, uint outputFileSize, uint headerSize)
        {
            FileSizeStatistics statistics = new FileSizeStatistics();

            statistics.InputFileSize = inputFileSize;
            statistics.OutputFileSize = outputFileSize;
            statistics.OutputFileSizeWithHeader = outputFileSize + headerSize;

            double compressionRatio = (double)outputFileSize / (double)inputFileSize;
            double compressionRatioWithHeader = (double)statistics.OutputFileSizeWithHeader / (double)inputFileSize;

            statistics.CompressionRatio = Math.Round(compressionRatio, DECIMAL_DIGITS);
            statistics.CompressionRatioWithHeader = Math.Round(compressionRatioWithHeader, DECIMAL_DIGITS);

            return statistics;
        }
    }
}
