using System;
using System.Collections;
using System.Linq;
using System.IO;

namespace AOC2022
{
    class Day2
    {
        public static void Run()
        {
            IEnumerable<string> input = File.ReadLines("src/02/input.txt");
            Console.WriteLine(Part1(input));
            Console.WriteLine(Part2(input));
        }

        private enum Choice
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3,  
        }

        private enum WinStatus
        {
            Lose = 0,
            Draw = 3,
            Win = 6
        }

        private static Choice MapToChoice(string choice)
        {
            switch(choice)
            {
                case "A":
                case "X": return Choice.Rock;
                case "B":
                case "Y": return Choice.Paper;
                case "C":
                case "Z": return Choice.Scissors;
                default: return Choice.Rock;
            }
        }

        private static WinStatus MapToStatus(string choice)
        {
            switch(choice)
            {
                case "A":
                case "X": return WinStatus.Lose;
                case "B":
                case "Y": return WinStatus.Draw;
                case "C":
                case "Z": return WinStatus.Win;
                default: return WinStatus.Lose;
            }
        }

        private static WinStatus GetStatus(Choice you, Choice opp)
        {
            if(you == Choice.Rock)
                return opp == Choice.Rock ? WinStatus.Draw : opp == Choice.Paper ? WinStatus.Lose : WinStatus.Win;
            if(you == Choice.Paper)
                return opp == Choice.Rock ? WinStatus.Win : opp == Choice.Paper ? WinStatus.Draw : WinStatus.Lose;
            if(you == Choice.Scissors)
                return opp == Choice.Rock ? WinStatus.Lose : opp == Choice.Paper ? WinStatus.Win : WinStatus.Draw;
            return WinStatus.Lose;
        }

        private static Choice GetChoice(Choice opp, WinStatus outcome)
        {
            if(opp == Choice.Rock)
                return outcome == WinStatus.Win ? Choice.Paper : outcome == WinStatus.Draw ? Choice.Rock : Choice.Scissors;
            if(opp == Choice.Paper)
                return outcome == WinStatus.Win ? Choice.Scissors : outcome == WinStatus.Draw ? Choice.Paper : Choice.Rock;
            if(opp == Choice.Scissors)
                return outcome == WinStatus.Win ? Choice.Rock : outcome == WinStatus.Draw ? Choice.Scissors : Choice.Paper;
            return Choice.Rock;
        }

        private static int Score(Choice you, WinStatus status)
        {
            return (int) you + (int) status;
        }


        private static int Part1(IEnumerable<string> input)
        {  
            int total = 0;
            foreach(string match in input)
            {
                var fighters = match.Split(" ");
                Choice you = MapToChoice(fighters[1]);
                Choice opp = MapToChoice(fighters[0]);
                WinStatus outcome = GetStatus(you, opp);
                total += Score(you, outcome);
            }
            return total;
        }

        private static int Part2(IEnumerable<string> input)
        {  
            int total = 0;
            foreach(string match in input)
            {
                var fighters = match.Split(" ");
                Choice opp = MapToChoice(fighters[0]);
                WinStatus outcome = MapToStatus(fighters[1]);
                Choice you = GetChoice(opp, outcome);
                total += Score(you, outcome);
            }
            return total;
        }
    }
}