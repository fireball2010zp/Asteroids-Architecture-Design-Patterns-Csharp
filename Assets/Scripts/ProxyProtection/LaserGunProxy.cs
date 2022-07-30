using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.ProxyProtection
{
    public sealed class LaserGunProxy : IWeapon
    {
        private readonly IWeapon _laserGun;
        private readonly UnlockWeapon _unlockWeapon;

        public LaserGunProxy(IWeapon laserGun, UnlockWeapon unlockWeapon)
        {
            _laserGun = laserGun;
            _unlockWeapon = unlockWeapon;
        }

        public void Fire()
        {
            if (_unlockWeapon.IsUnlock)
            {
                _laserGun.Fire();
            }
            else
            {
                Debug.Log("Weapon is lock");
            }
        }
    }
}