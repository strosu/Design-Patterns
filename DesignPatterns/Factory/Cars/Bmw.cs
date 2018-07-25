using System;

namespace Factory.Cars
{
    public class Bmw : ICar
    {
        public void Start()
        {
            Console.WriteLine("Starting bmw");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping bmw");
        }
    }
}