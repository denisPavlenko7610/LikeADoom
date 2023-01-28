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
        public float AttackCooldown { get; }
        public float ProjectileSpeed { get; }
        public LayerMask PlayerMask { get; }

        public EnemyStats(int initialHealth, int initialDamage, float moveSpeed, float aggroRadius,
            float attackDistance,
            float attackCooldown, float projectileSpeed, LayerMask playerMask)
        {
            InitialHealth = initialHealth;
            InitialDamage = initialDamage;
            MoveSpeed = moveSpeed;
            AggroRadius = aggroRadius;
            AttackDistance = attackDistance;
            AttackCooldown = attackCooldown;
            ProjectileSpeed = projectileSpeed;
            PlayerMask = playerMask;
        }
    }
}