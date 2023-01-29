using UnityEngine;

namespace LikeADoom
{
    public class EnemyAttackState : EnemyState
    {
        private readonly EnemyAttack _attack;

        private float _timePassed;

        public EnemyAttackState(
            IEnemyStateSwitcher switcher, 
            Transform transform, 
            Transform target,
            EnemyAttack attack
        ) 
            : base(switcher, transform, target)
        {
            _attack = attack;
        }

        public override void Enter() => _timePassed = 0;
        public override void Exit() => _timePassed = 0;

        public override void Act()
        {
            Transform.LookAt(Target);
            
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