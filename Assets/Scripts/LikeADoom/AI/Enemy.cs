using UnityEngine;

namespace LikeADoom
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;

        private EnemyStateMachine _stateMachine;

        public void Initialize(EnemyConfig config, Transform target)
        {
            _stateMachine = new EnemyStateMachine(config, transform, target);
        }

        public void Act() => _stateMachine.Act();
    }
}