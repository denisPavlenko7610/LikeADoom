using UnityEngine;

namespace LikeADoom.Units.Player
{
    public interface IPlayerTransformProvider
    {
        public Transform Transform { get; }
    }
}