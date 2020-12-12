using System;

namespace BinaryTree
{
    public class BinaryTreeImplementation
    {
        private Node RootNode { get; set; }
        public void Insert(int value) => RootNode = Insert(RootNode, value);
        public void InOrder() => InOrder(RootNode);
        private static void InOrder(Node rootNode)
        {
            if (rootNode == null)
                return;
            InOrder(rootNode.LeftChild);
            Console.WriteLine(rootNode.Value);
            InOrder(rootNode.RightChild);
        }
        public int Height() => Height(RootNode);
        private static int Height(Node root)
        {
            if (root == null)
                return -1;
            if (root.LeftChild == null && root.RightChild == null)
                return 0;
            var left = Height(root.LeftChild);
            var right = Height(root.RightChild);

            return 1 + Math.Max(left, right);
        }
        private static Node Insert(Node node, int value)
        {
            if (node == null)
                return new Node(value);

            if (BalanceFactor(node) > 0)
                node.RightChild = Insert(node.RightChild, value);
            else
                node.LeftChild = Insert(node.LeftChild, value);

            return node;
        }
        private static int BalanceFactor(Node root)
        {
            if (root == null)
                return -1;
            if (root.LeftChild == null && root.RightChild == null)
                return 0;
            var leftHeight = 1 + BalanceFactor(root.LeftChild);
            var rightHeight = 1 + BalanceFactor(root.RightChild);

            return leftHeight - rightHeight;
        }
        public bool Contains(int value) => Contains(RootNode, value);
        private static bool Contains(Node root, int value)
        {
            if (root == null)
                return false;
            if (root.Value == value)
                return true;
            return Contains(root.LeftChild, value) || Contains(root.RightChild, value);
        }
        public int MaxValue() => MaxValue(RootNode);
        private static int MaxValue(Node root)
        {
            if (root == null)
                return int.MinValue;
            var leftSide = MaxValue(root.LeftChild);
            var rightSide = MaxValue(root.RightChild);

            return Math.Max(Math.Max(leftSide, rightSide), root.Value);
        }
        public int MinValue() => MinValue(RootNode);
        private static int MinValue(Node root)
        {
            if (root == null)
                return int.MaxValue;
            var leftSide = MaxValue(root.LeftChild);
            var rightSide = MaxValue(root.RightChild);

            return Math.Min(Math.Min(leftSide, rightSide), root.Value);
        }

        public int CountNodes() => CountNodes(RootNode);
        private static int CountNodes(Node root)
        {
            if (root == null)
                return 0;
            var right = CountNodes(root.RightChild);
            var left = CountNodes(root.LeftChild);

            return left + right + 1;
        }

    }
}
