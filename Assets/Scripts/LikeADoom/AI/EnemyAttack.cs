using LikeADoom.Shooting;
using UnityEngine;

namespace LikeADoom
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField, Range(0.1f, 10f)] private float _projectileSpeed;
        [SerializeField, Range(0.01f, 5f)] private float _cooldown;

        private const int InitialPoolCapacity = 5;
        private const int MaxPoolCapacity = 20;
        private BulletPool _pool;

        public float Cooldown => _cooldown;

        public void Initialize()
        {
            IBulletFactory factory = new BulletFactory(_projectilePrefab, null, transform);
            _pool = new BulletPool(factory, transform, InitialPoolCapacity, MaxPoolCapacity);
        }

        public void Attack()
        {
            if (_pool == null)
                Initialize();
            
            IBullet bullet = _pool.Create();
            IShootPoint movement = new BulletMovement(Vector3.forward, _projectileSpeed);
            bullet.Shoot(movement);
        }
    }
}