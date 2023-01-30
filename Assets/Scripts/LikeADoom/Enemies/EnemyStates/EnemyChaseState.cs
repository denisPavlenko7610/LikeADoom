using UnityEngine;

namespace LikeADoom
{
    public class EnemyChaseState : EnemyState
    {
        private readonly EnemyMovement _movement;

        public EnemyChaseState(IEnemyStateSwitcher switcher, Transform transform, Targeting targeting, EnemyMovement movement) 
            : base(switcher, transform, targeting)
        {
            _movement = movement;
        }

        public override void Act()
        {
            _movement.HoverTo(Targeting.Target);
            
            if (Targeting.IsTargetClose)
                StateSwitcher.SwitchTo(EnemyStates.Attacking);
            else if (Targeting.IsTargetFar)
                StateSwitcher.SwitchTo(EnemyStates.Idle);
        }
    }
}