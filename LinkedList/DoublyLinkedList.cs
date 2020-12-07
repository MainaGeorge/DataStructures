using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListImplementation
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyLinkedNode<T> HeadNode { get; private set; }
        public DoublyLinkedNode<T> TailNode { get; private set; }
        public int Size { get; private set; }
        public void Add(T value) => AddLast(value);
        public void AddFirst(T value)
        {
            var node = new DoublyLinkedNode<T>(value);
            if (IsEmpty())
                AddVeryFirstElement(node);
            else
            {
                node.Next = HeadNode;
                HeadNode.Previous = node;
                HeadNode = node;
            }
            Size++;
        }
        public void AddLast(T value)
        {
            var node = new DoublyLinkedNode<T>(value);
            if (IsEmpty())
                AddVeryFirstElement(node);
            else
            {
                node.Previous = TailNode;
                TailNode.Next = node;
                TailNode = node;
            }

            Size++;
        }
        public void AddAt(int index, T value)
        {
            if (IsEmpty())
            {
                AddFirst(value);
                return;
            }

            if (index < 0 || index > Size)
                throw new IndexOutOfRangeException();

            if (index == 0)
                AddFirst(value);
            else if (index == Size)
                AddLast(value);
            else
            {
                var nodeBeforeIndex = GetNodeBeforeIndex(index);
                var newNode = new DoublyLinkedNode<T>(value, nodeBeforeIndex.Next, nodeBeforeIndex);
                nodeBeforeIndex.Next = newNode;
                nodeBeforeIndex.Next.Previous = newNode;
                Size++;
            }
        }
        public DoublyLinkedNode<T> GetAt(int index)
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();

            return GetNodeAtIndex(index);
        }
        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (HasOneNode())
                HeadNode = TailNode = null;
            else
            {
                HeadNode = HeadNode.Next;
                HeadNode.Previous = null;
            }

            Size--;
        }
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (HasOneNode())
                HeadNode = TailNode = null;
            else
            {
                TailNode = TailNode.Previous;
                TailNode.Next = null;
            }

            Size--;
        }
        public void RemoveAt(int index)
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();
            if (index == 0)
                RemoveFirst();
            else if (index == Size - 1)
                RemoveLast();
            else
            {
                var nodeBefore = GetNodeBeforeIndex(index);
                var nextNode = nodeBefore.Next.Next;

                nextNode.Previous = nodeBefore;
                nodeBefore.Next = nextNode;
                Size--;
            }
        }
        public bool Contains(T value)
        {
            var currentNode = HeadNode;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                    return true;
                currentNode = currentNode.Next;
            }

            return false;
        }
        public T[] ToArray()
        {
            if (IsEmpty())
                return Array.Empty<T>();
            var valueArray = new T[Size];
            var index = 0;
            var currentNode = HeadNode;
            while (index < Size)
            {
                valueArray[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return valueArray;

        }
        private void AddVeryFirstElement(DoublyLinkedNode<T> firstNode)
        {
            HeadNode = TailNode = firstNode;
        }
        private DoublyLinkedNode<T> GetNodeBeforeIndex(int index)
        {
            var count = 0;
            var currentNode = HeadNode;
            while (count < index - 1)
            {
                count++;
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
        private bool IsEmpty() => Size == 0;
        private DoublyLinkedNode<T> GetNodeAtIndex(int index)
        {
            var count = 0;
            var currentNode = HeadNode;
            while (count < index)
            {
                currentNode = currentNode.Next;
                count++;
            }
            return currentNode;
        }
        private bool HasOneNode() => Size == 1;
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = HeadNode;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
