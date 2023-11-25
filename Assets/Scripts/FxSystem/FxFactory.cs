using LikeADoom.ObjectCreation;
using UnityEngine;

namespace LikeADoom.FxSystem
{
    public class FxFactory : IObjFactory
    {
        public T Create<T>(GameObject prefab, GameObject parent)
        {
            return Object.Instantiate(prefab, parent.transform.position, parent.transform.rotation, parent.transform)
                .GetComponent<T>();
        }
    }
}