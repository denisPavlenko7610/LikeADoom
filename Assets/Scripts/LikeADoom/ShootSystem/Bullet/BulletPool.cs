using UnityEngine;
using UnityEngine.Pool;

namespace LikeADoom.Shooting
{
    public class BulletPool : IBulletCreator
    {
        public const int DefaultInitialCapacity = 3;
        public const int DefaultMaxSize = 10;
        
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Transform _spawnPoint;
        private readonly Transform _rotationParent;
        private readonly IObjectPool<IBullet> _pool;

        public BulletPool(
            GameObject bulletPrefab, Transform parent, Transform spawnPoint, Transform rotationParentParent, 
            int defaultCapacity = DefaultInitialCapacity, int maxSize = DefaultMaxSize)
        {
            _prefab = bulletPrefab;
            _parent = parent;
            _spawnPoint = spawnPoint;
            _rotationParent = rotationParentParent;
            _pool = new ObjectPool<IBullet>(
                OnCreateBullet, 
                OnGetBullet, 
                OnReleaseBullet,
                OnDestroyBullet,
                collectionCheck: true,
                defaultCapacity,
                maxSize);
        }
        
        public IBullet Create()
        {
            IBullet bullet = _pool.Get();
            return bullet;
        }

        private IBullet OnCreateBullet()
        {
            GameObject bulletObject = Object.Instantiate(_prefab, _parent, true);
            Transform transform = bulletObject.transform;
            transform.position = _spawnPoint.position;
            transform.rotation = _rotationParent.rotation;
            
            return bulletObject.GetComponent<IBullet>();
        }

        private void OnGetBullet(IBullet bullet)
        {
            Debug.Log("Bullet got!");
        }

        private void OnReleaseBullet(IBullet bullet)
        {
            Debug.Log("Bullet released!");
        }

        private void OnDestroyBullet(IBullet bullet)
        {
            Debug.Log("Bullet destroyed!");
        }
    }
}