using System;
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
        public List<List<int>> GetPathsToRoot()
        {
            var res = new List<List<int>>();
            var temp = new List<int>();

            GetPathsToRoot(_root, res, temp);

            return res;
        }
        public bool ContainsPathLeadingToGivenSum(int givenSum)
        {
            return ContainsPathLeadingToGivenSum(_root, givenSum, 0);
        }
        public int CountNodes() => CountNodes(_root);
        public int MaximumSumThroughRoot() => MaximumSumThroughRoot(_root, 0);
        public int MaximumSumThroughAnyRoot()
        {
            var maxSum = 0;
            const int currentSum = 0;
            MaximumSumThroughAnyRoot(_root, currentSum, ref maxSum);

            return maxSum;
        }
        public int TreeDiameter()
        {
            var cyclicDiameter = 0;
            const int straightPathDiameter = 0;
            TreeDiameter(_root, straightPathDiameter, ref cyclicDiameter);
            return cyclicDiameter;
        }
        public Node GetAncestor(int firstElement, int secondElement) =>
            AncestorNode(_root, firstElement, secondElement);
        public IList<int> GetNOdesAtGivenHeight(int height)
        {
            var nodes = new List<int>();
            GetNodesAtGivenHeight(_root, height, nodes);

            return nodes;
        }
        private static Node AncestorNode(Node root, int firstMember, int secondMember)
        {
            if (root == null)
                return null;
            if (root.Value == firstMember || root.Value == secondMember)
                return root;
            var leftAncestor = AncestorNode(root.LeftChild, firstMember, secondMember);
            var rightAncestor = AncestorNode(root.RightChild, firstMember, secondMember);

            if (leftAncestor != null && rightAncestor != null)
                return root;
            if (leftAncestor == null && rightAncestor == null)
                return null;
            return rightAncestor ?? leftAncestor;

        }
        private static int TreeDiameter(Node root, int straightPathDiameter, ref int cyclicDiameter)
        {
            if (root == null)
                return 0;
            if (IsALeafNode(root))
                return 1;
            var leftDiameter = TreeDiameter(root.LeftChild, straightPathDiameter, ref cyclicDiameter);
            var rightDiameter = TreeDiameter(root.RightChild, straightPathDiameter, ref cyclicDiameter);

            var cyclic = rightDiameter + leftDiameter;
            straightPathDiameter = Math.Max(Math.Max(leftDiameter, rightDiameter), straightPathDiameter);
            cyclicDiameter = Math.Max(Math.Max(cyclic, cyclicDiameter), straightPathDiameter);

            return Math.Max(rightDiameter, leftDiameter) + 1;
        }
        private static int MaximumSumThroughAnyRoot(Node root, int currentSum, ref int maximumSum)
        {
            if (root == null)
                return 0;
            if (IsALeafNode(root))
                return root.Value;
            var leftSum = MaximumSumThroughAnyRoot(root.LeftChild, currentSum, ref maximumSum);
            var rightSum = MaximumSumThroughAnyRoot(root.RightChild, currentSum, ref maximumSum);

            var maxSumPath = Math.Max(Math.Max(leftSum, rightSum), root.Value);
            var cyclicPath = leftSum + rightSum + root.Value;

            currentSum = Math.Max(maxSumPath, currentSum);
            maximumSum = Math.Max(Math.Max(maximumSum, currentSum), cyclicPath);

            Console.WriteLine(maximumSum);
            //return the max path, root + left or root + right or root to connect the tree for the recursion
            return Math.Max(Math.Max(leftSum + root.Value, rightSum + root.Value), root.Value);
        }
        private static int MaximumSumThroughRoot(Node root, int currentSum)
        {
            if (root == null)
                return currentSum;

            if (IsALeafNode(root))
                return Math.Max(currentSum, currentSum + root.Value);

            currentSum += root.Value;

            var leftSum = MaximumSumThroughRoot(root.LeftChild, currentSum);
            var rightSum = MaximumSumThroughRoot(root.RightChild, currentSum);

            return Math.Max(leftSum, rightSum);
        }
        private static int CountNodes(Node root)
        {
            if (root == null)
                return 0;
            return 1 + CountNodes(root.LeftChild) + CountNodes(root.RightChild);
        }
        private static bool ContainsPathLeadingToGivenSum(Node root, int givenSum, int currentSum)
        {
            if (root == null)
                return false;
            currentSum += root.Value;

            if (IsALeafNode(root) && currentSum == givenSum)
                return true;
            return ContainsPathLeadingToGivenSum(root.LeftChild, givenSum, currentSum) ||
                   ContainsPathLeadingToGivenSum(root.RightChild, givenSum, currentSum);
        }
        private static void GetPathsToRoot(Node root, List<List<int>> holder, List<int> temp)
        {
            if (root == null)
                return;
            temp.Add(root.Value);
            if (IsALeafNode(root))
                holder.Add(new List<int>(temp));

            GetPathsToRoot(root.LeftChild, holder, temp);
            GetPathsToRoot(root.RightChild, holder, temp);

            temp.RemoveAt(temp.Count - 1);
        }
        private static bool IsALeafNode(Node node) => node.LeftChild == null && node.RightChild == null;
        private static void GetNodesAtGivenHeight(Node root, int height, IList<int> nodes)
        {
            if (root == null)
                return;

            if(height == 0)
                nodes.Add(root.Value);

            GetNodesAtGivenHeight(root.LeftChild, height-1, nodes);
            GetNodesAtGivenHeight(root.RightChild, height-1, nodes);

        }
    }
}
