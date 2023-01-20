namespace LikeADoom.Shooting
{
    public class Shooting
    {
        private readonly IShootPoint _movement;
        private readonly IBulletCreator _creator;

        public Shooting(IShootPoint movement, IBulletCreator creator)
        {
            _movement = movement;
            _creator = creator;
        }

        public void Shoot()
        {
            IBullet bullet = _creator.Create();
            bullet.Shoot(_movement);
        }
    }
}

