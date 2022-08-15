
namespace Asteroids.Visitor
{
    public readonly struct InfoCollision
    {
        private readonly float _hp;

        public InfoCollision(float hp)
        {
            _hp = hp;
        }

        public float Health => _hp; 
    }
}
