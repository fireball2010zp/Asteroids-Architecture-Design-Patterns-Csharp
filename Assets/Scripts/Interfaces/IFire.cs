using UnityEngine;

namespace Asteroids
{
    public interface IFire
    {
        float Force { get; }
        void Fire(Transform barrel);
    }
}
