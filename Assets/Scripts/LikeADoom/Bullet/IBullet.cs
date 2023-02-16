namespace LikeADoom.Shooting
{
    public interface IBullet : IPoolable<IBullet>  
    {
        void Shoot(IShootPoint shootPointMovement);
    }
}

