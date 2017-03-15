using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.CoderInterface
{
    public interface IHuffmanCoderInterface<T>
    {
        /// <summary>
        /// Encodes symbols specified by the input to bits writted to output.
        /// </summary>
        /// <param name="input">Input from which symbols are read.</param>
        /// <param name="output">Output to which bits are written.</param>
        void Encode(IHuffmanCoderInterfaceInput<T> input, IHuffmanCoderInterfaceOutput output, IComparer<T> comparer);
    }
}
