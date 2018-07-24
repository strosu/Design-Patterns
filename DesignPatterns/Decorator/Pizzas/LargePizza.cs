namespace Decorator.Pizzas
{
    public class LargePizza : Pizza
    {
        public override int GetPrice()
        {
            return 20;
        }

        public override string GetDescription()
        {
            return "LargePizza";
        }
    }
}