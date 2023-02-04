using System;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IBullet : IRelease, IDestroy
    {
        event Action OnBulletHit;
        event Action OnBulletTimeOver;
        void Enable();
        void Disable();
        
        void Shoot(IShootPoint shootPointMovement);
        
        void SetupBulletPosition(Transform spawnPoint);
    }
}

