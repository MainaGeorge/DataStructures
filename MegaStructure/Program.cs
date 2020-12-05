using LinkedListImplementation;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {

            var circular = new CircularLinkedList<int>();

            circular.AddLast(20);
            circular.AddLast(30);
            circular.AddLast(50);
            circular.AddFirst(100);
            circular.ChangeCyclicNode(0);
            circular.AddAt(1, 400);

            circular.RemoveAt(0);

            Console.WriteLine(string.Join(" --> ", circular.ToArray()));
            Console.WriteLine("head ==> " + circular.HeadNode.Value);
            Console.WriteLine("tail ==> " + circular.TailNode.Value);
            Console.WriteLine("Size ==> " + circular.Size);

            var cyclic = circular.GetNodeWhereCycleBegins();
            Console.WriteLine("cyclic node ==> " + cyclic.Value);
        }

    }
}
