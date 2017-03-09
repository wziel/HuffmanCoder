using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Input of huffman coder, supplies symbols and specifies when there are no more symbols.
    /// </summary>
    /// <typeparam name="T">Type of symbol class.</typeparam>
    internal interface IHuffmanCoderInput<T>
    {
        /// <summary>
        /// Reads a single input symbol.
        /// </summary>
        /// <returns>Single input symbol.</returns>
        T Read();

        /// <summary>
        /// Checks if there are any more input symbols to be read.
        /// </summary>
        /// <returns>False if there are more symbols to read, true if there are not.</returns>
        bool IsEnd();
    }
}
