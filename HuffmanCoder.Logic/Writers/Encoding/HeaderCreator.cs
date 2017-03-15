using HuffmanCoder.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.Writers.Encoding
{
    /*Header consists of:
    -headerSize - 4 bytes
    -dataSizeInBits - 4 bytes
    -map (symbol and symbol counts)
    */
    public interface IHeaderCreator
    {
        byte[] Create(uint bitAmount, Dictionary<string, OutputValues> map);
    }

    public class HeaderCreator
    {
        internal byte[] Create(uint bitAmount, Dictionary<string, OutputValues> map)
        {
            throw new NotImplementedException();
        }
    }
}
