using UnityEngine;

namespace LikeADoom.Shooting
{
    public class BulletFactory : IBulletFactory
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Transform _spawnPoint;
        private readonly Transform _rotation;

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