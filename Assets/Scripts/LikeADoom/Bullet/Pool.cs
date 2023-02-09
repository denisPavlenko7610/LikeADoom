using System;
using LikeADoom.Shooting.BulletBuilder;
using UnityEngine;
using UnityEngine.Pool;

namespace LikeADoom.Shooting
{
    public class Pool : IBulletFactory
    {
        private const int DefaultInitialCapacity = 10;
        private const int DefaultMaxSize = 100;

        private readonly Transform _spawnPoint;
        private readonly IObjectPool<IBullet> _pool;
        private readonly IBulletBuilder _builder;

        public Pool(IBulletBuilder builder, Transform spawnPoint,
            int defaultCapacity = DefaultInitialCapacity, int maxSize = DefaultMaxSize)
        {
            _builder = builder;
            _spawnPoint = spawnPoint;
            _pool = new ObjectPool<IBullet>(
                OnCreateBullet,
                OnGetBullet,
                OnReleaseBullet,
                OnDestroyBullet,
                collectionCheck: true,
                defaultCapacity,
                maxSize);
        }

        public IBullet Create() => _pool.Get();

        private void Recycle(IBullet bullet)
        {
            if (bullet.IsReleased())
                return;
            
            bullet.SetIsReleased(true);
            _pool.Release(bullet);
        }

        private IBullet OnCreateBullet()
        {
            IBullet bullet = _builder
                        .SetupBulletPosition(_spawnPoint)
                        .SetIsReleased(false)
                        .Build();
            
            bullet.OnBulletHit += SubscribeOnRelease(bullet);
            bullet.OnBulletTimeOver += SubscribeOnRelease(bullet);
            return bullet;
        }

        private void OnGetBullet(IBullet bullet)
        {
            bullet.SetupBulletPosition(_spawnPoint)
                .Enable()
                .SetIsReleased(false);
        }

        private void OnReleaseBullet(IBullet bullet)
        {
            bullet.Disable();
        }

        private void OnDestroyBullet(IBullet bullet)
        {
            bullet.OnBulletHit -= SubscribeOnRelease(bullet);
            bullet.OnBulletTimeOver -= SubscribeOnRelease(bullet);
            bullet.Destroy();
        }

        private Action SubscribeOnRelease(IBullet bullet) => () => Recycle(bullet);
    }
}