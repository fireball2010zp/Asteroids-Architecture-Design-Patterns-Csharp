// created to expand the movement functionality of the Player (MoveTransform class), according to Open-closed principle

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}

