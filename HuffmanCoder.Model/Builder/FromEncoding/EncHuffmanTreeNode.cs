using HuffmanCoder.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Builder.FromEncoding
{
    internal class EncHuffmanTreeNode<T> : IHuffmanTreeNode<T>
    {
        private T value;

        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                this.IsAssignedValue = true;
            }
        }

        public bool IsAssignedValue { get; private set; }
        public bool IsLeaf { get { return RightChild == null && LeftChild == null; } }
        public EncHuffmanTreeNode<T> LeftChild { get; set; }
        public EncHuffmanTreeNode<T> RightChild { get; set; }
        public EncHuffmanTreeNode<T> Parent { get; set; }
        IHuffmanTreeNode<T> IHuffmanTreeNode<T>.Parent { get { return Parent; } }
        IHuffmanTreeNode<T> IHuffmanTreeNode<T>.LeftChild { get { return LeftChild; } }
        IHuffmanTreeNode<T> IHuffmanTreeNode<T>.RightChild { get { return RightChild; } }
    }
}
