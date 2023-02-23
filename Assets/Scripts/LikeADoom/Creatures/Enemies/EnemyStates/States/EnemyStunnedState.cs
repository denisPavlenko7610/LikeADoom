using UnityEngine;

namespace LikeADoom
{
    public class EnemyStunnedState : EnemyState
    {
        private readonly float _stunDuration;
        private float _timePassed;
        
        public EnemyStunnedState(IEnemyStateSwitcher stateSwitcher, Transform transform, Targeting targeting, float stunDuration) 
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