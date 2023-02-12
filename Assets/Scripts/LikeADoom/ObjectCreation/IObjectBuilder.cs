using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IObjectBuilder<out T>
    {
        public IObjectBuilder<T> At(Transform transform);
        public T Build();
    }
}