namespace Asteroids.Iterator
{
    internal interface IAbility
    {
        string AbilityName { get; }
        int DamagePower { get; }
        DamageType DamageType { get; }
        Target DamageTarget { get; }
    }
}
