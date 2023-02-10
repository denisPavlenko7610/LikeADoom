namespace LikeADoom.Shooting
{
    public class Shooting
    {
        private readonly Pool _pool;

        public Shooting(Pool pool)
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

