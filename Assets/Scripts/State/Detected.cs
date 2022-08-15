using UnityEngine;

namespace Asteroids.State
{
    public sealed class Detected : GuardMode 
    {
        public readonly Transform _enemy;
        public float _enemyDistance;
        
        public Detected(Transform enemy, float distance)
        {
            _enemy = enemy;
            _enemyDistance = distance;
        }
                
        public override void Handle(GuardShip player)
        {
            Debug.Log(_enemy.name + " is detected at a distance " + _enemyDistance);
        }
    }
}