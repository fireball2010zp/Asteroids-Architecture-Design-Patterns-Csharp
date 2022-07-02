// ответственность "перемещение игрока" в отдельном классе
// по принципу единственной ответственности (Single responsibility)

using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove // до интерфейса IMove был sealed
    {
        private readonly Transform _transform;
        // moved from Player
        private Vector3 _move;

        // вместо private readonly float _speed; после добавления интерфейса IMove
        public float Speed { get; protected set; }


        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            // вместо _speed = speed; после добавления интерфейса IMove
            Speed = speed; 
        }

        
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            // перекочевало из Player
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }
    }
}

