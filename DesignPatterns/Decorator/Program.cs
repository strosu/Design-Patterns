using System;
using Decorator.PizzaDecorators;
using Decorator.Pizzas;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new LargePizza();
            pizza = new Cheese(pizza);
            pizza = new Pineapple(pizza);

            Pizza pizza2 = new LargePizza().WithCheese().WithPineapple();

            Console.WriteLine(pizza.GetDescription());
            Console.WriteLine(pizza.GetPrice());

            Console.WriteLine(pizza2.GetDescription());
            Console.WriteLine(pizza2.GetPrice());

            Console.ReadLine();
        }
    }
}
