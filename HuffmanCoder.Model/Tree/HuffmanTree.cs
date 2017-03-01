using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Tree
{
    internal class HuffmanTree<T>
    {
        private HuffmanTreeNode<T> root;

        internal HuffmanTree(HuffmanTreeNode<T> root)
        {
            this.root = root;
        }
    }
}
