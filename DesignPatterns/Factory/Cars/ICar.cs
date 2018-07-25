namespace Factory
{
    public interface ICar
    {
        void Start();
        void Stop();
    }

    public class NullCar : ICar
    {
        public static NullCar Instance = new NullCar();
        private NullCar()
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}