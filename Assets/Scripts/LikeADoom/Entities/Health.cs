using System;
using UnityEngine;

namespace LikeADoom.Entities
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth;
        private int _health;

        private void Awake()
        {
            _health = _maxHealth;
        }
        
        public int Value => _health;
        public int Max => _maxHealth;

        public event Action Dying;
        public event Action<int> Damaged;

        public virtual void TakeDamage(int damage)
        {
            if (damage < 0)
                Debug.LogError($"Damage can't be negative! Was: {damage}.");

            damage = Math.Min(_health, damage);
            _health -= damage;
            Damaged?.Invoke(damage);

            if (_health <= 0)
                Die();
        }

        private void Die()
        {
            Dying?.Invoke();
        }
    }
}