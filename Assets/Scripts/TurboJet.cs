using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class TurboJet : IMoveEnemy
    {
        private readonly Transform _transform;
        public Rigidbody _rigidBody;
        private Vector3 _move;
        
        [SerializeField] private float _turbospeed;
        private float _horizontal;
        private float _vertical;
        private float _deltaTime;

        public void Move()
        {
                var speed = _deltaTime * _turbospeed;
                _move.Set(_horizontal * speed, _vertical * speed, 0.0f);
                _transform.localPosition += _move;
        }
    }
}