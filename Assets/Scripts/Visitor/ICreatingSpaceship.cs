
namespace Asteroids.Visitor
{
    public interface ICreatingSpaceship
    {
        void Visit(EnemyCorvette create, InfoCollision info);
        void Visit(EnemyBomber create, InfoCollision info);
        void Visit(EnemyInterceptor create, InfoCollision info);
    }
}

