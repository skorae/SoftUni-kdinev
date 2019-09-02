using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Slicing_File
{
    class Program
    {
        static List<string> paths;

        static void Main(string[] args)
        {
            paths = new List<string>();

            string sourceFile = "..//..//..//..//files//sliceMe.mp4";
            string destinationDirectory = "..//..//..//..//files//";
            int parts = int.Parse(Console.ReadLine());

            Slice(sourceFile, destinationDirectory, parts);
            Assemble(paths, destinationDirectory);
        }

        static void Assemble(List<string> paths, string destinationDirectory)
        {
            string assembled = destinationDirectory + "assembled.mp4";

            byte[] buffer = new byte[1024];

            using (FileStream writeFile = new FileStream(assembled, FileMode.Create))
            {
                foreach (var path in paths)
                {
                    using (GZipStream gzRead = new GZipStream(new FileStream(path + ".gz", FileMode.Open), CompressionMode.Decompress))
                    {
                        while (true)
                        {
                            int bytesCount = gzRead.Read(buffer, 0, buffer.Length);

                            if (bytesCount == 0)
                            {
                                break;
                            }
                            writeFile.Write(buffer, 0, bytesCount);
                        }

                    }
                }
            }
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                long totalLenght = readFile.Length / parts + readFile.Length % parts;

                byte[] buffer = new byte[totalLenght];

                for (int i = 0; i < parts; i++)
                {
                    string path = destinationDirectory + $"Part-{i}.mp4";
                    paths.Add(path);


                    using (FileStream writeFile = new FileStream(path, FileMode.Create))
                    {
                        int bytesCount = readFile.Read(buffer, 0, buffer.Length);
                        writeFile.Write(buffer, 0, buffer.Length);
                        ;
                    }
                    using (GZipStream gz = new GZipStream(new FileStream(path + ".gz", FileMode.Create), CompressionMode.Compress, false))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
