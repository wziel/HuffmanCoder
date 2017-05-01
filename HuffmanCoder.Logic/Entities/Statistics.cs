using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Entities
{
    public struct Statistics
    {
        public double Entropy { get; set; }
        public BitRateStatistics BitRateStatistics { get; set; }
        public FileSizeStatistics FileSizeStatistics { get; set; }
    }
}
