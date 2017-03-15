using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Readers.Decoding
{
    public interface IDecoderReader : IDisposable
    {
        Dictionary<string, int> symbolCounts { get; }
        bool ReadBit();
    }
    public sealed class DecoderReader : IDecoderReader
    {
        private StreamReader stream;
        public DecoderReader(string outputPath)
        {
            this.stream = new StreamReader(outputPath);
        }

        public Dictionary<string, int> symbolCounts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public bool ReadBit()
        {
            throw new NotImplementedException();
        }
    }
}
