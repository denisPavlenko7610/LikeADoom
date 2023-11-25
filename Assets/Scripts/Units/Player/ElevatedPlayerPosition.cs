using UnityEngine;

namespace LikeADoom.Units.Player
{
    public class ElevatedPlayerPosition : IPlayerTransformProvider
    {
        const float DefaultElevation = 1f;

        public ElevatedPlayerPosition(Player player, float elevation = DefaultElevation)
        {
            GameObject elevatedTransform = new GameObject("Elevated");
            Transform = Object.Instantiate(elevatedTransform.transform, player.transform);
            Transform.position += new Vector3(0f, elevation);
        }
        
        public Transform Transform { get; }
    }
}