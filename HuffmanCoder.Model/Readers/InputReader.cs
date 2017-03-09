using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Readers
{
    public sealed class InputReader : IEnumerator<byte[]>
    {
        private byte[] data;
        private StreamReader stream;

        public InputReader(string filePath)
        {
            this.stream = new StreamReader(filePath);
        }

        public byte[] Current
        {
            get
            {
                return data;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return data;
            }
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public bool MoveNext()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                this.stream.BaseStream.CopyTo(ms);
                data = ms.ToArray();
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
