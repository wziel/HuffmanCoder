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
        List<SymbolStatistics> CreateSymbolStatisticsList(Dictionary<string, OutputValues> symbolsMap, uint headerSize = 0);

        double EvaluateEntropy(List<SymbolStatistics> symbolStatisticsList);

        BitRateStatistics EvaluateBitRateStatistics(List<SymbolStatistics> symbolStatisticsList, List<SymbolStatistics> symbolStatisticsListWithHeader);

        FileSizeStatistics EvaluateFileSizeStatistics(uint inputFileSize, uint outputFileSize, uint headerSize);
    }

    public class HuffmanStatisticsHelper : IHuffmanStatisticsHelper
    {
        private const int DECIMAL_DIGITS = 3;

        public List<SymbolStatistics> CreateSymbolStatisticsList(Dictionary<string, OutputValues> symbolsMap, uint headerSize = 0)
        {
            int countsSum = 0;
            foreach (KeyValuePair<string, OutputValues> entry in symbolsMap)
            {
                countsSum += entry.Value.Counts;
            }

            countsSum += (int)headerSize;

            List<SymbolStatistics> symbolStatisticsList = new List<SymbolStatistics>();
            foreach (KeyValuePair<string, OutputValues> entry in symbolsMap)
            {
                SymbolStatistics symbol = new SymbolStatistics();
                symbol.Probability = (double)entry.Value.Counts / (double)countsSum;
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

        public BitRateStatistics EvaluateBitRateStatistics(List<SymbolStatistics> symbolStatisticsList, List<SymbolStatistics> symbolStatisticsListWithHeader)
        {
            double inputFileBitRate = EvaluateInputFileBitRate(symbolStatisticsList);
            double outputFileBitRate = EvaluateOutputFileBitRate(symbolStatisticsList);
            double outputFileBitRateWithHeader = EvaluateOutputFileBitRate(symbolStatisticsListWithHeader);

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

        private double EvaluateInputFileBitRate(List<SymbolStatistics> symbolStatisticsList)
        {
            double bitRate = 0;
            foreach (SymbolStatistics symbol in symbolStatisticsList)
            {
                bitRate += symbol.Probability * symbol.InputFileBitsLength;
            }

            return bitRate;
        }

        private double EvaluateOutputFileBitRate(List<SymbolStatistics> symbolStatisticsList)
        {
            double bitRate = 0;
            foreach (SymbolStatistics symbol in symbolStatisticsList)
            {
                bitRate += symbol.Probability * symbol.OutputFileBitsLength;
            }

            return Math.Round(bitRate, DECIMAL_DIGITS);
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
