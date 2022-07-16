using UnityEngine;

namespace Asteroids.Builder
{
    public sealed class BulletPhysicsBuilder : BulletBuilder
    {
        public BulletPhysicsBuilder(GameObject bullet) : base(bullet) { }

        public BulletPhysicsBuilder BoxCollider2D()
        {
            GetOrAddComponent<BoxCollider2D>();
            return this;
        }

        public BulletPhysicsBuilder Rigidbody2D(float mass)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _bullet.GetComponent<T>();
            if (!result)
            {
                result = _bullet.AddComponent<T>();
            }
            return result;
        }
    }
}
