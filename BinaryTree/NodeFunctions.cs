using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    public static class NodeFunctions
    {
        public static Node SecondNode = new Node(5)
        {
            LeftChild = new Node(4)
            {
                LeftChild = new Node(11)
                {
                    RightChild = new Node(7),
                    LeftChild = new Node(2)
                },
            },
            RightChild = new Node(8)
            {
                RightChild = new Node(13),
                LeftChild = new Node(4){LeftChild = new Node(5), RightChild = new Node(1)}
            }
        };
        public static Node FirstNode = new Node(2)
        {
            LeftChild = new Node(3)
            {
                LeftChild = new Node(5)
                {
                    LeftChild = new Node(1)
                },
                RightChild = new Node(4){LeftChild = new Node(2)}
            },
            RightChild = new Node(1)};
        public static Node Node { get; private set; }
        static NodeFunctions()
        {
            Node = new Node(17)
            {
                LeftChild = new Node(13)
                {
                    LeftChild = new Node(10)
                    {
                        LeftChild = new Node(8)
                        {
                            LeftChild = new Node(7)
                            {
                                LeftChild = new Node(6)
                            }
                        },
                        RightChild = new Node(11)
                    },
                    RightChild = new Node(14)
                    {
                        RightChild = new Node(15)
                    }

                },
                RightChild = new Node(20)
                {
                    RightChild = new Node(24)
                    {
                        LeftChild = new Node(22),
                        RightChild = new Node(30)
                    },
                    LeftChild = new Node(18)
                    {
                        RightChild = new Node(19)
                    }
                }

            };
        }
        public static int GetBiggestSum(this Node node)
        {
            var sums = new List<int>();
            const int seedValue = 0;
            if (node == null)
                return 0;
            GetSum(node, seedValue, sums);

            return sums.Max();
        }
        private static void GetSum(this Node node, int sum, IList<int> resultingSums)
        {
            if (node == null)
                return;
            sum =  sum * 10 + node.Value;
            if (node.IsALeafNode())
            {
                resultingSums.Add(sum);
                Console.WriteLine(sum);
            }

            GetSum(node.RightChild, sum, resultingSums);
            GetSum(node.LeftChild, sum, resultingSums);
        }
        public static void PrintPreOrder(this Node node)
        {
            if (node == null)
                return;
            Console.Write(node.Value + " ");
            PrintPreOrder(node.LeftChild);
            PrintPreOrder(node.RightChild);
        }
        public static bool NodesEqual(this Node firstNode, Node secondNode)
        {
            if (firstNode == null && secondNode == null)
                return true;
            if (firstNode == null || secondNode == null)
                return false;
            var currentNodesEqual = firstNode.Value == secondNode.Value;

            return currentNodesEqual &&
                   NodesEqual(firstNode.LeftChild, secondNode.LeftChild) &&
                   NodesEqual(firstNode.RightChild, secondNode.RightChild);
        }
        public static bool AreNodesMirrorImagesOfEachOther(this Node firstNode, Node secondNode)
        {
            if (firstNode == null && secondNode == null)
                return true;
            if (firstNode == null || secondNode == null)
                return false;

            var currentNodesEqual = firstNode.Value == secondNode.Value;

            return currentNodesEqual && AreNodesMirrorImagesOfEachOther(firstNode.LeftChild, secondNode.RightChild)
                                     && AreNodesMirrorImagesOfEachOther(firstNode.RightChild, secondNode.LeftChild);
        }
        public static int Height(this Node node)
        {
            if (node == null)
                return -1;

            if (IsALeafNode(node))
                return 0;

            var rightHeight = 1 + Height(node.RightChild);
            var leftHeight = 1 + Height(node.LeftChild);
            return Math.Max(leftHeight, rightHeight);
        }
        public static IEnumerable<int> GetNodesAtHeightK(this Node node, int height)
        {
            var nodesAtDepthK = new List<int>();
            GetNodesAtHeightK(node, height, nodesAtDepthK);

            return nodesAtDepthK;
        }
        private static void GetNodesAtHeightK(this Node node, int height, ICollection<int> valueKeeper)
        {
            if (node == null || height < 0)
                return;

            if (height == 0)
                valueKeeper.Add(node.Value);

            GetNodesAtHeightK(node.RightChild, height - 1, valueKeeper);
            GetNodesAtHeightK(node.LeftChild, height - 1, valueKeeper);
        }
        private static bool IsALeafNode(this Node node)
        {
            return node.RightChild == null && node.LeftChild == null;
        }
        private static bool HasTwoChildren(Node node)
        {
            return node.RightChild != null && node.LeftChild != null;
        }
        public static void PrintDepthFirst(this Node node)
        {
            for (var index = 0; index <= Height(node); index++)
            {
                Console.WriteLine(string.Join(" ", node.GetNodesAtHeightK(index)));
            }
        }
        public static bool IsABalancedTree(this Node node)
        {
            if (node == null || node.IsALeafNode())
                return true;

            var leftHeight = node.LeftChild.Height();
            var rightHeight = node.RightChild.Height();

            if (node.HasOneChild())
                return Math.Abs(leftHeight - rightHeight) <= 1;
            var leftSubTree = node.LeftChild;
            var rightSubTree = node.RightChild;

            return Math.Abs(leftHeight - rightHeight) <= 1
                   && IsABalancedTree(leftSubTree.LeftChild)
                   && IsABalancedTree(leftSubTree.RightChild)
                   && IsABalancedTree(rightSubTree.LeftChild)
                   && IsABalancedTree(rightSubTree.RightChild);
        }
        public static bool IsABinarySearchTree(this Node root)
        {
            return root != null && IsABinarySearchTree(root, int.MaxValue, int.MinValue);
        }
        public static bool IsAMirrorOfItself(this Node node)
        {
            if (node == null || node.IsALeafNode())
                return true;
            return NodesMirrorEachOther(node.LeftChild, node.RightChild);
        }
        private static bool NodesMirrorEachOther(this Node first, Node second)
        {
            if (first == null && second == null)
                return true;
            if (first == null || second == null)
                return false;
            return first.Value == second.Value
                   && NodesMirrorEachOther(first.LeftChild, second.RightChild)
                   && NodesMirrorEachOther(first.RightChild, second.LeftChild);
        }
        private static bool HasOneChild(this Node node)
        {
            return node.LeftChild == null || node.RightChild == null;
        }
        private static bool IsABinarySearchTree(this Node node, int maxValue, int minValue)
        {
            if (node == null)
                return true;
            if (node.Value < minValue || node.Value > maxValue)
                return false;
            return IsABinarySearchTree(node.LeftChild, node.Value - 1, minValue)
                   && IsABinarySearchTree(node.RightChild, maxValue, node.Value + 1);
        }
        public static bool ContainsPathLeadingToGivenSum(this Node node, int givenSum, int currentSum = 0)
        {
            if (node == null)
                return false;
            currentSum += node.Value;
            if (node.IsALeafNode() && currentSum == givenSum)
                return true;
            return ContainsPathLeadingToGivenSum(node.LeftChild, givenSum, currentSum) ||
                   ContainsPathLeadingToGivenSum(node.RightChild, givenSum, currentSum);
        }
        public static Node CommonAncestorsOfTwoNodes(this Node node, int firstValue, int secondValue)
        {
            if (node == null)
                return null;
            if (node.Value == firstValue || node.Value == secondValue)
                return node;
            var leftAncestor = CommonAncestorsOfTwoNodes(node.LeftChild, firstValue, secondValue);
            var rightAncestor = CommonAncestorsOfTwoNodes(node.RightChild, firstValue, secondValue);

            if (rightAncestor == null && leftAncestor == null)
                return null;
            if (rightAncestor != null && leftAncestor != null)
                return node;
            return rightAncestor ?? leftAncestor;
        }
        public static int MaximumSumThroughTheRootNode(this Node node) => MaximumSumThroughTheRootNode(node, 0);
        private static int MaximumSumThroughTheRootNode(this Node node,  int currentNodeSum)
        {
            if (node == null)
                return currentNodeSum;
            if (IsALeafNode(node))
                return Math.Max(currentNodeSum, currentNodeSum + node.Value);
            currentNodeSum += node.Value;
            return Math.Max(MaximumSumThroughTheRootNode(node.RightChild, currentNodeSum),
                MaximumSumThroughTheRootNode(node.LeftChild, currentNodeSum));
        }
        public static int MaximumPathSumStartingAtAnyNode(this Node node)
        {
            var maxSum = 0;
            MaximumPathSumStartingAtAnyNode(node, 0,  ref maxSum);
            return maxSum;
        }
        private static int MaximumPathSumStartingAtAnyNode(this Node node, int straightPathSum,
            ref int ifCurrentNodeWasMadeRootSum)
        {
            if (node == null)
                return 0;
            if (IsALeafNode(node))
                return node.Value;

            var leftSum = MaximumPathSumStartingAtAnyNode(node.LeftChild, straightPathSum, ref ifCurrentNodeWasMadeRootSum);
            var rightSum = MaximumPathSumStartingAtAnyNode(node.RightChild, straightPathSum, ref ifCurrentNodeWasMadeRootSum);

            var largerChildSum = Math.Max(leftSum, rightSum);
            straightPathSum = Math.Max(Math.Max(node.Value, largerChildSum), straightPathSum);
            ifCurrentNodeWasMadeRootSum = Math.Max(Math.Max(straightPathSum, leftSum + rightSum + node.Value),
                ifCurrentNodeWasMadeRootSum);

            //always return the maximum straight path sum i.e max of (leftsum+node.value, rightsum+node.value, node.value) connects the previous node to next in a straight line
            return Math.Max(node.Value, largerChildSum + node.Value);

        }
        public static int GetDiameterOfBinaryTree(this Node node)
        {
            var diameter = 0;
            GetDiameterOfBinaryTree(node, ref diameter);
            return diameter;
        }
        private static int GetDiameterOfBinaryTree(this Node node, ref int currentBiggestNumberOfNodes)
        {
            if (node == null)
                return 0;
            if (IsALeafNode(node))
                return 1;
            var leftNodes =  GetDiameterOfBinaryTree(node.LeftChild, ref currentBiggestNumberOfNodes);
            var rightNodes = GetDiameterOfBinaryTree(node.RightChild, ref currentBiggestNumberOfNodes);

            currentBiggestNumberOfNodes = Math.Max(currentBiggestNumberOfNodes, leftNodes + rightNodes + 1);
            return 1 + Math.Max(leftNodes, rightNodes);
        }

        public static void GetPathSums(this Node node, int givenSum, int currentSum=0)
        {
            if (node == null)
                return;
            currentSum += node.Value;
            Console.WriteLine("the current sum is " + currentSum);
            if(IsALeafNode(node) && givenSum == currentSum)
                Console.WriteLine(node.Value + " is the current node " + currentSum);
            GetPathSums(node.RightChild, givenSum, currentSum);
            GetPathSums(node.LeftChild, givenSum, currentSum);
        }

        public static IList<List<int>> GetPaths(this Node node, int sum)
        {
            const int currentSum = 0;
            var holder = new List<List<int>>();
            var numbers = new List<int>();
            GetPaths(node, sum, currentSum, numbers, holder);

            return holder;
        }

        private static void GetPaths(this Node node, int sum, int currentSum, IList<int> numbers, IList<List<int>> holder)
        {
            if(node == null)
                return;
            currentSum += node.Value;
            numbers.Add(node.Value);
            if (node.IsALeafNode() && currentSum == sum)
            {
                Console.WriteLine($"the sum here is {currentSum} --> {node.Value} --> {string.Join(" ",numbers)}");
                holder.Add(new List<int>(numbers));
                numbers.RemoveAt(numbers.Count-1);
                return;
            }
            GetPaths(node.LeftChild, sum, currentSum,numbers, holder);
            GetPaths(node.RightChild, sum, currentSum,numbers, holder);
            numbers.RemoveAt(numbers.Count-1);

        }

        public static void InOrderTraversal(this Node root)
        {
            if (root == null) return;

            InOrderTraversal(root.LeftChild);
            Console.WriteLine(root.Value);
            InOrderTraversal(root.RightChild);
        }
    }
}
