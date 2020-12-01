using System;
using System.Collections.Generic;
using System.Linq;

namespace dojo
{
    public static class UnclassifiedAlgorithms
    {
        public static bool IsPrime(int number)
        {
            if (number == 2 || number == 3)
            {
                return true;
            }
            else
            {
                var squareRoot = (int)Math.Floor((Math.Sqrt(number)));

                for (var num = 3; num < squareRoot; num += 2)
                {
                    if (number % num == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public static int SumOfIndividualIntegerNumbers(int num)
        {
            var sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
        public static int MemoizeFib(int n)
        {
            if (n == 2 || n == 3)
            {
                return 1;
            }

            if (Cache.ContainsKey(n))
            {
                Console.WriteLine("from cache for " + n);
                return Cache[n];
            }
            else
            {
                Console.WriteLine("calculating " + n);
                Cache[n] = MemoizeFib(n - 1) + MemoizeFib(n - 2);
                return Cache[n];
            }
        }
        public static int FibSequence(int n)
        {
            if (n == 2 || n == 3)
            {
                return 1;
            }

            return FibSequence(n - 1) + FibSequence(n - 2);
        }
        public static int CalculateNumberOfBoats(IList<int> weights, int limit)
        {
            weights = weights.OrderBy(w => w).ToArray();
            var leftPointer = 0;
            var rightPointer = weights.Count - 1;
            var boats = 0;

            while (leftPointer <= rightPointer)
            {
                if (leftPointer == rightPointer)
                {
                    boats++;
                    break;
                }

                if (weights[leftPointer] + weights[rightPointer] <= limit)
                {
                    leftPointer++;
                    rightPointer--;
                }
                else
                {
                    rightPointer--;
                }

                boats++;
            }

            return boats;
        }

        private static readonly Dictionary<int, int> Cache = new Dictionary<int, int>();

    }
}
