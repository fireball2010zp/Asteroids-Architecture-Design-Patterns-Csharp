using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace BulletPool
{
    internal sealed class ViewBullet : IViewBullets
    {
        private readonly Dictionary<string, BulletPool> _viewCache
            = new Dictionary<string, BulletPool>(15);

        public T Instantiate<T>(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out BulletPool viewPool))
            {
                viewPool = new BulletPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            if (viewPool.Pop().TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject value)
        {
            _viewCache[value.name].Push(value);
        }
    }
}
