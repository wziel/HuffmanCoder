using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Readers.Decoding
{
    public interface IDecoderReader
    {
        Dictionary<string, int> symbolCounts { get; }
        bool ReadBit();
    }
    public class DecoderReader : IDecoderReader
    {
        public Dictionary<string, int> symbolCounts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool ReadBit()
        {
            throw new NotImplementedException();
        }
    }
}
