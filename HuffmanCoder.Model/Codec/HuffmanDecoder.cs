using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Tree;

namespace HuffmanCoder.Model.Codec
{
    public class HuffmanDecoder<T> : IHuffmanDecoder<T>
    {
        private IHuffmanTreeNode<T> root;

        public HuffmanDecoder(IHuffmanTreeNode<T> root)
        {
            this.root = root;
        }

        public void Decode(IHuffmanDecoderInput input, IHuffmanDecoderOutput<T> output)
        {
            Decode(input, output, root);
        }

        private void Decode(IHuffmanDecoderInput input, IHuffmanDecoderOutput<T> output, IHuffmanTreeNode<T> currentNode)
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
