using HuffmanCoder.Model.Codec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Codec
{
    class MockDecoderOutput : IDecoderOutput<char>
    {
        private List<char> expected;
        private int i = 0;
        private bool foundIncorrectSymbol = false;

        public MockDecoderOutput(List<char> expected)
        {
            this.expected = expected;
        }

        public bool IsEnd()
        {
            return foundIncorrectSymbol || expected.Count == i;
        }

        public void Write(char symbol)
        {
            if (!foundIncorrectSymbol && expected[i] != symbol)
            {
                foundIncorrectSymbol = true;
            }
            else
            {
                ++i;
            }
        }

        public void AssertCorrectOutput()
        {
            if (foundIncorrectSymbol)
            {
                throw new AssertFailedException($"Expected a different symbol than received");
            }
            if (expected.Count != i)
            {
                throw new AssertFailedException("Not all expected symbols have been read");
            }
        }
    }
}
