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
            Targeting targeting,
            EnemyAttack attack
        ) 
            : base(switcher, transform, targeting)
        {
            _attack = attack;
        }

        public override void Enter() => _timePassed = 0;
        public override void Exit() => _timePassed = 0;

        public override void Act()
        {
            _attack.ShootPoint.LookAt(Targeting.Target);
            Transform.forward = _attack.ShootPoint.forward;
            
            if (_timePassed >= _attack.Cooldown)
            {
                _attack.Attack();
                _timePassed = 0;
            }
            else
            {
                _timePassed += Time.deltaTime;
            }
            
            if (Targeting.IsTargetAtMediumDistance)
                StateSwitcher.SwitchTo(EnemyStates.Chase);
        }
    }
}