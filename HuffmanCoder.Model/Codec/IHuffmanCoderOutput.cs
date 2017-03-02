using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    public interface IHuffmanCoderOutput
    {
        void Write(bool bit);
    }
}
