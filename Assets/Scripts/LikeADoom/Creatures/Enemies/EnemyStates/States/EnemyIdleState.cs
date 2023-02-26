using LikeADoom.LikeADoom.Creatures.Enemies.Targeting;
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
            if (Targeting.IsTargetAtMediumDistanceOrCloser)
                StateSwitcher.SwitchTo(EnemyStates.Chase);
        }
    }
}