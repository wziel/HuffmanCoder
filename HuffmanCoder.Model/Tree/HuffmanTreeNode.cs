using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Tree
{
    internal class HuffmanTreeNode<T>
    {
        public bool IsLeaf { get; internal set; }
        public T Value { get; internal set; }
        public int Probability { get; internal set; }
        public HuffmanTreeNode<T> Parent { get; internal set; }

        public override string ToString()
        {
            if(!IsLeaf)
            {
                return $"(non-leaf, {Probability})";
            }
            return $"(leaf, {Probability}, {Value.ToString()})";
        }
    }
}
