
using UnityEngine;

namespace Asteroids
{
    public class FireAction : IFire
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;

        public float Force { get; protected set; }

        public FireAction(Transform barrel, float force)
        {
            _barrel = barrel;
            Force = force;
        }

        public void Fire(Transform barrel)
        {
            var temAmmunition = Object.Instantiate(_bullet, barrel.position, barrel.rotation);
            temAmmunition.AddForce(barrel.up * Force);
        }

    }

}
