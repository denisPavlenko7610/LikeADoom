using UnityEngine;

namespace LikeADoom
{
    public class EnemyStats
    {
        public int InitialHealth { get; }
        public int InitialDamage { get; }
        public float AggroRadius { get; }
        public float AttackDistance { get; }
        public LayerMask PlayerMask { get; }

        public EnemyStats(int initialHealth, int initialDamage, float aggroRadius, float attackDistance, LayerMask playerMask)
        {
            InitialHealth = initialHealth;
            InitialDamage = initialDamage;
            AggroRadius = aggroRadius;
            AttackDistance = attackDistance;
            PlayerMask = playerMask;
        }
    }
}