// separate entity describing the rotation of the Player, by Liskov substitution principle

using UnityEngine;

namespace Asteroids
{
    public interface IRotation
    {
        void Rotation(Vector3 direction);
    }
}

