namespace Decorator.Pizzas
{
    public class SmallPizza : Pizza
    {
        public override int GetPrice()
        {
            return 10;
        }

        public override string GetDescription()
        {
            return "SmallPizza";
        }
    }
}