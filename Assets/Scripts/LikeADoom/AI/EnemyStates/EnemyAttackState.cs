using UnityEngine;

namespace LikeADoom
{
    public class EnemyAttackState : EnemyState
    {
        private readonly float _attackDistance;

        public EnemyAttackState(IEnemyStateSwitcher switcher, Transform transform, Transform target, float attackDistance) 
            : base(switcher, transform, target)
        {
            _attackDistance = attackDistance;
        }

        public override void Act()
        {
            if (Vector3.Distance(Transform.position, Target.position) > _attackDistance)
                StateSwitcher.SwitchTo(EnemyStates.Chase);
        }
    }
}