using LikeADoom.Units.Enemies.StateMachine;
using UnityEngine;

namespace LikeADoom.Units.Enemies.EnemyStates.States
{
    public class EnemyAttackState : EnemyState
    {
        readonly EnemyAttack _attack;

        float _timePassed;

        public EnemyAttackState(
            IEnemyStateSwitcher switcher, 
            Transform transform, 
            Targeting.Targeting targeting,
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
            
            if (Targeting.IsTargetAtMediumDistanceOrFurther)
                StateSwitcher.SwitchTo(EnemyStates.Chase);
        }
    }
}