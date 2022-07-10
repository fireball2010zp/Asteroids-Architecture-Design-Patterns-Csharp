using UnityEngine;

namespace Asteroids
{
    internal abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;

        public Health Health { get; private set; }

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }

        public static Comet CreateCometEnemy(Health hp)
        {
            var enemyComet = Instantiate(Resources.Load<Comet>("Enemy/Comet"));
            enemyComet.Health = hp;
            return enemyComet;
        }
        

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }


        private void EnemyMove(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

    }
}
