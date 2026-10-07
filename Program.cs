using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace BattlingReindeer
{
    internal class Program
    {
        const int SIZE = 6;
        const int RACE_END = 100;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("**********************News Flash**************************");
            Console.WriteLine("Rudolph has injured his leg and cannot lead Santa's sleigh");
            Console.WriteLine("Santa is holding reindeer games to see who is the fastest ");
            Console.WriteLine("Whoever wins will lead the sleigh on Christmas eve.       ");
            Console.WriteLine();
            string[] names = new string[SIZE];
            int[] position = new int[SIZE];
            char[] printChar = new char[SIZE];
            addNamesAndPrintChar(names, printChar);
            bool winner = false;
            int winnerNumber;
            int rounds = 0;
            var rand = new Random();
            while (!winner)
            {
                printRound(ref rounds);
                changePositions(position, rand);
                roundResults(position, names, printChar);
                winnerNumber = checkForWinner(position, ref winner);
                if (winner)
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine($"   The winner is {names[winnerNumber]} with a score of {position[winnerNumber]}   ");
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine();
                    Console.WriteLine($"-------------------Result Summary------------------------");
                    for (int i = 0; i < SIZE; i++)
                    {
                        Console.WriteLine($"\tReinder: {names[i]}   \tScore: {position[i]} ");
                    }
                }

            }

        }

        private static void addNamesAndPrintChar(string[] names, char[] printChar)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write($"Enter the reindeer's name: ");
                string tempName = Console.ReadLine();
                while (String.IsNullOrEmpty(tempName) && String.IsNullOrWhiteSpace(tempName))
                {
                    Console.WriteLine("You have entered an invalid name, please try again");
                    tempName = Console.ReadLine();
                }
                names[i] = tempName;
                Console.Write($"Enter a print character for {names[i]}  ");
                string tempChar = Console.ReadLine();
                while (String.IsNullOrEmpty(tempChar) && String.IsNullOrWhiteSpace(tempChar))
                {
                    Console.WriteLine("Please enter a valid character!");
                    tempChar = Console.ReadLine();
                }
                printChar[i] = Convert.ToChar(tempChar);
            }
            Console.WriteLine("The contestants are ready to race...");
        }

        private static void printRound(ref int rounds)
        {
            rounds++;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n\n---------------------Round# {rounds}-----------------------\n");
        }

        private static void changePositions(int[] position, Random rand)
        {
            for (int i = 0; i < position.Length; i++)
            {
                position[i] += rand.Next(1, 11);
            }

        }

        static void roundResults(int[] position, string[] names, char[] printChar)
        {
            Console.WriteLine();
            for (int i = 0; i < SIZE; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{names[i]}: ");
                for (int distance = 0; distance < position[i]; distance++)
                {
                    Console.Write(printChar[i]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
            return;
        }

        private static int checkForWinner(int[] position, ref bool winner)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int winningPosition = -1;
            for (int i = 0; i < position.Length && !winner; i++)
            {
                if (position[i] >= RACE_END)
                {
                    winner = true;
                    winningPosition = i;
                    Console.WriteLine("**********************News Flash**************************");
                    Console.WriteLine("                   We have a winner...                    ");
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine();
                    continue;
                }
            }
            return winningPosition;
        }
    }
}