using HuffmanCoder.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.Model.Builder.FromEncoding
{
    /// <summary>
    /// Class used for building a Huffman tree based on the already
    /// existing encoding of symbols.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class EncHuffmanTreeBuilder<T> : IHuffmanTreeBuilder<T>
    {
        private Dictionary<T, bool[]> encodingDictionary;

        public EncHuffmanTreeBuilder(Dictionary<T, bool[]> encodingDictionary)
        {
            this.encodingDictionary = encodingDictionary;
        }

        /// <summary>
        /// Builds a tree based on the encoding table specified in this object.
        /// </summary>
        /// <returns>A huffman tree</returns>
        public IHuffmanTreeNode<T> BuildTree()
        {
            if(encodingDictionary.Count < 2)
            {
                throw new Exception("Huffman tree requires at least two different symbols.");
            }
            var root = new EncHuffmanTreeNode<T>();
            foreach(var encDicEntry in encodingDictionary)
            {
                BuildPath(encDicEntry.Key, encDicEntry.Value, root);
            }
            AssertIsCompleteTree(root);
            return root;
        }

        /// <summary>
        /// Recursivly builds nodes in a tree that are on a path to a specified symbol encoding.
        /// </summary>
        /// <param name="symbol">Symbol for encoding</param>
        /// <param name="encoding">Encoding of the symbol</param>
        /// <param name="node">Root node of the tree</param>
        private void BuildPath(T symbol, bool[] encoding, EncHuffmanTreeNode<T> node)
        {
            for (var i = 0; i < encoding.Length; ++i)
            {
                node = GetNode(encoding[i], node);
            }
            assertIsNotAssignedValue(node);
            node.Value = symbol;
        }

        /// <summary>
        /// Gets a node that is a child of a specified node and is on a path of given bit.
        /// </summary>
        /// <param name="bit">If left or right child should be chosen</param>
        /// <param name="node">Node which left or right child will be chosen</param>
        /// <returns>A child node</returns>
        private EncHuffmanTreeNode<T> GetNode(bool bit, EncHuffmanTreeNode<T> node)
        {
            assertIsNotAssignedValue(node);
            if (bit)
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new EncHuffmanTreeNode<T>();
                    node.RightChild.Parent = node;
                }
                return node.RightChild;
            }
            else
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new EncHuffmanTreeNode<T>();
                    node.LeftChild.Parent = node;
                }
                return node.LeftChild;
            }
        }

        private static void assertIsNotAssignedValue(EncHuffmanTreeNode<T> node)
        {
            if (node.IsAssignedValue)
            {
                throw CannotBuildTreeException();
            }
        }

        /// <summary>
        /// Recursivly asserts that each node of this tree is correct.
        /// </summary>
        /// <param name="node">Start node of a subtree</param>
        private static void AssertIsCompleteTree(EncHuffmanTreeNode<T> node)
        {
            if(node == null 
                || (node.IsLeaf && !node.IsAssignedValue)
                || (!node.IsLeaf && node.IsAssignedValue))
            {
                throw CannotBuildTreeException();
            }
            if(!node.IsLeaf)
            {
                AssertIsCompleteTree(node.LeftChild);
                AssertIsCompleteTree(node.RightChild);
            }
        }

        private static Exception CannotBuildTreeException()
        {
            return new Exception("Malformed encoding data, cannot build tree");
        }
    }
}
