using Decorator.Pizzas;

namespace Decorator.PizzaDecorators
{
    public class PizzaDecorator : Pizza
    {
        private readonly Pizza _pizza;

        public PizzaDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override int GetPrice()
        {
            return _pizza.GetPrice();
        }

        public override string GetDescription()
        {
            return _pizza.GetDescription();
        }
    }
}