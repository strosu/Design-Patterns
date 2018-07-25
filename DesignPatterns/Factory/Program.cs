using Factory.Second;
using System;
using System.Reflection;

namespace Factory
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var factory = new CarFactory();
        //    var car = factory.CreateInstance("bm");

        //    car.Start();
        //    car.Stop();

        //    Console.ReadLine();
        //}

        static void Main()
        {
            var factory = LoadFactory("Factory.Second.AudiFactory");
            var car = factory.CreateCar();

            car.Start();
            car.Stop();

            Console.ReadLine();
        }

        private static ICarFactory LoadFactory(string name)
        {
            return Assembly.GetExecutingAssembly().CreateInstance(name) as ICarFactory;
        }
    }
}
