

namespace JsonUnits
{
    internal sealed class Mag : IUnit
    {
        public string Type { get; }
        public int Health { get; }

        public Mag(string type, int health)
        {
            Type = type;
            Health = health;
        }
    }
}
