using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Shooting
    {
        private readonly IShoot _movement;
        private readonly IBulletCreator _creator;

        public Shooting(IShoot movement, IBulletCreator creator)
        {
            _movement = movement;
            _creator = creator;
        }

        public void Shoot(Vector3 position)
        {
            IBullet bullet = _creator.Create(position);
            bullet.ToShoot(_movement);
        }
    }
}
