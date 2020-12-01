using System.Collections;
using System.Collections.Generic;

namespace QueueImplementation
{
    public class Queue<T> : IEnumerable<T>
    {
        private readonly LinkedListImplementation.LinkedList<T> _dataStorage;
        public int Size => _dataStorage.Size;
        public Queue()
        {
            _dataStorage = new LinkedListImplementation.LinkedList<T>();
        }

        public void Enqueue(T value) => _dataStorage.AddLast(value);

        public T Dequeue()
        {
            var toReturn = _dataStorage.HeadNode.Value;
            _dataStorage.RemoveFirst();
            return toReturn;
        }

        public T Peek() => _dataStorage.HeadNode.Value;

        public bool IsEmpty() => Size == 0;
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
