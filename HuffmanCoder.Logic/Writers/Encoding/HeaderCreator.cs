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
            List<byte> symbolsMapByteList = CreateSymbolsMapByteList(huffmanEncodeModel, symbolsMap);

            byte[] header = CreateHeaderFromBytes(huffmanEncodeModelByte, specialSymbolByte, symbolsMapByteList);
            return header;
        }

        private List<byte> CreateSymbolsMapByteList(HuffmanEncodeModel huffmanEncodeModel, Dictionary<string, OutputValues> symbolsMap)
        {
            List<byte> symbolsMapByteList = new List<byte>();
            System.Text.Encoding extendedASCII = System.Text.Encoding.GetEncoding(1252);

            foreach (KeyValuePair<string, OutputValues> symbol in symbolsMap)
            {
                string symbolKey = symbol.Key;
                if(symbolKey.Length == 1 && huffmanEncodeModel != HuffmanEncodeModel.Standard)
                {
                    char singleSymbol = symbolKey[0];
                    symbolsMapByteList.AddRange(new List<byte>(BitConverter.GetBytes(singleSymbol)));
                }
                else
                {
                    symbolsMapByteList.Add(Convert.ToByte(symbolKey[0]));
                }

                symbolsMapByteList.AddRange(new List<byte>(BitConverter.GetBytes(symbol.Value.Counts)));
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
