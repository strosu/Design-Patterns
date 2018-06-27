namespace Bridge.After
{
    public abstract class Manuscript
    {
        protected readonly IFormatter _formatter;

        public Manuscript(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public abstract void Print();
    }
}