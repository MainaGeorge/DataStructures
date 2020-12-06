using LinkedListImplementation;
using System;
using Xunit;

namespace Tests
{
    public class CircularLinkedLIstTests
    {
        [Fact]
        public void List_StartsEmpty()
        {
            var circular = new CircularLinkedList<int>();

            Assert.Equal(0, circular.Size);
        }
        [Fact]
        public void List_MakesFirstNodeHeadTailAndCyclicUsingAddFirst()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddFirst(30);
            var cyclic = circular.GetNodeWhereCycleBegins();
            Assert.Equal(1, circular.Size);
            Assert.Equal(30, circular.HeadNode.Value);
            Assert.Equal(30, circular.TailNode.Value);
            Assert.Equal(30, cyclic.Value);
        }

        [Fact]
        public void List_MakesFirstNodeHeadTailAndCyclicUsingAddLast()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            var cyclic = circular.GetNodeWhereCycleBegins();
            Assert.Equal(1, circular.Size);
            Assert.Equal(30, circular.HeadNode.Value);
            Assert.Equal(30, circular.TailNode.Value);
            Assert.Equal(30, cyclic.Value);
        }
        [Fact]
        public void List_CanInsertAtACorrectIndex()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);
            circular.AddLast(50);
            circular.AddAt(1, 100);

            Assert.Equal(4, circular.Size);
            Assert.Equal(100, circular.GetAt(1).Value);
        }

        [Fact]
        public void List_CanMoveCyclicNodeFromHeadToSomewhereInTheMiddle()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);
            circular.AddLast(50);

            circular.ChangeCyclicNode(1);
            var cyclic = circular.GetNodeWhereCycleBegins();

            Assert.Equal(40, cyclic.Value);
        }

        [Fact]
        public void List_CanMoveCyclicNodeFromHeadToTheEnd()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);
            circular.AddLast(50);

            circular.ChangeCyclicNode(2);
            var cyclic = circular.GetNodeWhereCycleBegins();

            Assert.Equal(50, cyclic.Value);
            Assert.Equal(circular.TailNode, cyclic);
        }

        [Fact]
        public void List_CanRemoveFirstNode()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);
            circular.AddLast(50);

            circular.RemoveFirst();
            Assert.Equal(2, circular.Size);
            Assert.Equal(40, circular.HeadNode.Value);
        }
        [Fact]
        public void List_CanRemoveLastNode()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);
            circular.AddLast(50);

            circular.RemoveLast();
            Assert.Equal(2, circular.Size);
            Assert.Equal(40, circular.TailNode.Value);
        }

        [Fact]
        public void List_CanRemoveAnyNode()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);
            circular.AddLast(50);

            circular.RemoveAt(1);
            Assert.Equal(2, circular.Size);
            Assert.False(circular.Contains(40));
        }

        [Fact]
        public void List_DeletingTheCyclicNodeMovesTheCyclicLinkToNextNode()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);
            circular.AddLast(50);

            circular.ChangeCyclicNode(1);
            circular.RemoveAt(1);
            var cyclic = circular.GetNodeWhereCycleBegins();

            Assert.Equal(2, circular.Size);
            Assert.Equal(circular.TailNode, cyclic);
            Assert.Equal(circular.GetAt(1), cyclic);
        }

        [Fact]
        public void List_ThrowsErrorIfAddingAtAnInvalidIndex()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);

            Assert.Throws<IndexOutOfRangeException>(() => circular.AddAt(-1, 100));
            Assert.Throws<IndexOutOfRangeException>(() => circular.AddAt(3, 100));
        }

        [Fact]
        public void List_ThrowsErrorIfRemovingAtAnInvalidIndex()
        {
            var circular = new CircularLinkedList<int>();
            circular.AddLast(30);
            circular.AddLast(40);

            Assert.Throws<IndexOutOfRangeException>(() => circular.RemoveAt(-1));
            Assert.Throws<IndexOutOfRangeException>(() => circular.RemoveAt(3));
        }

        [Fact]
        public void List_ThrowsAnErrorIfRemovingFromAnEmptyList()
        {
            var circular = new CircularLinkedList<string>();

            Assert.Throws<InvalidOperationException>(() => circular.RemoveAt(0));
        }

        [Fact]
        public void List_ReturnsTrueIfElementInList()
        {
            var circular = new CircularLinkedList<string>();
            circular.AddLast("name");
            circular.AddFirst("here");

            Assert.True(circular.Contains("here"));
        }

        [Fact]
        public void List_ReturnsFalseIfElementIsNotInList()
        {
            var circular = new CircularLinkedList<string>();
            circular.AddLast("name");
            circular.AddFirst("here");

            Assert.False(circular.Contains("there"));
        }

    }
}