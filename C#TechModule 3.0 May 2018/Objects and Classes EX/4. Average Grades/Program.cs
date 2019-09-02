using System;
using System.Collections.Generic;

namespace _4._Average_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class Student
    {
        public Student(string name, double[] grades)
        {
            this.Name = name;
            this.Grades = grades;
        }
        public string Name { get; set; }
        public double[] Grades { get; set; }

    }

        

}
