using HuffmanCoder.Logic.Entities;
using System.Collections.Generic;
using System.Text;
using System;

namespace HuffmanCoder.Logic.Writers.Encoding
{
    /*Header consists of:
    -headerSize - 4 bytes
    -dataSizeInBits - 4 bytes
    -map (symbol and symbol counts)
    */
    /*
    50
    0
    10345
    A:5;B:6;C:8
    */
    public interface IHeaderCreator
    {
        byte[] Create(uint bitAmount, HuffmanEncodeModel huffmanEncodeModel, Dictionary<string, OutputValues> symbolsMap);
    }

    public class HeaderCreator : IHeaderCreator
    {
        public byte[] Create(uint bitAmount, HuffmanEncodeModel huffmanEncodeModel, Dictionary<string, OutputValues> symbolsMap)
        {
            List<byte> huffmanEncodeModelByteList= CreateHuffmanEncodeModelByteList(huffmanEncodeModel);
            List<byte> bitAmountByteList = CreateBitAmountByteList(bitAmount);
            List<byte> symbolsMapByteList = CreateSymbolsMapByteList(symbolsMap);

            byte[] header = CreateHeaderFromByteLists(huffmanEncodeModelByteList, bitAmountByteList, symbolsMapByteList);
            return header;
        }

        private List<byte> CreateHuffmanEncodeModelByteList(HuffmanEncodeModel encodeModel)
        {
            throw new NotImplementedException();
        }

        private List<byte> CreateBitAmountByteList(uint bitAmount)
        {
            throw new NotImplementedException();
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
            builder.Append(System.Environment.NewLine);

            return new List<byte>(System.Text.Encoding.ASCII.GetBytes(builder.ToString()));
        }

        private byte[] CreateHeaderFromByteLists(List<byte> huffmanEncodeModelByteList, List<byte> bitAmountByteList, List<byte> symbolsMapByteList)
        {
            throw new NotImplementedException();
        }
    }
}
