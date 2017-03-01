using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Tree;
using C5;
using HuffmanCoder.Model.Codec;

namespace HuffmanCoder.Model.Builder
{
    /// <summary>
    /// Class used for building a huffman tree. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HuffmanCodecBuilder<T> : IHuffmanCodecBuilder<T>
    {
        private const int LEAF_SUB_TREE_DEPTH = 0;

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
        public HuffmanCodecBuilder(IComparer<T> valueComparer)
        {
            this.nodeComparer = new HuffmanTreeNodeComparer<T>(valueComparer);
        }

        /// <summary>
        /// Adds a symbol occurence to this builder.
        /// </summary>
        /// <param name="symbol">Symbol that occured.</param>
        public void Add(T symbol)
        {
            Add(symbol, 1);
        }

        /// <summary>
        /// Adds a specified amount of occurences of a symbol to this builder.
        /// </summary>
        /// <param name="symbol">symbol that occured.</param>
        /// <param name="quantity">numer of times it occured.</param>
        public void Add(T symbol, int quantity)
        {
            if (symbolQuantityDic.ContainsKey(symbol))
            {
                symbolQuantityDic[symbol] += quantity;
            }
            else
            {
                symbolQuantityDic.Add(symbol, quantity);
            }
        }

        /// <summary>
        /// Returns coder that represents state of this builder.
        /// </summary>
        /// <returns>Coder</returns>
        public IHuffmanCoder<T> GetCoder()
        {
            return new HuffmanCoder<T>(BuildTree());
        }

        /// <summary>
        /// Returns decoder that represents state of this builder.
        /// </summary>
        /// <returns>Decoder</returns>
        public IHuffmanDecoder<T> GetDecoder()
        {
            return new HuffmanDecoder<T>(BuildTree());
        }

        /// <summary>
        /// Builds a Huffman tree from symbols that previously were added to this builder.
        /// </summary>
        /// <returns>Huffman tree from this builder.</returns>
        private HuffmanTree<T> BuildTree()
        {
            var priorityQueue = GetHuffmanNodePriorityQueue();
            if (priorityQueue.Count() == 0)
            {
                throw new Exception("Cannot build an empty Hufffman tree");
            }
            while (priorityQueue.Count() > 1)
            {
                var first = priorityQueue.DeleteMax();
                var second = priorityQueue.DeleteMax();
                var mergedNode = Merge(first, second);
                priorityQueue.Add(mergedNode);

            }
            return new HuffmanTree<T>(priorityQueue.DeleteMax());
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
                    quantity: s.Value,
                    subTreeDepth: LEAF_SUB_TREE_DEPTH
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