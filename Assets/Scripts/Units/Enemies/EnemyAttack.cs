using LikeADoom.Bullet;
using LikeADoom.Bullet.BulletFactory;
using LikeADoom.ObjectCreation;
using UnityEngine;

namespace LikeADoom.Units.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] GameObject _projectilePrefab;
        [SerializeField] Transform _shootPoint;
        [SerializeField, Range(0.1f, 10f)] float _projectileSpeed;
        [SerializeField, Range(0.01f, 5f)] float _cooldown;

        const int InitialPoolCapacity = 5;
        const int MaxPoolCapacity = 20;
        Pool<IBullet> _pool;

        public float Cooldown => _cooldown;
        public Transform ShootPoint => _shootPoint;

        void Awake()
        {
            BulletFactory factory = new(_projectilePrefab, null, _shootPoint);
            _pool = new Pool<IBullet>(factory, _shootPoint, InitialPoolCapacity, MaxPoolCapacity);
        }

        public void Attack()
        {
            IBullet bullet = _pool.Create();
            IShootPoint movement = new BulletMovement(Vector3.forward, _projectileSpeed);
            bullet.Shoot(movement);
        }
    }
}