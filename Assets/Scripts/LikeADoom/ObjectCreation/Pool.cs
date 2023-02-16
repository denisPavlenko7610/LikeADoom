using UnityEngine;
using UnityEngine.Pool;

namespace LikeADoom.Shooting
{
    public class Pool<T> : IObjectFactory<T>
    {
        private const int DefaultInitialCapacity = 10;
        private const int DefaultMaxSize = 100;

        private readonly Transform _spawnPoint;
        private readonly IObjectPool<IPoolable<T>> _pool;
        private readonly IObjectFactory<IPoolable<T>> _builder;

        public Pool(IObjectFactory<IPoolable<T>> builder, Transform spawnPoint,
            int defaultCapacity = DefaultInitialCapacity, int maxSize = DefaultMaxSize)
        {
            _builder = builder;
            _spawnPoint = spawnPoint;
            _pool = new ObjectPool<IPoolable<T>>(
                OnCreate,
                OnGet,
                OnRelease,
                OnDestroy,
                collectionCheck: true,
                defaultCapacity,
                maxSize);
        }

        public T Create() => _pool.Get().GetObject();
        private void Recycle(IPoolable<T> poolable) => _pool.Release(poolable);

        private IPoolable<T> OnCreate()
        {
            IPoolable<T> poolable = _builder.Create();
            return poolable;
        }

        private void OnGet(IPoolable<T> poolable)
        {
            poolable.ReleaseRequested += OnReleaseRequested;
            poolable.SetPosition(_spawnPoint.position)
                .SetRotation(_spawnPoint.rotation)
                .Enable();
        }

        private void OnRelease(IPoolable<T> poolable)
        {
            poolable.ReleaseRequested -= OnReleaseRequested;
            poolable.Disable();
        }

        private void OnDestroy(IPoolable<T> poolable)
        {
            poolable.ReleaseRequested -= OnReleaseRequested;
            poolable.Destroy();
        }

        private void OnReleaseRequested(IPoolable<T> poolable) => Recycle(poolable);
    }
}