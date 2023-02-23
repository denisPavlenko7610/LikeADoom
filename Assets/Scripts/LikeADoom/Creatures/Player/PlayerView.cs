using UnityEngine;
using Zenject;

namespace LikeADoom
{
    public class PlayerView : MonoBehaviour
    {
        private Animator _animator;
        
        private ArmorBar _armorBar;
        private HealthBar _healthBar;

        private const string HurtAnimationName = "Hurt";
        
        [Inject]
        private void Initialize(ArmorBar armorBar, HealthBar healthBar)
        {
            _armorBar = armorBar;
            _healthBar = healthBar;
        }

        public void PlayPlayerHurtAnimation() => _animator?.Play(HurtAnimationName);

        public void ShowArmorLeft(int count, int maxAmount) => _armorBar.SetValue(count, maxAmount);
        public void ShowHealthLeft(int count, int maxAmount) => _healthBar.SetValue(count, maxAmount);
    }
}