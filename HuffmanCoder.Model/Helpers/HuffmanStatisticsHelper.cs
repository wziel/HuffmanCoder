using HuffmanCoder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Helpers
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
            int bitsLength = 2;
            // TODO IMPLEMENT METHOD

            return bitsLength;
        }

        public double EvaluateEntropy(List<SymbolStatistics> symbolStatisticsList)
        {
            double entropy = 0;
            foreach (SymbolStatistics symbol in symbolStatisticsList)
            {
                entropy += symbol.Probability * Math.Log(symbol.Probability, 2);
            }
            entropy *= (-1);

            return Math.Round(entropy,DECIMAL_DIGITS);
        }

        public BitsMeanStatistics EvaluateBitsMeanStatistics(List<SymbolStatistics> symbolStatisticsList)
        {
            double inputFileBitsMean = EvaluateInputFileBitsMean(symbolStatisticsList);
            double outputFileBitsMean = EvaluateOutputFileBitsMean(symbolStatisticsList);
            double bitsMeanProportion = Math.Round(outputFileBitsMean / inputFileBitsMean, DECIMAL_DIGITS);

            BitsMeanStatistics statistics = new BitsMeanStatistics();
            statistics.InputFileBitsMean = inputFileBitsMean;
            statistics.OutputFileBitsMean = outputFileBitsMean;
            statistics.BitsMeanProportion = bitsMeanProportion;

            return statistics;
        }

        private double EvaluateInputFileBitsMean(List<SymbolStatistics> symbolStatisticsList)
        {
            double bitsMean = 0;
            foreach(SymbolStatistics symbol in symbolStatisticsList)
            {
                bitsMean += symbol.Probability * symbol.InputFileBitsLength;
            }

            return bitsMean;
        }

        private double EvaluateOutputFileBitsMean(List<SymbolStatistics> symbolStatisticsList)
        {
            double bitsMean = 0;
            foreach (SymbolStatistics symbol in symbolStatisticsList)
            {
                bitsMean += symbol.Probability * symbol.OutputFileBitsLength;
            }

            return bitsMean;
        }

        public FilesSizeStatistics EvaluateFilesSizeStatistics(uint inputFileSize, uint outputFileSize)
        {
            FilesSizeStatistics statistics = new FilesSizeStatistics();

            statistics.InputFileSize = inputFileSize;
            statistics.OutputFileSize = outputFileSize;
            double proportion = (double)outputFileSize / (double)inputFileSize;
            statistics.FilesSizeProportion = Math.Round(proportion, DECIMAL_DIGITS);

            return statistics;
        }
    }
}
