using HuffmanCoder.Logic.Entities;
using System.Collections.Generic;
using System.Text;
using System;

namespace HuffmanCoder.Logic.Writers.Encoding
{
    /*Header consists of:
    -headerSize - 4 bytes
    -huffmanEncodeModel - 4 bytes
    -dataSizeInBits - 4 bytes
    -map (symbol and symbol counts)
    */
    
    public interface IHeaderCreator
    {
        byte[] Create(uint bitAmount, HuffmanEncodeModel huffmanEncodeModel, Dictionary<string, OutputValues> symbolsMap);
    }

    public class HeaderCreator : IHeaderCreator
    {
        public byte[] Create(uint bitAmount, HuffmanEncodeModel huffmanEncodeModel, Dictionary<string, OutputValues> symbolsMap)
        {
            List<byte> huffmanEncodeModelByteList = new List<byte>(BitConverter.GetBytes((uint)huffmanEncodeModel));
            List<byte> bitAmountByteList = new List<byte>(BitConverter.GetBytes(bitAmount));
            List<byte> symbolsMapByteList = CreateSymbolsMapByteList(symbolsMap);

            byte[] header = CreateHeaderFromByteLists(huffmanEncodeModelByteList, bitAmountByteList, symbolsMapByteList);
            return header;
        }

        private List<byte> CreateSymbolsMapByteList(Dictionary<string, OutputValues> symbolsMap)
        {
            StringBuilder builder = new StringBuilder();
            foreach(KeyValuePair<string, OutputValues> symbol in symbolsMap)
            {
                builder.Append(symbol.Key);
                builder.Append(":");
                builder.Append(symbol.Value.Counts);
                builder.Append(";");
            }

            List<byte> symbolsMapByteList = new List<byte>(System.Text.Encoding.ASCII.GetBytes(builder.ToString()));
            
            // If map contains at least one element remove last ';' 
            if (symbolsMap.Count > 0)
            {
                symbolsMapByteList.RemoveAt(symbolsMapByteList.Count - 1);
            }

            return symbolsMapByteList;
        }

        private byte[] CreateHeaderFromByteLists(List<byte> huffmanEncodeModelByteList, List<byte> bitAmountByteList, List<byte> symbolsMapByteList)
        {
            List<byte> headerBody = new List<byte>();
            headerBody.AddRange(huffmanEncodeModelByteList);
            headerBody.AddRange(bitAmountByteList);
            headerBody.AddRange(symbolsMapByteList);

            uint headerBodySize = (uint)headerBody.Count + 4;
     
            List<byte> header = new List<byte>(BitConverter.GetBytes(headerBodySize));
            header.AddRange(headerBody);

            return header.ToArray();
        }
    }
}
