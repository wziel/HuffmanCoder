using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Tree;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Coder that encodes data using huffman algorithm.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class HuffmanCoder<T> : ICoder<T>
    {
        private Dictionary<T, bool[]> EncodingDictionary { get; } = new Dictionary<T, bool[]>();

        public HuffmanCoder(IHuffmanTreeNode<T> root)
        {
            GenerateSymbolEncodingDic(root, new List<bool>());
        }

        private void GenerateSymbolEncodingDic(IHuffmanTreeNode<T> node, List<bool> currentEncoding)
        {
            if(node.IsLeaf)
            {
                EncodingDictionary.Add(node.Value, currentEncoding.ToArray());
                return;
            }
            currentEncoding.Add(false);
            GenerateSymbolEncodingDic(node.LeftChild, currentEncoding);
            currentEncoding.RemoveAt(currentEncoding.Count - 1);
            currentEncoding.Add(true);
            GenerateSymbolEncodingDic(node.RightChild, currentEncoding);
            currentEncoding.RemoveAt(currentEncoding.Count - 1);
        }

        public void Encode(ICoderInput<T> input, ICoderOutput output)
        {
            while(!input.IsEnd())
            {
                var symbol = input.Read();
                bool[] symbolEncoding;
                var found = EncodingDictionary.TryGetValue(symbol, out symbolEncoding);
                if(!found)
                {
                    throw new Exception($"Symbol {symbol.ToString()} not found");
                }
                for(int i = 0; i < symbolEncoding.Length; ++i)
                {
                    output.Write(symbolEncoding[i]);
                }
            }
        }

        public Dictionary<T, bool[]> GetEncodingDictionary()
        {
            return EncodingDictionary;
        }
    }
}
