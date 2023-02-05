namespace LikeADoom.Shooting
{
    public class Shooting
    {
        private readonly IShootPoint _movement;
        private readonly BulletPool _bulletPool;

        public Shooting(IShootPoint movement, BulletPool bulletPool)
        {
            _movement = movement;
            _bulletPool = bulletPool;
        }

        public void Shoot()
        {
            _bulletPool.Create()
                .Shoot(_movement);
        }
    }
}

