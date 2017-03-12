using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Helpers;
using HuffmanCoder.Model.Entities;

namespace HuffmanCoder.UnitTests.Model.Helpers
{
    [TestClass]
    public class HuffmanEfficiencyEvaluationHelperTests
    {
        private Dictionary<string, OutputValues> symbolsMap;

        [TestInitialize]
        public void TestInitialize()
        {
            symbolsMap = new Dictionary<string, OutputValues>();
            OutputValues valuesForA = new OutputValues();
            valuesForA.Counts = 2;
            valuesForA.BitSize = 1;
            symbolsMap.Add("A", valuesForA);
            OutputValues valuesForB = new OutputValues();
            valuesForB.Counts = 3;
            valuesForB.BitSize = 1;
            symbolsMap.Add("B", valuesForB);
            OutputValues valuesForC = new OutputValues();
            valuesForC.Counts = 5;
            valuesForC.BitSize = 1;
            symbolsMap.Add("C", valuesForC);
        }

        [TestMethod]
        public void Entropy_Evaluate()
        {
            var efficiencyEvaluationHelper = new HuffmanEfficiencyEvaluationHelper();

            var output = efficiencyEvaluationHelper.EvaluateEntropy(symbolsMap);
            Assert.AreEqual(1.485, output); 
        }

        [TestMethod]
        public void BitsMean_EvaluateProportion()
        {
            var efficiencyEvaluationHelper = new HuffmanEfficiencyEvaluationHelper();
        }

        [TestMethod]
        public void FilesSize_EvaluateProportion()
        {
            var efficiencyEvaluationHelper = new HuffmanEfficiencyEvaluationHelper();
        }
    }
}
