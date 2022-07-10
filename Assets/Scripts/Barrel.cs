
using BulletPool;
using UnityEngine;

namespace Asteroids
{
    public sealed class Barrel : IWeapon
    {
        private readonly Rigidbody _prefabBullet;
        private readonly IViewBullets _viewBullets;

        public Barrel(Rigidbody prefabBullet, IViewBullets viewBullets)
        {
            _prefabBullet = prefabBullet;
            _viewBullets = viewBullets;
        }

        public void Fire()
        {
            var bullet = _viewBullets.Instantiate<Rigidbody>(_prefabBullet.gameObject);
            bullet.AddForce(Vector3.forward);

            _viewBullets.Destroy(bullet.gameObject);
        }
    }
}
