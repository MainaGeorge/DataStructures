using LinkedListImplementation;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {

            var node = new Node<int>(3, new Node<int>(5));

            Console.WriteLine(node);
        }

    }
}
