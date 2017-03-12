using System;
using System.Collections.Generic;
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
    public class DecoderFileWriter : IDecoderFileWriter
    {
        public DecoderFileWriter(string filePath)
        {

        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Write(byte data)
        {
            throw new NotImplementedException();
        }
    }
}
