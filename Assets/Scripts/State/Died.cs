using UnityEngine;

namespace Asteroids.State
{
    internal sealed class Died : GuardMode
    {
        private GuardShip _guard;

        public override void Handle(GuardShip player)
        {
            Debug.Log(player + " is dead!");
            _guard.DestroyGuard(player);
        }
    }
}