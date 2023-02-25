using System;
using LikeADoom.LikeADoom.Enemies;
using LikeADoom.Creatures;
using RDTools.AutoAttach;
using UnityEngine;

namespace LikeADoom
{
    [
        RequireComponent(typeof(Health)),
        RequireComponent(typeof(EnemyAttack)),
        RequireComponent(typeof(EnemyMovement)),
        RequireComponent(typeof(DistanceChecker))
    ]
    public class Enemy : MonoBehaviour 
    {
        [SerializeField, Attach] private Health _health;
        [SerializeField, Attach] private EnemyAttack _attack;
        [SerializeField, Attach] private EnemyMovement _movement;
        [SerializeField, Attach] private DistanceChecker _checker;

        private EnemyStateMachine _stateMachine;

        public event Action<Enemy> Dead;

        private void Awake()
        {
            _health.Damaged += OnDamaged;
            _health.Dying += OnDying;
        }

        private void OnDestroy()
        {
            _health.Damaged -= OnDamaged;
            _health.Dying -= OnDying;
        }

        public void Initialize(Transform target)
        {
            Targeting targeting = new Targeting(target, _checker);
            _stateMachine = new EnemyStateMachine(transform, targeting, _attack, _movement);
            
            targeting.Start();
        }

        public void Act() => _stateMachine.Act();

        private void OnDamaged(int damage)
        {
            _stateMachine.SwitchTo(EnemyStates.Stunned);
        }

        private void OnDying()
        {
            Dead?.Invoke(this);
        }
    }
}