using LikeADoom.Units.Enemies.StateMachine;
using UnityEngine;

namespace LikeADoom.Units.Enemies.EnemyStates.States
{
    public class EnemyStunnedState : EnemyState
    {
        readonly float _stunDuration;
        float _timePassed;
        
        public EnemyStunnedState(IEnemyStateSwitcher stateSwitcher, Transform transform, Targeting.Targeting targeting, float stunDuration) 
            : base(stateSwitcher, transform, targeting)
        {
            _stunDuration = stunDuration;
        }

        public override void Enter() => _timePassed = 0;

        public override void Act()
        {
            _timePassed += Time.deltaTime;
            if (_timePassed >= _stunDuration)
                StateSwitcher.SwitchTo(EnemyStates.Idle);
        }
    }
}