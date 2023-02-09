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
        private const string HitAnimationName = "Hit";

        private AmmoBar _ammoBar;
        
        [Inject]
        public void Initialize(AmmoBar ammoBar)
        {
            _ammoBar = ammoBar;
        }
        
        public event Action ShootAnimationAmmoClipInserted;
        public event Action ShootAnimationEnd;
        public event Action ReloadAnimationEnd;
        public event Action HitAnimationHit;

        public void OnAmmoClipInserted() => ShootAnimationAmmoClipInserted?.Invoke();
        public void OnShootAnimationEnd() => ShootAnimationEnd?.Invoke();
        public void OnReloadAnimationEnd() => ReloadAnimationEnd?.Invoke();
        public void OnHitAnimationHit() => HitAnimationHit?.Invoke();

        public void PlayShootAnimation() => _animator.Play(ShootingAnimationName);
        public void PlayReloadAnimation() => _animator.Play(ReloadAnimationName);
        public void PlayHitAnimation() => _animator.Play(HitAnimationName);

        public void ShowAmmoLeft(int count) => _ammoBar.ShowCount(count);
    }
}