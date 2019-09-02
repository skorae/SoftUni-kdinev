using System;

namespace EXAM
{
    class Program
    {
        static void Main(string[] args)
        {
            int emp1 = int.Parse(Console.ReadLine());
            int emm2 = int.Parse(Console.ReadLine());
            int emp3 = int.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());

            int perH = emm2 + emp1 + emp3;
            double total = Math.Ceiling(studentCount * 1.0 / perH);

            for (int i = 1; i <= total; i++)
            {
                if (i % 4 ==0)
                {
                    total++;
                }
            }

            Console.WriteLine($"Time needed: {total}h.");

        }
    }
}
