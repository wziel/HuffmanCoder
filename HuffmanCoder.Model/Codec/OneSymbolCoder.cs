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
        private T symbol;

        public OneSymbolCoder(T symbol)
        {
            this.symbol = symbol;
        }

        public void Encode(ICoderInput<T> input, ICoderOutput output)
        {
            while(!input.IsEnd())
            {
                input.Read();
                output.Write(true);
            }
        }

        public Dictionary<T, bool[]> GetEncodingDictionary()
        {
            return new Dictionary<T, bool[]>
            {
                { symbol, new bool[] { true } }
            };
        }
    }
}
