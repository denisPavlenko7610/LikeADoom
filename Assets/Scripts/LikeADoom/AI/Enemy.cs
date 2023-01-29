using UnityEngine;

namespace LikeADoom
{
    [RequireComponent(typeof(EnemyAttack))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField, Range(0.1f, 10f)] private float _moveSpeed;
        [SerializeField, Range(1f, 50f)] private float _aggroRadius;
        [SerializeField, Range(1f, 50f)] private float _attackDistance;
        [SerializeField] private LayerMask _playerMask;

        private EnemyAttack _enemyAttack;
        private EnemyStateMachine _stateMachine;

        public void Initialize(Transform target)
        {
            EnemyStats stats = new(_health, _damage, _moveSpeed, _aggroRadius, _attackDistance, _playerMask);
            _enemyAttack = GetComponent<EnemyAttack>();
            _enemyAttack.Initialize();
            _stateMachine = new EnemyStateMachine(stats, transform, target, _enemyAttack);
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