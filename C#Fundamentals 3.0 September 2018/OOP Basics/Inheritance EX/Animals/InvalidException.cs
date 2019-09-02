using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class InvalidException : Exception
    {
        public InvalidException(string message = "Invalid input!") 
            : base(message)
        {
        }
    }
}
