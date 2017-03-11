using HuffmanCoder.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoder.UnitTests.Model.Codec
{
    /// <summary>
    /// Helper class used for quick building mock huffman trees.
    /// </summary>
    internal class MockHuffmanTreeBuilder
    {
        /// <summary>
        /// Builds a tree based on a given definition.
        /// </summary>
        /// <param name="treeDefinition">Definition of the tree based on a list
        /// of characters. a character '#' means an inner node of tree,
        /// and all other characters mean leaf values. Builds a tree
        /// from queue, starts from root then adds two children from definition,
        /// ale repeats the procedure for them if they are not leafs.</param>
        /// <returns>Mock tree.</returns>
        public static IHuffmanTreeNode<char> Build(params char[] treeDefinition)
        {
            Queue<MockHuffmanTreeNode> nodeQueue = new Queue<MockHuffmanTreeNode>();
            var root = new MockHuffmanTreeNode();
            nodeQueue.Enqueue(root);
            for(int i = 0; i < treeDefinition.Length;)
            {
                var parent = nodeQueue.Dequeue();
                var left = new MockHuffmanTreeNode() { Value = treeDefinition[i++] };
                var right = new MockHuffmanTreeNode() { Value = treeDefinition[i++] };
                parent.LeftChild = left;
                parent.RightChild = right;
                left.Parent = parent;
                right.Parent = parent;
                if (left.Value == '#') nodeQueue.Enqueue(left);
                if (right.Value == '#') nodeQueue.Enqueue(right);
            }
            return root;
        }

        private class MockHuffmanTreeNode : IHuffmanTreeNode<char>
        {
            public bool IsLeaf { get { return LeftChild == null && RightChild == null; } }
            public IHuffmanTreeNode<char> LeftChild { get; set; }
            public IHuffmanTreeNode<char> Parent { get; set; }
            public IHuffmanTreeNode<char> RightChild { get; set; }
            public char Value { get; set; }
        }
    }
}
