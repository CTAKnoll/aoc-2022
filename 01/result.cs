using System;
using System.Collections;
using System.Linq;
using System.IO;

namespace AOC2022
{
    class Day1
    {
        public static void Main(string[] args)
        {
            IEnumerable<string> lines = File.ReadLines("input.txt");
            int total = 0;
            int most = 0;
            foreach(var line in lines)
            {
                if(String.IsNullOrWhiteSpace(line))
                {
                    if(total > most)
                        most = total;
                    total = 0;
                }
                total += int.Parse(line);
            }
            Console.WriteLine(most);
        }
    }
}