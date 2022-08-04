using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public interface IShoot
    {
        public Vector3 GetNextShootPoint();
    }
}