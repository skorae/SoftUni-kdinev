using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                string name = arr[0];
                double grade = double.Parse(arr[1]);

                if (dictionary.ContainsKey(name) == false)
                {
                    dictionary.Add(name, new List<double>());
                    dictionary[name].Add(grade);
                }
                else
                {
                    dictionary[name].Add(grade);
                }
            }

            foreach (var k in dictionary)
            {
                Console.WriteLine($"{k.Key} -> {string.Join(" ",k.Value.Select(x => string.Format("{0:f2}", x)))} (avg: {k.Value.Average():f2})");
            }
        }
    }
}
