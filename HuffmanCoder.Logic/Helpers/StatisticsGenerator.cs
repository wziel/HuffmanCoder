using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Helpers
{
    public interface IStatisticsGenerator
    {
        Statistics GenerateStatistics(Dictionary<string, OutputValues> map, uint inputFileSize, uint outputFileSize);
    }

    public class StatisticsGenerator : IStatisticsGenerator
    {
        public Statistics GenerateStatistics(Dictionary<string, OutputValues> map, uint inputFileSize, uint outputFileSize)
        {
            //ToDo Kacper
            throw new NotImplementedException();
        }
    }

}
