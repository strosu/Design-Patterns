namespace Bridge.After
{
    public class RegularFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return $"Key is {key}, value is {value}";
        }
    }
}