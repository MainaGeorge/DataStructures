using BinaryTree;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {

            var tree = new Tree();
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(10);
            tree.Insert(50);
            // tree.Insert(30);
            // tree.Insert(15);
            tree.Insert(8);

            var paths = tree.GetPathsToRoot();

            Console.WriteLine(tree.TreeDiameter());

        }



    }
}
