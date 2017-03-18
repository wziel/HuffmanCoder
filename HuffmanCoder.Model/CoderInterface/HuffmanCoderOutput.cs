using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Model.CoderInterface
{
    class HuffmanCoderOutput : IHuffmanCoderOutput
    {
        private IHuffmanCoderInterfaceOutput huffmanCoderInterfaceOutput;

        public HuffmanCoderOutput(IHuffmanCoderInterfaceOutput output)
        {
            this.huffmanCoderInterfaceOutput = output;
        }

        public void Write(bool bit)
        {
            huffmanCoderInterfaceOutput.Write(bit);
        }
    }
}
