using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Entities
{
    public struct BitsMeanStatistics
    {
        public double InputFileBitsMean { get; set; }
        public double OutputFileBitsMean { get; set; }
        public double BitsMeanProportion { get; set; }
    }
}
