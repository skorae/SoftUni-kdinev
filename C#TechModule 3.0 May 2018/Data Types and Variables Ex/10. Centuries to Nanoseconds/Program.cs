using System;
using System.Numerics;

namespace _10._Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());

            ushort years = (ushort)(centuries * 100);
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
            long seconds = minutes * 60L;
            long millisecond = seconds * 1000;
            BigInteger microseconds = millisecond * 1000;
            BigInteger nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {millisecond} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
