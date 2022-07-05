using UnityEngine;

namespace Asteroids
{
    public class DamageProcessing
    {
        private Object gameObject;
        private float _hp;

        public DamageProcessing(float hp)
        {
            _hp = hp;
        }

        public void Damage(float hp)
        {
            if (hp <= 0)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                hp--;
            }
        }
    }
}

