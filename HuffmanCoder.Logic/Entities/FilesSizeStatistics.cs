using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Entities
{
    public struct FilesSizeStatistics
    {
        public uint InputFileSize { get; set; }
        public uint OutputFileSize { get; set; }
        public double FilesSizeProportion { get; set; }
    }
}
