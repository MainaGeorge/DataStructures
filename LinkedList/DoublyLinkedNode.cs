namespace LinkedListImplementation
{
    public class DoublyLinkedNode<T>
    {
        public DoublyLinkedNode<T> Previous { get; set; }
        public DoublyLinkedNode<T> Next { get; set; }
        public T Value { get; set; }
        public DoublyLinkedNode(T value, DoublyLinkedNode<T> next = null, DoublyLinkedNode<T> previous=null)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
}
