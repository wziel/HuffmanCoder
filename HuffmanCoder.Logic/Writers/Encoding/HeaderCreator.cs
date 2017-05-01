using HuffmanCoder.Logic.Entities;
using System.Collections.Generic;
using System.Text;
using System;

namespace HuffmanCoder.Logic.Writers.Encoding
{
    /*Header consists of:
    -headerSize - 4 bytes
    -huffmanEncodeModel - 1 byte
    -specialSymbol - 1 byte
    -map (symbol and symbol counts)
    */
    
    public interface IHeaderCreator
    {
        byte[] Create(HuffmanEncodeModel huffmanEncodeModel, bool specialSymbol, Dictionary<string, OutputValues> symbolsMap);
    }

    public class HeaderCreator : IHeaderCreator
    {
        public byte[] Create(HuffmanEncodeModel huffmanEncodeModel, bool specialSymbol, Dictionary<string, OutputValues> symbolsMap)
        {
            byte huffmanEncodeModelByte = Convert.ToByte(huffmanEncodeModel);
            byte specialSymbolByte = Convert.ToByte(specialSymbol);
            List<byte> symbolsMapByteList = CreateSymbolsMapByteList(huffmanEncodeModel, symbolsMap, specialSymbol);

            byte[] header = CreateHeaderFromBytes(huffmanEncodeModelByte, specialSymbolByte, symbolsMapByteList);
            return header;
        }

        private byte[] ToByteArray(string text)
        {
            var array = new byte[text.Length];
            for (int i = 0; i < text.Length; ++i)
                array[i] = Convert.ToByte(text[i]);
            return array;
        }

        private List<byte> CreateSymbolsMapByteList(HuffmanEncodeModel huffmanEncodeModel, Dictionary<string, OutputValues> symbolsMap, bool specialSymbol)
        {
            List<byte> symbolsMapByteList = new List<byte>();
            char specialSymbolCharacter = '0';
            ushort specialSymbolCounts = 0;
            foreach (KeyValuePair<string, OutputValues> symbol in symbolsMap)
            {
                string symbolKey = symbol.Key;
                if(symbolKey.Length == 1 && huffmanEncodeModel != HuffmanEncodeModel.Standard)
                {
                    specialSymbolCharacter = symbolKey[0];
                    specialSymbolCounts = symbol.Value.Counts;
                }
                else
                {
                    symbolsMapByteList.AddRange(ToByteArray(symbolKey));
                    symbolsMapByteList.AddRange(new List<byte>(BitConverter.GetBytes(symbol.Value.Counts)));
                }
            }
            if (specialSymbol)
            {
                symbolsMapByteList.Add(Convert.ToByte(specialSymbol));
                symbolsMapByteList.AddRange(new List<byte>(BitConverter.GetBytes(specialSymbolCounts)));
            }

            return symbolsMapByteList;
        }

        private byte[] CreateHeaderFromBytes(byte huffmanEncodeModelByte, byte specialSymbolByte, List<byte> symbolsMapByteList)
        {
            uint headerSize = (uint)symbolsMapByteList.Count + 6;
     
            List<byte> header = new List<byte>();
            header.AddRange(new List<byte>(BitConverter.GetBytes(headerSize)));
            header.Add(huffmanEncodeModelByte);
            header.Add(specialSymbolByte);
            header.AddRange(symbolsMapByteList);

            return header.ToArray();
        }
    }
}
