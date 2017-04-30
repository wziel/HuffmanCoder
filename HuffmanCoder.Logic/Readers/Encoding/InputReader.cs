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
        private StreamReader stream;
        private byte[] data;
        private uint currentSize;
        private uint iterator = 0;

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
            ++iterator;
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
                return iterator;
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
            currentByte = data[iterator];
            ++iterator;
            return true;             
        }

        public void Reset()
        {
            stream.BaseStream.Seek(0, SeekOrigin.Begin);
        }
    }
}
