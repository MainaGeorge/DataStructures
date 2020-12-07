using BinaryTree;
using System.Collections.Generic;

namespace Tests
{
    public class TreeData
    {

        public static IEnumerable<object[]> TreeWithMaximumHeights
        {
            get
            {
                return new List<object[]>()
                {
                    new object[] { Tree1, 2 },
                    new object[] { Tree2, 3 },
                    new object[] { Tree3, 0 },
                    new object[] { Tree4, 1 }

                };
            }
        }
        public static IEnumerable<object[]> IsValidBst => new List<object[]>()
        {
            new object[]{Tree2},
            new object[]{Tree1},
            new object[]{Tree3}
        };
        public static IEnumerable<object[]> TreeWithMinimumHeights =>
            new List<object[]>() 
            {
                new object[] {Tree1, 2},
                new object[] {Tree2, 2},
                new object[] {Tree3, 0},
                new object[] {Tree4, 1}
             };
        public static IEnumerable<object[]> TreeWithMaxNodesPerLevel => new List<object[]>()
        {
            new object[]{Tree4, new[]{50, 75}},
            new object[]{Tree2, new[]{100,200,250,300}},
            new object[]{Tree3, new[]{10}},
            new object[]{Tree1, new[]{20, 40, 50}}
        };
        public static IEnumerable<object[]> TreeWithMinNodeValue => new List<object[]>()
        {
            new object[] {Tree4, 25},
            new object[] {Tree3, 10},
            new object[] {Tree2, 45},
            new object[] {Tree1, 8},
        };
        public static IEnumerable<object[]> TreeWithNumberOfLeaves => new List<object[]>()
        {
            new object[] {Tree1, 4},
            new object[] {Tree2, 5},
            new object[] {Tree1, 4},
            new object[] {Tree3, 1},
        };
        public static IEnumerable<object[]> TreeWithSiblingNodes => new List<object[]>()
        {
            new object[]{Tree1, 10, 40, true},
            new object[]{Tree2, 50, 75, false},
            new object[]{Tree3, 10, 40, false},
            new object[]{Tree4, 25, 75, true},
        };
        public static IEnumerable<object[]> TreeWithPathsToRoot
        {
            get
            {
                var res = new List<List<int>>()
                {
                    new List<int> {50, 25},
                    new List<int> {50, 75}
                };
                var res2 = new List<List<int>>
                {
                    new List<int>() {20, 10, 8},
                    new List<int>() {20, 10, 15},
                    new List<int>() {20, 40, 30},
                    new List<int>() {20, 40, 50},
                };

                return new List<object[]>()
                {
                    new object[] {Tree4, res},
                    new object[] {Tree1, res2},
                };
            }
        }
        public static IEnumerable<object[]> TreeWithNumberOfNodes => new List<object[]>()
        {
            new object[] {Tree1, 7},
            new object[] {Tree2, 10},
            new object[] {Tree4, 3}
        };
        public static IEnumerable<object[]> TreeWithPossibleSum => new List<object[]>()
        {
            new object[] {Tree1, 45, true},
            new object[] {Tree4, 75, true},
            new object[] {Tree4, 100, false},
            new object[] {Tree2, 195, true},
            new object[] {Tree2, 1000, false}
        };
        public static IEnumerable<object[]> TreeWithMaximumSumThroughRoot => new List<object[]>()
        {
            new object[] { Tree1, 110},
            new object[] { Tree4, 125},
            new object[] { Tree2, 850},
        };
        public static IEnumerable<object[]> TreeWithMaximumSumThroughAnyRoot => new List<object[]>()
        {
            new object[] {Tree4, 150},
            new object[] {Tree1, 135}
        };
        public static IEnumerable<object[]> TreeWithDiameter => new List<object[]>()
        {
            new object[] {Tree1, 4},
            new object[] {Tree2, 5},
            new object[] {Tree4, 2}
        };
        public static IEnumerable<object[]> TreeWithAncestor => new List<object[]>()
        {
            new object[] {Tree1, 10, 40, 20},
            new object[] {Tree1, 10, 30, 20},
            new object[] {Tree1, 10, 100, 10},
        };
        public static IEnumerable<object[]> TraverseZigZag {
            get
            {
                var res = new List<IList<int>>
                {
                    new List<int>() {20}, new List<int>() {10, 40}, new List<int>() {50, 30, 15, 8}
                };
                var res2 = new List<IList<int>>
                {
                    new List<int>() {100}, new List<int>() {50, 200}, 
                    new List<int>() {250, 150, 75, 45}, new List<int>() {110, 160,300}
                };
                return new List<object[]>()
                {
                    new object[] {Tree1, res},
                    new object[] {Tree2, res2}
                };
            }
        }
        public static IEnumerable<object[]> TraverseLevelWiseReverse
        {
            get
            {
                var res = new List<IList<int>>()
                {
                    new List<int>(){8, 15, 30, 50}, new List<int>(){10, 40}, new List<int>(){20},
                };
                var res2 = new List<IList<int>>()
                {
                    new List<int>(){25, 75}, new List<int>(){50}
                };

                return new List<object[]>()
                {
                    new object[] {Tree1, res},
                    new object[] {Tree4, res2},
                };
            }
        }
        public static IEnumerable<object[]> TraverseLevelWise
        {

            get
            {
                var res = new List<IList<int>>()
                {
                    new List<int>(){20},new List<int>(){10, 40}, new List<int>(){8, 15, 30, 50},
                };
                var res2 = new List<IList<int>>()
                {
                    new List<int>(){50}, new List<int>(){25, 75}
                };

                return new List<object[]>()
                {
                    new object[] {Tree1, res},
                    new object[] {Tree4, res2},
                };
            }
            
        }
        private static Tree Tree1
        {
            get
            {
                var tree = new Tree();
                tree.Insert(20);
                tree.Insert(40);
                tree.Insert(10);
                tree.Insert(50);
                tree.Insert(30);
                tree.Insert(15);
                tree.Insert(8);

                return tree;
            }
        }
        private static Tree Tree2
        {
            get
            {
                var tree2 = new Tree();
                tree2.Insert(100);
                tree2.Insert(200);
                tree2.Insert(50);
                tree2.Insert(75);
                tree2.Insert(45);
                tree2.Insert(150);
                tree2.Insert(250);
                tree2.Insert(300);
                tree2.Insert(110);
                tree2.Insert(160);

                return tree2;
            }
        }
        private static Tree Tree3
        {
            get
            {
                var tree3 = new Tree();
                tree3.Insert(10);
                return tree3;
            }
        }
        private static Tree Tree4
        {
            get
            {
                var tree = new Tree();
                tree.Insert(50);
                tree.Insert(25);
                tree.Insert(75);
                return tree;
            }
        }


    }
}
