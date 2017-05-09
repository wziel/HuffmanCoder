using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Helpers;
using HuffmanCoder.Logic.Entities;


namespace HuffmanCoder.UnitTests.Logic.Helpers
{
    [TestClass]
    public class HuffmanStatisticsHelperTests
    {
        private Dictionary<string, OutputValues> symbolsMap;
        private int symbolsCount = 10;
        private List<SymbolStatistics> symbolStatisticsList;

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeSymbolsMap();
            InitializeSymbolStatisticsList();
        }

        private void InitializeSymbolsMap()
        {
            symbolsMap = new Dictionary<string, OutputValues>();
            OutputValues valuesForA = new OutputValues();
            valuesForA.Counts = 2;
            valuesForA.BitsLength = 2;
            symbolsMap.Add("A", valuesForA);
            OutputValues valuesForB = new OutputValues();
            valuesForB.Counts = 3;
            valuesForB.BitsLength = 2;
            symbolsMap.Add("B", valuesForB);
            OutputValues valuesForC = new OutputValues();
            valuesForC.Counts = 5;
            valuesForC.BitsLength = 2;
            symbolsMap.Add("C", valuesForC);
        }

        private void InitializeSymbolStatisticsList()
        {
            symbolStatisticsList = new List<SymbolStatistics>();

            SymbolStatistics symbolA = new SymbolStatistics();
            symbolA.InputFileBitsLength = 8;
            symbolA.OutputFileBitsLength = 2;
            symbolA.Probability = 0.2;
            symbolStatisticsList.Add(symbolA);

            SymbolStatistics symbolB = new SymbolStatistics();
            symbolB.InputFileBitsLength = 8;
            symbolB.OutputFileBitsLength = 2;
            symbolB.Probability = 0.3;
            symbolStatisticsList.Add(symbolB);

            SymbolStatistics symbolC = new SymbolStatistics();
            symbolC.InputFileBitsLength = 8;
            symbolC.OutputFileBitsLength = 2;
            symbolC.Probability = 0.5;
            symbolStatisticsList.Add(symbolC);
        }

        [TestMethod]
        public void CreateSymbolsStatisticsListFormDictionary()
        {
            var helper = new HuffmanStatisticsHelper();

            List<SymbolStatistics> result = helper.CreateSymbolStatisticsList(symbolsMap, symbolsCount);

            Assert.AreEqual(symbolStatisticsList.Count, result.Count);

            for (int i = 0; i < symbolStatisticsList.Count; i++)
            {
                Assert.AreEqual(symbolStatisticsList[i].Probability, result[i].Probability);
                Assert.AreEqual(symbolStatisticsList[i].InputFileBitsLength, result[i].InputFileBitsLength);
                Assert.AreEqual(symbolStatisticsList[i].OutputFileBitsLength, result[i].OutputFileBitsLength);
            }
        }

        [TestMethod]
        public void Entropy_Evaluate()
        {
            var helper = new HuffmanStatisticsHelper();

            var output = helper.EvaluateEntropy(symbolStatisticsList);
            Assert.AreEqual(1.485, output);
        }

        [TestMethod]
        public void BitRate_EvaluateStatistics()
        {
            var helper = new HuffmanStatisticsHelper();

            uint inputFileSize = 10;
            uint outputFileSize = 5;
            uint headerSize = 5;

            BitRateStatistics expectedStatistics = new BitRateStatistics();
            expectedStatistics.InputFileBitRate = 8;
            expectedStatistics.OutputFileBitRate = 4;
            expectedStatistics.OutputFileBitRateWithHeader = 8;
              
            expectedStatistics.BitRateProportion = 0.5;
            expectedStatistics.BitRateProportionWithHeader = 1;

     

            BitRateStatistics statistics = helper.EvaluateBitRateStatistics(symbolsCount, inputFileSize, outputFileSize, headerSize);

            Assert.AreEqual(expectedStatistics.InputFileBitRate, statistics.InputFileBitRate);
            Assert.AreEqual(expectedStatistics.OutputFileBitRate, statistics.OutputFileBitRate);
            Assert.AreEqual(expectedStatistics.OutputFileBitRateWithHeader, statistics.OutputFileBitRateWithHeader);
            Assert.AreEqual(expectedStatistics.BitRateProportion, statistics.BitRateProportion);
            Assert.AreEqual(expectedStatistics.BitRateProportionWithHeader, statistics.BitRateProportionWithHeader);

        }

        [TestMethod]
        public void FileSize_EvaluateStatistics()
        {
            var helper = new HuffmanStatisticsHelper();
            uint inputFileSize = 100;
            uint outputFileSize = 50;
            uint headerSize = 10;
            FileSizeStatistics expectedStatistics = new FileSizeStatistics();
            expectedStatistics.InputFileSize = 100;
            expectedStatistics.OutputFileSize = 50;
            expectedStatistics.OutputFileSizeWithHeader = 60;
            expectedStatistics.CompressionRatio = 0.5;
            expectedStatistics.CompressionRatioWithHeader = 0.6;

            FileSizeStatistics statistics = helper.EvaluateFileSizeStatistics(inputFileSize, outputFileSize, headerSize);

            Assert.AreEqual(expectedStatistics.InputFileSize, statistics.InputFileSize);
            Assert.AreEqual(expectedStatistics.OutputFileSize, statistics.OutputFileSize);
            Assert.AreEqual(expectedStatistics.OutputFileSizeWithHeader, statistics.OutputFileSizeWithHeader);
            Assert.AreEqual(expectedStatistics.CompressionRatio, statistics.CompressionRatio);
            Assert.AreEqual(expectedStatistics.CompressionRatioWithHeader, statistics.CompressionRatioWithHeader);
        }
    }
}
