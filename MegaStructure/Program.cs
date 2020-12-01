﻿using DictionaryImplementation;
using System;

namespace MegaStructure
{
    internal class Program
    {
        private static void Main()
        {
            var dic = new Dictionary<string, string> { { "name", "George" }, { "surname", "Maina" } };


            dic["married"] = "yes of course";
            dic["wife"] = "Nuria";

            foreach (var entry in dic.Keys())
            {
                Console.WriteLine(entry);
            }
        }

    }
}
