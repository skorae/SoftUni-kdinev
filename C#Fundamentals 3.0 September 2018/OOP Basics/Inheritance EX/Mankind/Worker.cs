using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal? WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value < 10 || value == null)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = (decimal)value;
            }
        }

        public decimal? WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12 || value == null)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }

                workHoursPerDay = (decimal)value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"First Name: {base.FirstName}");
            builder.AppendLine($"Last Name: {base.LastName}");
            builder.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            builder.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
            builder.AppendLine($"Salary per hour: {CalculateSalary():f2}");

            return builder.ToString();
        }

        private decimal CalculateSalary()
        {
            return ((decimal)this.WeekSalary / 5m) / (decimal)this.WorkHoursPerDay;
        }
    }
}
