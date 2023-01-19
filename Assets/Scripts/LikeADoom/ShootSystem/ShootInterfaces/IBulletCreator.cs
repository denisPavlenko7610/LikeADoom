namespace LikeADoom.Shooting
{
    public interface IBulletCreator
    {
        public IBullet Create();
        public void Recycle(Bullet bullet);
    }
}

