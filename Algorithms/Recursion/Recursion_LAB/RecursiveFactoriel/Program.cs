using System;

namespace RecursiveFactoriel
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int factoriel = Factoriel(n, 1);

            Console.WriteLine(factoriel);
        }

        private static int Factoriel(int n, int currentNumber)
        {
            if (currentNumber > n)
            {
                return 1;
            }

            int factoriel = currentNumber * Factoriel(n, currentNumber + 1);

            return factoriel;
        }
    }
}
