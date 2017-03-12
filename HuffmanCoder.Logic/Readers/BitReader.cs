using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Readers
{
    internal interface IBitReader
    {
        void InitCurrentByte(byte currentByte);
        bool ReadBit(byte bitNumber);
    }
    internal class BitReader : IBitReader
    {
        public void InitCurrentByte(byte currentByte)
        {
            throw new NotImplementedException();
        }

        public bool ReadBit(byte bitNumber)
        {
            if (bitNumber>=8)
                throw new Exception($"Cannot read bit with number greater than 8");
            throw new NotImplementedException();
        }
    }
}
