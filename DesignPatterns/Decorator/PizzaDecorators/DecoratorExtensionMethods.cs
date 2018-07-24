using Decorator.Pizzas;

namespace Decorator.PizzaDecorators
{
    public static class DecoratorExtensionMethods
    {
        public static Pizza WithCheese(this Pizza pizza)
        {
            return new Cheese(pizza);
        }

        public static Pizza WithPineapple(this Pizza pizza)
        {
            return new Pineapple(pizza);
        }
    }
}