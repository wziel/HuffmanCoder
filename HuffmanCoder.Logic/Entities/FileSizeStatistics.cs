using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Entities
{
    public struct FileSizeStatistics
    {
        public uint InputFileSize { get; set; }
        public uint OutputFileSize { get; set; }
        public uint OutputFileSizeWithHeader { get; set; }
        public double CompressionRatio { get; set; }
        public double CompressionRatioWithHeader { get; set; }
    }
}
