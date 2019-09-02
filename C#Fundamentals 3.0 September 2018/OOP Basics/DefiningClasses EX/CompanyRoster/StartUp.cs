using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = arr[0];
                decimal salary = decimal.Parse(arr[1]);
                string positon = arr[2];
                string department = arr[3];

                Employee employee = new Employee(name, salary, positon, department);

                if (arr.Length == 5)
                {
                    if (arr[4].Contains('@'))
                    {
                        employee.Email = arr[4];
                    }
                    else
                    {
                        employee.Age = int.Parse(arr[4]);
                    }

                }
                else if (arr.Length == 6)
                {
                    employee.Email = arr[4];
                    employee.Age = int.Parse(arr[5]);
                }
                employees.Add(employee);
            }

            var topDepartment = employees
                                .GroupBy(x => x.Department)
                                .ToDictionary(x => x.Key, y => y.Select(s => s))
                                .OrderByDescending(v => v.Value.Average(s => s.Salary));

            Console.WriteLine($"Highest Average Salary: {topDepartment.FirstOrDefault().Key}");

            foreach (var employee in topDepartment.FirstOrDefault().Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
