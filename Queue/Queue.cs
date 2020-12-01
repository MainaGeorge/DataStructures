using LinkedListImplementation;

namespace QueueImplementation
{
    public class Queue<T>
    {
        private readonly LinkedList<T> _dataStorage;
        public int Size => _dataStorage.Size;
        public Queue()
        {
            _dataStorage = new LinkedList<T>();
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
    }
}
