namespace Chronometer.IO
{
    using System;

    using Chronometer.IO.Contracts;

    public class Reader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
