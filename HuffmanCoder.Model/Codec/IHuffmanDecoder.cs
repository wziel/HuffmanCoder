﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    public interface IHuffmanDecoder<T>
    {
        void Decode(IHuffmanDecoderInput input, IHuffmanDecoderOutput<T> output);
    }
}
