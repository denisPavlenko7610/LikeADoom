using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Gun
    {
        private readonly Shooting _shooting;
        private readonly Weapon _type;
        private readonly int _maxAmmo;
        private readonly float _bulletSpeed;

        private int _currentAmmo;

        // TODO: Get maxAmmo and speed by weapon type
        public Gun(Shooting shooting, Weapon type, int maxAmmo, float bulletSpeed)
        {
            _shooting = shooting;
            _type = type;
            _maxAmmo = _currentAmmo = maxAmmo;
            _bulletSpeed = bulletSpeed;
        }

        public int AmmoLeft => _currentAmmo;
        public bool CanShoot => _currentAmmo > 0;

        public void Shoot()
        {
            if (!CanShoot)
                Debug.LogError("No ammo! Check IsEnoughAmmo property before shooting!");

            IShootPoint movement = new BulletMovement(Vector3.forward, _bulletSpeed);
            _shooting.Shoot(movement);

            _currentAmmo--;
        }

        public void Reload()
        {
            _currentAmmo = _maxAmmo;
        }
    }
}