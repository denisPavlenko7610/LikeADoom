namespace LikeADoom.Shooting
{
    public class Shooting
    {
        private readonly Pool<IBullet> _pool;

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

