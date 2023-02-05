using UnityEngine;

namespace LikeADoom.Shooting.BulletBuilder
{
    public interface IBulletBuilder
    {
        BulletBuilder SetupBulletPosition(Transform spawnPoint);
        BulletBuilder SetIsReleased(bool isReleased);
        IBullet Build();
    }
}