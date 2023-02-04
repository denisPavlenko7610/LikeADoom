using LikeADoom.LikeADoom.Enemies;
using UnityEngine;

namespace LikeADoom
{
    [RequireComponent(typeof(EnemyAttack), typeof(EnemyMovement), typeof(DistanceChecker))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private DistanceChecker _checker;

        private EnemyStateMachine _stateMachine;

        public void Initialize(Transform target)
        {
            Targeting targeting = new Targeting(target, _checker);
            _stateMachine = new EnemyStateMachine(transform, targeting, _attack, _movement);
            
            targeting.Start();
        }
        
        public void Act() => _stateMachine.Act();
    }
}