using UnityEngine;
using UnityEngine.Pool;

namespace LikeADoom.Shooting
{
    public class BulletPool : IBulletCreator
    {
        public const int DefaultInitialCapacity = 10;
        public const int DefaultMaxSize = 100;
        
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Transform _spawnPoint;
        private readonly Transform _rotationParent;
        private readonly IObjectPool<Bullet> _pool;

        public BulletPool(
            GameObject bulletPrefab, Transform parent, Transform spawnPoint, Transform rotationParentParent, 
            int defaultCapacity = DefaultInitialCapacity, int maxSize = DefaultMaxSize)
        {
            _prefab = bulletPrefab;
            _parent = parent;
            _spawnPoint = spawnPoint;
            _rotationParent = rotationParentParent;
            _pool = new ObjectPool<Bullet>(
                OnCreateBullet, 
                OnGetBullet, 
                OnReleaseBullet,
                OnDestroyBullet,
                collectionCheck: true,
                defaultCapacity,
                maxSize);
        }

        public IBullet Create() => _pool.Get();
        public void Recycle(Bullet bullet) => _pool.Release(bullet);

        private Bullet OnCreateBullet()
        {
            GameObject bulletObject = Object.Instantiate(_prefab, _parent, true);
            SetupBulletPosition(bulletObject);
            var bullet = InitBullet(bulletObject);
            return bullet;
        }

        private void OnGetBullet(Bullet bullet)
        {
            GameObject bulletObject = bullet.gameObject;
            SetupBulletPosition(bulletObject);
            EnableBullet(bulletObject);
        }
        
        private void OnReleaseBullet(Bullet bullet)
        {
            DisableBullet(bullet.gameObject);
        }
        
        private void OnDestroyBullet(Bullet bullet)
        {
            DestroyBullet(bullet.gameObject);
        }
        
        private void SetupBulletPosition(GameObject bulletObject)
        {
            Transform transform = bulletObject.transform;
            transform.position = _spawnPoint.position;
            transform.rotation = _rotationParent.rotation;
        }

        private Bullet InitBullet(GameObject bulletObject)
        {
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.Initialize(this);
            return bullet;
        }

        private void EnableBullet(GameObject bulletObject) =>
            bulletObject.SetActive(true);
        private void DisableBullet(GameObject bulletObject) =>
            bulletObject.SetActive(false);
        private void DestroyBullet(GameObject bulletObject) =>
            Object.Destroy(bulletObject);
    }
}