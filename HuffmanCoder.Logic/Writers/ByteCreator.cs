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
        void Add(bool bit);   
    }

    public class ByteCreator : IByteCreator
    {
        private const int START_POSITION = 0;
        private const int END_POSITION = 8;
        private const byte EMPTY_DATA = 0;

        private int currentPosition = START_POSITION;
        private byte data = EMPTY_DATA;
        private byte[] bitMasks = {128,64,32,16,8,4,2,1};

        public byte Data
        {
            get
            {
                byte result = data;
                currentPosition = START_POSITION;
                data = EMPTY_DATA;
                return result;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return currentPosition == START_POSITION;
            }
        }

        public bool IsReady
        {
            get
            {
                return currentPosition == END_POSITION;
            }
        }

        public void Add(bool bit)
        {
            if (bit)
            {
                data = (byte)(data | bitMasks[currentPosition]);
            }

            ++currentPosition;
        }
    }
}
