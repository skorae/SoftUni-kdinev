using System;

namespace ClassBox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                decimal length = decimal.Parse(Console.ReadLine());
                decimal width = decimal.Parse(Console.ReadLine());
                decimal height = decimal.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                box.GetArea(length, width, height);
                box.GetLateralArea(length, width, height);
                box.Volume(length, width, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
