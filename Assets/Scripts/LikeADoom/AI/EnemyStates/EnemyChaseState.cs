using UnityEngine;

namespace LikeADoom
{
    public class EnemyChaseState : EnemyState
    {
        private readonly float _chaseDistance;
        private readonly float _attackDistance;

        public EnemyChaseState(IEnemyStateSwitcher switcher, Transform transform, Transform target, float chaseDistance, float attackDistance) 
            : base(switcher, transform, target)
        {
            _chaseDistance = chaseDistance;
            _attackDistance = attackDistance;
        }

        public override void Act()
        {
            Transform.LookAt(Target);

            float distance = Vector3.Distance(Transform.position, Target.position);
            if (distance < _attackDistance )
                StateSwitcher.SwitchTo(EnemyStates.Attacking);
            else if (distance >= _chaseDistance)
                StateSwitcher.SwitchTo(EnemyStates.Idle);
        }
    }
}