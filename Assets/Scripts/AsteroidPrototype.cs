
using UnityEngine;


namespace Asteroids.Prototype
{
    internal sealed class AsteroidPrototype : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private void Start()
        {
            AsteroidData asteroidData = new AsteroidData
            {
                Hp = new AsteroidHp
                {
                    CurrentHP = 100,
                    MaxHP = 100
                },
                Speed = 100
            };

            AsteroidData asteroidNew = (AsteroidData)asteroidData.Clone();
            asteroidNew.Hp.CurrentHP = 100;

        }
    }
}