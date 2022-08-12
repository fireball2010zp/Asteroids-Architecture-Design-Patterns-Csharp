namespace Asteroids.Iterator
{
    internal sealed class Ability : IAbility
    {
        public string AbilityName { get; }
        public Target DamageTarget { get; }
        public DamageType DamageType { get; }
        public int DamagePower { get; }

        public Ability(string name, Target target, DamageType damageType, int damage)
        {
            AbilityName = name;
            DamageTarget = target;
            DamageType = damageType;
            DamagePower = damage;
        }

        public override string ToString()
        {
            return AbilityName;
        }
    }
}
