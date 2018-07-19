using System;

namespace Composite
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Gold { get; set; }

        public void Stats()
        {
            Console.WriteLine($"Player {Name} has {Gold} gold.");
        }
    }
}