using UnityEngine;

namespace Asteroids.State
{
    public class Attack : GuardMode, IFire
    {
        private FireAction fire;
        private readonly Transform _enemy;

        public float Force => ((IFire)fire).Force;

        public Attack(Transform enemy)
        {
            _enemy = enemy;
        }

        public override void Handle(GuardShip player)
        {
            Debug.Log("Attack!");
        }

        public void Fire(Transform barrel)
        {
            var attack = Object.Instantiate(fire._bullet, barrel.position, barrel.rotation);
            attack.AddForce(barrel.up * fire.Force);
        }
    }
}