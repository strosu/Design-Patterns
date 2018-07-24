using Decorator.Pizzas;

namespace Decorator.PizzaDecorators
{
    public class Pineapple : PizzaDecorator
    {
        public Pineapple(Pizza pizza) : base(pizza)
        {
        }

        public override int GetPrice()
        {
            return 2 + base.GetPrice();
        }

        public override string GetDescription()
        {
            return "PineApple" + base.GetDescription();
        }
    }
}