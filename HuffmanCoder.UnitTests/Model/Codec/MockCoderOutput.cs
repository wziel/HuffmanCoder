using HuffmanCoder.Model.Codec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Codec
{
    class MockCoderOutput : ICoderOutput
    {
        private List<int> output = new List<int>();

        public void Write(bool bit)
        {
            output.Add(bit ? 1 : 0);
        }

        public void AssertEquals(List<int> expected)
        {
            if (expected.Count != output.Count)
            {
                Fail(expected);
            }
            for (int i = 0; i < expected.Count; ++i)
            {
                if (output[i] != expected[i])
                {
                    Fail(expected);
                }
            }
        }

        public void Fail(List<int> expected)
        {
            throw new AssertFailedException($"Expected is not equal to received");
        }
    }
}
