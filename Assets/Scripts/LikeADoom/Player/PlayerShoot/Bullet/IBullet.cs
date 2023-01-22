using System;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IBullet : IDestroy
    {
        public event Action OnBulletHit;
        public event Action OnBulletTimeOver;
        public void Enable();
        public void Disable();
        
        public void Shoot(IShootPoint shootPointMovement);
        
        public void SetupBulletPosition(Transform spawnPoint);
    }
}

