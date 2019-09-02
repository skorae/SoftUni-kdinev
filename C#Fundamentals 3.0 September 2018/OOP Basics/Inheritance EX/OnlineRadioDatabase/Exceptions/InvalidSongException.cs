using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : Exception
    {
        public InvalidSongException(string message = "Invalid song.") 
            : base(message)
        {
        }
    }
}
