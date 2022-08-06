using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class BulletCreator : IBulletCreator
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Transform _cameraTransform;

        public BulletCreator(GameObject prefab, Transform parent, Transform cameraTransform)
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