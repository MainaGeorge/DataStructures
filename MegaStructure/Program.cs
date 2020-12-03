using LinkedListImplementation;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {

            var list = new LinkedList<int>(new Node<int>(3, new Node<int>(2)));
            list.AddAt(1, 13);
        }

    }
}
