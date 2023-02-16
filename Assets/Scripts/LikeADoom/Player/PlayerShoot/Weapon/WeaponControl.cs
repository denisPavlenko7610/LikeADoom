using LikeADoom.Shooting.BulletBuilder;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class WeaponControl : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _cameraTransform;

        // This can all be set by the weapon's type
        [SerializeField, Range(5, 50)] private int _ammoCount;
        [SerializeField, Range(1, 100)] private float _bulletSpeed;
        [SerializeField] private bool _canSpamShoot;

        [SerializeField] private GunView _view;

        private bool _isShootAnimationPlaying;
        private bool _isAmmoClipInserted;
        private bool _isReloadAnimationPlaying;
        private bool _isMeleeHitAnimationPlaying;
        private Gun _gun;

        private void Awake()
        {
            BulletFactory factory = new(_prefab, _parent, _spawnPoint, _cameraTransform);
            Pool<IBullet> pool = new(factory, _spawnPoint, maxSize: _ammoCount);
            Shooting shooting = new(pool);
            
            _gun = new Gun(shooting, Weapon.BFG9000, _ammoCount, _bulletSpeed);

            // No unsubscription because the lifetimes are the same
            _view.ShootAnimationAmmoClipInserted += OnAmmoClipInserted;
            _view.ShootAnimationEnd += OnShootAnimationEnd;
            _view.ReloadAnimationEnd += OnReloadAnimationEnd;
            _view.HitAnimationHit += OnMeleeHit;
        }

        private bool CanShoot => 
            _gun.CanShoot && 
            !_isReloadAnimationPlaying &&
            !_isMeleeHitAnimationPlaying &&
            (!_isShootAnimationPlaying || _canSpamShoot);

        private bool CanMeleeHit =>
            !_isShootAnimationPlaying ||
            (_isReloadAnimationPlaying && _isAmmoClipInserted);

        private bool CanReload =>
            !_isMeleeHitAnimationPlaying;

        public void Shoot()
        {
            if (!CanShoot)
                return;
            
            _gun.Shoot();
            _view.PlayShootAnimation();
            _view.ShowAmmoLeft(_gun.AmmoLeft);
            
            ResetState();
            _isShootAnimationPlaying = true;
        }

        public void Reload()
        {
            if (!CanReload)
                return;
            
            _view.PlayReloadAnimation();
            
            ResetState();
            _isReloadAnimationPlaying = true;
        }

        public void MeleeHit()
        {
            if (!CanMeleeHit)
                return;
            
            _view.PlayHitAnimation();

            ResetState();
            _isMeleeHitAnimationPlaying = true;
        }

        private void OnAmmoClipInserted()
        {
            _gun.Reload();
            _view.ShowAmmoLeft(_gun.AmmoLeft);
            
            _isAmmoClipInserted = true;
        }

        private void OnMeleeHit()
        {
            // Logic for dealing damage
            
            ResetState();
        }
        
        private void OnReloadAnimationEnd() => ResetState();
        private void OnShootAnimationEnd() => ResetState();
        
        private void ResetState()
        {
            _isReloadAnimationPlaying = false;
            _isShootAnimationPlaying = false;
            _isMeleeHitAnimationPlaying = false;
            _isAmmoClipInserted = false;
        }
    }
}