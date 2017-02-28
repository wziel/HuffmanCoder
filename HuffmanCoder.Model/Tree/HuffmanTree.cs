using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Tree
{
    public class HuffmanTree<T> : IHuffmanTree<T>
    {
        private HuffmanTreeNode<T> root;

        internal HuffmanTree(HuffmanTreeNode<T> root)
        {
            this.root = root;
        }
    }
}
