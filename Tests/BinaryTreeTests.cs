using BinaryTree;
using Xunit;

namespace Tests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void Tree_StartsEmpty()
        {
            var tree = new BinaryTreeImplementation();
            
            Assert.Equal(-1, tree.Height());
            Assert.Equal(0,tree.CountNodes());
        }

        [Fact]
        public void Tree_CanInsertNodes()
        {
            var tree = new BinaryTreeImplementation();
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            
            Assert.Equal(1,tree.Height());
            Assert.Equal(1, tree.GetMaximumDepth());

        }

        [Fact]
        public void Tree_CanCountNodes()
        {
            var tree = new BinaryTreeImplementation();
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            Assert.Equal(3, tree.CountNodes());
            Assert.Equal(3, tree.CountNodesWithQueue());
        }

        [Fact]
        public void Tree_CanGetMaximumValue()
        {
            var tree = new BinaryTreeImplementation();
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            Assert.Equal(40, tree.MaxValue());
        }
        
        [Fact]
        public void Tree_CanGetMinimumValue()
        {
            var tree = new BinaryTreeImplementation();
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            Assert.Equal(20, tree.MinValue());
        }
        
        [Fact]
        public void Tree_ReturnsTrueIfTreeContainsElement()
        {
            var tree = new BinaryTreeImplementation();
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            Assert.True(tree.Contains(20));
        }
        
        [Fact]
        public void Tree_ReturnsFalseIfTreeDoesNotContainElement()
        {
            var tree = new BinaryTreeImplementation();
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            Assert.False(tree.Contains(120));
        }
    }
}