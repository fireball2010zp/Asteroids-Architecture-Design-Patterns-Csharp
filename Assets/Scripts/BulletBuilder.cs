
using UnityEngine;

namespace Asteroids.Builder
{
    public class BulletBuilder
    {
        protected GameObject _bullet;

        public BulletBuilder() => _bullet = new GameObject();
        protected BulletBuilder(GameObject bullet) => _bullet = bullet;

        public BulletVisualBuilder Visual => new(_bullet);

        public BulletPhysicsBuilder Physics => new(_bullet);

        public static implicit operator GameObject(BulletBuilder builder)
        {
            return builder._bullet;
        }
    }
}