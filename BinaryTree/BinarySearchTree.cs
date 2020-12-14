using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinarySearchTree
    {
        private Node _root;
        public BinarySearchTree()
        {
        }
        public BinarySearchTree(int value)
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
        public ICollection<int> GetMaxValuesPerLevel() => BinaryFunctions.GetMaximumValuesPerLevel(_root);
        public ICollection<IList<int>> TraverseLevelWise() => _root.LevelOrderTraversal();
        public ICollection<IList<int>> ReverseTraverseLevelWise() => _root.TraverseLevelsReverse();
        public ICollection<int> TraversePreOrder()
        {
            var nodes = new List<int>();
            PreOrderTraversal(_root, nodes);
            return nodes;
        }
        public bool Contains(int value) => Contains(_root, value);
        public ICollection<int> TraverseInOrder()
        {
            var nodes = new List<int>();
            InOrderTraversal(_root, nodes);

            return nodes;
        }
        public ICollection<int> TraversePostOrder()
        {
            var nodes = new List<int>();
            PostOrder(_root, nodes);
            return nodes;
        }
        public ICollection<IList<int>> ZigZagTraversal() => _root.ZigZagTraversal();
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
        public Node GetLowestCommonAncestor(int firstElement, int secondElement) =>
            GetLowestCommonAncestor(_root, firstElement, secondElement);
        public ICollection<int> GetNOdesAtGivenHeight(int height)
        {
            var nodes = new List<int>();
            GetNodesAtGivenHeight(_root, height, nodes);

            return nodes;
        }
        public Node GetParent(int value) => GetParent(_root, value);
        public void Delete(int value) => Delete(_root, value);
        private static Node GetLowestCommonAncestor(Node root, int firstMember, int secondMember)
        {
            if (root == null)
                return null;
            if (root.Value == firstMember || root.Value == secondMember)
                return root;
            var leftAncestor = GetLowestCommonAncestor(root.LeftChild, firstMember, secondMember);
            var rightAncestor = GetLowestCommonAncestor(root.RightChild, firstMember, secondMember);

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
        private static void GetPathsToRoot(Node root, ICollection<List<int>> holder, IList<int> temp)
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
        private static void GetNodesAtGivenHeight(Node root, int height, ICollection<int> nodes)
        {
            if (root == null)
                return;

            if (height == 0)
                nodes.Add(root.Value);

            GetNodesAtGivenHeight(root.LeftChild, height - 1, nodes);
            GetNodesAtGivenHeight(root.RightChild, height - 1, nodes);

        }
        private static void InOrderTraversal(Node root, ICollection<int> nodes)
        {
            if (root == null)
                return;
            InOrderTraversal(root.LeftChild, nodes);
            nodes.Add(root.Value);
            InOrderTraversal(root.RightChild, nodes);
        }
        private static void PreOrderTraversal(Node root, ICollection<int> nodes)
        {
            if (root == null)
                return;

            nodes.Add(root.Value);
            PreOrderTraversal(root.LeftChild, nodes);
            PreOrderTraversal(root.RightChild, nodes);
        }
        private static void PostOrder(Node root, ICollection<int> nodes)
        {
            if (root == null)
                return;
            PostOrder(root.LeftChild, nodes);
            PostOrder(root.RightChild, nodes);

            nodes.Add(root.Value);
        }
        private static bool Contains(Node root, int value)
        {
            if (root == null)
                return false;
            var appropriateRoot = value > root.Value ? root.RightChild : root.LeftChild;

            return root.Value == value || Contains(appropriateRoot, value);
        }
        private static Node GetParent(Node root, int value)
        {
            if (root == null)
                return null;

            if (IsALeafNode(root))
                return null;

            if (root.Value == value)
                return root;

            if (value > root.Value && root.RightChild?.Value == value)
                return root;

            if (value < root.Value && root.LeftChild?.Value == value)
                return root;

            var appropriateNode = value > root.Value ? root.RightChild : root.LeftChild;
            return GetParent(appropriateNode, value);

        }
        private static void Delete(Node root, int value)
        {
            var parentNode = GetParent(root, value);

            if (parentNode == null)
                return;

            var nodeToBeDeleted =
                parentNode == root && value == root.Value ? root : GetNodeToBeDeleted(parentNode, value);

            if (IsALeafNode(nodeToBeDeleted))
                DeleteLeafNode(parentNode, nodeToBeDeleted);

            else if (HasBothLeftAndRightSubTrees(nodeToBeDeleted))
                DeleteNodeWithTwoSubTrees(nodeToBeDeleted);

            else if (RightChildIsNotNull(root))
                DeleteNodeWithRightChild(parentNode, nodeToBeDeleted);

            else
                DeleteNodeWithLeftChild(parentNode, nodeToBeDeleted);
        }
        private static bool RightChildIsNotNull(Node root) => root.RightChild != null;
        private static bool HasBothLeftAndRightSubTrees(Node root) => root.RightChild != null && root.LeftChild != null;
        private static void DeleteNodeWithLeftChild(Node parentNode, Node nodeToBeDeleted)
        {
            if (nodeToBeDeleted.Value > parentNode.Value)
                parentNode.RightChild = nodeToBeDeleted.LeftChild;
            else
                parentNode.LeftChild = nodeToBeDeleted.LeftChild;
        }
        private static void DeleteNodeWithRightChild(Node parentNode, Node nodeToBeDeleted)
        {
            if (nodeToBeDeleted.Value > parentNode.Value)
                parentNode.RightChild = nodeToBeDeleted.RightChild;
            else
                parentNode.LeftChild = nodeToBeDeleted.RightChild;
        }
        private static void DeleteLeafNode(Node parentNode, Node nodeToBeDeleted)
        {
            if (nodeToBeDeleted.Value > parentNode.Value)
                parentNode.RightChild = null;
            else
                parentNode.LeftChild = null;
        }
        private static Node GetNodeToBeDeleted(Node parent, int value)
        {
            return value > parent.Value ? parent.RightChild : parent.LeftChild;
        }
        private static void DeleteNodeWithTwoSubTrees(Node nodeToBeDeleted)
        {
            var toReplace = nodeToBeDeleted.RightChild;
            Node parentOfToReplace = null;
            var ifHasHimselfAsParent = toReplace.RightChild;

            while (toReplace.LeftChild != null)
            {
                parentOfToReplace = toReplace;
                toReplace = toReplace.LeftChild;
            }

            if (parentOfToReplace != null)
                parentOfToReplace.LeftChild = toReplace.RightChild;
            else
                nodeToBeDeleted.RightChild = ifHasHimselfAsParent;

            nodeToBeDeleted.Value = toReplace.Value;
        }
    }
}
