using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.ServiceLocator
{
    internal sealed class BulletService : IBulletService
    {
        public BulletService(GameObject bullet)
        {
            Bullet = bullet;
        }

        public GameObject Bullet { get; set; }

        public void CreateBullet(GameObject bullet)
        {
            Bullet = bullet;
        }
    }

}