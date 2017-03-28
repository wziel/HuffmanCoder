using HuffmanCoder.Model.Codec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Codec
{

    [TestClass]
    public class OneSymbolCoderTests
    {
        [TestMethod]
        public void Encode_NumberOfBitsIsEqualsToNumberOfSymbolsEncoded()
        {
            //given
            var coder = new OneSymbolCoder<char>('a');
            var input = new MockCoderInput<char>(new List<char>() { 'a', 'a', 'a', 'a' });
            var output = new MockCoderOutput();
            //when
            coder.Encode(input, output);
            //then
            output.AssertEquals(new List<int>() { 1, 1, 1, 1 });
        }
    }
}
