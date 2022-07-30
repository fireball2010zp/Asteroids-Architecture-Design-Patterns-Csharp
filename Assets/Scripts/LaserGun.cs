using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.ProxyProtection;

namespace Asteroids
{
    public class LaserGun : MonoBehaviour, IWeapon
    {
        private LineRenderer lineRenderer;

        [SerializeField]
        private Transform startpoint;

        [SerializeField]
        private int distance;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();

            var unlockWeapon = new UnlockWeapon(false);
            var weapon = new LaserGun();
            var weaponProxy = new LaserGunProxy(weapon, unlockWeapon);
            weaponProxy.Fire();
            unlockWeapon.IsUnlock = true;
            weaponProxy.Fire();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire(); 
            }
        }
        public void Fire()
        {
            lineRenderer.SetPosition(0, startpoint.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider)
                {
                    lineRenderer.SetPosition(1, hit.point);
                }
                if (hit.transform.tag == "Player")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            else lineRenderer.SetPosition(1, -transform.forward * distance);
        }
    }
}


