using HuffmanCoder.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Builder
{
    interface IHuffmanTreeBuilder<T>
    {
        /// <summary>
        /// Builds a huffman tree and returns root node.
        /// </summary>
        /// <returns>Root node of huffman tree.</returns>
        IHuffmanTreeNode<T> BuildTree();
    }
}
