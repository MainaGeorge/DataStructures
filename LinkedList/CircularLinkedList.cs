using System;

namespace LinkedListImplementation
{
    public class CircularLinkedList<T>
    {
        public Node<T> HeadNode { get; private set; }
        public Node<T> TailNode { get; private set; }
        public int Size { get; private set; }
        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            if (IsEmpty())
            {
                AddVeryFirstElement(newNode);
            }
            else
            {
                newNode.Next = HeadNode;
                HeadNode = newNode;
            }

            Size++;
        }
        public void AddAt(int position, T value)
        {
            if (position < 0 || position > Size)
                throw new IndexOutOfRangeException();
            if (position == 0)
                AddFirst(value);
            else if (position == Size)
                AddLast(value);
            else
            {
                var nodeToConnectTo = GetNodeBeforeRequiredIndex(position);
                var newNode = new Node<T>(value, nodeToConnectTo.Next);
                nodeToConnectTo.Next = newNode;
                Size++;
            }
        }
        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);
            if (IsEmpty())
            {
                AddVeryFirstElement(newNode);
            }
            else
            {
                newNode.Next = TailNode.Next;
                TailNode.Next = newNode;
                TailNode = TailNode.Next;
            }

            Size++;
        }
        public T[] ToArray()
        {
            if (IsEmpty())
                return Array.Empty<T>();

            var currentNode = HeadNode;
            var count = 0;
            var elementsArray = new T[Size];


            while (count < Size)
            {
                elementsArray[count++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return elementsArray;
        }
        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (HasOneElement())
            {
                HeadNode = TailNode = null;
            }
            else if (HeadNode == GetNodeWhereCycleBegins())
            {
                TailNode.Next = HeadNode.Next;
                HeadNode = HeadNode.Next;
            }
            else
                HeadNode = HeadNode.Next;

            Size--;

        }
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (HasOneElement())
            {
                HeadNode = TailNode = null;
            }
            else
            {
                var currentNode = HeadNode;
                while (currentNode.Next != TailNode)
                    currentNode = currentNode.Next;

                currentNode.Next = TailNode.Next;
                TailNode = currentNode;
            }
            Size--;
        }

        public void RemoveAt(int index)
        {
            if(index < 0 || index > Size-1)
                throw new IndexOutOfRangeException();

            if(index == 0 )
                RemoveFirst();
            else if(index == Size-1)
                RemoveLast();
            else
            {
                var node = GetNodeBeforeRequiredIndex(index);
                if (node.Next == GetNodeWhereCycleBegins())
                    TailNode.Next = node.Next.Next;
                
                node.Next = node.Next.Next;
                Size--;
            }
        }
        public Node<T> GetNodeWhereCycleBegins() => IsEmpty() ? null : TailNode.Next;
        public void ChangeCyclicNode(int index)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();

            if (IsEmpty())
                throw new InvalidOperationException();

            var nodeToMakeCyclic = GetNodeToMakeCyclic(index);
            TailNode.Next = nodeToMakeCyclic;
        }
        private Node<T> GetNodeToMakeCyclic(int index)
        {
            if (index == 0)
                return HeadNode;
            if (index == Size - 1)
                return TailNode;
            var count = 0;
            var currentNode = HeadNode;

            while (count < index)
            {
                currentNode = currentNode.Next;
                count++;
            }

            return currentNode;
        }
        private bool IsEmpty() => Size == 0;
        private void AddVeryFirstElement(Node<T> node)
        {
            node.Next = node;
            HeadNode = TailNode = node;
        }
        private bool HasOneElement() => Size == 1;
        private Node<T> GetNodeBeforeRequiredIndex(int index)
        {
            var count = 0;
            var currentNode = HeadNode;
            while (count < index - 1)
            {
                currentNode = currentNode.Next;
                count++;
            }

            return currentNode;
        }
        private Node<T> GetNodeBeforeLast()
        {
            var currentNode = HeadNode;
            if (HasOneElement())
                return HeadNode;

            while (currentNode.Next != TailNode)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

    }
}
