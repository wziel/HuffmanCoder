using HuffmanCoder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Helpers
{
    public class HuffmanEfficiencyEvaluationHelper : IHuffmanEfficencyEvaluationHelper
    {
        private const int DECIMAL_DIGITS = 3;

        public double EvaluateEntropy(Dictionary<string, OutputValues> symbolsMap)
        {
            double entropy = 0;
            List<double> probabilities = CalculateProbabilitiesFromSymbolsMap(symbolsMap);

            foreach (double xProbability in probabilities)
            {
                entropy += xProbability * Math.Log(xProbability, 2);
            }
            entropy *= (-1);

            return Math.Round(entropy,DECIMAL_DIGITS);
        }

        private List<double> CalculateProbabilitiesFromSymbolsMap(Dictionary<string, OutputValues> symbolsMap)
        {
            int countsSum = 0;
            List<OutputValues> outputValues = symbolsMap.Values.ToList();
            foreach (OutputValues outputValue in outputValues)
            {
                countsSum += outputValue.Counts;
            }

            List<double> probablities = new List<double>();
            foreach (OutputValues outputValue in outputValues)
            {
                double probablity = (double)outputValue.Counts / (double)countsSum;
                probablities.Add(probablity);
            }

            return probablities;
        }

        public double EvaluateBitsMeanProportion(Dictionary<string, OutputValues> symbolsMap)
        {
            double proportion = EvaluateOutputBitsMean() / EvaluateInputBitsMean();
            return Math.Round(proportion, DECIMAL_DIGITS);
        }

        private double EvaluateInputBitsMean()
        {
            throw new NotImplementedException();
        }

        private double EvaluateOutputBitsMean()
        {
            throw new NotImplementedException();
        }

        public double EvaluateFilesSizeProportion(uint inputFileSize, uint outputFileSize)
        {
            double proportion = (double)outputFileSize / (double)inputFileSize;
            return Math.Round(proportion,DECIMAL_DIGITS);
        }
    }
}
