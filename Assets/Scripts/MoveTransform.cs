using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        public Rigidbody _rigidBody;
        private Vector3 _move;

        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed; 
        }
        
        /*
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }
        */

        public void Move(float x, float y, float z)
        {
           if (_rigidBody)
           {
               _rigidBody.AddForce(new Vector3(x, y, z) * Speed);
           }
           else
           {
               Debug.Log("NO Rigidbody!");
           }
        }
    }
}

