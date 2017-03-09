using HuffmanCoder.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Builder.FromQuantity
{
    /// <summary>
    /// Comparer used for comparing two huffman tree nodes. The smaller is assumed to be in order:
    /// 1. The one with less quantity of occurances.
    /// 2. The one with small subtree depth.
    /// 3. The one which has a smaller value.
    /// Value comparer is defined by user of this class.
    /// </summary>
    /// <typeparam name="T">Value type of huffman nodes</typeparam>
    internal class QHuffmanTreeNodeComparer<T> : IComparer<QHuffmanTreeNode<T>>
    {
        private IComparer<T> valueComparer;

        /// <summary>
        /// </summary>
        /// <param name="valueComparer">
        /// Value comparer of huffman nodes values. Used as a last resort to defined
        /// relation between huffman nodes.
        /// It should never return 0 (equality) for different elements.
        /// </param>
        public QHuffmanTreeNodeComparer(IComparer<T> valueComparer)
        {
            this.valueComparer = valueComparer;
        }

        public int Compare(QHuffmanTreeNode<T> x, QHuffmanTreeNode<T> y)
        {
            if(x.Quantity != y.Quantity)
            {
                return x.Quantity - y.Quantity;
            }
            if(x.SubTreeDepth != y.SubTreeDepth)
            {
                return x.SubTreeDepth - y.SubTreeDepth;
            }
            var valueComparerResult = valueComparer.Compare(x.Value, y.Value);
            if(valueComparerResult == 0)
            {
                throw new Exception("Two huffman nodes cannot be equal to each other");
            }
            return valueComparerResult;
        }
    }
}
