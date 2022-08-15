using UnityEngine;

namespace Asteroids.Visitor
{
    public abstract class Hit : MonoBehaviour
    {
        public float hp;
        public abstract void Activate(ICreatingSpaceship enemyShip, InfoCollision infoCollision);
    }
}
