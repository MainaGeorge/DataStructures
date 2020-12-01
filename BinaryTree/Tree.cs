using System.Collections.Generic;

namespace BinaryTree
{
    public class Tree
    {
        private Node _root;
        public Tree()
        {
        }
        public Tree(int value)
        {
            _root = new Node(value);
        }
        public void Insert(int value) => _root = Insert(_root, value);
        private static Node Insert(Node root, int value)
        {
            if (root == null)
                root = new Node(value);
            else if (value > root.Value)
                root.RightChild = Insert(root.RightChild, value);
            else if (value < root.Value)
                root.LeftChild = Insert(root.LeftChild, value);

            return root;
        }
        public int MinimumDepth => _root.MinimumDepth();
        public int MinimumDepthWithQueue => _root.MinimumDepthWithQueue();
        public bool IsValidBst() => _root.IsBinarySearchTree(int.MaxValue, int.MinValue);
        public IList<int> GetMaxValuesPerLevel() => BinaryFunctions.GetMaximumValuesPerLevel(_root);
        public IList<IList<int>> TraverseLevelWise() => _root.LevelOrderTraversal();
        public IList<IList<int>> ReverseTraverseLevelWise() => _root.TraverseLevelsReverse();
        public void TraverseInOrder() => _root.InOrderTraversal();
        public IList<IList<int>> ZigZagTraversal() => _root.ZigZagTraversal();
        public void InvertTree() => _root = _root.InvertTree();
        public int MaximumDepth => _root.MaximumDepth();
        public int MinimumNodeValue() => IsValidBst() ? _root.MinimumValueNodeBinarySearchTree() : _root.MinimumValueBinaryTree();
        public int CountLeaves => _root.CountLeaves();
        public bool AreSiblings(int firstValue, int secondValue) => _root.AreSiblings(firstValue, secondValue);
    }
}
