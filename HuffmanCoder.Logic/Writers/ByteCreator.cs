using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Writers.Encoding
{
    public interface IByteCreator
    {
        bool IsReady { get; }
        byte Data { get; }
        bool IsEmpty { get; }
        byte CurrentByteAligned { get; }
        void Add(bool bit);   
    }

    public class ByteCreator : IByteCreator
    {
        public byte CurrentByteAligned
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public byte Data
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReady
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(bool bit)
        {
            throw new NotImplementedException();
        }
    }
}
