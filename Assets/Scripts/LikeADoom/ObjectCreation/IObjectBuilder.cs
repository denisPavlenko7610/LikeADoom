using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IObjectBuilder<out T>
    {
        public IObjectBuilder<T> AtTransform(Transform transform);
        public T Build();
    }
}