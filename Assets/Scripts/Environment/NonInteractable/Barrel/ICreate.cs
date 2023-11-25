using UnityEngine;

namespace LikeADoom.Environment.NonInteractable.Barrel
{
    public interface ICreate
    {
        T Create<T>(GameObject prefab, GameObject parent);
    }
}