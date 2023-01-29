using UnityEngine;

namespace LikeADoom
{
    public class EnemyStats
    {
        public int InitialHealth { get; }
        public int InitialDamage { get; }
        public float MoveSpeed { get; }
        public float AggroRadius { get; }
        public float AttackDistance { get; }
        public LayerMask PlayerMask { get; }

        public EnemyStats(int initialHealth, int initialDamage, float moveSpeed, float aggroRadius,
            float attackDistance, LayerMask playerMask)
        {
            InitialHealth = initialHealth;
            InitialDamage = initialDamage;
            MoveSpeed = moveSpeed;
            AggroRadius = aggroRadius;
            AttackDistance = attackDistance;
            PlayerMask = playerMask;
        }
    }
}