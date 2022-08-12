using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Iterator
{
    internal sealed class Unit : IUnit
    {
        private readonly List<IAbility> _ability;

        public Unit(List<IAbility> ability)
        {
            _ability = ability;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _ability.Count; i++)
            {
                yield return _ability[i];
            }
        }
        
        public IEnumerable<IAbility> GetAbility(DamageType index)
        {
            foreach (IAbility ability in _ability)
            {
                if (ability.DamageType == index)
                {
                    yield return ability;
                }
            }
        }

        public IAbility this[int index] => _ability[index];

        public string this[Target index]
        {
            get
            {
                var ability = _ability.FirstOrDefault(a => a.DamageTarget == index);
                return ability == null ? "Not supported" : ability.ToString();
            }
        }
    }
}
