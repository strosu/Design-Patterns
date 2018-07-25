using System;

namespace Factory.Cars
{
    public class Audi : ICar
    {
        public void Start()
        {
            Console.WriteLine("Starting audi");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping audi");
        }
    }
}