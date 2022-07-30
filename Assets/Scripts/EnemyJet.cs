using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyJet : MonoBehaviour
    {
        private EnemyBridge enemy;

        private void Start()
        {
            enemy = new EnemyBridge(new LaserGun(), new TurboJet());

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                enemy.Move();
            }

            if (Input.GetMouseButtonDown(0))
            {
                enemy.Fire();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
            {
                enemy.Switch(new TurboJet());
            }
        }
    }
}
