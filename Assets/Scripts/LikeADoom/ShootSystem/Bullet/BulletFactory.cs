using UnityEngine;

namespace LikeADoom.Shooting
{
    public class BulletFactory : IBulletCreator
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Transform _cameraTransform;

        public BulletFactory(GameObject prefab, Transform parent, Transform cameraTransform)
        {
            _prefab = prefab;
            _parent = parent;
            _cameraTransform = cameraTransform;
        }

        public IBullet Create(Vector3 position)
        {
            GameObject cartridge = Object.Instantiate(_prefab, position, _cameraTransform.rotation);
            cartridge.transform.SetParent(_parent);
            return cartridge.GetComponent<IBullet>();
        }
    }
}