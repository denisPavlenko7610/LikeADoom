using System;
using UnityEngine;

namespace LikeADoom.Creatures
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
            Changed?.Invoke(0);
        }

        public int Armor { get; private set; }
        public int Health { get; private set; }
        public int MaxArmor => _maxArmor;
        public int MaxHealth => _maxHealth;

        public event Action<int> Changed;
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
            
            Changed?.Invoke(damage);
        }
        
        public void Heal(int amount)
        {
            if (amount < 0)
                Debug.LogError($"Can't heal negative amount of health! Was: {amount}.");

            Health += amount;
            Health = Math.Min(_maxHealth, Health);
            
            Changed?.Invoke(amount);
        }

        private void Die()
        {
            Dying?.Invoke();
        }

        public void ArmorUp(int count)
        {
            if (count < 0)
                Debug.LogError($"Can't armor up on a negative armor amount! Was: {count}");

            Armor += count;
            Armor = Math.Min(_maxArmor, Armor);
            
            Changed?.Invoke(count);
        }
    }
}