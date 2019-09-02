using System;
using System.IO;

namespace Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//copyMe.png";

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (FileStream createCopy = new FileStream($"{path}..//..//copyMe-copy.png", FileMode.Create))
                {
                    file.CopyTo(createCopy);
                }
            }
        }
    }
}
