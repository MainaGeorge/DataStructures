using LinkedListImplementation;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {

            var doubly = new DoublyLinkedList<int> {100, 200, 300};
            doubly.AddAt(doubly.Size, 1000);

            Console.WriteLine(string.Join(" ==> ", doubly.ToArray()));

        }

    }
}
