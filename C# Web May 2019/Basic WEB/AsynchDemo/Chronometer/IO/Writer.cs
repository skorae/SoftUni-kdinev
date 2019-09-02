namespace Chronometer.IO
{
    using System;

    using Chronometer.IO.Contracts;

    public class Writer : IWriter
    {
        public void Write(string result)
        {
            Console.WriteLine(result);
        }

    }
}
