using LikeADoom.LikeADoom.ObjectCreation;
using UnityEngine;

namespace LikeADoom.LikeADoom.Environment.NonInteractable.Barrel
{
    public class ObjFactory : IObjFactory
    {
        public T Create<T>(GameObject prefab, GameObject parent)
        {
           return Object.Instantiate(prefab, parent.transform.position, parent.transform.rotation,
                parent.transform).GetComponent<T>();
        }
    }
}