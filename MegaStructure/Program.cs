using LinkedListImplementation;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {

            var doubly = new DoublyLinkedList<int>();
            doubly.AddFirst(10);
            doubly.AddFirst(100);
            doubly.AddLast(20);

            var second = doubly.GetAt(1);


            Console.WriteLine("head node: " + doubly.HeadNode?.Value);
            Console.WriteLine("size: " + doubly.Size);
            Console.WriteLine("tail node: " + doubly.TailNode?.Value);
            Console.WriteLine("contains : " + doubly.Contains(30));
            Console.WriteLine("second node " + second.Value);

            Console.WriteLine(string.Join(" ==> ", doubly.ToArray()));

        }

    }
}
