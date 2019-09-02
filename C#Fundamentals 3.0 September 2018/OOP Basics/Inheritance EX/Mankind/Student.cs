using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facilityNumber;

        public Student(string firstName, string lastName, string facilityNumber)
            : base(firstName, lastName)
        {
            this.FacilityNumber = facilityNumber;
        }

        public string FacilityNumber
        {
            get { return facilityNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10 || value.Any(x => !char.IsLetterOrDigit(x)))
                {
                    throw new ArgumentException($"Invalid faculty number!");
                }
                facilityNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"First Name: {base.FirstName}");
            builder.AppendLine($"Last Name: {base.LastName}");
            builder.AppendLine($"Faculty number: {this.FacilityNumber}");

            return builder.ToString();
        }
    }
}
