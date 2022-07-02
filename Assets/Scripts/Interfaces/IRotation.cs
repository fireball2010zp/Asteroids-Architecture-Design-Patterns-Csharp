// отдельная сущность описывающая вращение игрока
// по принципу подстановки (Liskov substitution)

using UnityEngine;

namespace Asteroids
{
    public interface IRotation
    {
        void Rotation(Vector3 direction);
    }
}

