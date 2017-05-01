using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Entities
{
    public struct BitRateStatistics
    {
        public double InputFileBitRate { get; set; }
        public double OutputFileBitRate { get; set; }
        public double BitRateProportion { get; set; }
    }
}
