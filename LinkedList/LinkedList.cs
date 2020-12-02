using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListImplementation
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T> HeadNode { get; private set; }
        public Node<T> TailNode { get; private set; }
        public int Size { get; private set; }
        public LinkedList() { }
        public void Add(Node<T> node) => AddLast(node);
        public void Add(T value) => AddLast(value);
        public LinkedList(Node<T> headNode)
        {
            AddFirst(headNode);
        }
        public void AddFirst(Node<T> node)
        {
            if (IsEmpty)
            {
                HeadNode = node;
                TailNode = SetTailNode(node);
            }
            else
            {
                if (node.Next == null)
                {
                    node.Next = HeadNode;
                    HeadNode = node;
                }
                else
                {
                    var fakeNode = node;
                    while (fakeNode.Next != null)
                    {
                        Size++;
                        fakeNode = fakeNode.Next;
                    }

                    fakeNode.Next = HeadNode;
                    HeadNode = node;
                }
            }

            Size++;
        }
        public void AddFirst(T value)
        {
            var node = new Node<T>(value);

            AddFirst(node);
        }
        public void AddLast(Node<T> node)
        {
            if (IsEmpty)
            {
                HeadNode = node;
                TailNode = SetTailNode(node);
            }
            else
                TailNode = SetTailNode(node);

            Size++;
        }
        private Node<T> SetTailNode(Node<T> node)
        {
            while (node.Next != null)
            {
                node = node.Next;
                Size++;
            }
            return node;
        }
        public void AddLast(T value)
        {
            var node = new Node<T>(value);
            AddLast(node);
        }
        public void AddAt(int index, T value)
        {
            if (index == 0)
                AddFirst(value);
            else if (index == Size - 1)
                AddLast(value);
            else
            {
                var nodeBefore = GetNodeBeforeRequired(index);
                var node = new Node<T>(value)
                {
                    Next = nodeBefore.Next
                };
                nodeBefore.Next = node;
            }

        }
        private Node<T> GetNodeBeforeRequired(int index)
        {
            var current = HeadNode.Next;
            var previous = HeadNode;
            var count = 0;
            while (current != null)
            {
                if (count == index - 1)
                    break;
                count++;
                previous = current;
                current = current.Next;
            }

            return previous;

        }
        public bool IsEmpty => HeadNode == null;
        public bool Contains(T value) => IndexOf(value) != -1;
        public void RemoveFirst()
        {
            if (HeadNode == null)
                throw new InvalidOperationException("Can not remove from an empty list");
            if (ContainsOneElement())
                HeadNode = TailNode = null;
            else
                HeadNode = HeadNode.Next;
            Size--;
        }
        public void RemoveLast()
        {
            if (HeadNode == null)
                throw new InvalidOperationException("Can not remove from an empty list");
            if (ContainsOneElement())
                HeadNode = TailNode = null;
            else
            {
                var secondLast = GetSecondLastNode();
                secondLast.Next = null;
                TailNode = secondLast;
            }

            Size--;
        }
        public void Reverse()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            var current = HeadNode.Next;
            var previous = HeadNode;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;

                current = next;
            }

            HeadNode.Next = null;
            TailNode = HeadNode;
            HeadNode = previous;
        }
        public Node<T> GetNthNodeFromEnd(int indexFromEnd)
        {
            if (indexFromEnd > Size)
            {
                throw new IndexOutOfRangeException();
            }

            var firstPointer = HeadNode;
            var secondPointer = HeadNode;

            for (var index = 0; index < indexFromEnd - 1; index++)
            {
                firstPointer = firstPointer.Next;
            }

            while (firstPointer != TailNode)
            {
                firstPointer = firstPointer.Next;
                secondPointer = secondPointer.Next;
            }

            return secondPointer;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();
            if (index == 0)
                RemoveFirst();
            else if (index == Size - 1)
                RemoveLast();
            else
                RemoveAMidElement(index);
        }
        public Node<T>[] ToArray()
        {
            var current = HeadNode;
            var array = new Node<T>[Size];

            for (var index = 0; index < Size; index++)
            {
                array[index] = current;
                current = current.Next;
            }

            return array;
        }
        private void RemoveAMidElement(int index)
        {
            var previousNode = GetNodeBeforeRequired(index);

            previousNode.Next = previousNode.Next.Next;
            Size--;
        }
        private Node<T> GetSecondLastNode()
        {
            var currentNode = HeadNode;
            while (currentNode.Next != TailNode)
                currentNode = currentNode.Next;

            return currentNode;
        }
        private bool ContainsOneElement() => HeadNode == TailNode;
        public int IndexOf(T value)
        {
            var count = 0;
            var foundIndex = -1;
            var currentNode = HeadNode;

            while (currentNode != null)
            {
                if (value.Equals(currentNode.Value))
                {
                    foundIndex = count;
                    break;
                }

                count++;
                currentNode = currentNode.Next;
            }

            return foundIndex;
        }

        public void Remove(T value)
        {
            if (HeadNode.Value.Equals(value))
            {
                RemoveFirst();
                return;
            }

            if (TailNode.Value.Equals(value))
            {
                RemoveLast();
                return;
            }
            var nodeBeforeToBeDeleted = GetNodeBeforeGiven(value);

            if (nodeBeforeToBeDeleted == null) return;

            nodeBeforeToBeDeleted.Next = nodeBeforeToBeDeleted.Next.Next;
            Size--;


        }

        private Node<T> GetNodeBeforeGiven(T value)
        {
            var currentNode = HeadNode;
            Node<T> result = null;
            var hasFoundNode = false;

            if (HeadNode.Value.Equals(value))
            {
                result = HeadNode;
                hasFoundNode = true;
            }

            while (currentNode.Next != null && !hasFoundNode)
            {
                if (currentNode.Next.Value.Equals(value))
                {
                    result = currentNode;
                    break;
                }

                currentNode = currentNode.Next;
            }

            return result;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var starting = HeadNode;
            while (starting != null)
            {
                yield return starting.Value;
                starting = starting.Next;
            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
