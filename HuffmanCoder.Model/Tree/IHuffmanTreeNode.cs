using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Tree
{
    internal interface IHuffmanTreeNode<T>
    {
        T Value { get; }
        IHuffmanTreeNode<T> Parent { get; }
        IHuffmanTreeNode<T> LeftChild { get; }
        IHuffmanTreeNode<T> RightChild { get; }
        bool IsLeaf { get; }
    }
}
