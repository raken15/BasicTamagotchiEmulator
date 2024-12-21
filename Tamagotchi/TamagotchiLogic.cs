using System;
using System.Timers;

namespace Tamagotchi
{
    public class TamagotchiLogic
    {
        private const int INTERVAL = 20;
        public System.Timers.Timer MyTimer { get; set; }
        public bool CurrentlyUpdating { get; set; }
        public string Name { get; set; }
        public int Food { get; set; }
        public int Happiness { get; set; }
        public int Energy { get; set; }
        public TamagotchiLogic(string name)
        {
            Name = name;
            Food = 50;
            Happiness = 50;
            Energy = 50;
            CurrentlyUpdating = false;
            MyTimer = new System.Timers.Timer(); // 20000 milliseconds = 20 seconds
            MyTimer.Interval = TimeSpan.FromSeconds(INTERVAL).TotalMilliseconds;
            MyTimer.Elapsed += OnTimedEvent; // Attach the event handler
            MyTimer.AutoReset = true; // Repeat every 20 seconds
            MyTimer.Enabled = true; // Start the timer
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            CurrentlyUpdating = true;
            // Decrease Food by 2 and happiness by 1 every 20 seconds
            Food = Math.Max(0, Food - 2);
            Happiness = Math.Max(0, Happiness - 1);
            ShowStatus();
            Console.WriteLine("Food decreased and Happiness decreased!");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("What do you want to do? (Feed, Play, Sleep, Show Status, Quit)");
            CurrentlyUpdating = false;
        }
        public void Feed()
        {
            Food = Math.Min(100, Food + 10);
            Console.WriteLine(@"
    /\_/\  
   ( o_o )  *Yummy!*  
    > ^ <   *Munching on food...*  
   *Beep Beep!*   
            ");
            Console.WriteLine(@"
    /\_/\  
   ( o.o )  *Yummy!*  
    > ^ <   *Munching on food...*  
   *Beep Beep!*   
            ");
            Console.WriteLine($"You fed {Name}. Food decreased!");
        }
        public void Play()
        {
            if(Energy > 10)
            {
                Happiness = Math.Min(100, Happiness + 10);
                Energy = Math.Max(0, Energy - 10);
                Console.WriteLine(@"
    /\_/\  
   ( ^.^ )  *Woohoo!*  
    > ^ <   *Playing around...*  
   *Beep Beep!*   
            ");
                Console.WriteLine($"You played with {Name}. Happiness increased and Energy decreased!");
                
            }
            else
            {
                Console.WriteLine(@"
    /\_/\  
   ( -.- )  *Zzz...*  
    > ^ <   *Too tired to play...*  
   *Beep Beep!*   
            ");
                Console.WriteLine($"{Name} is too tired to play.");
            }
        }
        public void Sleep()
        {
            Energy = Math.Min(100, Energy + 20);
            Console.WriteLine(@"
    /\_/\  
   ( -_-)  *Zzz...*  
    > ^ <   *Taking a nap...*  
   *Beep Beep!*   
            ");
            Console.WriteLine($"You let {Name} sleep. Energy increased!");
        }
        public void ShowStatus()
        {
            Console.WriteLine($@"
    /\_/\  
   ( o.o )  *Tamagotchi*  
    > ^ <   *Virtual Pet*  
   *Beep Beep!*
            ");
            Console.WriteLine($"\n--- {Name}'s Status ---");
            Console.WriteLine($"Food: {Food}");
            Console.WriteLine($"Happiness: {Happiness}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine("-------------------------\n");
        }
    }
}