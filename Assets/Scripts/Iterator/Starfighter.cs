using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Iterator
{
    internal sealed class Starfighter : MonoBehaviour
    {
        private void Start()
        {
            var ability = new List<IAbility>
            {
                new Ability("Ice Shot", Target.Asteroid | Target.Comet, DamageType.Pure, 1),
                new Ability("Double Ice Shot", Target.Asteroid | Target.Comet, DamageType.Double, 2),

                new Ability("Laser Shot", Target.TurboJet, DamageType.Pure, 3),
                new Ability("Double Laser Shot", Target.TurboJet, DamageType.Double, 6),
            };

            IUnit unit = new Unit(ability);

            Debug.Log(unit[0]);

            Debug.Log(unit[Target.Asteroid | Target.Comet]);

            Debug.Log(unit[Target.TurboJet]);

            foreach (var o in unit)
            {
                Debug.Log(o);
            }

            foreach (var o in unit.GetAbility(DamageType.Double))
            {
                Debug.Log(o);
            }
        }
    }
}
