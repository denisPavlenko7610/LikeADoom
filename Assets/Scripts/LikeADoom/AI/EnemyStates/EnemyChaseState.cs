using UnityEngine;

namespace LikeADoom
{
    public class EnemyChaseState : EnemyState
    {
        private readonly float _attackDistance;

        public EnemyChaseState(IEnemyStateSwitcher switcher, Transform transform, Transform target, float attackDistance) 
            : base(switcher, transform, target)
        {
            _attackDistance = attackDistance;
        }

        public override void Act()
        {
            Debug.Log("Chase!");
            Transform.LookAt(Target);

            if (Vector3.Distance(Transform.position, Target.position) < _attackDistance)
            {
                StateSwitcher.SwitchTo(EnemyStates.Attacking);
            }
        }
    }
}