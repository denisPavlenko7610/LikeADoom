using UnityEngine;

namespace LikeADoom.LikeADoom.Environment.NonInteractable.Barrel
{
    public interface ICreate
    {
        T Create<T>(GameObject prefab, GameObject parent);
    }
}