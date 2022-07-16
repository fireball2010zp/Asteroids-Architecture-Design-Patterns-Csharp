using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids.ServiceLocator
{
    public class BulletServiceLocator : MonoBehaviour
    {
        private GameObject bullet;

        private void Start()
        {
            ServiceLocator.SetService<IBulletService>(new BulletService(bullet));
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ServiceLocator.Resolve<IBulletService>().CreateBullet(bullet);
            }
        }
    }
}


