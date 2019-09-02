using System;

namespace Photo_Galery
{
    class Program
    {
        static void Main(string[] args)
        {
            int photoNumber = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int widhtPhoto = int.Parse(Console.ReadLine());
            int lenghtPhoto = int.Parse(Console.ReadLine());
            string orientation = "";
            

            Console.WriteLine($"Name: DSC_{photoNumber:D4}.jpg");
            Console.WriteLine($"Date Taken: {day:d2}/{month:d2}/{year} {hours:d2}:{minutes:d2}");

            if (size < 1000)
            {
                                Console.WriteLine($"Size: {size}B");
            }
            else if (size < 1000000)
            {
               size /= 1000;
                Console.WriteLine($"Size: {size}KB");
            }
            else
            {
                size /= 1000000;
                Console.WriteLine($"Size: {size}MB");
            }

            if (widhtPhoto == lenghtPhoto)
            {
                orientation = "square";
            }
            else if (widhtPhoto < lenghtPhoto)
            {
                orientation = "portrait";
            }
            else
            {
                orientation = "landscape";
            }
            Console.WriteLine($"Resolution: {widhtPhoto}x{lenghtPhoto} ({orientation})");
        }
    }
}
