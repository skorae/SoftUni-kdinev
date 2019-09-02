﻿using System;

namespace Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int cen = int.Parse(Console.ReadLine());

            int years = cen * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine($"{cen} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}