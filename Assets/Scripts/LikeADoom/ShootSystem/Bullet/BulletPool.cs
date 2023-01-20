using UnityEngine;
using UnityEngine.Pool;

namespace LikeADoom.Shooting
{
    public class BulletPool : IBulletCreator
    {
        public const int DefaultInitialCapacity = 10;
        public const int DefaultMaxSize = 100;
        
        private readonly Transform _spawnPoint;
        private readonly IObjectPool<Bullet> _pool;
        private IBulletCreator _bulletFactory;

        public BulletPool(IBulletCreator bulletFactory, Transform spawnPoint,
            int defaultCapacity = DefaultInitialCapacity, int maxSize = DefaultMaxSize)
        {
            _bulletFactory = bulletFactory;
            _spawnPoint = spawnPoint;
            _pool = new ObjectPool<Bullet>(
                OnCreateBullet,
                OnGetBullet,
                OnReleaseBullet,
                OnDestroyBullet,
                collectionCheck: true,
                defaultCapacity,
                maxSize);
        }

        public Bullet Create() => _pool.Get();
        public void Recycle(Bullet bullet) => _pool.Release(bullet);

        private Bullet OnCreateBullet()
        {
            Bullet bullet = _bulletFactory.Create();
            SetupBulletPosition(bullet);
            bullet.Initialize(this);
            return bullet;
        }

        private void OnGetBullet(Bullet bullet)
        {
            Bullet bulletObject = bullet;
            SetupBulletPosition(bulletObject);
            EnableBullet(bulletObject);
        }

        private void OnReleaseBullet(Bullet bullet)
        {
            DisableBullet(bullet);
        }

        private void OnDestroyBullet(Bullet bullet)
        {
            _bulletFactory.Recycle(bullet);
        }

        private void SetupBulletPosition(Bullet bulletObject)
        {
            Transform transform = bulletObject.transform;
            transform.position = _spawnPoint.position;
            transform.rotation = _spawnPoint.rotation;
        }

        private void EnableBullet(Bullet bulletObject) =>
            bulletObject.gameObject.SetActive(true);

        private void DisableBullet(Bullet bulletObject) =>
            bulletObject.gameObject.SetActive(false);
    }
}