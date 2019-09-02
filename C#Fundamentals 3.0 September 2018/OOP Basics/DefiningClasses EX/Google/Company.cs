using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Company
    {
        private string name;
        private string department;
        private decimal salary;

        public Company(string name,string department,decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}
