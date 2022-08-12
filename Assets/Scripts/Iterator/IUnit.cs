using System.Collections;
using System.Collections.Generic;

namespace Asteroids.Iterator
{
    internal interface IUnit
    {
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(DamageType index);
        IAbility this[int index] { get; }
        string this[Target index] { get; }
    }
}