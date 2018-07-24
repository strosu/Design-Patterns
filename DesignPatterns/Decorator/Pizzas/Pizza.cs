namespace Decorator.Pizzas
{
    public abstract class Pizza
    {
        public string Description { get; set; }

        public abstract int GetPrice();

        public abstract string GetDescription();
    }
}