using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.CodecInterfaces
{
    public class DefaultableSymbol<T>
    {
        T value;
        bool isDefault;

        public DefaultableSymbol(bool isDefault)
        {
            this.isDefault = isDefault;
        }

        public DefaultableSymbol(T value) : this(value, false) { }

        public DefaultableSymbol(T value, bool isDefault)
        {
            this.value = value;
            this.isDefault = isDefault;
        }
    }
}
