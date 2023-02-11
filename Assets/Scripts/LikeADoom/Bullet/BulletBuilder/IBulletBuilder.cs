using UnityEngine;

namespace LikeADoom.Shooting.BulletBuilder
{
    public interface IBulletBuilder
    {
        IBulletBuilder SetupBulletPosition(Transform spawnPoint);
        IBulletBuilder SetIsReleased(bool isReleased);
        IBullet Build();
    }
}