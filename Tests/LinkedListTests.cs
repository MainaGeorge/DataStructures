using System;
using LinkedListImplementation;
using Xunit;

namespace Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void LinkedList_StartsEmpty()
        {
            var list = new LinkedList<int>();

            Assert.Equal(0, list.Size);
        }

        [Fact]
        public void LinkedList_CanBeInitiatedWithAValue()
        {
            var list = new LinkedList<int>(3);

            Assert.Equal(1, list.Size);
        }
        
        [Fact]
        public void LinkedList_CanBeInitiatedWithANode()
        {
            var list = new LinkedList<int>(new Node<int>(13, new Node<int>(2, new Node<int>(1))));

            Assert.Equal(3, list.Size);
            Assert.Equal(13, list.HeadNode.Value);
            Assert.Equal(1, list.TailNode.Value);
        }
        [Fact]
        public void LinkedList_CorrectlyAddsFirst()
        {
            var list = new LinkedList<int>(10);
            list.AddFirst(20);

            Assert.Equal(20, list.HeadNode.Value);
        }
        
        [Fact]
        public void LinkedList_CorrectlyAddsLast()
        {
            var list = new LinkedList<int>(10);
            list.AddLast(20);

            Assert.Equal(20, list.TailNode.Value);
            Assert.Equal(10, list.HeadNode.Value);
        }
        
        [Fact]
        public void LinkedList_CorrectlyRemovesLast()
        {
            var list = new LinkedList<int>(10);
            list.AddFirst(20);

            list.RemoveLast();

            Assert.Equal(1, list.Size);
            Assert.Equal(20, list.HeadNode.Value);
            Assert.Equal(20, list.TailNode.Value);

            
        }
        [Fact]
        public void LinkedList_CorrectlyRemovesFirst()
        {
            var list = new LinkedList<int>(20);
            list.AddLast(10);

            list.RemoveFirst();

            Assert.Equal(1, list.Size);
            Assert.Equal(10, list.HeadNode.Value);
            Assert.Equal(10, list.TailNode.Value);

        }

        [Fact]
        public void LinkedList_GetsNOdeAtSpecifiedIndex()
        {
            var list = new LinkedList<int>(new Node<int>(3, new Node<int>(2)));

            var firstNode = list.GetAt(0);

            Assert.Equal(list.HeadNode, firstNode);
        }
        [Fact]
        public void LinkedList_InsertsAtCorrectPosition()
        {
            var list = new LinkedList<int>(new Node<int>(3, new Node<int>(2)));
            list.AddAt(1, 13);

            Assert.Equal(13, list.GetAt(1).Value);

        }

        [Fact]
        public void LinkedList_CanInsertElementAtTheBeginning_UsingIndexZero()
        {
            var list = new LinkedList<int>(new Node<int>(3, new Node<int>(2)));
            list.AddAt(0, 13);

            Assert.Equal(13, list.HeadNode.Value);
        }
        [Fact]
        public void LinkedList_CanInsertElementAtTheEnd_UsingIndex()
        {
            var list = new LinkedList<int>();
            list.AddFirst(10);
            list.AddLast(20);
            list.AddAt(2, 13);

            Assert.Equal(13, list.TailNode.Value);
        }

        [Fact]
        public void LinkedList_ThrowsErrorIfRemovingFromEmptyList()
        {
            var list = new LinkedList<int>();

            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Fact]
        public void LinkedList_CanReturnAnArrayOfValues()
        {
            var list = new LinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            var arr = new int[] {10, 20, 30};
            Assert.Equal(arr, list.ToArray());
        }

        [Fact]
        public void LinkedList_ReturnsTrueIfElementIsPresent()
        {
            var list = new LinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            Assert.True(list.Contains(20));
        }
        
        [Fact]
        public void LinkedList_ReturnsFalseIfElementIsNotPresent()
        {
            var list = new LinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            Assert.False(list.Contains(200));
        }


    }
}
