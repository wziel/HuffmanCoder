using HuffmanCoder.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Builder
{
    public interface IHuffmanTreeBuilder<T>
    {
        void Add(T symbol);
        IHuffmanTree<T> Build();
    }
}
