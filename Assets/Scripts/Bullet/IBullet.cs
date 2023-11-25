using LikeADoom.ObjectCreation;

namespace LikeADoom.Bullet
{
    public interface IBullet : IPoolable<IBullet>  
    {
        void Shoot(IShootPoint shootPointMovement);
    }
}

