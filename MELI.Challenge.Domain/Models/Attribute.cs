namespace MELI.Challenge.Domain.Models
{
    public class Attribute
    {
        public string Name { get; }
        public string Value { get; }

        public Attribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
