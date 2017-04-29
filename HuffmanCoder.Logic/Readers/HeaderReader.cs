using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Readers
{
    internal interface IHeaderReader
    {
        Dictionary<string, ushort> symbolCounts { get; }
        void Read(byte[] map, bool specialSymbol, HuffmanEncodeModel huffmanEncodeModel);
    }
    internal class HeaderReader : IHeaderReader
    {
        private Dictionary<string, ushort> symbolCountDict = new Dictionary<string, ushort>();
        private const byte CountsSize = 2;
        private const byte StandardSymbolSize = 1;
        private const byte MarkovBlockSymbolSize = 2;

        public Dictionary<string, ushort> symbolCounts
        {
            get
            {
                return symbolCountDict;
            }
        }

        private void StandardRead(byte[] map)
        {
            for (int i = 0; i < map.Length; i += 2)
            {
                symbolCountDict.Add(((char)map[i]).ToString(), map[i + 1]);
            }
        }


        private void BlockMarkovRead(byte[] map, bool specialSymbol)
        {
            var loopBoundry = map.Length;
            if (specialSymbol)
                loopBoundry -= CountsSize + MarkovBlockSymbolSize - 1;
            for (int i = 0; i < loopBoundry; i += CountsSize + MarkovBlockSymbolSize)
            {
                symbolCountDict.Add(((char)map[i]).ToString() + ((char)map[i+1]).ToString(), BitConverter.ToUInt16(map.Skip(i+2).Take(CountsSize).ToArray(), 0));
            }
            if (specialSymbol)
                symbolCountDict.Add(((char)map[loopBoundry]).ToString(), BitConverter.ToUInt16(map.Skip(loopBoundry+1).Take(CountsSize).ToArray(),0));
        }


        public void Read(byte[] map, bool specialSymbol, HuffmanEncodeModel huffmanEncodeModel)
        {
            switch (huffmanEncodeModel)
            {
                case HuffmanEncodeModel.Standard:
                    StandardRead(map);
                    break;
                case HuffmanEncodeModel.Block:
                case HuffmanEncodeModel.Markov:
                    BlockMarkovRead(map, specialSymbol);
                    break;
            }
        }
    }
}
