using BinaryTree;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void Tree_CanStartWithARootNode()
        {
            var tree = new BinarySearchTree(10);
            Assert.Equal(1, tree.CountNodes());
        }
        [Fact]
        public void Tree_CanStartWithoutARootNode()
        {
            var tree = new BinarySearchTree();
            Assert.Equal(0, tree.CountNodes());
        }

        [Fact]
        public void Tree_AddsNodesCorrectly()
        {
            var tree = new BinarySearchTree();
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(10);

            Assert.Equal(new List<int>() { 20 }, tree.GetNOdesAtGivenHeight(0));
            Assert.Equal(1, tree.MaximumDepth);
        }
        [Fact]
        public void Tree_ReturnTrueIfContainsValue()
        {
            var tree = new BinarySearchTree();
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(10);

            Assert.True(tree.Contains(30));
            Assert.True(tree.Contains(10));
        }
        [Fact]
        public void Tree_ReturnFalseIfDoesntContainsValue()
        {
            var tree = new BinarySearchTree();
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(10);

            Assert.False(tree.Contains(130));
            Assert.False(tree.Contains(110));
        }

        [Fact]
        public void Tree_CanNotInsertDuplicateValues()
        {
            var tree = new BinarySearchTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(20);

            Assert.Equal(2, tree.CountNodes());
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithParents), MemberType = typeof(TreeData))]
        public void Tree_CanCalculateParentNode(BinarySearchTree tree, int childNodeValue, int parentNodeValue)
        {
            Assert.Equal(parentNodeValue, tree.GetParent(childNodeValue)?.Value);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMaximumHeights), MemberType = typeof(TreeData))]
        public void Tree_CalculatesCorrectMaximumHeight(BinarySearchTree binarySearchTree, int height)
        {
            Assert.Equal(height, binarySearchTree.MaximumDepth);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMinimumHeights), MemberType = typeof(TreeData))]
        public void Tree_CalculatesCorrectMinimumHeight(BinarySearchTree binarySearchTree, int height)
        {
            Assert.Equal(height, binarySearchTree.MinimumDepth);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMinimumHeights), MemberType = typeof(TreeData))]
        public void Tree_CalculatesCorrectMinimumHeightUsingQueue(BinarySearchTree binarySearchTree, int height)
        {
            Assert.Equal(height, binarySearchTree.MinimumDepthWithQueue);
        }

        [Theory]
        [MemberData(nameof(TreeData.IsValidBst), MemberType = typeof(TreeData))]
        public void Tree_AlwaysBuildsABst(BinarySearchTree binarySearchTree)
        {
            Assert.True(binarySearchTree.IsValidBst());
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMaxNodesPerLevel), MemberType = typeof(TreeData))]
        public void Tree_CanGetMaxValuesPerLevel(BinarySearchTree binarySearchTree, int[] maxValuesArray)
        {
            Assert.Equal(binarySearchTree.GetMaxValuesPerLevel(), maxValuesArray);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMinNodeValue), MemberType = typeof(TreeData))]
        public void Tree_CanGetMinimumNodeValue(BinarySearchTree binarySearchTree, int expectedValue)
        {
            Assert.Equal(binarySearchTree.MinimumNodeValue(), expectedValue);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithNumberOfLeaves), MemberType = typeof(TreeData))]
        public void Tree_CanCountNumberOfLeafNodes(BinarySearchTree binarySearchTree, int leafNodes)
        {
            Assert.Equal(binarySearchTree.CountLeaves, leafNodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithSiblingNodes), MemberType = typeof(TreeData))]
        public void Tree_CanDetermineIfMembersAreSiblings(BinarySearchTree binarySearchTree, int firstSibling, int secondSibling,
            bool areSiblings)
        {
            Assert.Equal(binarySearchTree.AreSiblings(firstSibling, secondSibling), areSiblings);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithPathsToRoot), MemberType = typeof(TreeData))]
        public void Tree_CanReturnPathsToLeafNodes(BinarySearchTree binarySearchTree, List<List<int>> paths)
        {
            Assert.Equal(binarySearchTree.GetPathsToRoot().Count, paths.Count);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithPossibleSum), MemberType = typeof(TreeData))]
        public void Tree_ReturnCorrectBoolWhether_TreeContainsPathToGivenSum(BinarySearchTree binarySearchTree, int givenSum, bool containsPath)
        {
            Assert.Equal(binarySearchTree.ContainsPathLeadingToGivenSum(givenSum), containsPath);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithNumberOfNodes), MemberType = typeof(TreeData))]
        public void Tree_CanCountHowManyNodesItContains(BinarySearchTree binarySearchTree, int numberOfNodes)
        {
            Assert.Equal(binarySearchTree.CountNodes(), numberOfNodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMaximumSumThroughRoot), MemberType = typeof(TreeData))]
        public void Tree_CanCalculateMaximumSumThroughRoot(BinarySearchTree binarySearchTree, int maxSumThroughRoot)
        {
            Assert.Equal(binarySearchTree.MaximumSumThroughRoot(), maxSumThroughRoot);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMaximumSumThroughAnyRoot), MemberType = typeof(TreeData))]
        public void Tree_CanCalculateMaximumSumThroughAnyNode(BinarySearchTree binarySearchTree, int maximumSum)
        {
            Assert.Equal(binarySearchTree.MaximumSumThroughAnyRoot(), maximumSum);
        }
        [Theory]
        [MemberData(nameof(TreeData.TreeWithDiameter), MemberType = typeof(TreeData))]
        public void Tree_CanCalculateDiameter(BinarySearchTree binarySearchTree, int diameter)
        {
            Assert.Equal(binarySearchTree.TreeDiameter(), diameter);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithAncestor), MemberType = typeof(TreeData))]
        public void Tree_CanGetAncestor(BinarySearchTree binarySearchTree, int firstElement, int secondElement, int ancestorValue)
        {
            Assert.Equal(binarySearchTree.GetLowestCommonAncestor(firstElement, secondElement)?.Value, ancestorValue);
        }

        [Theory]
        [MemberData(nameof(TreeData.TraverseZigZag), MemberType = typeof(TreeData))]
        public void Tree_CanTraverseZigZag(BinarySearchTree binarySearchTree, IList<IList<int>> zigzagNodes)
        {
            Assert.Equal(binarySearchTree.ZigZagTraversal(), zigzagNodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TraverseLevelWiseReverse), MemberType = typeof(TreeData))]
        public void Tree_CanTraverseLevelWiseInReverse(BinarySearchTree binarySearchTree, IList<IList<int>> reversedNodes)
        {
            Assert.Equal(binarySearchTree.ReverseTraverseLevelWise(), reversedNodes);
        }
        [Theory]
        [MemberData(nameof(TreeData.TraverseLevelWise), MemberType = typeof(TreeData))]
        public void Tree_CanTraverseLevelWise(BinarySearchTree binarySearchTree, IList<IList<int>> nodes)
        {
            Assert.Equal(binarySearchTree.TraverseLevelWise(), nodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithNodesAtHeight), MemberType = typeof(TreeData))]
        public void Tree_CanGetNodesAtAGivenLevel(BinarySearchTree binarySearchTree, int height, IList<int> nodes)
        {
            Assert.Equal(binarySearchTree.GetNOdesAtGivenHeight(height), nodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TraverseInOrder), MemberType = typeof(TreeData))]
        public void Tree_CanTraverseInOrder(BinarySearchTree binarySearchTree, IList<int> nodes)
        {
            Assert.Equal(binarySearchTree.TraverseInOrder(), nodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TraversePreOrder), MemberType = typeof(TreeData))]
        public void Tree_CanTraversePreOrder(BinarySearchTree binarySearchTree, IList<int> nodes)
        {
            Assert.Equal(binarySearchTree.TraversePreOrder(), nodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TraversePostOrder), MemberType = typeof(TreeData))]
        public void Tree_CanTraversePostOrder(BinarySearchTree binarySearchTree, IList<int> nodes)
        {
            Assert.Equal(binarySearchTree.TraversePostOrder(), nodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithNodesToDelete), MemberType = typeof(TreeData))]
        public void Tree_CanDeleteNodes(BinarySearchTree tree, int nodeToRemove, IList<int> nodesInOrder,
            int numberOfNodesAfterDeleting)
        {
            tree.Delete(nodeToRemove);

            Assert.False(tree.Contains(nodeToRemove));
            Assert.Equal(nodesInOrder, tree.TraverseInOrder());
            Assert.Equal(numberOfNodesAfterDeleting, tree.CountNodes());
        }



    }
}
