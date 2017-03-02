﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    public interface IHuffmanCoder<T>
    {
        void Encode(IHuffmanCoderInput<T> input, IHuffmanCoderOutput output);
    }
}
