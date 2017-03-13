using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Codec;
using HuffmanCoder.Logic.Writers.Encoding;

namespace HuffmanCoder.Logic.CoderInterfaces
{
    class HuffmanCoderOutput : IHuffmanCoderOutput
    {
        private ICoderOutputWriter coderOutputWriter;

        public HuffmanCoderOutput(ICoderOutputWriter coderOutputWriter)
        {
            this.coderOutputWriter = coderOutputWriter;
        }

        public void Write(bool bit)
        {
            coderOutputWriter.Write(bit);
        }
    }
}
