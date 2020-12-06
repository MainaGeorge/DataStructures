using System;
using LinkedListImplementation;
using Xunit;

namespace Tests
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void List_StartsOffEmpty()
        {
            var doubly = new DoublyLinkedList<int>();
            
            Assert.Equal(0, doubly.Size);
        }
        
        [Fact]
        public void List_CorrectlyAddsFirstElement_UsingAddFirst()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.AddFirst(100);

            Assert.Equal(doubly.HeadNode, doubly.TailNode);
            Assert.Equal(1, doubly.Size);
        }
        
        [Fact]
        public void List_CorrectlyAddsElement_UsingAddFirst()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.AddFirst(100);
            doubly.AddFirst(200);

            Assert.Equal(200, doubly.HeadNode.Value);
            Assert.Equal(100, doubly.TailNode.Value);
            Assert.Equal(2, doubly.Size);
        }
        
        [Fact]
        public void List_CorrectlyAddsFirstElement_UsingAddLast()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.AddLast(100);

            Assert.Equal(doubly.HeadNode, doubly.TailNode);
            Assert.Equal(1, doubly.Size);
        }
        
        [Fact]
        public void List_CorrectlyAddsElement_UsingAddLast()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.AddLast(100);
            doubly.AddLast(200);

            Assert.Equal(100, doubly.HeadNode.Value);
            Assert.Equal(200, doubly.TailNode.Value);
            Assert.Equal(2, doubly.Size);
        }
        
        [Fact]
        public void List_ReturnsTrueIfElementIsPresent()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.AddLast(100);
            doubly.AddLast(200);
            
            Assert.True(doubly.Contains(100));
        }
        
        [Fact]
        public void List_ReturnsFalseIfElementIsNotPresent()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.AddLast(100);
            doubly.AddLast(200);
            
            Assert.False(doubly.Contains(300));
        }

        [Fact]
        public void List_AddsLastIfUsingAddMethod()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.Add(100);
            doubly.Add(200);
            doubly.Add(300);
            
            Assert.Equal(3, doubly.Size);
            Assert.Equal(300, doubly.TailNode.Value);
        }
        
        [Fact]
        public void List_CorrectlyReturnsElementAtIndex()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.Add(100);
            doubly.Add(200);
            doubly.Add(300);
            
            Assert.Equal(100, doubly.GetAt(0).Value);
            Assert.Equal(200, doubly.GetAt(1).Value);
            Assert.Equal(300, doubly.GetAt(2).Value);
        }
        
        [Fact]
        public void List_CorrectlyAddsAtMidIndex()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};
            doubly.AddAt(1, 1000);
            
            Assert.Equal(1000, doubly.GetAt(1).Value);
        }
        
        [Fact]
        public void List_CorrectlyAddsAtIndexZero()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};
            doubly.AddAt(0, 1000);
            
            Assert.Equal(1000, doubly.HeadNode.Value);
        }

        [Fact]
        public void List_CorrectlyAddsAtLastIndex()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};
            doubly.AddAt(doubly.Size, 1000);
            
            Assert.Equal(1000, doubly.TailNode.Value);
        }

        [Fact]
        public void List_ThrowsAnErrorIfAddingAnInvalidIndex()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};
            doubly.AddAt(doubly.Size, 1000);

            Assert.Throws<IndexOutOfRangeException>(() => doubly.AddAt(6, 2000));
            Assert.Throws<IndexOutOfRangeException>(() => doubly.AddAt(-1, 2000));
        }

        [Fact]
        public void List_AddsFirstIfListIsEmptyNoMatterTheIndex()
        {
            var doubly = new DoublyLinkedList<int>();
            doubly.AddAt(100, 1000);
            
            Assert.Equal(1, doubly.Size);
            Assert.Equal(1000, doubly.HeadNode.Value);
            Assert.Equal(doubly.HeadNode, doubly.TailNode);
        }
        
        [Fact]
        public void List_ReturnsAnArrayOfElements()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};
            doubly.AddAt(doubly.Size, 1000);
            var arr = new[] {100, 200, 300, 1000};
            
            Assert.Equal(arr, doubly.ToArray());
        }
        
        [Fact]
        public void List_CorrectlyRemovesFirst()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};

            doubly.RemoveFirst();
            
            Assert.Equal(2, doubly.Size);
            Assert.Equal(200, doubly.HeadNode.Value);
        }
        
        [Fact]
        public void List_CorrectlyRemovesLast()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};

            doubly.RemoveLast();
            
            Assert.Equal(2, doubly.Size);
            Assert.Equal(200, doubly.TailNode.Value);
        }
        
        [Fact]
        public void List_CorrectlyRemovesAtLastIndex()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};

            doubly.RemoveAt(2);
            
            Assert.Equal(2, doubly.Size);
            Assert.Equal(200, doubly.TailNode.Value);
        }
        
        [Fact]
        public void List_CorrectlyRemovesAtIndexZero()
        {
            var doubly = new DoublyLinkedList<int> {100, 200, 300};

            doubly.RemoveAt(0);
            
            Assert.Equal(2, doubly.Size);
            Assert.Equal(200, doubly.HeadNode.Value);
        }
        
        [Fact]
        public void List_CorrectlyRemovesAtMidIndex()
        {
            var doubly = new DoublyLinkedList<int> {100, 200,400, 300};

            doubly.RemoveAt(1);
            
            Assert.Equal(3, doubly.Size);
            Assert.Equal(400, doubly.GetAt(1).Value);
        }

        [Fact]
        public void List_ThrowsAnErrorIfRemovingFromEmptyList()
        {
            var doubly = new DoublyLinkedList<string>();

            Assert.Throws<InvalidOperationException>(() => doubly.RemoveFirst());
        }

        [Fact]
        public void List_ThrowsAnErrorIfInvalidIndex()
        {
            var doubly = new DoublyLinkedList<string> {"beautiful"};

            Assert.Equal(1, doubly.Size);
            Assert.Throws<IndexOutOfRangeException>(() => doubly.RemoveAt(-2));
            Assert.Throws<IndexOutOfRangeException>(() => doubly.RemoveAt(7));
        }
    }

    
}