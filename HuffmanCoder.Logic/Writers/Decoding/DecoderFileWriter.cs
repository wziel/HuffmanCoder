using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Writers.Decoding
{
    public interface IDecoderFileWriter
    {
        void Save();
        void Write(byte data);
    }
    public sealed class DecoderFileWriter : IDecoderFileWriter
    {
        private string filePath;
        private List<byte> bytes = new List<byte>();
        public DecoderFileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void Save()
        {
            File.WriteAllBytes(filePath, bytes.ToArray())
        }

        public void Write(byte data)
        {
            bytes.Add(data);
        }
    }
}
