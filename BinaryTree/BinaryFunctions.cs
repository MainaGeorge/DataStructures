using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    public static class BinaryFunctions
    {
        public static bool AreTwoTreesEqual(Node firstRootNode, Node secondRootNode)
        {
            if (firstRootNode == null && secondRootNode == null)
                return true;
            if (firstRootNode == null || secondRootNode == null)
                return false;

            return firstRootNode.Value == secondRootNode.Value
                   && AreTwoTreesEqual(firstRootNode.LeftChild, secondRootNode.LeftChild)
                   && AreTwoTreesEqual(firstRootNode.RightChild, secondRootNode.RightChild);
        }

        public static Node LowestCommonAncestor(Node rootNode, Node firstChild, Node secondChild)
        {
            if (rootNode == null)
                return null;
            if (rootNode == firstChild || rootNode == secondChild)
                return rootNode;
            var leftAncestor = LowestCommonAncestor(rootNode.LeftChild, firstChild, secondChild);
            var rightAncestor = LowestCommonAncestor(rootNode.RightChild, firstChild, secondChild);

            if (leftAncestor == null && rightAncestor == null)
                return null;
            if (rightAncestor != null && leftAncestor != null)
                return rootNode;
            return rightAncestor ?? leftAncestor;
        }

        public static IList<int> GetMaximumValuesPerLevel(Node rootNode)
        {
            if (rootNode == null)
                return Array.Empty<int>();
            var nodeQueue = new Queue<Node>();
            var resultList = new List<int>();

            nodeQueue.Enqueue(rootNode);

            while (nodeQueue.Any())
            {
                var size = nodeQueue.Count;
                var currentMaxValue = int.MinValue;

                for (var each = 0; each < size; each++)
                {
                    var currentNode = nodeQueue.Dequeue();
                    currentMaxValue = Math.Max(currentMaxValue, currentNode.Value);
                    if (currentNode.LeftChild != null) nodeQueue.Enqueue(currentNode.LeftChild);
                    if (currentNode.RightChild != null) nodeQueue.Enqueue(currentNode.RightChild);
                }

                resultList.Add(currentMaxValue);
            }

            return resultList;
        }

        public static bool IsBinarySearchTree(this Node rootNode, int maxValue, int minValue)
        {
            if (rootNode == null)
                return true;

            if (rootNode.Value == int.MinValue && rootNode.LeftChild != null
                || rootNode.Value == int.MaxValue && rootNode.RightChild != null)
                return false;

            if (rootNode.Value < minValue || rootNode.Value > maxValue)
                return false;

            return IsBinarySearchTree(rootNode.LeftChild, rootNode.Value - 1, minValue)
                   && IsBinarySearchTree(rootNode.RightChild, maxValue, rootNode.Value + 1);

        }

        public static int MinimumDepth(this Node rootNode)
        {
            if (rootNode == null)
                return -1;

            if (rootNode.IsALeafNode())
                return 0;

            var leftLength = 1 + MinimumDepth(rootNode.LeftChild);
            var rightLength = 1 + MinimumDepth(rootNode.RightChild);

            return Math.Min(leftLength, rightLength);

        }

        public static int MinimumDepthWithQueue(this Node root)
        {
            if (root == null)
                return -1;

            var nodeQueue = new Queue<(Node Node, int Depth)>();
            nodeQueue.Enqueue((root, 0));

            while (nodeQueue.Any())
            {
                var (node, depth) = nodeQueue.Dequeue();

                if (node.IsALeafNode())
                    return depth;

                if (node.LeftChild != null) nodeQueue.Enqueue((node.LeftChild, depth + 1));
                if (node.RightChild != null) nodeQueue.Enqueue((node.RightChild, depth + 1));
            }

            return -1;
        }

        public static int MaximumDepth(this Node rootNode)
        {
            if (rootNode == null)
                return -1;
            if (rootNode.IsALeafNode())
                return 0;

            var leftLength = 1 + MaximumDepth(rootNode.LeftChild);
            var rightLength = 1 + MaximumDepth(rootNode.RightChild);

            return Math.Max(leftLength, rightLength);
        }

        public static Node InvertTree(this Node root)
        {
            if (root == null)
                return null;

            var leftSide = root.LeftChild;
            root.LeftChild = root.RightChild;
            root.RightChild = leftSide;

            root.LeftChild = InvertTree(root.LeftChild);
            root.RightChild = InvertTree(root.RightChild);

            return root;
        }
        private static bool IsALeafNode(this Node root)
        {
            return root.LeftChild == null && root.RightChild == null;
        }

        public static IList<IList<int>> ZigZagTraversal(this Node root)
        {
            var result = new List<IList<int>>();

            if (root == null)
                return result;

            var nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(root);

            var leftToRight = false;

            while (nodeQueue.Any())
            {
                var size = nodeQueue.Count;
                var tempResult = new int[size];

                for (var index = 0; index < size; index++)
                {
                    var correctPosition = leftToRight ? index : size - 1 - index;
                    var dequeued = nodeQueue.Dequeue();
                    tempResult[correctPosition] = dequeued.Value;


                    if (dequeued.LeftChild != null) nodeQueue.Enqueue(dequeued.LeftChild);
                    if (dequeued.RightChild != null) nodeQueue.Enqueue(dequeued.RightChild);
                }

                leftToRight = !leftToRight;
                result.Add(tempResult);
            }

            return result;
        }

        public static IList<IList<int>> LevelOrderTraversal(this Node root)
        {
            var result = new List<IList<int>>();

            if (root == null)
                return result;

            var nodeQueue = new Queue<Node>();
            var levelHolder = new List<int>();
            nodeQueue.Enqueue(root);
            nodeQueue.Enqueue(null);

            while (nodeQueue.Any())
            {
                var dequeued = nodeQueue.Dequeue();

                switch (dequeued)
                {
                    case null when nodeQueue.Any():
                        nodeQueue.Enqueue(null);
                        result.Add(new List<int>(levelHolder));
                        levelHolder.Clear();
                        break;

                    case null:
                        result.Add(new List<int>(levelHolder));
                        break;

                    default:
                        levelHolder.Add(dequeued.Value);
                        if (dequeued.LeftChild != null) nodeQueue.Enqueue(dequeued.LeftChild);
                        if (dequeued.RightChild != null) nodeQueue.Enqueue(dequeued.RightChild);
                        break;
                }
            }
            return result;
        }

        public static bool AreSiblings(this Node root, int firstValue, int secondValue)
        {
            if (root == null)
                return false;

            if (root.HasOneChild())
                return false;

            return root.LeftChild.Value == firstValue && root.RightChild.Value == secondValue
                   || root.RightChild.Value == firstValue && root.LeftChild.Value == secondValue
                   || AreSiblings(root.LeftChild, firstValue, secondValue)
                   || AreSiblings(root.RightChild, firstValue, secondValue);


        }

        public static int MinimumValueBinaryTree(this Node root)
        {
            if (root == null)
                return int.MaxValue;

            if (root.IsALeafNode())
                return root.Value;

            var leftSide = MinimumValueBinaryTree(root.LeftChild);
            var rightSide = MinimumValueBinaryTree(root.LeftChild);

            return Math.Min(Math.Min(leftSide, rightSide), root.Value);
        }
        public static int MinimumValueNodeBinarySearchTree(this Node root)
        {
            Node previous = null;
            while (root != null)
            {
                previous = root;
                root = root.LeftChild;
            }

            return previous?.Value ?? -1;
        }
        public static int CountLeaves(this Node root)
        {
            if (root == null)
                return 0;
            if (root.IsALeafNode())
                return 1;
            return CountLeaves(root.LeftChild) + CountLeaves(root.RightChild);
        }
        public static IList<IList<int>> TraverseLevelsReverse(this Node root)
        {
            return ReverseListOfLists(LevelOrderTraversal(root));
        }
        private static IList<IList<int>> ReverseListOfLists(IList<IList<int>> source)
        {
            var leftPointer = 0;
            var rightPointer = source.Count - 1;

            while (leftPointer <= rightPointer)
            {
                var temp = source[leftPointer];
                source[leftPointer++] = source[rightPointer];
                source[rightPointer--] = temp;
            }

            return source;
        }

        private static bool HasOneChild(this Node node)
        {
            return node.LeftChild == null || node.RightChild == null;
        }

    }


}
