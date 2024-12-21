using System;

namespace Tamagotchi
{
    public class TamagotchiLogic
    {
        public int Hunger { get; set; }
        public int Happiness { get; set; }
        public int Energy { get; set; }
        public TamagotchiLogic()
        {
            Hunger = 50;
            Happiness = 50;
            Energy = 50;
        }
        public void Feed()
        {
            Hunger = Math.Max(0, Hunger - 10);
            Console.WriteLine("You fed the Tamagotchi. Hunger decreased!");
        }
        public void Play()
        {
            if(Energy > 10)
            {
                Happiness = Math.Min(100, Happiness + 10);
                Energy = Math.Max(0, Energy - 10);
                Console.WriteLine("You played with the Tamagotchi. Happiness increased and Energy decreased!");
            }
            else
            {
                Console.WriteLine("The Tamagotchi is too tired to play.");
            }
        }
        public void Sleep()
        {
            Energy = Math.Min(100, Energy + 20);
            Console.WriteLine("You let the Tamagotchi sleep. Energy increased!");
        }
        public void ShowStatus()
        {
            Console.WriteLine($"\n--- Tamagotchi Status ---");
            Console.WriteLine($"Hunger: {Hunger}");
            Console.WriteLine($"Happiness: {Happiness}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine("-------------------------\n");
        }
    }
}