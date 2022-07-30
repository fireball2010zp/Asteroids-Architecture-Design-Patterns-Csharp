using UnityEngine;

namespace Asteroids.Decorator
{
    public interface IScope
    {
        public Transform BarrelPositionScope { get; }
        public GameObject ScopeInstance { get; }
    }
}
