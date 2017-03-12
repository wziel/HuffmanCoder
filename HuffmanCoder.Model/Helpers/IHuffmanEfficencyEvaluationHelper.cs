using HuffmanCoder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Helpers
{
    public interface IHuffmanEfficencyEvaluationHelper
    {
        double EvaluateEntropy(Dictionary<string, OutputValues> symbolsMap);
        double EvaluateBitsMeanProportion(Dictionary<string, OutputValues> symbolsMap);
        double EvaluateFilesSizeProportion(uint inputFileSize, uint outputFileSize);
    }
}