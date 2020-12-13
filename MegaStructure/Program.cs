using BinaryTree;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {
            var tree = new BinarySearchTree();


            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(50);
            tree.Insert(45);
            tree.Insert(60);
            tree.Insert(35);
            tree.Insert(47);
            tree.Insert(8);

            tree.Delete(50);

            Console.WriteLine(string.Join(" ", tree.TraverseInOrder()));

        }



    }
}
