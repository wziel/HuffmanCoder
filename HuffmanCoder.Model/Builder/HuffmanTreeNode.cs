using HuffmanCoder.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Builder
{
    public class HuffmanTreeNode<T> : IHuffmanTreeNode<T>
    {
        public HuffmanTreeNode(T value, int quantity, int subTreeDepth = 0)
        {
            Value = value;
            Quantity = quantity;
            SubTreeDepth = subTreeDepth;
        }

        public T Value { get; set; }
        public int Quantity { get; set; }
        public int SubTreeDepth { get; set; }
        public bool IsLeaf { get { return RightChild == null && LeftChild == null; } }
        public HuffmanTreeNode<T> Parent { get; set; }
        public HuffmanTreeNode<T> LeftChild { get; set; }
        public HuffmanTreeNode<T> RightChild { get; set; }
        IHuffmanTreeNode<T> IHuffmanTreeNode<T>.Parent { get { return Parent;  } }
        IHuffmanTreeNode<T> IHuffmanTreeNode<T>.LeftChild { get { return LeftChild; } }
        IHuffmanTreeNode<T> IHuffmanTreeNode<T>.RightChild { get { return RightChild;  } }

        public override string ToString()
        {
            return $"(leaf={IsLeaf},{Quantity},{Value.ToString()})";
        }
    }
}