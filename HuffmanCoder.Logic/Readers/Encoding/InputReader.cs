using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Readers.Encoding
{
    public interface IInputReader : IEnumerator<byte>, IDisposable
    {
        uint Size { get; }
    }

    public sealed class InputReader : IInputReader
    {
        private byte currentByte;
        private uint currentSize = 0;
        private StreamReader stream;
        private byte[] data;
        private int iterator;

        public InputReader(string filePath)
        {
            this.stream = new StreamReader(filePath);
            InitData();
        }


        private void InitData()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                this.stream.BaseStream.CopyTo(ms);
                data = ms.ToArray();
            }
            if (data == null || data.Length==0)
                throw new Exception($"Input file is empty");
            currentByte = data[0];
        }

        public byte Current
        {
            get
            {
                return currentByte;
            }
        }

        public uint Size
        {
            get
            {
                return currentSize;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return currentByte;
            }
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public bool MoveNext()
        {
            if (iterator == data.Length)
                return false;
            ++iterator;
            currentByte = data[iterator];
            return true;             
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
