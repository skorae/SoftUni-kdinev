using System;

namespace Different_Numberss
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            if (second - first < 5)
            {
                Console.WriteLine("No");
                return;
            }

            for (int i = first; i <= second; i++)
            {
                for (int j = first; j <= second; j++)
                {
                    for (int k = first; k <= second; k++)
                    {
                        for (int l = first; l <= second; l++)
                        {
                            for (int m = first; m <= second; m++)
                            {
                                if (first <= i && i < j && j < k && k < l && l < m && m <= second)
                                {
                                    Console.WriteLine($"{i} {j} {k} {l} {m}");
                                }
                            }
                        }

                    }
                }
            }
        }
    }
}
