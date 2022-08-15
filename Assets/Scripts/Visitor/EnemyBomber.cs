using UnityEngine;

namespace Asteroids.Visitor
{
    public class EnemyBomber : Hit
    {
        public override void Activate(ICreatingSpaceship enemyShip, InfoCollision infoCollision)
        {
            enemyShip.Visit(this, infoCollision);
        }

        public static EnemyBomber CreateEnemyBomber(float hp) 
        {
            var ship = Instantiate(Resources.Load<EnemyBomber>("EnemyShips/EnemyBomber"));
            ship.hp = hp;
            return ship;
        }
    }
}
