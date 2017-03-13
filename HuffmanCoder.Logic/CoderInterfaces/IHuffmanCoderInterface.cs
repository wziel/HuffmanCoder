using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.CoderInterfaces
{
    public interface IHuffmanCoderInterface
    {
        /// <summary>
        /// Encodes symbols specified by the input to bits writted to output.
        /// </summary>
        /// <param name="input">Input from which symbols are read.</param>
        /// <param name="output">Output to which bits are written.</param>
        void Encode();
    }
}
