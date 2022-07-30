

namespace JsonUnits
{
    public sealed class Infantry : IUnit
    {
        public string Type { get; }
        public int Health { get; }

        public Infantry(string type, int health)
        {
            Type = type;
            Health = health;
        }
    }
}