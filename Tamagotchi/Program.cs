using System;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
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
                tamagotchi.MyTimer.Start();
                Console.Clear();
                tamagotchi.ShowStatus();
                Console.WriteLine("What do you want to do? (Feed, Play, Sleep, Show Status, Quit)");
                if(!tamagotchi.CurrentlyUpdating)
                {
                    string choice = Console.ReadLine() ?? string.Empty;
                    switch (choice.ToLower())
                    {
                        case "feed":
                            tamagotchi.MyTimer.Stop();
                            tamagotchi.Feed();
                            System.Threading.Thread.Sleep(3000);
                            break;
                        case "play":
                            tamagotchi.MyTimer.Stop();
                            tamagotchi.Play();
                            System.Threading.Thread.Sleep(3000);
                            break;
                        case "sleep":
                            tamagotchi.MyTimer.Stop();
                            tamagotchi.Sleep();
                            System.Threading.Thread.Sleep(3000);
                            break;
                        case "show status":
                            tamagotchi.MyTimer.Stop();
                            tamagotchi.ShowStatus();
                            System.Threading.Thread.Sleep(3000);
                            break;
                        case "quit":
                            tamagotchi.MyTimer.Stop();
                            Console.WriteLine("Goodbye!");
                            isAlive = false;
                            return;
                        default:
                            tamagotchi.MyTimer.Stop();
                            Console.WriteLine("Invalid choice. Please try again.");
                            System.Threading.Thread.Sleep(3000);
                            break;
                    }
                }
            }
        }
    }
}