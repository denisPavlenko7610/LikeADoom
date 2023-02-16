using System;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public abstract class Poolable<T> : MonoBehaviour, IPoolable<T>
    {
        public abstract event Action<IPoolable<T>> ReleaseRequested;

        public abstract T GetObject();

        public IPoolable<T> SetPosition(Vector3 position)
        {
            transform.position = position;
            return this;
        }

        public IPoolable<T> SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
            return this;
        }

        public void Enable() => gameObject.SetActive(true);
        public void Disable() => gameObject.SetActive(false);
        public void Destroy() => Destroy(gameObject);
    }
}