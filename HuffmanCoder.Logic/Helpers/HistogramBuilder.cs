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
        void BuildHistogram(Dictionary<string, OutputValues> symbolsMap);
    }

    public class HistogramBuilder : IHistogramBuilder
    {
        public void BuildHistogram(Dictionary<string, OutputValues> symbolsMap)
        {
            List<KeyValuePair<string, int>> symbols = CreateSymbolsList(symbolsMap);
            WriteToCsvFile(symbols);
        }

        private List<KeyValuePair<string, int>> CreateSymbolsList(Dictionary<string, OutputValues> symbolsMap)
        {
            List<KeyValuePair<string, int>> symbols = new List<KeyValuePair<string, int>>();
             
            foreach (KeyValuePair<string, OutputValues> entry in symbolsMap)
            {
                symbols.Add(new KeyValuePair<string, int>(entry.Key, entry.Value.BitsLength));
            }

            // TODO sort symbols descending

            return symbols;
        }

        private void WriteToCsvFile(List<KeyValuePair<string, int>> symbols)
        {
            var csvContent = new StringBuilder();

            foreach(KeyValuePair<string,int> entry in symbols)
            {
                var symbol = entry.Key;
                var bitsLength = entry.Value;
                var newline = $"{symbol},{bitsLength}";
                csvContent.AppendLine(newline); 
            }

            // TODO path to histogram
            File.WriteAllText("histogram.csv", csvContent.ToString());
        }
    }
}