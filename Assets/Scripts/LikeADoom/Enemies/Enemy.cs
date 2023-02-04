using LikeADoom.LikeADoom.Enemies;
using UnityEngine;

namespace LikeADoom
{
    [RequireComponent(typeof(EnemyAttack), typeof(EnemyMovement), typeof(DistanceChecker))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;

        private EnemyStateMachine _stateMachine;

        public void Initialize(Transform target)
        {
            EnemyAttack attack = GetComponent<EnemyAttack>();
            EnemyMovement movement = GetComponent<EnemyMovement>();
            DistanceChecker checker = GetComponent<DistanceChecker>();
            Targeting targeting = new Targeting(target, checker);
            
            _stateMachine = new EnemyStateMachine(transform, targeting, attack, movement);
            
            targeting.Start();
        }
        
        public void Act() => _stateMachine.Act();
    }
}