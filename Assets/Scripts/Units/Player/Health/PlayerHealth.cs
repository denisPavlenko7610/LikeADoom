using LikeADoom.Core;
using System;
using UnityEngine;

namespace LikeADoom.Units.Player.Health
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField, Range(0, 100)] int _armorDefensePercentage;
        [field:SerializeField] public int MaxArmor { get; set; }
        [field:SerializeField] public int MaxHealth { get; set; }
        public int CurrentArmor { get; private set; }
        public int CurrentHealth { get; private set; }
        public event Action<int> HealthChanged;
        public event Action<int> ArmorChanged;
        public event Action Dying;

        public void Init()
        {
            if (GameSettings.IsNewGame)
            {
                CurrentHealth = MaxHealth;
                CurrentArmor = MaxArmor;
            }
        }
        
        bool HasArmor => CurrentArmor > 0;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Debug.LogError($"Damage can't be negative! Was: {damage}.");
                return;
            }

            if (HasArmor)
            {
                damage = damage * (100 - _armorDefensePercentage) / 100;
                damage = Mathf.Min(CurrentArmor, damage);
                CurrentArmor -= damage;
            }
            else
            {
                damage = Math.Min(CurrentHealth, damage);
                CurrentHealth -= damage;
                
                if (CurrentHealth <= 0)
                    Die();
            }
            
            HealthChanged?.Invoke(damage);
        }
        
        public void Heal(int amount)
        {
            if (amount < 0)
                Debug.LogError($"Can't heal negative amount of health! Was: {amount}.");

            CurrentHealth += amount;
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth);
            
            HealthChanged?.Invoke(amount);
        }

        public void UpdateParams(int health, int armor)
        {
            CurrentHealth = Mathf.Clamp(health, CurrentHealth, MaxHealth);
            CurrentArmor = Mathf.Clamp(armor, CurrentArmor, MaxArmor);
        }

        void Die()
        {
            Dying?.Invoke();
        }

        public void ArmorUp(int count)
        {
            if (count < 0)
                Debug.LogError($"Can't armor up on a negative armor amount! Was: {count}");

            CurrentArmor += count;
            CurrentArmor = Math.Min(MaxArmor, CurrentArmor);
            
            ArmorChanged?.Invoke(count);
        }
    }
}