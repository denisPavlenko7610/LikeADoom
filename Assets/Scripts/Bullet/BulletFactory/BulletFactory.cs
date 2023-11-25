using LikeADoom.ObjectCreation;
using UnityEngine;

namespace LikeADoom.Bullet.BulletFactory
{
    public class BulletFactory : IObjectFactory<IBullet>
    {
        readonly GameObject _prefab;
        readonly Transform _parent;
        readonly Transform _spawnPoint;
        readonly Transform _rotation;

        public BulletFactory(GameObject prefab, Transform parent, Transform spawnPoint)
            : this(prefab, parent, spawnPoint, spawnPoint) { }
        
        public BulletFactory(GameObject prefab, Transform parent, Transform spawnPoint, Transform rotation)
        {
            _prefab = prefab;
            _spawnPoint = spawnPoint;
            _parent = parent;
            _rotation = rotation;
        }

        public IBullet Create()
        {
            GameObject cartridge = Object.Instantiate(_prefab, _spawnPoint.position, _rotation.rotation);
            cartridge.transform.SetParent(_parent);
            return cartridge.GetComponent<Bullet>();
        }
    }
}