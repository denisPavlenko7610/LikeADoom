using LikeADoom.HUD;
using UnityEngine;
using Zenject;

namespace LikeADoom.Units.Player
{
    public class PlayerView : MonoBehaviour
    {
        Animator _animator;
        
        ArmorBar _armorBar;
        HealthBar _healthBar;

        const string HurtAnimationName = "Hurt";
        
        [Inject]
        void Initialize(ArmorBar armorBar, HealthBar healthBar)
        {
            _armorBar = armorBar;
            _healthBar = healthBar;
        }

        public void PlayPlayerHurtAnimation() => _animator?.Play(HurtAnimationName);

        public void UpdateArmor(int count, int maxAmount) => _armorBar.SetValue(count, maxAmount);
        public void UpdateHealth(int count, int maxAmount) => _healthBar.SetValue(count, maxAmount);
    }
}