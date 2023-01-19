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
        private readonly Transform _rotationParent;
        private readonly IObjectPool<Bullet> _pool;

        public BulletPool(GameObject bulletPrefab, Transform parent, Transform rotationParentParent, int defaultCapacity = DefaultInitialCapacity, int maxSize = DefaultMaxSize)
        {
            _prefab = bulletPrefab;
            _parent = parent;
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
        
        public IBullet Create(Vector3 position)
        {
            Bullet bullet = _pool.Get();
            var transform = bullet.transform;
            transform.position = position;
            transform.rotation = _rotationParent.rotation;
            return bullet;
        }

        private Bullet OnCreateBullet()
        {
            GameObject bulletObject = Object.Instantiate(_prefab, _parent, true);
            return bulletObject.GetComponent<Bullet>();
        }

        private void OnGetBullet(Bullet bullet)
        {
            Debug.Log("Bullet got!");
        }

        private void OnReleaseBullet(Bullet bullet)
        {
            Debug.Log("Bullet released!");
        }

        private void OnDestroyBullet(Bullet bullet)
        {
            Debug.Log("Bullet destroyed!");
        }
    }
}