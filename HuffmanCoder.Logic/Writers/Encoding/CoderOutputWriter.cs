using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Writers.Encoding
{
    public interface ICoderOutputWriter
    {
        void Write(bool bit);
        void Save(Dictionary<string, OutputValues> map);
        Dictionary<string, OutputValues> SymbolMap { get; }
        uint Size { get; }    
    }
    public class CoderOutputWriter : ICoderOutputWriter
    {
        private uint currentSize = 0;
        private List<Byte> data = new List<byte>();
        private IByteCreator byteCreator;
        private Dictionary<string, OutputValues> symbolMap;
        private string outputPath;
        private List<Byte> header = new List<byte>();

        public Dictionary<string, OutputValues> SymbolMap
        {
            get
            {
                return symbolMap;
            }
        }

        public uint Size
        {
            get
            {
                return currentSize;
            }
        }

        public CoderOutputWriter(string outputPath)
        {
            this.byteCreator = new ByteCreator();
            this.outputPath = outputPath;
        }

        public void Write(bool bit)
        {
            if (byteCreator.IsReady)
            {
                ++currentSize;
                data.Add(byteCreator.Data);
            }
            else
                byteCreator.Add(bit);
        }

        private void CreateHeader()
        {

        }

        public void Save(Dictionary<string, OutputValues> map)
        {
            this.symbolMap = map;
            if (byteCreator.IsEmpty == false)
            {
                ++currentSize;
                data.Add(byteCreator.CurrentByteAligned);
            }
            CreateHeader();
            System.IO.File.WriteAllBytes(outputPath, data.ToArray());
        }
    }
}
