using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Entities
{
    public struct SymbolStatistics
    {
        public double Probability { get; set; }
        public int InputFileBitsLength { get; set; }
        public int OutputFileBitsLength { get; set; }
    }
}
