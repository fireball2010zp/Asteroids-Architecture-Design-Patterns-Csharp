// ��������������� "����������� ������" � ��������� ������
// �� �������� ������������ ��������������� (Single responsibility)

using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove // �� ���������� IMove ��� sealed
    {
        private readonly Transform _transform;
        // moved from Player
        private Vector3 _move;

        // ������ private readonly float _speed; ����� ���������� ���������� IMove
        public float Speed { get; protected set; }


        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            // ������ _speed = speed; ����� ���������� ���������� IMove
            Speed = speed; 
        }

        
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            // ������������ �� Player
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }
    }
}

