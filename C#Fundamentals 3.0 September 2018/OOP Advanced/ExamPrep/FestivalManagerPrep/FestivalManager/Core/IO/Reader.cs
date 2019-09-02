using FestivalManager.Core.IO.Contracts;
using System;

namespace FestivalManager.Core.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
