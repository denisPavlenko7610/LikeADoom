using UnityEngine;

namespace LikeADoom.Bullet
{ 
    public class BulletMovement : IShootPoint
    {
        readonly Vector3 _direction;
        readonly float _speed;

        public BulletMovement(Vector3 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        public Vector3 GetNextShootPoint() => _direction * (Time.deltaTime * _speed);
    }
}

