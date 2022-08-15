using UnityEngine;
using System;

namespace Asteroids
{
    public class DamageProcessing
    {
        public event Action OnDestroyChange;
        private bool _exist = true;

        public UnityEngine.Object gameObject;
        private float _hp;

        public DamageProcessing(float hp, bool argsExist)
        {
            _hp = hp;
            _exist = argsExist;
        }

        public bool Exist
        {
            get => _exist;
            set 
            {
                _exist = value;
            }
        }

        public void Damage(float hp)
        {
            if (hp <= 0)
            {
                GameObject.Destroy(gameObject);
                _exist = false;
                OnDestroyChange?.Invoke();
            }
            else
            {
                hp--;
            }
        }

        public bool ViewExist { get; }
    }
}

