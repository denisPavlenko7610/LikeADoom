namespace LikeADoom.Shooting
{
    public interface IBulletCreator
    {
        public Bullet Create();
        public void Recycle(Bullet bullet);
    }
}

