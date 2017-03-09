using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Interface that consumes symbols decoded from decoder and specifies when there
    /// are no more symbols expected.
    /// </summary>
    /// <typeparam name="T">Type of symbols class.</typeparam>
    internal interface IHuffmanDecoderOutput<T>
    {
        /// <summary>
        /// Writes a decoded symbol to the output.
        /// </summary>
        /// <param name="symbol">The symbol that has been decoded.</param>
        void Write(T symbol);

        /// <summary>
        /// Checks if any more symbols are expected.
        /// </summary>
        /// <returns>True if there are no more symbols expected, false if there are.</returns>
        bool IsEnd();
    }
}
