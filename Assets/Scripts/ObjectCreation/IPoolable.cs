using System;
using UnityEngine;

namespace LikeADoom.ObjectCreation
{
    public interface IPoolable<out T>
    {
        public event Action<IPoolable<T>> ReleaseRequested;

        public T GetObject();
        
        public IPoolable<T> SetPosition(Vector3 position);
        public IPoolable<T> SetRotation(Quaternion rotation);

        public void Enable();
        public void Disable();
        public void Destroy();
    }
}