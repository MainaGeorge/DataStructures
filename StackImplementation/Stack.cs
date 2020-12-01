using LinkedListImplementation;

namespace StackImplementation
{
    public class Stack<T>
    {
        private readonly LinkedList<T> _dataStorage;

        public Stack()
        {
            _dataStorage = new LinkedList<T>();
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
    }
}
