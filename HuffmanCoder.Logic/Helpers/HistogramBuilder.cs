using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuffmanCoder.Logic.Helpers
{
    public interface IHistogramBuilder
    {
        void BuildHistogram(Dictionary<string, OutputValues> symbolsMap, string outputFilePath);
    }

    public class HistogramBuilder : IHistogramBuilder
    {
        public void BuildHistogram(Dictionary<string, OutputValues> symbolsMap, string outputFilePath)
        {
            List<KeyValuePair<string, int>> symbols = CreateSymbolsList(symbolsMap);

            string histogramPath = BuildHistogramPath(outputFilePath); 
            WriteToCsvFile(symbols, histogramPath);
        }

        private List<KeyValuePair<string, int>> CreateSymbolsList(Dictionary<string, OutputValues> symbolsMap)
        {
            List<KeyValuePair<string, int>> symbols = new List<KeyValuePair<string, int>>();
             
            foreach (KeyValuePair<string, OutputValues> entry in symbolsMap.OrderByDescending(key => key.Value.BitsLength))
            {
                symbols.Add(new KeyValuePair<string, int>(entry.Key, entry.Value.BitsLength));
            }

            return symbols;
        }

        private string BuildHistogramPath(string outputFilePath)
        {
            FileInfo outputFileInfo = new FileInfo(outputFilePath);
            string directoryPath = outputFileInfo.Directory.FullName;
            string fileName = Path.GetFileNameWithoutExtension(outputFilePath);
            fileName += "Histogram.csv";

            return directoryPath + "/" + fileName;
        }

        private void WriteToCsvFile(List<KeyValuePair<string, int>> symbols, string histogramPath)
        {
            var csvContent = new StringBuilder();

            foreach(KeyValuePair<string,int> entry in symbols)
            {
                var symbol = entry.Key;
                var bitsLength = entry.Value;
                var newline = $"{symbol},{bitsLength}";
                csvContent.AppendLine(newline); 
            }

            File.WriteAllText(histogramPath, csvContent.ToString());
        }
    }
}