using UnityEngine;

namespace LikeADoom.Shooting
{ 
    public class BulletMovement : IShootPoint
    {
        private readonly Vector3 _direction;
        private readonly float _speed;

        public BulletMovement(Vector3 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        public Vector3 GetNextShootPoint()
        {
            return _direction * (Time.deltaTime * _speed);
        }
    }
}

