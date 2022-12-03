using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AOC2022
{
    class Day3
    {
        public static void Run()
        {
            IEnumerable<string> input = File.ReadLines("src/03/input.txt");
            Console.WriteLine(Part1(input));
            //Console.WriteLine(Part2(input));
        }

        public static char FindItem(string s)
        {
            string[] halves = s.Insert(s.Length / 2, "|").Split("|");
            HashSet<char> first = new HashSet<char>(halves[0]);
            HashSet<char> second = new HashSet<char>(halves[1]);
            return first.Intersect(second).First();
        }

        public static int Priority(char c)
        {
            return 26 * (Char.IsUpper(c) ? 1 : 0) + (int)(Char.ToUpper(c) - 64);
        }

        public static int Part1(IEnumerable<string> input)
        {
            int total = 0;
            foreach(string sack in input)
            {
                total += Priority(FindItem(sack));
            }
            return total;
        }
    }       
}