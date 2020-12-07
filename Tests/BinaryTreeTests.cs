using BinaryTree;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void Tree_CanStartWithARootNode()
        {
            var tree = new Tree(10);
            Assert.Equal(1, tree.CountNodes());
        }
        [Fact]
        public void Tree_CanStartWithoutARootNode()
        {
            var tree = new Tree();
            Assert.Equal(0, tree.CountNodes());
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMaximumHeights), MemberType = typeof(TreeData))]
        public void Tree_CalculatesCorrectMaximumHeight(Tree tree, int height)
        {
            Assert.Equal(height, tree.MaximumDepth);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMinimumHeights), MemberType = typeof(TreeData))]
        public void Tree_CalculatesCorrectMinimumHeight(Tree tree, int height)
        {
            Assert.Equal(height, tree.MinimumDepth);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMinimumHeights), MemberType = typeof(TreeData))]
        public void Tree_CalculatesCorrectMinimumHeightUsingQueue(Tree tree, int height)
        {
            Assert.Equal(height, tree.MinimumDepthWithQueue);
        }

        [Theory]
        [MemberData(nameof(TreeData.IsValidBst), MemberType = typeof(TreeData))]
        public void Tree_AlwaysBuildsABst(Tree tree)
        {
            Assert.True(tree.IsValidBst());
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMaxNodesPerLevel), MemberType = typeof(TreeData))]
        public void Tree_CanGetMaxValuesPerLevel(Tree tree, int[] maxValuesArray)
        {
            Assert.Equal(tree.GetMaxValuesPerLevel(), maxValuesArray);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMinNodeValue), MemberType = typeof(TreeData))]
        public void Tree_CanGetMinimumNodeValue(Tree tree, int expectedValue)
        {
            Assert.Equal(tree.MinimumNodeValue(), expectedValue);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithNumberOfLeaves), MemberType = typeof(TreeData))]
        public void Tree_CanCountNumberOfLeafNodes(Tree tree, int leafNodes)
        {
            Assert.Equal(tree.CountLeaves, leafNodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithSiblingNodes), MemberType = typeof(TreeData))]
        public void Tree_CanDetermineIfMembersAreSiblings(Tree tree, int firstSibling, int secondSibling,
            bool areSiblings)
        {
            Assert.Equal(tree.AreSiblings(firstSibling, secondSibling), areSiblings);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithPathsToRoot), MemberType = typeof(TreeData))]
        public void Tree_CanReturnPathsToLeafNodes(Tree tree, List<List<int>> paths)
        {
            Assert.Equal(tree.GetPathsToRoot().Count, paths.Count);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithPossibleSum), MemberType = typeof(TreeData))]
        public void Tree_ReturnCorrectBoolWhether_TreeContainsPathToGivenSum(Tree tree, int givenSum, bool containsPath)
        {
            Assert.Equal(tree.ContainsPathLeadingToGivenSum(givenSum), containsPath);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithNumberOfNodes), MemberType = typeof(TreeData))]
        public void Tree_CanCountHowManyNodesItContains(Tree tree, int numberOfNodes)
        {
            Assert.Equal(tree.CountNodes(), numberOfNodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMaximumSumThroughRoot), MemberType = typeof(TreeData))]
        public void Tree_CanCalculateMaximumSumThroughRoot(Tree tree, int maxSumThroughRoot)
        {
            Assert.Equal(tree.MaximumSumThroughRoot(), maxSumThroughRoot);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithMaximumSumThroughAnyRoot), MemberType = typeof(TreeData))]
        public void Tree_CanCalculateMaximumSumThroughAnyNode(Tree tree, int maximumSum)
        {
            Assert.Equal(tree.MaximumSumThroughAnyRoot(), maximumSum);
        }
        [Theory]
        [MemberData(nameof(TreeData.TreeWithDiameter), MemberType = typeof(TreeData))]
        public void Tree_CanCalculateDiameter(Tree tree, int diameter)
        {
            Assert.Equal(tree.TreeDiameter(), diameter);
        }

        [Theory]
        [MemberData(nameof(TreeData.TreeWithAncestor), MemberType = typeof(TreeData))]
        public void Tree_CanGetAncestor(Tree tree, int firstElement, int secondElement, int ancestorValue)
        {
            Assert.Equal(tree.GetAncestor(firstElement, secondElement)?.Value, ancestorValue);
        }

        [Theory]
        [MemberData(nameof(TreeData.TraverseZigZag), MemberType = typeof(TreeData))]
        public void Tree_CanTraverseZigZag(Tree tree, IList<IList<int>> zigzagNodes)
        {
            Assert.Equal(tree.ZigZagTraversal(), zigzagNodes);
        }

        [Theory]
        [MemberData(nameof(TreeData.TraverseLevelWiseReverse), MemberType = typeof(TreeData))]
        public void Tree_CanTraverseLevelWiseInReverse(Tree tree, IList<IList<int>> reversedNodes)
        {
            Assert.Equal(tree.ReverseTraverseLevelWise(), reversedNodes);
        }
        [Theory]
        [MemberData(nameof(TreeData.TraverseLevelWise), MemberType = typeof(TreeData))]
        public void Tree_CanTraverseLevelWise(Tree tree, IList<IList<int>> nodes)
        {
            Assert.Equal(tree.TraverseLevelWise(), nodes);
        }

        
    }
}
