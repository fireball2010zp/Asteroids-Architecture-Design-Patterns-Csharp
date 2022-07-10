// the main entry point to the program, to initialize the game

using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            Enemy.Factory = factory;
            Enemy.Factory.Create(new Health(100.0f, 100.0f));


            Enemy.CreateCometEnemy(new Health(100.0f, 100.0f));


            IEnemyFactory EnemyShipfactory = new EnemyShipFactory();
            EnemyShipfactory.Create(new Health(100.0f, 100.0f));

        }
    }
}

