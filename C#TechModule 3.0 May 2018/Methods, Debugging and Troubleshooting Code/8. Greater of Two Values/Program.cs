using System;

namespace _8._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());
                    int result = GetMax(firstNumber, secondNumber);
                    Console.WriteLine(result);
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    char resultCH = GetMax(firstChar, secondChar);
                    Console.WriteLine(resultCH);
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    string resultSTR = GetMax(firstString, secondString);
                    Console.WriteLine(resultSTR);
                    break;
            }
        }

        static int GetMax(int first, int second)
        {
            return Math.Max(first, second);
        }

        static char GetMax(char first, char second)
        {
            return (char)Math.Max(first, second);
        }

        static string GetMax(string first, string second)
        {
            if (first.CompareTo(second) >= 0)
            {
                return first;
            }
            return second;
        }

    }
}

