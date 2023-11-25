using UnityEngine;
using UnityEngine.Pool;

namespace LikeADoom.ObjectCreation
{
    public class Pool<T> : IObjectFactory<T>
    {
        const int DefaultInitialCapacity = 10;
        const int DefaultMaxSize = 100;

        readonly Transform _spawnPoint;
        readonly IObjectPool<IPoolable<T>> _pool;
        readonly IObjectFactory<IPoolable<T>> _builder;

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
        void Recycle(IPoolable<T> poolable) => _pool.Release(poolable);

        IPoolable<T> OnCreate()
        {
            IPoolable<T> poolable = _builder.Create();
            return poolable;
        }

        void OnGet(IPoolable<T> poolable)
        {
            poolable.ReleaseRequested += OnReleaseRequested;
            poolable.SetPosition(_spawnPoint.position)
                .SetRotation(_spawnPoint.rotation)
                .Enable();
        }

        void OnRelease(IPoolable<T> poolable)
        {
            poolable.ReleaseRequested -= OnReleaseRequested;
            poolable.Disable();
        }

        void OnDestroy(IPoolable<T> poolable)
        {
            poolable.ReleaseRequested -= OnReleaseRequested;
            poolable.Destroy();
        }

        void OnReleaseRequested(IPoolable<T> poolable) => Recycle(poolable);
    }
}