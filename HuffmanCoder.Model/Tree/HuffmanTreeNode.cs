using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Tree
{
    internal class HuffmanTreeNode<T>
    {
        public HuffmanTreeNode(T value, int quantity, int subTreeDepth)
        {
            this.Value = value;
            this.Quantity = quantity;
            this.SubTreeDepth = SubTreeDepth;
        }

        public int SubTreeDepth { get; internal set; }
        public T Value { get; internal set; }
        public int Quantity { get; internal set; }
        public HuffmanTreeNode<T> Parent { get; internal set; }
        public HuffmanTreeNode<T> LeftChild { get; internal set; }
        public HuffmanTreeNode<T> RightChild { get; internal set; }

        public override string ToString()
        {
            return $"(leaf, {Quantity}, {Value.ToString()})";
        }
    }
}
