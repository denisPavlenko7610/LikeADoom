using UnityEngine;

namespace LikeADoom.Shooting
{
    public class BulletBulletFactory : IBulletFactory
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Transform _spawnPoint;
        private readonly Transform _cameraTransform;

        public BulletBulletFactory(GameObject prefab, Transform parent, Transform spawnPoint, Transform cameraTransform)
        {
            _prefab = prefab;
            _spawnPoint = spawnPoint;
            _parent = parent;
            _cameraTransform = cameraTransform;
        }

        public IBullet Create()
        {
            GameObject cartridge = Object.Instantiate(_prefab, _spawnPoint.position, _cameraTransform.rotation);
            cartridge.transform.SetParent(_parent);
            return cartridge.GetComponent<Bullet>();
        }
    }
}