
namespace Asteroids.ChainOfResponsibility
{
    internal sealed class AddSpeedModifier : ShipModifier
    {
        private readonly float _speed;

        public AddSpeedModifier(Ship ship, float speed)
            : base(ship)
        {
            _speed = speed;
        }

        public override void Handle()
        {
            _ship.Speed += _speed;
            base.Handle();
        }
    }
}