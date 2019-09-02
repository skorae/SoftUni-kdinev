using System;
using System.Text;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            string newStudent = Console.ReadLine();
            string newWorker = Console.ReadLine();

            StringBuilder builder = new StringBuilder();
            
            try
            {
                string[] studArr = newStudent.Split();

                string studentFirstName = studArr[0];
                string studentLastName = studArr[1];
                string facultyNumber = studArr[2];


                string[] workerArr = newWorker.Split();

                string firstName = workerArr[0];
                string lastName = workerArr[1];

                decimal weekSalary = decimal.Parse(workerArr[2]);
                decimal workHoursPerDay = decimal.Parse(workerArr[3]);

                Student student = new Student(studentFirstName, studentLastName, facultyNumber);
                builder.Append(student);
                builder.AppendLine();
                Worker worker = new Worker(firstName, lastName, weekSalary, workHoursPerDay);
                builder.Append(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
