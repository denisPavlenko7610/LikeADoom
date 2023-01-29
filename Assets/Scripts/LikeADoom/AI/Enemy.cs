using UnityEngine;

namespace LikeADoom
{
    [RequireComponent(typeof(EnemyAttack), typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField, Range(0.1f, 10f)] private float _moveSpeed;
        [SerializeField, Range(1f, 50f)] private float _aggroRadius;
        [SerializeField, Range(1f, 50f)] private float _attackDistance;
        [SerializeField] private LayerMask _playerMask;

        private EnemyMovement _movement;
        private EnemyAttack _attack;
        private EnemyStateMachine _stateMachine;

        public void Initialize(Transform target)
        {
            EnemyStats stats = new(_health, _damage, _moveSpeed, _aggroRadius, _attackDistance, _playerMask);
            _attack = GetComponent<EnemyAttack>();
            _attack.Initialize();
            _movement = GetComponent<EnemyMovement>();
            _stateMachine = new EnemyStateMachine(stats, transform, target, _attack, _movement);
        }

        public void Act() => _stateMachine.Act();

        private void OnDrawGizmos()
        {
            var position = transform.position;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(position, _aggroRadius);
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(position, _attackDistance);
        }
    }
}