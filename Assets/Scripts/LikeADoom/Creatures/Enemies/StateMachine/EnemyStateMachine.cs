using System.Collections.Generic;
using LikeADoom.LikeADoom.Creatures.Enemies.Targeting;
using UnityEngine;

namespace LikeADoom.LikeADoom.Enemies
{
    public class EnemyStateMachine : IEnemyStateSwitcher
    {
        private readonly Dictionary<EnemyStates, EnemyState> _states;
        private EnemyState _currentState;

        public EnemyStateMachine(Transform transform, Targeting targeting, EnemyAttack attack, EnemyMovement movement)
        {
            EnemyIdleState idleState = new(this, transform, targeting);
            EnemyChaseState chaseState = new(this, transform, targeting, movement);
            EnemyAttackState attackState = new(this, transform, targeting, attack);
            EnemyStunnedState stunnedState = new(this, transform, targeting, 0.1f);

            _states = new Dictionary<EnemyStates, EnemyState>()
            {
                { EnemyStates.Idle, idleState },
                { EnemyStates.Chase, chaseState },
                { EnemyStates.Attacking, attackState },
                { EnemyStates.Stunned, stunnedState },
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