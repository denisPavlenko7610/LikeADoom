using UnityEngine;

namespace LikeADoom
{
    public class EnemyChaseState : EnemyState
    {
        private readonly float _chaseDistance;
        private readonly float _attackDistance;
        private readonly EnemyMovement _movement;

        public EnemyChaseState(IEnemyStateSwitcher switcher, Transform transform, Transform target, float chaseDistance, float attackDistance, EnemyMovement movement) 
            : base(switcher, transform, target)
        {
            _chaseDistance = chaseDistance;
            _attackDistance = attackDistance;
            _movement = movement;
        }

        public override void Act()
        {
            float distance = Vector3.Distance(Transform.position, Target.position);
            if (distance >= _chaseDistance)
                StateSwitcher.SwitchTo(EnemyStates.Idle);
            else if (distance < _attackDistance)
                StateSwitcher.SwitchTo(EnemyStates.Attacking);

            _movement.MoveTo(Target);
        }
    }
}