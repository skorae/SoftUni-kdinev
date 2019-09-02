using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {

        public static TimeSpan GetPassedDays(string startDate, string endDate)
        {
            int[] start = startDate.Split(" ").Select(int.Parse).ToArray();
            int[] end = endDate.Split(" ").Select(int.Parse).ToArray();
            
            DateTime s = new DateTime(start[0],start[1],start[2]);
            DateTime e = new DateTime(end[0],end[1],end[2]);

            TimeSpan diff = e.Subtract(s);

            return diff;
        }
    }
}
