using HuffmanCoder.Model.Codec;
using HuffmanCoder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Writers
{
    public interface ICoderOutputWriter : IDisposable
    {
        void Write(bool bit);
        void Save(Dictionary<string, OutputValues> map);
        Dictionary<string, OutputValues> map { get; }
        uint Size { get; }    
    }
    public class CoderOutputWriter : ICoderOutputWriter
    {
        private List<Byte> data = new List<byte>();
        private IByteCreator byteCreator;

        public Dictionary<string, OutputValues> map
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public uint Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CoderOutputWriter(string outputPath)
        {
            this.byteCreator = new ByteCreator();
        }

        public void Write(bool bit)
        {
            if (byteCreator.IsReady)
                data.Add(byteCreator.Data);
            else
                byteCreator.Add(bit);
        }

        public void Save(Dictionary<string, OutputValues> map)
        {
            if (byteCreator.IsEmpty == false)
                data.Add(byteCreator.CurrentByteAligned);
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
