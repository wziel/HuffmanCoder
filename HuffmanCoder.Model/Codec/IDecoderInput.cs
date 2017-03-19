using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Interface that supplies encoded bits to huffman decoder.
    /// </summary>
    public interface IDecoderInput
    {
        /// <summary>
        /// Reads a single bit of encoded input.
        /// </summary>
        /// <returns>A single bit of encoded input.</returns>
        bool Read();
    }
}
