using LikeADoom.Bullet;
using UnityEngine;

namespace LikeADoom.Units.Player.PlayerShoot.Weapon
{
    public class Gun
    {
        readonly Shooting _shooting;
        readonly Enums.Weapon _type;
        readonly int _maxAmmo;
        readonly float _bulletSpeed;

        int _currentAmmo;

        // TODO: Get maxAmmo and speed by weapon type
        public Gun(Shooting shooting, Enums.Weapon type, int maxAmmo, float bulletSpeed)
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