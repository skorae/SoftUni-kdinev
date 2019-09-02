using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interface;

namespace Telephony.Phone
{
    public class Smartphone : ICallable, IBrowsable
    {
        private List<string> numbers;
        private List<string> webSites;

        public Smartphone(string[] numbers, string[] sites)
        {
            this.Numbers = numbers.ToList();
            this.WebSites = sites.ToList();
        }

        public List<string> Numbers
        {
            get { return numbers; }
            set { numbers = value; }
        }

        public List<string> WebSites
        {
            get { return webSites; }
            set { webSites = value; }
        }

        public void Browse()
        {
            foreach (var w in WebSites)
            {
                if (w.Any(c => Char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                Console.WriteLine($"Browsing: {w}!");
            }
        }

        public void Call()
        {
            foreach (var n in this.Numbers)
            {
                if (n.Any(c => !Char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                Console.WriteLine($"Calling... {n}");
            }
        }
    }
}
