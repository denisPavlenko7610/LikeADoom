using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IBulletCreator
    {
        public IBullet Create(Vector3 position);
    }
}

