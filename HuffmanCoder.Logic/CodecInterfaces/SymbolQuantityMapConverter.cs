using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Logic.Entities;

namespace HuffmanCoder.Logic.CodecInterfaces
{
    public class SymbolQuantityMapConverter
    {
        public static Dictionary<byte, int> StandardExtToIntConvert(Dictionary<string, ushort> mapFromFile)
        {
            var internalSymbolQuantMap = new Dictionary<byte, int>();
            foreach (KeyValuePair<string, ushort> entry in mapFromFile)
            {
                if(entry.Key.Length > 1)
                {
                    throw new ArgumentException();
                }
                internalSymbolQuantMap.Add((byte)entry.Key[0], entry.Value);
            }
            return internalSymbolQuantMap;
        }

        public static Dictionary<Tuple<byte, DefaultableSymbol<byte>>, int> PairExtToIntConvert(Dictionary<string, ushort> mapFromFile)
        {
            var internalSymbolQuantMap = new Dictionary<Tuple<byte, DefaultableSymbol<byte>>, int>();
            foreach (KeyValuePair<string, ushort> entry in mapFromFile)
            {
                if (entry.Key.Length == 1)
                {
                    internalSymbolQuantMap.Add(new Tuple<byte, DefaultableSymbol<byte>>((byte)entry.Key[0], new DefaultableSymbol<byte>(true)), entry.Value);
                }
                else
                {
                    internalSymbolQuantMap.Add(new Tuple<byte, DefaultableSymbol<byte>>((byte)entry.Key[0], new DefaultableSymbol<byte>((byte)entry.Key[1])), entry.Value);
                }
            }
            return internalSymbolQuantMap;
        }

        public static Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> MarkowExtToIntConvert(Dictionary<string, ushort> mapFromFile)
        {
            var internalSymbolQuantMap = new Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>>();
            foreach (KeyValuePair<string, ushort> entry in mapFromFile)
            {
                if (entry.Key.Length == 1)
                {
                    internalSymbolQuantMap.Add(new DefaultableSymbol<byte>(true), new Dictionary<byte, int>()
                    {
                        {(byte) entry.Key[0], entry.Value}
                    });
                }
                else
                {
                    if (internalSymbolQuantMap.ContainsKey(new DefaultableSymbol<byte>((byte)entry.Key[0])))
                    {
                        internalSymbolQuantMap[new DefaultableSymbol<byte>((byte)entry.Key[0])].Add((byte)entry.Key[1], entry.Value);
                    }
                    else
                    {
                        internalSymbolQuantMap.Add(new DefaultableSymbol<byte>((byte)entry.Key[0]), new Dictionary<byte, int>()
                    {
                        {(byte) entry.Key[1], entry.Value}
                    });
                    }
                }
            }
            return internalSymbolQuantMap;
        }
        public static Dictionary<string, OutputValues> StandardIntToExtConvert(Dictionary<byte, int> internalMap, Dictionary<byte, bool[]> codedSymbolsMap)
        {
            var externalSymbolQuantMap = new Dictionary<string, OutputValues>();
            foreach (KeyValuePair<byte, int> entry in internalMap)
            {
                OutputValues outputValues = new OutputValues();
                outputValues.Counts = (ushort) entry.Value;
                outputValues.BitsLength = codedSymbolsMap[entry.Key].Length;

                externalSymbolQuantMap.Add(((char) entry.Key).ToString(), outputValues);
            }
            return externalSymbolQuantMap;
        }

        public static Dictionary<string, OutputValues> PairIntToExtConvert(Dictionary<Tuple<byte, DefaultableSymbol<byte>>, int> internalMap, Dictionary<Tuple<byte, DefaultableSymbol<byte>>, bool[]> codedSymbolsMap)
        {
            var externalSymbolQuantMap = new Dictionary<string, OutputValues>();
            foreach (KeyValuePair<Tuple<byte, DefaultableSymbol<byte>>, int> entry in internalMap)
            {
                OutputValues outputValues = new OutputValues();
                outputValues.Counts = (ushort)entry.Value;
                outputValues.BitsLength = codedSymbolsMap[entry.Key].Length;
                if (entry.Key.Item2.IsDefault)
                {
                    externalSymbolQuantMap.Add(((char)entry.Key.Item1).ToString(), outputValues);
                }
                else
                {
                    externalSymbolQuantMap.Add(((char)entry.Key.Item1).ToString() + ((char)entry.Key.Item2.Value).ToString(), outputValues);
                }
            }
            return externalSymbolQuantMap;
        }

        public static Dictionary<string, OutputValues> MarkowIntToExtConvert(Dictionary<DefaultableSymbol<byte>, Dictionary<byte, int>> internalMap, Dictionary<DefaultableSymbol<byte>, Dictionary<byte, bool[]>> codedSymbolsMap)
        {
            var externalSymbolQuantMap = new Dictionary<string, OutputValues>();
            foreach (KeyValuePair<DefaultableSymbol<byte>, Dictionary<byte, int>> mainEntry in internalMap)
            {
                foreach (KeyValuePair<byte, int> entry in mainEntry.Value)
                {
                    OutputValues outputValues = new OutputValues();
                    outputValues.Counts = (ushort)entry.Value;
                    outputValues.BitsLength = codedSymbolsMap[mainEntry.Key][entry.Key].Length;
                    if (mainEntry.Key.IsDefault)
                    {
                        externalSymbolQuantMap.Add(((char)entry.Key).ToString(), outputValues);
                    }
                    else
                    {
                        externalSymbolQuantMap.Add(((char)mainEntry.Key.Value).ToString() + ((char)entry.Key).ToString(), outputValues);
                    }
                }
            }
            return externalSymbolQuantMap;
        }

    }
}
