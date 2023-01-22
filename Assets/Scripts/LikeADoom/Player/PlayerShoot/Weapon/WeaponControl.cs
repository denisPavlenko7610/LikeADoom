using UnityEngine;

namespace LikeADoom.Shooting
{
    public class WeaponControl : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField, Range(1, 100)] private float _speed;

        private BulletPool _bulletPool;

        private void Awake()
        {
            IBulletFactory bulletFactory = new BulletBulletFactory(_prefab, _parent, _spawnPoint, _cameraTransform);
            _bulletPool = new BulletPool(bulletFactory, _spawnPoint );
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            IShootPoint movement = new BulletMovement(Vector3.forward, _speed);
            Shooting shooting = new Shooting(movement, _bulletPool);
            shooting.Shoot();
        }
    }
}