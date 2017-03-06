using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Output of huffman coder that consumes bits.
    /// </summary>
    public interface IHuffmanCoderOutput
    {
        /// <summary>
        /// Writes a single bit of encoded input to the output.
        /// </summary>
        /// <param name="bit"></param>
        void Write(bool bit);
    }
}
