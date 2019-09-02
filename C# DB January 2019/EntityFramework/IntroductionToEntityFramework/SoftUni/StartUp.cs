namespace SoftUni
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                string result = GetEmployeesByFirstNameStartingWithSa(context);

                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId);

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)

                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName);

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return builder.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            var employee = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            employee.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.AddressText}");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                                                         p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(p => new
                        {
                            p.Project.Name,
                            p.Project.StartDate,
                            p.Project.EndDate
                        })
                        .ToList()
                })
                .Take(10)
                .ToList();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.EmployeeFullName} - Manager: {e.ManagerFullName}");

                foreach (var p in e.Projects)
                {
                    var startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    var endDate = p.EndDate.HasValue ?
                        p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) :
                        "not finished";

                    builder.AppendLine($"--{p.Name} - {startDate} - {endDate}");
                }
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(x => x.EmployeeCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                builder.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                                    .Where(p => p.EmployeeId == 147)
                                    .Select(p => new
                                    {
                                        ProjectName = p.Project.Name
                                    })
                                    .OrderBy(p => p.ProjectName)
                                    .ToList()
                })
                .ToList();

            foreach (var e in employee)
            {
                builder.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.Projects)
                {
                    builder.AppendLine(p.ProjectName);
                }
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    EmployeesCount = d.Employees
                                    .Select(e => new
                                    {
                                        e.FirstName,
                                        e.LastName,
                                        e.JobTitle
                                    })
                                    .OrderBy(e => e.FirstName)
                                    .ThenBy(e => e.LastName)
                                    .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                builder.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");

                foreach (var employee in department.EmployeesCount)
                {
                    builder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var projects = context.Projects
                .Where(p => p.EndDate == null)
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var p in projects)
            {
                builder.AppendLine(p.Name);
                builder.AppendLine(p.Description);
                builder.AppendLine(p.StartDate);
            }

            return builder.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }
            return builder.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                builder.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return builder.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var project = context.Projects.FirstOrDefault(p => p.ProjectId == 2);

            var employeesProjects = context.EmployeesProjects
                .Where(p => p.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(employeesProjects);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => new
                {
                    p.Name
                })
                .ToList();

            foreach (var p in projects)
            {
                builder.AppendLine(p.Name);
            }

            return builder.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employeeTowns = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var t in employeeTowns)
            {
                t.Address = null;
            }

            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            return $"{addresses.Count} addresses in Seattle were deleted";
        }
    }
}
