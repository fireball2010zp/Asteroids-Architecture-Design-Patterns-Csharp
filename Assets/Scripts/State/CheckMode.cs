using UnityEngine;

namespace Asteroids.State
{
    public sealed class CheckMode : MonoBehaviour
    {
        [SerializeField] private float activeDistance;
        [SerializeField] private float activeAngle;
        [SerializeField] private float attackDistance;

        [SerializeField] private float hp; 
        [SerializeField] private Transform _guardView;
        [SerializeField] private Transform[] _enemies;

        private GuardShip _guardian;
        private readonly Detected detect;

        private void Start()
        {
            _guardian = new GuardShip(_guardView, new Inspection(), hp);
        }

        private void Update()
        {
            foreach (var enemy in _enemies)
            {
                if (Vision(_guardView, enemy))
                {
                    var detected = new Detected(enemy, detect._enemyDistance);
                    _guardian.GuardMode = detected;
                }

                if (Vision(_guardView, enemy) && (detect._enemyDistance <= attackDistance))
                {
                    var attack = new Attack(enemy);
                    _guardian.GuardMode = attack;
                }
            }
            
            if (_guardian._hp <= 0)
            {
                var died = new Died();
                _guardian.GuardMode = died;
            }
        }

        public bool Vision(Transform guardian, Transform target)
        {
            return Distance(guardian, target) && Angle(guardian, target) && !CheckBlock(guardian, target);
        }

        private bool CheckBlock(Transform guardian, Transform target)
        {
            if (!Physics.Linecast(guardian.position, target.position, out var hit))
                return true;
            return hit.transform != target;
        }

        private bool Angle(Transform guardian, Transform target)
        {
            var angle = Vector3.Angle(target.position - guardian.position, guardian.forward);
            return angle <= activeAngle;
        }

        private bool Distance(Transform guardian, Transform target)
        {
            return (guardian.position - target.position).sqrMagnitude <= activeDistance * activeDistance;
        }
    }
}
