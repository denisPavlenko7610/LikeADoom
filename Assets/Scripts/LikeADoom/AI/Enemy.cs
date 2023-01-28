using UnityEngine;

namespace LikeADoom
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField, Range(0.1f, 10f)] private float _moveSpeed;
        [SerializeField, Range(1f, 50f)] private float _aggroRadius;
        [SerializeField, Range(1f, 50f)] private float _attackDistance;
        [SerializeField, Range(0.01f, 3f)] private float _attackCooldownSeconds;
        [SerializeField, Range(0.1f, 10f)] private float _projectileSpeed;
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private LayerMask _playerMask;

        private EnemyStateMachine _stateMachine;

        public void Initialize(Transform target)
        {
            EnemyStats stats = new(_health, _damage, _moveSpeed, _aggroRadius, _attackDistance, _attackCooldownSeconds, _projectileSpeed, _playerMask);
            _stateMachine = new EnemyStateMachine(stats, transform, target, _projectilePrefab);
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