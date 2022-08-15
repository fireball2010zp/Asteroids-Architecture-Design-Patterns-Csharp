using UnityEngine;

namespace Asteroids.State
{
    public class Inspection : GuardMode
    {
        public override void Handle(GuardShip player)
        {
            if (player._hp > 0)
            {
                player.GuardMode = new Inspection();
                Debug.Log("Inspection");
            }
        }
    }
}