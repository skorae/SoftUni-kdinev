using System;

namespace _18._Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            bool isTrue = long.TryParse(n, out long lOng);

            if (isTrue == false)
            {
                Console.WriteLine($"{n} can't fit in any type");
                return;
            }
            else
            {

                Console.WriteLine($"{n} can fit in:");
                if (sbyte.TryParse(n, out sbyte sByte))
                {
                    Console.WriteLine("* sbyte");
                }
                if (byte.TryParse(n, out byte bYte))
                {
                    Console.WriteLine("* byte");
                }
                if (short.TryParse(n, out short sHort))
                {
                    Console.WriteLine("* short");
                }
                if (ushort.TryParse(n, out ushort uShort))
                {
                    Console.WriteLine("* ushort");
                }
                if (int.TryParse(n, out int iNt))
                {
                    Console.WriteLine("* int");
                }
                if (uint.TryParse(n, out uint uInt))
                {
                    Console.WriteLine("* uint");
                }

                Console.WriteLine("* long");
            }
        }
    }
}