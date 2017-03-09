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
    internal interface IHuffmanCoder<T>
    {
        /// <summary>
        /// Encodes symbols specified by the input to bits writted to output.
        /// </summary>
        /// <param name="input">Input from which symbols are read.</param>
        /// <param name="output">Output to which bits are written.</param>
        void Encode(IHuffmanCoderInput<T> input, IHuffmanCoderOutput output);

        /// <summary>
        /// The encoding dictionary used for encoding, which
        /// maps the symbol to its bit representation.
        /// </summary>
        Dictionary<T, bool[]> EncodingDictionary { get; }
    }
}