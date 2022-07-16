using System;

namespace Asteroids.Prototype
{
    [Serializable] 
    internal sealed class AsteroidData : ICloneable
    {
        public float Speed;
        public AsteroidHp Hp;

        public override string ToString()
        {
            return $"Speed {Speed} Hp {Hp}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
