using DictionaryImplementation;
using QueueImplementation;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {
            var dic = new Dictionary<string, string> { { "name", "George" }, { "surname", "Maina" } };

            /*
            dic["married"] = "yes of course";
            dic["wife"] = "Nuria";

            foreach (var entry in dic.Keys())
            {
                Console.WriteLine(entry);
            }
            */

            var queue = new Queue<int>();
            Console.WriteLine("is empty " + queue.IsEmpty());
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);


            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }



        }

    }
}
