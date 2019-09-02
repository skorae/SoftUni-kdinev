using System;

namespace Blank_Receipt
{
    class Program
    {
        static void Main(string[] args)
        {
            printReceiptHeader();
            printReceiptBody();
            printReceiptFooter();

        }
        static void printReceiptHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
        static void printReceiptBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }
        static void printReceiptFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\u00A9 SoftUni");
        }
    }
}
