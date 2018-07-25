using Factory.Cars;

namespace Factory.Second
{
    public class BmwFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new Bmw();
        }
    }
}