using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Helpers
{
    public class HuffmanStatisticsHelper : IHuffmanStatisticsHelper
    {
        private const int DECIMAL_DIGITS = 3;

        public List<SymbolStatistics> CreateSymbolStatisticsListFromDictionary(Dictionary<string, OutputValues> symbolsMap)
        {
            int countsSum = 0;
            foreach (KeyValuePair<string, OutputValues> entry in symbolsMap)
            {
                countsSum += entry.Value.Counts;
            }

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

        public BitRateStatistics EvaluateBitRateStatistics(List<SymbolStatistics> symbolStatisticsList)
        {
            double inputFileBitRate = EvaluateInputFileBitRate(symbolStatisticsList);
            double outputFileBitRate = EvaluateOutputFileBitRate(symbolStatisticsList);
            double bitRateProportion = Math.Round(outputFileBitRate / inputFileBitRate, DECIMAL_DIGITS);

            BitRateStatistics statistics = new BitRateStatistics();
            statistics.InputFileBitRate = inputFileBitRate;
            statistics.OutputFileBitRate = outputFileBitRate;
            statistics.BitRateProportion = bitRateProportion;

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

            return bitRate;
        }

        public FileSizeStatistics EvaluateFileSizeStatistics(uint inputFileSize, uint outputFileSize)
        {
            FileSizeStatistics statistics = new FileSizeStatistics();

            statistics.InputFileSize = inputFileSize;
            statistics.OutputFileSize = outputFileSize;
            double proportion = (double)outputFileSize / (double)inputFileSize;
            statistics.FileSizeProportion = Math.Round(proportion, DECIMAL_DIGITS);

            return statistics;
        }
    }
}
