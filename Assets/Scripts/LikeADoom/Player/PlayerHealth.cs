using System;
using RDTools.AutoAttach;
using UnityEngine;

namespace LikeADoom.Entities
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxArmor;
        [SerializeField] private int _maxHealth;
        [SerializeField, Range(0, 100)] private int _armorDefensePercentage;

        private void Awake()
        {
            Armor = _maxArmor;
            Health = _maxHealth;
        }

        public int Armor { get; private set; }
        public int Health { get; private set; }
        public int MaxArmor => _maxArmor;
        public int MaxHealth => _maxHealth;

        public event Action<int> Damaged;
        public event Action Dying;
        
        private bool HasArmor => Armor > 0;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                Debug.LogError($"Damage can't be negative! Was: {damage}.");
            
            if (HasArmor)
            {
                damage = damage * (100 - _armorDefensePercentage) / 100;
                damage = Math.Min(Armor, damage);
                Armor -= damage;
            }
            else
            {
                damage = Math.Min(Health, damage);
                Health -= damage;
                
                if (Health <= 0)
                    Die();
            }
            
            Damaged?.Invoke(damage);
        }

        private void Die()
        {
            Dying?.Invoke();
        }
    }
}