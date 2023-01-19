using UnityEngine;

namespace LikeADoom.Shooting
{
    public class WeaponControl : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _spawnBullet;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField, Range(0, 1000)] private float _speed;
        //[SerializeField, Attach] private Transform _thisTransform;

        private IBulletCreator _bulletCreator;

        private void Awake()
        {
            _bulletCreator = new BulletPool(_prefab, _parent, _cameraTransform);
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
            // CalculateDirection calculatorDirection = new CalculateDirection(_thisTransform, _spawnBullet);
            // Vector3 direction = calculatorDirection.GetDirection();

            IShootPoint movement = new BulletMovement(Vector3.forward, _speed);

            Shooting shooting = new Shooting(movement, _bulletCreator);
            shooting.Shoot(_spawnBullet.position);
        }
    }
}