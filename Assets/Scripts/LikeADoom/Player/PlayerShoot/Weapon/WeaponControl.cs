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

        [SerializeField, Range(5, 50)] private int _ammoCount;
        [SerializeField, Range(1, 100)] private float _bulletSpeed;
        [SerializeField] private bool _canSpamShoot;

        [SerializeField] private GunView _view;

        private bool _isShootAnimationPlaying;
        private bool _isReloadAnimationPlaying;
        private Gun _gun;

        private void Awake()
        {
            IBulletFactory bulletFactory = new BulletFactory(_prefab, _parent, _spawnPoint, _cameraTransform);
            IBulletBuilder bulletBuilder = new BulletBuilder.BulletBuilder(bulletFactory);
            Pool pool = new Pool(bulletBuilder, _spawnPoint);
            Shooting shooting = new Shooting(pool);
            
            _gun = new Gun(shooting, Weapon.BFG9000, _ammoCount, _bulletSpeed);

            // No unsubscription because the lifetimes are the same
            _view.ShootAnimationAmmoClipInserted += OnAmmoClipInserted;
            _view.ShootAnimationEnd += OnShootAnimationEnd;
            _view.ReloadAnimationEnd += OnReloadAnimationEnd;
        }

        private bool CanShoot => 
            _gun.CanShoot && 
            !_isReloadAnimationPlaying &&
            (!_isShootAnimationPlaying || _canSpamShoot);

        public void Shoot()
        {
            if (!CanShoot)
                return;
            
            _gun.Shoot();
            _isShootAnimationPlaying = true;
            _view.PlayShootAnimation();
            _view.ShowAmmoLeft(_gun.AmmoLeft);
        }

        public void Reload()
        {
            _isReloadAnimationPlaying = true;
            _view.PlayReloadAnimation();
        }

        private void OnAmmoClipInserted()
        {
            _gun.Reload();
            _view.ShowAmmoLeft(_gun.AmmoLeft);
        }

        private void OnReloadAnimationEnd() => OnAnyAnimationEnd();
        private void OnShootAnimationEnd() => OnAnyAnimationEnd();

        private void OnAnyAnimationEnd()
        {
            _isReloadAnimationPlaying = false;
            _isShootAnimationPlaying = false;
        }
    }
}