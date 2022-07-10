using UnityEngine;

namespace BulletPool
{
    public interface IViewBullets
    {
        T Instantiate<T>(GameObject prefab);
        void Destroy(GameObject value);
    }
}
