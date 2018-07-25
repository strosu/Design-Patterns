using Factory.Cars;

namespace Factory.Second
{
    public class AudiFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new Audi();
        }
    }
}