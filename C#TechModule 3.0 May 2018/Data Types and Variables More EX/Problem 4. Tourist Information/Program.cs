using System;

namespace Problem_4._Tourist_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string imperialValue = Console.ReadLine();
            decimal valueToConvert = decimal.Parse(Console.ReadLine());
            string output = "";
            decimal temp = 0.0m;

            switch (imperialValue)
            {
                case "miles":
                    output = "kilometers";
                    Math.Abs(temp = valueToConvert * 1.6m);
                    break;
                case "inches":
                    output = "centimeters";
                    Math.Abs(temp = valueToConvert * 2.54m);
                    break;
                case "feet":
                    output = "centimeters";
                    Math.Abs(temp = valueToConvert * 30m);
                    break;
                case "yards":
                    output = "meters";
                    Math.Abs(temp = valueToConvert * 0.91m);
                    break;
                case "gallons":
                    output = "liters";
                    Math.Abs(temp = valueToConvert * 3.8m);
                    break;
            }
            Console.WriteLine($"{valueToConvert} {imperialValue} = {temp:F2} {output}");
        }
    }
}
