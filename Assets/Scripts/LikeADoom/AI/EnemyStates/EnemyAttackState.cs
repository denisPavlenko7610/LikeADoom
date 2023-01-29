using LikeADoom.Shooting;
using UnityEngine;

namespace LikeADoom
{
    public class EnemyAttackState : EnemyState
    {
        private readonly EnemyAttack _attack;
        private readonly float _attackDistance;

        private float _timePassed;

        public EnemyAttackState(
            IEnemyStateSwitcher switcher, 
            Transform transform, 
            Transform target,
            EnemyAttack attack,
            float attackDistance
        ) 
            : base(switcher, transform, target)
        {
            _attack = attack;
            _attackDistance = attackDistance;
        }

        public override void Enter() => _timePassed = 0;
        public override void Exit() => _timePassed = 0;

        public override void Act()
        {
            Transform.LookAt(Target);
            
            if (Vector3.Distance(Transform.position, Target.position) >= _attackDistance)
                StateSwitcher.SwitchTo(EnemyStates.Chase);

            if (_timePassed >= _attack.Cooldown)
            {
                _attack.Attack();
                _timePassed = 0;
            }
            else
            {
                _timePassed += Time.deltaTime;
            }
        }
    }
}