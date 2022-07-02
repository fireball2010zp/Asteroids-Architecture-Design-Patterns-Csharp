// для расширения функционала перемещения игрока (MoveTransform)
// по принципу открытости закрытости (Open-closed principle)

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}

