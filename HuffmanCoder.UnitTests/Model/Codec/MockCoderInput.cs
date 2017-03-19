using HuffmanCoder.Model.Codec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Codec
{
    class MockCoderInput<T> : ICoderInput<T>
    {
        private List<T> input = new List<T>();
        private int idx = 0;

        internal MockCoderInput(List<T> input)
        {
            this.input = input;
        }

        public bool IsEnd()
        {
            return idx == input.Count;
        }

        public T Read()
        {
            return input[idx++];
        }
    }
}
