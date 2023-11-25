using LikeADoom.Bullet;
using LikeADoom.ObjectCreation;

namespace LikeADoom.Units.Player.PlayerShoot.Weapon
{
    public class Shooting
    {
        readonly Pool<IBullet> _pool;

        public Shooting(Pool<IBullet> pool)
        {
            _pool = pool;
        }

        public void Shoot(IShootPoint movement)
        {
            _pool.Create()
                .Shoot(movement);
        }
    }
}

