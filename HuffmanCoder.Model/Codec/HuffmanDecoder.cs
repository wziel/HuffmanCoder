using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Tree;

namespace HuffmanCoder.Model.Codec
{
    internal class HuffmanDecoder<T> : IHuffmanDecoder<T>
    {
        private HuffmanTreeNode<T> root;

        internal HuffmanDecoder(HuffmanTreeNode<T> root)
        {
            this.root = root;
            throw new NotImplementedException("Please unit test me first :(");
        }

        public void Decode(IHuffmanDecoderInput input, IHuffmanDecoderOutput<T> output)
        {
            Decode(input, output, root);
        }

        private void Decode(IHuffmanDecoderInput input, IHuffmanDecoderOutput<T> output, HuffmanTreeNode<T> currentNode)
        {
            while(!input.IsEnd())
            {
                var bit = input.Read();
                currentNode = bit ? currentNode.RightChild : currentNode.LeftChild;
                if(currentNode.IsLeaf)
                {
                    output.Write(currentNode.Value);
                    currentNode = root;
                }
            }
            if(currentNode != root)
            {
                throw new Exception(@"Unexpected end of input. 
                    Decoder was during encoding of current symbol and input ended.");
            }
        }
    }
}
