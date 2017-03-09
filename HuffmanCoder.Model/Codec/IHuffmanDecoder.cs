using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Class responsible for decoding encoded bits to symbols.
    /// </summary>
    /// <typeparam name="T">Type of symbols class.</typeparam>
    internal interface IHuffmanDecoder<T>
    {
        /// <summary>
        /// Decodes bits supplied by input to symbols that are delieverd to output.
        /// </summary>
        /// <param name="input">Input which supplies bits.</param>
        /// <param name="output">Output that consumes symbols.</param>
        void Decode(IHuffmanDecoderInput input, IHuffmanDecoderOutput<T> output);
    }
}
