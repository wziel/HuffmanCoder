using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Tree;

namespace HuffmanCoder.Model.Codec
{
    internal class HuffmanCoder<T> : IHuffmanCoder<T>
    {
        Dictionary<T, bool[]> symbolEncodingDic = new Dictionary<T, bool[]>();

        internal HuffmanCoder(HuffmanTreeNode<T> root)
        {
            GenerateSymbolEncodingDic(root, new List<bool>());
        }

        private void GenerateSymbolEncodingDic(HuffmanTreeNode<T> node, List<bool> currentEncoding)
        {
            if(node.IsLeaf)
            {
                symbolEncodingDic.Add(node.Value, currentEncoding.ToArray());
                return;
            }
            currentEncoding.Add(false);
            GenerateSymbolEncodingDic(node.LeftChild, currentEncoding);
            currentEncoding.RemoveAt(currentEncoding.Count - 1);
            currentEncoding.Add(true);
            GenerateSymbolEncodingDic(node.RightChild, currentEncoding);
            currentEncoding.RemoveAt(currentEncoding.Count - 1);
        }

        public void Encode(IHuffmanCoderInput<T> input, IHuffmanCoderOutput output)
        {
            while(!input.IsEnd())
            {
                var symbol = input.Read();
                bool[] symbolEncoding;
                var found = symbolEncodingDic.TryGetValue(symbol, out symbolEncoding);
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
    }
}
