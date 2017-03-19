using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Coder that encodes data which contains only one symbol in alphabet.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class OneSymbolCoder<T> : ICoder<T>
    {
        public void Encode(ICoderInput<T> input, ICoderOutput output)
        {
            while(!input.IsEnd())
            {
                input.Read();
                output.Write(true);
            }
        }
    }
}
