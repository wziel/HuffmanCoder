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

        public bool IsDefault
        {
            get
            {
                return isDefault;
            }
        }

        public T Value
        {
            get
            {
                return value;
            }
        }

        public DefaultableSymbol(T value) : this(value, false) { }

        public DefaultableSymbol(T value, bool isDefault)
        {
            this.value = value;
            this.isDefault = isDefault;
        }

        public bool Equals(DefaultableSymbol<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.isDefault == other.isDefault || Comparer<T>.Default.Compare(this.value, other.value) == 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(DefaultableSymbol<T>)) return false;
            return Equals((DefaultableSymbol<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 1;
                result = (result * 397) ^ value.GetHashCode();
                result = (result * 397) ^ isDefault.GetHashCode();
                return result;
            }
        }



    }
}
