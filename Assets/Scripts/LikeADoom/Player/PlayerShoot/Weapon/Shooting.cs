namespace LikeADoom.Shooting
{
    public class Shooting
    {
        private readonly IShootPoint _movement;
        private readonly BulletPool _pool;

        public Shooting(IShootPoint movement, BulletPool pool)
        {
            _movement = movement;
            _pool = pool;
        }

        public void Shoot()
        {
            IBullet bullet = _pool.Create();
            bullet.Shoot(_movement);
        }
    }
}

