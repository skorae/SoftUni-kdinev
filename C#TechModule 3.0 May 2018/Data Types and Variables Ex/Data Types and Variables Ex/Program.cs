using System;

namespace Variable_in_Heaxadeciaml_Format

{
    class Program
    {
        static void Main(string[] args)
        {
            string hexaDec = Console.ReadLine();

            int output = Convert.ToInt32(hexaDec, 16);

            Console.WriteLine(output);
        }
    }
}
