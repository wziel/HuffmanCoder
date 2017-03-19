using HuffmanCoder.Model.Codec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Codec
{
    class MockDecoderInput : IDecoderInput
    {
        private List<int> bits;
        private int i = 0;

        public MockDecoderInput(List<int> bits)
        {
            this.bits = bits;
        }

        public bool Read()
        {
            return bits[i++] == 1 ? true : false;
        }
    }
}
