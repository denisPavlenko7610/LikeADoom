using UnityEngine;

namespace LikeADoom.Shooting.BulletBuilder
{
    public class BulletBuilder : IBulletBuilder
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Transform _spawnPoint;
        private readonly Transform _rotation;
        private IBullet _bullet;

        public BulletBuilder(GameObject prefab, Transform parent, Transform spawnPoint)
            : this(prefab, parent, spawnPoint, spawnPoint) { }
            
        public BulletBuilder(GameObject prefab, Transform parent, Transform spawnPoint, Transform rotation)
        {
            _prefab = prefab;
            _parent = parent;
            _spawnPoint = spawnPoint;
            _rotation = rotation;
        }

        public IObjectBuilder<IBullet> AtTransform(Transform transform)
        {
            CreateIfNull();
            
            _bullet.SetPosition(transform.position)
                .SetRotation(transform.rotation);
            
            return this;
        }

        public IBullet Build()
        {
            _bullet.Enable();
            var copyBullet = _bullet;
            _bullet = null;
            return copyBullet;
        }

        private void CreateIfNull()
        {
            if (IsBulletNull())
                Create();
        }

        private bool IsBulletNull() => _bullet == null;

        private void Create()
        {
            GameObject cartridge = Object.Instantiate(_prefab, _spawnPoint.position, _rotation.rotation);
            cartridge.transform.SetParent(_parent);
            _bullet = cartridge.GetComponent<Bullet>();
        }
    }
}