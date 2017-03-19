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
    public class OneSymbolDecoderTests
    {
        [TestMethod]
        public void Decode_NumberOfSymbolsReturnedIsEqualToNumberOfBits()
        {
            //given
            var decoder = new OneSymbolDecoder<char>('x');
            var input = new MockDecoderInput(new List<int> { 1, 1, 1, 1 });
            var output = new MockDecoderOutput(new List<char> { 'x', 'x', 'x', 'x' });
            //when
            decoder.Decode(input, output);
            //then
            output.AssertCorrectOutput();
        }
    }
}
