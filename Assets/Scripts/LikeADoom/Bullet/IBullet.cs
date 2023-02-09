using System;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IBullet : IRelease, IDestroy
    {
        event Action OnBulletHit;
        event Action OnBulletTimeOver;
        IBullet Enable();
        IBullet Disable();
        
        void Shoot(IShootPoint shootPointMovement);
        
        IBullet SetupBulletPosition(Transform spawnPoint);
    }
}
