using System;

namespace Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            try
            {
                sbyte sByte = sbyte.Parse(n);
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
