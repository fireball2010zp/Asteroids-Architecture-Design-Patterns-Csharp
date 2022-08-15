using UnityEngine;

namespace Asteroids.Visitor
{
    public sealed class EnemyInterceptor : Hit
    {
        public override void Activate(ICreatingSpaceship enemyShip, InfoCollision infoCollision)
        {
            enemyShip.Visit(this, infoCollision);
        }

        public static EnemyInterceptor CreateEnemyInterceptor(float hp)
        {
            var ship = Instantiate(Resources.Load<EnemyInterceptor>("EnemyShips/EnemyInterceptor"));
            ship.hp = hp;
            return ship;
        }
    }
}
