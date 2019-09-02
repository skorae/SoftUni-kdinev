using System;

namespace Problem_14._Boat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int fmoves = 0;
            int smoves = 0;

            for (int i = 1; i <= n; i++)
            {
                string moves = Console.ReadLine();

                if (moves == "UPGRADE")
                {
                    first = (char)(first + 3);
                    second = (char)(second + 3);
                    continue;
                }
                if (i % 2 !=0)
                {
                    fmoves += moves.Length;
                }
                else
                {
                    smoves += moves.Length;
                }

                if (fmoves >= 50)
                {
                    Console.WriteLine($"{first}");
                    return;
                }
                else if (smoves >= 50)
                {
                    Console.WriteLine($"{second}");
                    return;
                }
            }
            if (fmoves > smoves)
            {
                Console.WriteLine($"{first}");
            }
            else
            {
                Console.WriteLine($"{second}");
            }
        }
    }
}
