using LikeADoom.Units.Enemies.StateMachine;
using UnityEngine;

namespace LikeADoom.Units.Enemies.EnemyStates.States
{
    public class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(IEnemyStateSwitcher switcher, Transform transform, Targeting.Targeting targeting) 
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