using System;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Gun
    {
        private readonly Shooting _shooting;
        private readonly Weapon _type;
        private readonly int _maxAmmo;
        private readonly float _speed;

        private int _currentAmmo;

        // TODO: Get maxAmmo and Speed by weapon type
        public Gun(Shooting shooting, Weapon type, int maxAmmo, float speed)
        {
            _shooting = shooting;
            _type = type;
            _maxAmmo = _currentAmmo = maxAmmo;
            _speed = speed;
        }

        public int AmmoLeft => _currentAmmo;
        public bool IsEnoughAmmo => _currentAmmo > 0;

        public void Shoot()
        {
            if (!IsEnoughAmmo)
                throw new InvalidOperationException("No ammo! Check IsEnoughAmmo property before shooting!");
            
            IShootPoint movement = new BulletMovement(Vector3.forward, _speed);
            _shooting.Shoot(movement);

            _currentAmmo--;
        }

        public void Reload()
        {
            _currentAmmo = _maxAmmo;
        }
    }
}