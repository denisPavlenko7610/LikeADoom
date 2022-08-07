using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IShootPoint
    {
        public Vector3 GetNextShootPoint();
    }
}