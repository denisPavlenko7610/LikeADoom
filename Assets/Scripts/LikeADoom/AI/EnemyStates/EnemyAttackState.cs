using LikeADoom.Shooting;
using UnityEngine;

namespace LikeADoom
{
    public class EnemyAttackState : EnemyState
    {
        private readonly float _attackDistance;
        private readonly float _attackCooldownSeconds;
        private readonly float _projectileSpeed;
        private readonly BulletPool _pool;

        private float _timePassed;

        private const int PoolInitialCapacity = 5;
        private const int PoolMaximumCapacity = 20;

        public EnemyAttackState(
            IEnemyStateSwitcher switcher, 
            Transform transform, 
            Transform target,
            GameObject projectilePrefab,
            float attackDistance, 
            float attackCooldownSeconds,
            float projectileSpeed
        ) 
            : base(switcher, transform, target)
        {
            IBulletFactory factory = new BulletFactory(projectilePrefab, Transform, Transform, Transform);
            _pool = new BulletPool(factory, Transform, PoolInitialCapacity, PoolMaximumCapacity);
            _attackDistance = attackDistance;
            _attackCooldownSeconds = attackCooldownSeconds;
            _projectileSpeed = projectileSpeed;
        }

        public override void Enter() => _timePassed = 0;
        public override void Exit() => _timePassed = 0;

        public override void Act()
        {
            Transform.LookAt(Target);
            
            if (Vector3.Distance(Transform.position, Target.position) >= _attackDistance)
                StateSwitcher.SwitchTo(EnemyStates.Chase);

            if (_timePassed >= _attackCooldownSeconds)
            {
                Attack();
                _timePassed = 0;
            }
            else
            {
                _timePassed += Time.deltaTime;
            }
        }

        private void Attack()
        {
            IBullet bullet = _pool.Create();
            IShootPoint movement = new BulletMovement(Vector3.forward, _projectileSpeed);
            bullet.Shoot(movement);
        }
    }
}