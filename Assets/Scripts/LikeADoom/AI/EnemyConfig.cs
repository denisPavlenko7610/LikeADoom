using UnityEngine;

namespace LikeADoom
{
    [CreateAssetMenu(menuName = "Enemy Config", fileName = "SO_EnemyConfig", order = 51)]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public float AggroRadius { get; private set; }
        [field: SerializeField] public float AttackDistance { get; private set; }
        [field: SerializeField] public LayerMask CheckMask { get; private set; }
    }
}