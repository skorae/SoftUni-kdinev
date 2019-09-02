using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-L5A0R6C\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContextClass(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                IsEmployed = true,
                DepartmentId = context.Departments.First().Id,
            });

            Employee employee = context.Employees.Last();

            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
