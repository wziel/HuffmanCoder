using HuffmanCoder.Model.Codec;
using HuffmanCoder.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Builder
{
    public interface IHuffmanCodecBuilder<T>
    {
        void Add(T symbol);
        void Add(T symbol, int quantity);
        IHuffmanCoder<T> GetCoder();
        IHuffmanDecoder<T> GetDecoder();
    }
}