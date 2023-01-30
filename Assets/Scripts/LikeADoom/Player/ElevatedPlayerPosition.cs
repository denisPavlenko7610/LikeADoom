using UnityEngine;

namespace LikeADoom
{
    public class ElevatedPlayerPosition : IPlayerTransformProvider
    {
        private const float DefaultElevation = 1f;

        public ElevatedPlayerPosition(Player player, float elevation = DefaultElevation)
        {
            var elevatedTransform = new GameObject("Elevated").GetComponent<Transform>();
            Transform = Object.Instantiate(elevatedTransform, player.transform);
            Transform.position += new Vector3(0f, elevation);
        }
        
        public Transform Transform { get; }
    }
}