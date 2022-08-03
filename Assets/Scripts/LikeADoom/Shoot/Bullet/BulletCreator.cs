using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class BulletCreator : IBulletCreator
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;

        public BulletCreator(GameObject prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public IBullet Create(Vector3 position)
        {
            GameObject cartridge = Object.Instantiate(_prefab, position, Quaternion.identity);
            cartridge.transform.SetParent(_parent);
            return cartridge.GetComponent<IBullet>();
        }
    }
}