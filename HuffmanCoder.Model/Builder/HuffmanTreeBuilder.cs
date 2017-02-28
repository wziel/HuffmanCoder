using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuffmanCoder.Model.Tree;
using C5;

namespace HuffmanCoder.Model.Builder
{
    public class HuffmanTreeBuilder<T> : IHuffmanTreeBuilder<T>
    {
        private Dictionary<T, int> symbolOccurenceCounterDic = new Dictionary<T, int>();

        /// <summary>
        /// Adds a symbol occurence to this builder.
        /// </summary>
        /// <param name="symbol">Symbol that occured.</param>
        public void Add(T symbol)
        {
            if (symbolOccurenceCounterDic.ContainsKey(symbol))
            {
                symbolOccurenceCounterDic[symbol]++;
            }
            else
            {
                symbolOccurenceCounterDic.Add(symbol, 1);
            }
        }

        /// <summary>
        /// Builds a Huffman tree from symbols that previously were added to this builder.
        /// </summary>
        /// <returns>Huffman tree from this builder.</returns>
        public IHuffmanTree<T> Build()
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
            var priorityQueue = new IntervalHeap<HuffmanTreeNode<T>>(
                Comparer<HuffmanTreeNode<T>>.Create((x, y) => x.Probability - y.Probability));
            priorityQueue.AddAll(symbolOccurenceCounterDic.Select(s => new HuffmanTreeNode<T>()
            {
                Value = s.Key,
                Probability = s.Value,
                IsLeaf = true
            }));
            return priorityQueue;
        }

        /// <summary>
        /// Merges two huffman tree nodes and creates a new non-leaf node which probability
        /// is equal to sum of probabilities of given nodes.
        /// </summary>
        /// <param name="first">first node to merge</param>
        /// <param name="second">second node to merge</param>
        /// <returns>a node representing a parent of given nodes</returns>
        private HuffmanTreeNode<T> Merge(HuffmanTreeNode<T> first, HuffmanTreeNode<T> second)
        {
            return new HuffmanTreeNode<T>()
            {
                Probability = first.Probability + second.Probability,
                IsLeaf = false,
            };
        }
    }
}
