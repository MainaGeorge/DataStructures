namespace LinkedListImplementation
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }

        public Node(T value, Node<T> next = null)
        {
            Next = next;
            Value = value;
        }

        public override string ToString()
        {
            var nodeValue = Next?.ToString() ?? "null";
            return $"Node: {Value} with next as {nodeValue}";
        }
    }
}
