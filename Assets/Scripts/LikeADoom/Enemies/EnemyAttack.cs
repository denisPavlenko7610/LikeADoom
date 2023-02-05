using LikeADoom.Shooting;
using LikeADoom.Shooting.BulletBuilder;
using UnityEngine;

namespace LikeADoom
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField, Range(0.1f, 10f)] private float _projectileSpeed;
        [SerializeField, Range(0.01f, 5f)] private float _cooldown;

        private const int InitialPoolCapacity = 5;
        private const int MaxPoolCapacity = 20;
        private Pool _pool;

        public float Cooldown => _cooldown;
        public Transform ShootPoint => _shootPoint;

        private void Awake()
        {
            IBulletFactory bulletFactory = new BulletFactory(_projectilePrefab, null, _shootPoint);
            IBulletBuilder bulletBuilder = new BulletBuilder(bulletFactory);
            _pool = new Pool(bulletBuilder, _shootPoint, InitialPoolCapacity, MaxPoolCapacity);
        }

        public void Attack()
        {
            IBullet bullet = _pool.Create();
            IShootPoint movement = new BulletMovement(Vector3.forward, _projectileSpeed);
            bullet.Shoot(movement);
        }
    }
}