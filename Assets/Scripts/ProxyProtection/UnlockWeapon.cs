using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.ProxyProtection
{
    public sealed class UnlockWeapon
    {
        public bool IsUnlock { get; set; }
        public UnlockWeapon(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }
    }
}

