namespace Decorator.Pizzas
{
    public class MediumPizza : Pizza
    {
        public override int GetPrice()
        {
            return 15;
        }

        public override string GetDescription()
        {
            return "MediumPizza";
        }
    }
}