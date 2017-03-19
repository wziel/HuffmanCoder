using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Codec
{
    /// <summary>
    /// Decoder that decodes data which contains only one symbol in alphabet.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class OneSymbolDecoder<T> : IDecoder<T>
    {
        private T symbol;

        public OneSymbolDecoder(T symbol)
        {
            this.symbol = symbol;
        }

        public void Decode(IDecoderInput input, IDecoderOutput<T> output)
        {
            while (!output.IsEnd())
            {
                input.Read();
                output.Write(symbol);
            }
        }
    }
}
