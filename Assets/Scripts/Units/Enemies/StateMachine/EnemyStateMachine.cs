using LikeADoom.Units.Enemies.EnemyStates;
using LikeADoom.Units.Enemies.EnemyStates.States;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Units.Enemies.StateMachine
{
    public class EnemyStateMachine : IEnemyStateSwitcher
    {
        readonly Dictionary<EnemyStates.EnemyStates, EnemyState> _states;
        EnemyState _currentState;

        public EnemyStateMachine(Transform transform, Targeting.Targeting targeting, EnemyAttack attack, EnemyMovement movement)
        {
            EnemyIdleState idleState = new EnemyIdleState(this, transform, targeting);
            EnemyChaseState chaseState = new EnemyChaseState(this, transform, targeting, movement);
            EnemyAttackState attackState = new EnemyAttackState(this, transform, targeting, attack);
            EnemyStunnedState stunnedState = new EnemyStunnedState(this, transform, targeting, 0.1f);

            _states = new Dictionary<EnemyStates.EnemyStates, EnemyState>()
            {
                { EnemyStates.EnemyStates.Idle, idleState },
                { EnemyStates.EnemyStates.Chase, chaseState },
                { EnemyStates.EnemyStates.Attacking, attackState },
                { EnemyStates.EnemyStates.Stunned, stunnedState },
            };

            _currentState = _states[EnemyStates.EnemyStates.Idle];
        }

        public void Act() => _currentState.Act();

        public void SwitchTo(EnemyStates.EnemyStates state)
        {
            _currentState.Exit();
            _currentState = _states[state];
            _currentState.Enter();
        }
    }
}