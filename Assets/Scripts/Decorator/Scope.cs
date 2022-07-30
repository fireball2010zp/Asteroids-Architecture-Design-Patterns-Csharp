using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Decorator
{
    public class Scope : IScope
    {
        public Transform BarrelPositionScope { get; }
        public GameObject ScopeInstance { get; }

        public Scope(Transform barrelPositionScope, GameObject scope)
        {
            BarrelPositionScope = barrelPositionScope;
            ScopeInstance = scope;
        }
    }
}