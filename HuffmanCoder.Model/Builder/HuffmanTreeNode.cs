using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Tree
{
    internal class HuffmanTreeNode<T>
    {
        public HuffmanTreeNode(T value, int quantity, int subTreeDepth = 0)
        {
            this.Value = value;
            this.Quantity = quantity;
            this.SubTreeDepth = subTreeDepth;
        }

        public int SubTreeDepth { get; internal set; }
        public T Value { get; internal set; }
        public int Quantity { get; internal set; }
        public HuffmanTreeNode<T> Parent { get; internal set; }
        public HuffmanTreeNode<T> LeftChild { get; internal set; }
        public HuffmanTreeNode<T> RightChild { get; internal set; }
        public bool IsLeaf { get { return SubTreeDepth == 0;  } }

        public override string ToString()
        {
            return $"(leaf, {Quantity}, {Value.ToString()})";
        }
    }
}
