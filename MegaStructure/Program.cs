using BinaryTree;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {
            var tree = new BinaryTreeImplementation();

            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(60);

            tree.InOrder();
            Console.WriteLine($"{tree.MaxValue()}  {tree.MinValue()}");
            Console.WriteLine($"{tree.Contains(40)}  {tree.Contains(70)}");

        }



    }
}
