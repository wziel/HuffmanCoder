using HuffmanCoder.Model.Codec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Writers
{
    public class DecoderOutputWriter : IHuffmanCoderOutput
    {
        private Dictionary<string, int> symbolWithCounts = new Dictionary<string, int>();
        private List<Byte> data = new List<byte>();
        public DecoderOutputWriter(Dictionary<string, int> symbolWithCounts)
        {
            this.symbolWithCounts = symbolWithCounts;
        }

        public void Write(bool bit)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

        }
    }
}
