using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom
{
    public class EnemyStateMachine : IEnemyStateSwitcher
    {
        private readonly Dictionary<EnemyStates, EnemyState> _states;
        private EnemyState _currentState;

        public EnemyStateMachine(EnemyStats stats, Transform transform, Transform target)
        {
            EnemyIdleState idleState = new(this, transform, target, stats.AggroRadius, stats.PlayerMask);
            EnemyChaseState chaseState = new(this, transform, target, stats.AttackDistance);
            EnemyAttackState attackState = new(this, transform, target);

            _states = new Dictionary<EnemyStates, EnemyState>()
            {
                { EnemyStates.Idle, idleState },
                { EnemyStates.Chase, chaseState },
                { EnemyStates.Attacking, attackState }
            };

            _currentState = _states[EnemyStates.Idle];
        }

        public void Act() => _currentState.Act();

        public void SwitchTo(EnemyStates state)
        {
            _currentState.Exit();
            _currentState = _states[state];
            _currentState.Enter();
        }
    }
}