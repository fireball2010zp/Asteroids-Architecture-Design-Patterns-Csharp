using UnityEngine;

namespace Asteroids.Visitor
{
    public sealed class ConsoleDisplay : ICreatingSpaceship
    {
        public void Visit(EnemyCorvette enemyShip, InfoCollision info)
        {
            Debug.Log($"{nameof(EnemyCorvette)} - {info.Health}");
        }

        public void Visit(EnemyBomber enemyShip, InfoCollision info)
        {
            Debug.Log($"{nameof(EnemyBomber)} - {info.Health}");
        }

        public void Visit(EnemyInterceptor enemyShip, InfoCollision info)
        {
            Debug.Log($"{nameof(EnemyInterceptor)} - {info.Health}");
        }
    }
}
