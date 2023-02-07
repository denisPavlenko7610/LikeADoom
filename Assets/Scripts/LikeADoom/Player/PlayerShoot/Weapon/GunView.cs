using System;
using RDTools.AutoAttach;
using UnityEngine;
using Zenject;

namespace LikeADoom.Shooting
{
    class GunView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string ShootingAnimationName = "Shooting";
        private const string ReloadAnimationName = "Reload";

        private AmmoBar _ammoBar;
        
        [Inject]
        public void Initialize(AmmoBar ammoBar)
        {
            _ammoBar = ammoBar;
        }
        
        public event Action AmmoClipInserted;

        public void OnAmmoClipInserted() => AmmoClipInserted?.Invoke();

        public void PlayShootAnimation() => _animator.Play(ShootingAnimationName);
        public void PlayReloadAnimation() => _animator.Play(ReloadAnimationName);

        public void ShowAmmoLeft(int count) => _ammoBar.ShowCount(count);
    }
}