using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string namesPatter = "[A-Za-z]+";
            string tpatt = @"[\w]+";

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(';');

                if (arr.Length < 3)
                {
                    continue;
                }
                string tempSender = arr[0].ToString();
                string tempReceiver = arr[1].ToString();
                string tempMessage = arr[2].ToString();

                string sender = "";
                string receiver = "";
                string message = "";

                if (tempSender.Contains("s:"))
                {
                    sender = tempSender.Remove(0, 2);
                }
                else
                {
                    continue;
                }
                if (tempReceiver.Contains("r:"))
                {
                    receiver = tempReceiver.Remove(0, 2);
                }
                else
                {
                    continue;
                }
                if (tempMessage.Contains("m--"))
                {
                    message = tempMessage.Remove(0, 3);
                }
                else
                {
                    continue;
                }

                string namePatter = "[A-Za-z]+ ?";
                string digits = @"\d";
                string messagePat = "[A-Za-z]+ *";

                Regex regex = new Regex(digits);
                Regex names = new Regex(messagePat);
                Regex nnn = new Regex(messagePat);

                MatchCollection matches = regex.Matches(tempSender);
                MatchCollection matchess = regex.Matches(tempReceiver);

                foreach (var d in matches)
                {
                    sum += int.Parse(d.ToString());
                }
                foreach (var d in matchess)
                {
                    sum += int.Parse(d.ToString());
                }

                string printSender = string.Join("", nnn.Matches(sender));
                string printReceiver = string.Join("", nnn.Matches(receiver));

                string printMessage = string.Join("", names.Matches(message));

                Console.WriteLine($"{printSender} says \"{ printMessage}\" to {printReceiver}");
            }
            Console.WriteLine($"Total data transferred: {sum}MB");
        }
    }
}
