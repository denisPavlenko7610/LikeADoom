using UnityEngine;

namespace LikeADoom
{
    public class EnemyChaseState : EnemyState
    {
        private readonly float _chaseDistance;
        private readonly float _attackDistance;
        private readonly float _chaseSpeed;

        public EnemyChaseState(IEnemyStateSwitcher switcher, Transform transform, Transform target, float chaseDistance, float attackDistance, float chaseSpeed) 
            : base(switcher, transform, target)
        {
            _chaseDistance = chaseDistance;
            _attackDistance = attackDistance;
            _chaseSpeed = chaseSpeed;
        }

        public override void Act()
        {
            Transform.LookAt(Target);

            float distance = Vector3.Distance(Transform.position, Target.position);
            if (distance >= _chaseDistance)
                StateSwitcher.SwitchTo(EnemyStates.Idle);
            else if (distance < _attackDistance)
                StateSwitcher.SwitchTo(EnemyStates.Attacking);

            Vector3 translation = Transform.forward * (Time.deltaTime * _chaseSpeed);
            Transform.Translate(translation, Space.World);
        }
    }
}