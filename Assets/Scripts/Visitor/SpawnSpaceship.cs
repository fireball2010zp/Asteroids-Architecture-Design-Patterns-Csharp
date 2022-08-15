
namespace Asteroids.Visitor
{
    public sealed class SpawnSpaceship : ICreatingSpaceship
    {
        public void Visit(EnemyCorvette create, InfoCollision info)
        {
            EnemyCorvette.CreateEnemyCorvette(create.hp); 
        }

        public void Visit(EnemyBomber create, InfoCollision info)
        {
            EnemyBomber.CreateEnemyBomber(create.hp);
        }

        public void Visit(EnemyInterceptor create, InfoCollision info)
        {
            EnemyInterceptor.CreateEnemyInterceptor(create.hp);
        }
    }
}
