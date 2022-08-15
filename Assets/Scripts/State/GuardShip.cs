using UnityEngine;

namespace Asteroids.State
{
    public sealed class GuardShip : MonoBehaviour
    {
        private readonly Transform _transform;
        public readonly float _hp; 
        private GuardMode _guardMode;

        public GuardShip(Transform transform, GuardMode guardMode, float hp)
        {
            _transform = transform;
            _guardMode = guardMode;
            _hp = hp;
        }

        public GuardMode GuardMode
        {
            set
            {
                _guardMode = value;
                Debug.Log("Guardian mode: " + _guardMode.GetType().Name);
            }
        }

        public void DestroyGuard(GuardShip _guard)
        {
            if (_hp < 0)
                Destroy(_guard);
        }
    }
}
