// responsibility "moving the Player" in a separate class (Single responsibility principle)

using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove // before the adding IMove interface the class was sealed
    {
        private readonly Transform _transform;
        // moved from Player class
        private Vector3 _move;

        // appeared instead of "private readonly float _speed;" after adding IMove interface
        public float Speed { get; protected set; }


        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            // appeared instead of "_speed = speed;" after adding IMove interface
            Speed = speed; 
        }

        
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            // migrated from Player class
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }
    }
}

