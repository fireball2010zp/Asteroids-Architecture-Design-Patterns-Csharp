
using UnityEngine;

namespace Asteroids
{
    public class ViewPlayer
    {
        [SerializeField] public float _speed;
        [SerializeField] public float _acceleration;
        [SerializeField] public float _hp;
        [SerializeField] public Rigidbody2D _bullet;
        [SerializeField] public Transform _barrel;
        [SerializeField] public float _force;

        public Camera _camera;
        public Ship _ship;

        public FireAction _fireAction;
        public DamageProcessing _damageProcessing;

        public Transform transform;
    }
}

