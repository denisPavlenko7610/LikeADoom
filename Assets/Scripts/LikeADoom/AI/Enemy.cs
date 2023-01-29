using System;
using UnityEngine;

namespace LikeADoom
{
    [RequireComponent(typeof(EnemyAttack), typeof(EnemyMovement), typeof(DistanceChecker))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;

        private DistanceChecker _checker;
        private EnemyStateMachine _stateMachine;

        public void Initialize(Transform target)
        {
            EnemyAttack attack = GetComponent<EnemyAttack>();
            EnemyMovement movement = GetComponent<EnemyMovement>();
            DistanceChecker checker = GetComponent<DistanceChecker>();
            attack.Initialize();
            checker.Initialize(target);
            
            _stateMachine = new EnemyStateMachine(transform, target, attack, movement);
            _checker = checker;
            _checker.OnReachDistance += SwitchState;
            _checker.StartChecking();
        }
        
        private void OnDestroy()
        {
            _checker.OnReachDistance -= SwitchState;
        }
        
        public void Act() => _stateMachine.Act();

        private void SwitchState(DistanceChecker.Distance distance)
        {
            switch (distance)
            {
                case DistanceChecker.Distance.Closest:
                    _stateMachine.SwitchTo(EnemyStates.Attacking);
                    break;
                case DistanceChecker.Distance.Close:
                    _stateMachine.SwitchTo(EnemyStates.Chase);
                    break;
                case DistanceChecker.Distance.Medium:
                    _stateMachine.SwitchTo(EnemyStates.Idle);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(distance), distance, null);
            }
        }
    }
}