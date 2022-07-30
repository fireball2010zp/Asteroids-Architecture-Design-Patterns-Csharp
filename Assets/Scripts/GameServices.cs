using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Facade
{
    public class GameServices : MonoBehaviour
    {
        public void Start()
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