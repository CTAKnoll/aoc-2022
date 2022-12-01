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
            Console.WriteLine(Part1(input));
            Console.WriteLine(Part2(input));
        }

        private static List<int> GetTotals(IEnumerable<string> input)
        {
            List<int> totals = new();
            int total = 0;
            foreach(var line in input)
            {
                if(String.IsNullOrWhiteSpace(line))
                {
                    totals.Add(total);
                    total = 0;
                }
                else
                {
                    total += int.Parse(line);
                }
            }
            return totals;
        }

        private static int Part1(IEnumerable<string> input)
        {  
            return GetTotals(input).OrderByDescending(elf => elf).First();
        }

        private static int Part2(IEnumerable<string> input)
        {
            
            return GetTotals(input).OrderByDescending(elf => elf).Take(3).Sum();
        }
    }
}