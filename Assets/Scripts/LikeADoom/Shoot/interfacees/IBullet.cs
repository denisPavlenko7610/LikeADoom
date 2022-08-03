using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IBullet
    {
        public void ToShoot(IShoot shootMovement);

        public void DestroyObject();
    }
}

