using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Entities
{
    public struct Header
    {
        public byte[] Content { get; set; }
        public uint Size { get; set; }
    }
}
