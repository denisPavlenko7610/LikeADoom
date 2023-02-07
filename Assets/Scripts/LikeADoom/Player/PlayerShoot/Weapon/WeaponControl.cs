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

        [SerializeField] private GunView _view;

        private bool _isReloading;
        private Gun _gun;

        private void Awake()
        {
            IBulletFactory bulletFactory = new BulletFactory(_prefab, _parent, _spawnPoint, _cameraTransform);
            IBulletBuilder bulletBuilder = new BulletBuilder.BulletBuilder(bulletFactory);
            Pool pool = new Pool(bulletBuilder, _spawnPoint);
            Shooting shooting = new Shooting(pool);
            
            _gun = new Gun(shooting, Weapon.BFG9000, _ammoCount, _bulletSpeed);
        }
        
        private bool CanShoot => !_gun.IsEnoughAmmo || _isReloading;

        public void Shoot()
        {
            if (CanShoot)
                return;
            
            _view.PlayShootAnimation();
            _gun.Shoot();
            _view.ShowAmmoLeft(_gun.AmmoLeft);
        }

        public void Reload()
        {
            _isReloading = true;
            _view.PlayReloadAnimation();
            
            _view.AmmoClipInserted += OnAmmoClipInserted;
        }

        private void OnAmmoClipInserted()
        {
            _isReloading = false;
            _gun.Reload();
            
            _view.ShowAmmoLeft(_gun.AmmoLeft);
            _view.AmmoClipInserted -= OnAmmoClipInserted;
        }
    }
}