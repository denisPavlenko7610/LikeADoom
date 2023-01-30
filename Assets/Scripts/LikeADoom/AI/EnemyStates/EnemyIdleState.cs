using UnityEngine;

namespace LikeADoom
{
    public class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(IEnemyStateSwitcher switcher, Transform transform, Targeting targeting) 
            : base(switcher, transform, targeting)
        {
        }
        
        public override void Act()
        {
            if (Targeting.IsTargetAtMediumDistanceOrClose)
                StateSwitcher.SwitchTo(EnemyStates.Chase);
        }
    }
}