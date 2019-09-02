using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Add bonus: ");

            string bonus = Console.ReadLine();
            
            while (int.TryParse(bonus, out int x) != true)
            {
                if (x % 10 != 0)
                {
                    Console.WriteLine("Bonus was in incorrect format!");
                    Console.Write("Add bonus: ");
                    bonus = Console.ReadLine();
                    continue;
                }
                Console.WriteLine("Bonus was in incorrect format!");
                Console.Write("Add bonus: ");
                bonus = Console.ReadLine();
            }

            while (int.Parse(bonus) % 10 != 0)
            {
                Console.WriteLine("Bonus was in incorrect format!");
                Console.Write("Add bonus: ");
                bonus = Console.ReadLine();
            }

            Console.WriteLine("Valid game types are:");
            string[] types = { "VK - All Koz", "BK - No Koz", "Pika", "Kupa", "Karo", "Spatiq, Spatia, Spatiya" };
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {types[i]}");
            }
            Console.WriteLine("Enter type of game: ");
            string level = Console.ReadLine().ToLower();
            bool isTrue = false;

            if (types.Contains(level) == false)
            {
                while (isTrue)
                {
                    if (types.Contains(level))
                    {
                        break;
                    }
                    Console.WriteLine("Game type is incorect!");
                    Console.WriteLine("Enter type of game: ");
                    level = Console.ReadLine().ToLower();
                }
            }

            Console.WriteLine(@"Note: Add ""p"" if the card is a power card!");
            if (level == "pika" || level == "kupa" || level == "karo" || level == "spatiq" || level == "spatia" || level == "spatiya" ||
                level == "1" || level == "2" || level == "3" || level == "4" || level == "5" || level == "6")
            {
                Console.WriteLine(@"Only the ""Jack"" card is considered a power card in this type of game!");
            }
            else
            {
                Console.WriteLine("There are no power cards in this type of game!");
            }

            Console.WriteLine("Add cards: ");
            string cards = Console.ReadLine();
            int sum = 0;
            
            switch (level)
            {
                case "vk":
                case "1":
                    for (int i = 0; i < cards.Length; i++)
                    {
                        switch (cards[i])
                        {
                            case 'a': sum += 11; break;
                            case 'k': sum += 4; break;
                            case 'q': sum += 3; break;
                            case 'j': sum += 20; break;
                            case '1': sum += 10; i++; break;
                            case '9': sum += 14; break;
                        }
                    }
                    sum += int.Parse(bonus);
                    break;
                case "bk":
                case "2":
                    for (int i = 0; i < cards.Length; i++)
                    {
                        switch (cards[i])
                        {
                            case 'a': sum += 11; break; 
                            case 'k': sum += 4; break; 
                            case 'q': sum += 3; break; 
                            case 'j': sum += 2; break; 
                            case '1': sum += 10; i++; break; 
                        }
                    }
                    sum = (sum * 2) + int.Parse(bonus);
                    break;
                default:
                    for (int i = 0; i < cards.Length; i++)
                    {
                        switch (cards[i])
                        {
                            case 'a': sum += 11; break;
                            case 'k': sum += 4; break;
                            case 'q': sum += 3; break;
                            case 'j': sum += 2;
                                if (cards[i + 1] == 'p')
                                {
                                    sum += 18;
                                    i++;
                                }
                                break;
                            case '1': sum += 10; i++; break;
                            case '9': sum += 14; break;
                        }
                    }
                    sum += int.Parse(bonus);
                    break;
                    
            }

            Console.Write($"Your score is: {sum}");
        }
    }
}