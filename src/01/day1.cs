using System;
using System.Collections;
using System.Linq;
using System.IO;

namespace AOC2022
{
    class Day1
    {
        public static void Run()
        {
            IEnumerable<string> input = File.ReadLines("src/01/input.txt");
            var totals = GetTotals(input).OrderByDescending(elf => elf);
            Console.WriteLine(Part1(totals));
            Console.WriteLine(Part2(totals));
        }

        private static IEnumerable<int> GetTotals(IEnumerable<string> input)
        {
            int total = 0;
            foreach(var line in input)
            {
                if(String.IsNullOrWhiteSpace(line))
                {
                    yield return total;
                    total = 0;
                }
                else
                {
                    total += int.Parse(line);
                }
            }
        }

        private static int Part1(IEnumerable<int> input)
        {  
            return input.First();
        }

        private static int Part2(IEnumerable<int> input)
        {
            
            return input.Take(3).Sum();
        }
    }
}