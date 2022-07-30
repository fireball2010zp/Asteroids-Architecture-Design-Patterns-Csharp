using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class ModificationScope : ModificationWeapon
    {
        private readonly IScope _scope;
        private readonly Vector3 _scopePosition;
        private GameObject _scopeInstance;

        public ModificationScope(IScope scope, Vector3 scopePosition)
        {
            _scope = scope;
            _scopePosition = scopePosition;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _scopeInstance = Object.Instantiate(_scope.ScopeInstance, _scopePosition, Quaternion.identity);
            weapon.SetBarrelPosition(_scope.BarrelPositionScope);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            Object.Destroy(_scopeInstance);
            return weapon;
        }

    }
}