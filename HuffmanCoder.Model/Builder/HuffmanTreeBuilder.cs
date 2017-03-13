using System;
using System.Collections.Generic;
using System.Linq;
using HuffmanCoder.Model.Tree;
using C5;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Model.Builder
{
    /// <summary>
    /// Class used for building a huffman tree based on quantitty of symbols used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HuffmanTreeBuilder<T>
    {
        private Dictionary<T, int> symbolQuantityDic = new Dictionary<T, int>();
        private HuffmanTreeNodeComparer<T> nodeComparer;

        /// <summary>
        /// </summary>
        /// <param name="valueComparer">
        /// Comparer used as a last resort to define
        /// relation between two huffman tree nodes. It is used to define the 
        /// relation only if other means based on Quantity and Subtree depth fail.
        /// It should never return 0 (equality) for different elements.
        /// </param>
        /// <param name="terminalSymbol">symbol that means the end of input</param>
        public HuffmanTreeBuilder(IComparer<T> valueComparer, Dictionary<T, int> symbolQuantityDic)
        {
            nodeComparer = new HuffmanTreeNodeComparer<T>(valueComparer);
            this.symbolQuantityDic = symbolQuantityDic;
        }

        /// <summary>
        /// Builds a Huffman tree from symbols that previously were added to this builder.
        /// </summary>
        /// <returns>Huffman tree from this builder.</returns>
        public IHuffmanTreeNode<T> BuildTree()
        {
            var priorityQueue = GetHuffmanNodePriorityQueue();
            if (priorityQueue.Count() < 2)
            {
                throw new Exception("Huffman tree requires at leas two different symbols");
            }
            while (priorityQueue.Count() > 1)
            {
                var first = priorityQueue.DeleteMin();
                var second = priorityQueue.DeleteMin();
                var mergedNode = Merge(first, second);
                priorityQueue.Add(mergedNode);
            }
            return priorityQueue.DeleteMin();
        }

        /// <summary>
        /// </summary>
        /// <returns>An initial priority queue created for building Huffman tree.</returns>
        private IntervalHeap<HuffmanTreeNode<T>> GetHuffmanNodePriorityQueue()
        {
            var priorityQueue = new IntervalHeap<HuffmanTreeNode<T>>(nodeComparer);
            priorityQueue.AddAll(symbolQuantityDic.Select(
                s => new HuffmanTreeNode<T>(
                    value: s.Key,
                    quantity: s.Value
                )
            ));
            return priorityQueue;
        }

        /// <summary>
        /// Merges two huffman tree nodes and creates a new non-leaf node which quantity
        /// is equal to sum of quantities of given nodes.
        /// </summary>
        /// <param name="first">first node to merge</param>
        /// <param name="second">second node to merge</param>
        /// <returns>a node representing a parent of given nodes</returns>
        private HuffmanTreeNode<T> Merge(HuffmanTreeNode<T> left, HuffmanTreeNode<T> right)
        {
            var parent = new HuffmanTreeNode<T>(
                value: left.Value,
                quantity: left.Quantity + right.Quantity,
                subTreeDepth: Math.Max(left.SubTreeDepth, right.SubTreeDepth) + 1
            ) {
                LeftChild = left,
                RightChild = right
            };
            left.Parent = right.Parent = parent;
            return parent;
        }
    }
}