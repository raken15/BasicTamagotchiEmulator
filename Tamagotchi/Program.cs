using System;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your Tamagotchi's name:");
            string name = Console.ReadLine() ?? string.Empty;
            if(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid name. Quitting the program");
                return;
            }
            TamagotchiLogic tamagotchi = new TamagotchiLogic(name);
            bool isAlive = true;

            while(isAlive)
            {
                Console.Clear();
                tamagotchi.ShowStatus();
                Console.WriteLine("What do you want to do? (Feed, Play, Sleep, Show Status, Quit)");
                if(!tamagotchi.CurrentlyUpdating)
                {
                    string choice = Console.ReadLine() ?? string.Empty;
                    switch (choice.ToLower())
                    {
                        case "feed":
                            tamagotchi.Feed();
                            System.Threading.Thread.Sleep(3000);
                            break;
                        case "play":
                            tamagotchi.Play();
                            System.Threading.Thread.Sleep(3000);
                            break;
                        case "sleep":
                            tamagotchi.Sleep();
                            System.Threading.Thread.Sleep(3000);
                            break;
                        case "show status":
                            tamagotchi.ShowStatus();
                            System.Threading.Thread.Sleep(3000);
                            break;
                        case "Quit":
                            Console.WriteLine("Goodbye!");
                            isAlive = false;
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}