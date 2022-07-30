﻿namespace Asteroids.Decorator
{
    internal abstract class ModificationWeapon : IFire
    {

        private Weapon _weapon;
        
        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon RemoveModification(Weapon weapon);
        
        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void CancelModification(Weapon weapon)
        {
            _weapon = RemoveModification(weapon);
        }

        public void Fire()
        {
            _weapon.Fire();
        }
    }
}
