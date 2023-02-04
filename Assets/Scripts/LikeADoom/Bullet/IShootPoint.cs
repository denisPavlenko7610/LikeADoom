using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IShootPoint
    {
        Vector3 GetNextShootPoint();
    }
}