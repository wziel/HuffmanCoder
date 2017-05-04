using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Logic.CodecInterfaces.Comparers
{
    public class PairComparer : IComparer<Tuple<byte, DefaultableSymbol<byte>>>
    {
        public int Compare(Tuple<byte, DefaultableSymbol<byte>> x, Tuple<byte, DefaultableSymbol<byte>> y)
        {
            if (x.Item2.IsDefault)
            {
                if (y.Item2.IsDefault)
                {
                    if (x.Item1 > y.Item1)
                    {
                        return 1;
                    }
                    else if (x.Item1 < y.Item1)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (x.Item1 <= y.Item1)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (y.Item2.IsDefault)
                {
                    if (x.Item1 >= y.Item1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (x.Item1 > y.Item1)
                    {
                        return 1;
                    }
                    else if (x.Item1 < y.Item1)
                    {
                        return -1;
                    }
                    else
                    {
                        if (x.Item2.Value > y.Item2.Value)
                        {
                            return 1;
                        }
                        else if (x.Item2.Value < y.Item2.Value)
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }
    }
}
