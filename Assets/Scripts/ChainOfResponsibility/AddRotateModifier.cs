using UnityEngine;

namespace Asteroids.ChainOfResponsibility
{
    internal sealed class AddRotateModifier : ShipModifier
    {
        private readonly Vector3 _direction;

        public AddRotateModifier(Ship ship, Vector3 direction)
            : base(ship)
        {
            _direction = direction;
        }

        public override void Handle()
        {
            _ship._rotationImplementation.Rotation(-_direction);
            base.Handle();
        }
    }
}