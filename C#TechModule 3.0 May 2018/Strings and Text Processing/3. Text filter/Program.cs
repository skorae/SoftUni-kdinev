using System;
using System.Diagnostics;

namespace _3._Text_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string[] replaceWord = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text =  Console.ReadLine();

            foreach (var banword in replaceWord)
            {
                if (text.Contains(banword))
                {
                    text = text.Replace(banword, new string('*', banword.Length));
                }
            }

            Console.WriteLine(text);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }
    }
}
