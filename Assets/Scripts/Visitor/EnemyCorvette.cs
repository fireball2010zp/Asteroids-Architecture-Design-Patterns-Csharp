using UnityEngine;

namespace Asteroids.Visitor
{
    public sealed class EnemyCorvette : Hit
    {
        public override void Activate(ICreatingSpaceship enemyShip, InfoCollision infoCollision)
        {
            enemyShip.Visit(this, infoCollision);
        }

        public static EnemyCorvette CreateEnemyCorvette(float hp)
        {
            var ship = Instantiate(Resources.Load<EnemyCorvette>("EnemyShips/EnemyCorvette"));
            ship.hp = hp;
            return ship;
        }
    }
}
