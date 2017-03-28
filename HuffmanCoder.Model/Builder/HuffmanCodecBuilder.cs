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
    public class HuffmanCodecBuilder<T>
    {
        /// <summary>
        /// Builds a Huffman tree based on symbols quantity dictionary.
        /// </summary>
        /// <param name="valueComparer">
        /// Comparer used as a last resort to define
        /// relation between two huffman tree nodes. It is used to define the 
        /// relation only if other means based on Quantity and Subtree depth fail.
        /// It should never return 0 (equality) for different elements.
        /// </param>
        /// <param name="symbolQuantityDic">dicrionary containing quantity
        /// of symbol occurences for this tree to build.</param>
        /// <returns>Huffman tree.</returns>
        public IHuffmanTreeNode<T> BuildTree(IComparer<T> valueComparer, Dictionary<T, int> symbolQuantityDic)
        {
            var nodeComparer = new HuffmanTreeNodeComparer<T>(valueComparer);
            if(symbolQuantityDic.Keys.Count == 0)
            {
                throw new Exception("This builder requires at least one symbol in quantity dictionary.");
            }
            if (symbolQuantityDic.Keys.Count == 1)
            {
                var only = symbolQuantityDic.Keys.First();
                return new HuffmanTreeNode<T>(
                    value: only,
                    quantity: 1);
            }
            var priorityQueue = GetHuffmanNodePriorityQueue(nodeComparer, symbolQuantityDic);
            while (priorityQueue.Count() > 1)
            {
                var first = priorityQueue.DeleteMin();
                var second = priorityQueue.DeleteMin();
                var mergedNode = Merge(first, second);
                priorityQueue.Add(mergedNode);
            }
            return priorityQueue.DeleteMin();
        }

        public ICoder<T> GetCoder(IHuffmanTreeNode<T> root)
        {
            if(root.IsLeaf)
            {
                return new OneSymbolCoder<T>(root.Value);
            }
            return new HuffmanCoder<T>(root);
        }

        public IDecoder<T> GetDecoder(IHuffmanTreeNode<T> root)
        {
            if(root.IsLeaf)
            {
                return new OneSymbolDecoder<T>(root.Value);
            }
            return new HuffmanDecoder<T>(root);
        }

        /// <summary>
        /// </summary>
        /// <returns>An initial priority queue created for building Huffman tree.</returns>
        private IntervalHeap<HuffmanTreeNode<T>> GetHuffmanNodePriorityQueue(
            HuffmanTreeNodeComparer<T> nodeComparer, Dictionary<T, int> symbolQuantityDic)
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