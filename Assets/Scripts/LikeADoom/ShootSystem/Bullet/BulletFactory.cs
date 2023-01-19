using UnityEngine;

namespace LikeADoom.Shooting
{
    public class BulletFactory : IBulletCreator
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Transform _spawnPoint;
        private readonly Transform _cameraTransform;

        public BulletFactory(GameObject prefab, Transform parent, Transform spawnPoint, Transform cameraTransform)
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
            return cartridge.GetComponent<IBullet>();
        }

        public void Recycle(Bullet bullet)
        {
            // TODO: Find a way to remove this bullet
        }
    }
}