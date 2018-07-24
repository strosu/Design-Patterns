using Decorator.Pizzas;

namespace Decorator.PizzaDecorators
{
    public class Cheese : PizzaDecorator
    {
        public Cheese(Pizza pizza) : base(pizza)
        {
            Description = "Cheese";
        }

        public override string GetDescription()
        {
            return Description + base.GetDescription();
        }

        public override int GetPrice()
        {
            return 1 + base.GetPrice();
        }
    }
}