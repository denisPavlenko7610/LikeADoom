using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IBulletCreator
    {
        public IBullet Create(Vector3 position);
    }
}

