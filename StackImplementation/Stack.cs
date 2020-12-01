using System.Collections;
using System.Collections.Generic;

namespace StackImplementation
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly LinkedListImplementation.LinkedList<T> _dataStorage;

        public Stack()
        {
            _dataStorage = new LinkedListImplementation.LinkedList<T>();
        }

        public int Size => _dataStorage.Size;

        public void Push(T value)
        {
            _dataStorage.AddLast(value);
        }

        public T Pop()
        {
            var toReturn = _dataStorage.TailNode;
            _dataStorage.RemoveLast();
            return toReturn.Value;
        }

        public T Peek()
        {
            return _dataStorage.TailNode.Value;
        }

        public bool IsEmpty()
        {
            return _dataStorage.Size == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dataStorage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
