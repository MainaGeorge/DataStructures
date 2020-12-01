using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvedProblems
{
    public static class StringProblems
    {
        public static bool IsPalindrome(string parameter)
        {
            return parameter == parameter.Aggregate(string.Empty, (current, t) => t + current);

        }

        private static IEnumerable<IEnumerable<string>> GroupAnagrams(IEnumerable<string> source)
        {
            var anagramsGroupingsContainer = new Dictionary<string, List<string>>();

            foreach (var word in source)
            {
                var sorted = string.Concat(word.OrderBy(w => w));

                if (anagramsGroupingsContainer.ContainsKey(sorted))
                {
                    anagramsGroupingsContainer[sorted].Add(word);
                }
                else
                {
                    anagramsGroupingsContainer[sorted] = new List<string> { word };
                }
            }

            return anagramsGroupingsContainer.Values;
        }

        public static string ReverseString(string toReverse)
        {
            return toReverse.Aggregate(string.Empty, (s, c) => c + s);

            // return new string(toReverse.Reverse().ToArray());
        }

        public static string ReverseStringLooping(string toReverse)
        {
            var toReturn = new StringBuilder();
            foreach (var character in toReverse)
            {
                toReturn.Insert(0, character);
            }

            return toReturn.ToString();
        }

        public static string ReverseSentence(string sentence)
        {
            var reversedSentence = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();
            return string.Join(' ', reversedSentence);
        }

        public static string ReverseSentenceAndEachWordInThatSentence(string toReverse)
        {
            var charArray = toReverse.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Reverse().Select(str => new string(str.Reverse().ToArray()));

            return string.Join(' ', charArray);
        }
        public static string ReverseEachWord(string sentence)
        {
            var result = sentence.Split(' ').Select(ReverseString);
            return string.Join(' ', result);
        }

        public static string RemoveDuplicates(string duplicate)
        {
            var charTracker = new Dictionary<char, int>();
            var finalString = new StringBuilder();
            foreach (var character in duplicate.Where(character => !charTracker.ContainsKey(character)))
            {
                charTracker[character] = 1;
                finalString.Append(character);
            }

            var lenWithoutDuplicates = charTracker.Sum(x => x.Value);
            return finalString.ToString();
        }

        public static string RemoveDuplicatesLinq(string duplicates)
        {
            return new string(duplicates.Distinct().ToArray());
        }

        public static string FindAllPossibleSubsetOfString(string str)
        {
            var index = 0;
            var finalResult = new StringBuilder();

            while (index < str.Length)
            {
                var tempString = BuildString(str[index], str.Substring(index + 1));
                finalResult.Append($"{tempString} ");
                index++;
            }

            return finalResult.ToString();

        }

        private static string BuildString(char a, string str)
        {
            var subStringLength = 1;

            var finalString = new StringBuilder();

            while (subStringLength <= str.Length)
            {
                var tempString = str.Substring(0, subStringLength)
                    .Aggregate(a.ToString(), (current, c) => current + c);

                subStringLength++;

                finalString.Append($"{tempString} ");
            }

            return finalString.ToString();
        }

        public static bool IsStringARotationOfB(string a, string b)
        {
            // Find out if a string is a rotation of another string.E.g.ABCD is a rotation of BCDA but not ACBD.
            return a.Length == b.Length && (a + a).Contains(b);
        }

        private static string MakeString(char a, string substring, int substringLength)
        {
            var finalString = new StringBuilder();

            for (var i = 1; i <= substringLength; i++)
            {
                finalString.Append(a + substring.Substring(0, i) + " ");
            }

            return finalString.ToString();
        }

        public static string GetSubstrings(string str)
        {
            var finalString = new StringBuilder();

            for (var index = 0; index < str.Length; index++)
            {
                var substring = str.Substring(index + 1);
                finalString.Append(MakeString(str[index], substring, substring.Length));
            }
            return finalString.ToString();
        }

        public static bool IsPalindromeB(string palindrome)
        {
            palindrome = palindrome.ToLower();

            var leftIndex = 0;
            var rightIndex = palindrome.Length - 1;

            while (leftIndex < rightIndex)
            {
                if (palindrome[leftIndex] == palindrome[rightIndex])
                {
                    leftIndex++;
                    rightIndex--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPalindromic(string testSubject)
        {
            if (testSubject.Any(x => !char.IsLetter(x)))
            {
                testSubject = CreateStringOfJustLetters(testSubject);
            }

            var leftIndex = 0;
            var rightIndex = testSubject.Length - 1;

            while (leftIndex < rightIndex)
            {
                if (testSubject[rightIndex] != testSubject[leftIndex])
                {
                    return false;
                }

                leftIndex++;
                rightIndex--;
            }

            return true;

        }

        private static string CreateStringOfJustLetters(string testSubject)
        {
            return new string(testSubject.Where(char.IsLetter).Select(char.ToUpper).ToArray());
        }

        private static IEnumerable<int> LargestNumbersInEachArray(IEnumerable<int[]> source)
        {
            return source.Select(x => x.Max()).ToArray();
        }
        private static string TitleCaseASentence(string sentence)
        {
            var titleCasedArray = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => char.ToUpper(x[0]) + x.Substring(1))
                .ToArray();

            return string.Join(' ', titleCasedArray);
        }
        private static (string, int) GetLongestWordInASentence(string sentence)
        {
            var longestWord = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderByDescending(x => x.Length)
                .First();

            return (longestWord, longestWord.Length);

        }

    }
}
