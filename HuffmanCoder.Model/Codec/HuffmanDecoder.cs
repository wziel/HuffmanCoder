using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Tree;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Decoder that decodes data using huffman algorithm.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class HuffmanDecoder<T> : IDecoder<T>
    {
        private IHuffmanTreeNode<T> root;

        public HuffmanDecoder(IHuffmanTreeNode<T> root)
        {
            this.root = root;
        }

        public void Decode(IDecoderInput input, IDecoderOutput<T> output)
        {
            Decode(input, output, root);
        }

        private void Decode(IDecoderInput input, IDecoderOutput<T> output, IHuffmanTreeNode<T> currentNode)
        {
            while(!output.IsEnd())
            {
                var bit = input.Read();
                currentNode = bit ? currentNode.RightChild : currentNode.LeftChild;
                if(currentNode.IsLeaf)
                {
                    output.Write(currentNode.Value);
                    currentNode = root;
                }
            }
        }
    }
}
