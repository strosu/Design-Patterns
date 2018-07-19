namespace Composite
{
    public interface IPlayer
    {

        string Name { get; set; }

        int Gold { get; set; }

        void Stats();
    }
}