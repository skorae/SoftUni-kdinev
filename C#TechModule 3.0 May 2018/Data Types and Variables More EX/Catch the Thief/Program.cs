using System;

namespace Catch_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeID = Console.ReadLine();
            byte n = byte.Parse(Console.ReadLine());
            long diff = long.MinValue;

            for (int i = 0; i < n; i++)
            {
                string num = Console.ReadLine();
                long temp = 0;
                switch (typeID)
                {
                    case "sbyte":
                        if (sbyte.TryParse(num, out sbyte x))
                        {
                            temp = x;
                            if (diff <= temp && temp <= sbyte.MaxValue)
                            {
                                diff = temp;
                            }
                        }
                        break;
                    case "int":
                        if (int.TryParse(num, out int y))
                        {
                            temp = y;
                            if (diff <= temp && temp <= int.MaxValue)
                            {
                                diff = temp;
                            }
                        }
                        break;
                    case "long":
                        if (long.TryParse(num, out long k))
                        {
                            temp = k;
                            if (diff <= temp && temp <= long.MaxValue)
                            {
                                diff = temp;
                            }
                        }
                        break;
                }
            }
            double sentence = 0.0;
            if (diff <= 0)
            {
                sentence = Math.Abs(diff * 1.0 / -128);
            }
            else
            {
                sentence = Math.Abs(diff* 1.0 / 127);
            }
            if (sentence > 1)
            {
                Console.WriteLine($"Prisoner with id {diff} is sentenced to {Math.Ceiling(sentence)} years");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {diff} is sentenced to {Math.Ceiling(sentence)} year");
            }

        }
    }
}
