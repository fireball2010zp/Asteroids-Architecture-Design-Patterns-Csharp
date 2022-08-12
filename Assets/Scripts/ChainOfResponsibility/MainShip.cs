using UnityEngine;

namespace Asteroids.ChainOfResponsibility
{
    internal sealed class MainShip : MonoBehaviour
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        private void Start()
        {
            var mainShip = new Ship(_moveImplementation, _rotationImplementation);

            var root = new ShipModifier(mainShip);
            root.Add(new AddSpeedModifier(mainShip, 50));
            root.Add(new AddSpeedModifier(mainShip, 5));
            root.Add(new AddRotateModifier(mainShip, Vector3.forward));
            root.Add(new AddRotateModifier(mainShip, Vector3.up));
            root.Handle();
        }
    }
}
