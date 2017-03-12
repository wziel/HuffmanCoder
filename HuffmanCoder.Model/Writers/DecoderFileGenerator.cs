using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Writers
{
    public interface IDecoderFileGenerator
    {
        void GenerateFile();
    }
    public class DecoderFileGenerator : IDecoderFileGenerator
    {
        public DecoderFileGenerator()
        {

        }

        public void GenerateFile()
        {
            throw new NotImplementedException();
        }
    }
}
