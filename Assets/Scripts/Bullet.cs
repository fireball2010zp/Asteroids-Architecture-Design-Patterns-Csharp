using UnityEngine;

namespace Asteroids.Builder
{
    internal sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;


        private void Start()
        {
            var bulletBuilder = new BulletBuilder();
            GameObject rocket = bulletBuilder
                .Physics
                .BoxCollider2D()
                .Rigidbody2D(10.0f)
                .Visual
                .Name("Rocket")
                .Sprite(_sprite);
        }

    }
}