using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom
{
    public class EnemyStateMachine : IEnemyStateSwitcher
    {
        private readonly Dictionary<EnemyStates, EnemyState> _states;
        private EnemyState _currentState;

        public EnemyStateMachine(Transform transform, Transform target, EnemyAttack attack, EnemyMovement movement)
        {
            EnemyIdleState idleState = new(this, transform, target);
            EnemyChaseState chaseState = new(this, transform, target, movement);
            EnemyAttackState attackState = new(this, transform, target, attack);

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