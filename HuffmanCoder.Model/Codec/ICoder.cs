using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Interface for encoding symbols to bits.
    /// </summary>
    /// <typeparam name="T">The type of symbol class.</typeparam>
    public interface ICoder<T>
    {
        /// <summary>
        /// Encodes symbols specified by the input to bits writted to output.
        /// </summary>
        /// <param name="input">Input from which symbols are read.</param>
        /// <param name="output">Output to which bits are written.</param>
        void Encode(ICoderInput<T> input, ICoderOutput output);
    }
}