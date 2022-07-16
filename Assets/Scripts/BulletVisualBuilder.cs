using UnityEngine;

namespace Asteroids.Builder
{
    public sealed class BulletVisualBuilder : BulletBuilder
    {
        public BulletVisualBuilder(GameObject bullet) : base(bullet) { }

        public BulletVisualBuilder Name(string name)
        {
            _bullet.name = name;
            return this;
        }

        public BulletVisualBuilder Sprite(Sprite sprite)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
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