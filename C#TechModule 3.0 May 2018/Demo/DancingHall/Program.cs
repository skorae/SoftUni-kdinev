using System;

namespace DancingHall
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

            Console.WriteLine("Enter type of game: ");
            string level = Console.ReadLine().ToLower();
            int sum = int.Parse(bonus);
            bool isTrue = false;

            while (isTrue)
            {
                if (level != "vk" && level != "bk")
                {
                    Console.WriteLine("Note: If the card is a power card enter 1 after the number!");
                    Console.WriteLine("NO power cards on this game!");
                }
                else if (level == "pika" || level == "kupa" || level == "karo" || level == "spatiq" || level == "spatia" || level == "spatiya")
                {
                    Console.WriteLine("Note: If the card is a power card enter 1 after the number!");
                    Console.WriteLine("Power cards are Jack and 9!");
                }
                else
                {
                    Console.WriteLine("Type of game is Incorect!");
                    Console.WriteLine("Enter type of game: ");
                }
            }

            Console.WriteLine("Enter cards: ");
            string card = Console.ReadLine().ToLower();

            while (card != "end")
            {
                if (int.TryParse(card, out int x) == false)
                {
                    Console.WriteLine("Incorect card format!");
                    Console.Write("Enter card: ");
                    card = Console.ReadLine().ToLower();
                }

                switch (level)
                {
                    case "vk":
                        switch (x)
                        {
                            case 14: sum += 11; break;
                            case 13: sum += 4; break;
                            case 12: sum += 3; break;
                            case 11: sum += 20; break;
                            case 10: sum += 10; break;
                            case 9: sum += 14; break;
                            default:
                                Console.WriteLine("Incorrect card!");
                                Console.Write("Enter card: ");
                                card = Console.ReadLine();
                                continue;
                        }
                        break;
                    case "bk":
                        switch (x)
                        {
                            case 14: sum += 11; break;
                            case 13: sum += 4; break;
                            case 12: sum += 3; break;
                            case 11: sum += 2; break;
                            case 10: sum += 10; break;
                            default:
                                Console.WriteLine("Incorrect card!");
                                Console.Write("Enter card: ");
                                card = Console.ReadLine();
                                continue;
                        }
                        break;
                    default:
                        switch (x)
                        {
                            case 14: sum += 11; break;
                            case 13: sum += 4; break;
                            case 12: sum += 3; break;
                            case 121: sum += 20; break;
                            case 11: sum += 2; break;
                            case 10: sum += 10; break;
                            case 91: sum += 14; break;
                            default:
                                Console.WriteLine("Incorrect card!");
                                Console.WriteLine("Note: If the card is a power card enter 1 after the number!");
                                Console.WriteLine("Power cards are Jack and 9!");
                                Console.Write("Enter card: ");
                                card = Console.ReadLine();
                                continue;
                        }
                        break;
                }
                Console.WriteLine("Enter card: ");
                card = Console.ReadLine();
            }
            if (level == "bk")
            {
                sum *= 2;
            }
            Console.WriteLine($"Result: {sum}");
        }
    }
}
