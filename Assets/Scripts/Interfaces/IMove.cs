

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        
        // void Move(float horizontal, float vertical, float deltaTime);

        void Move(float x, float y, float z);
    }
}

