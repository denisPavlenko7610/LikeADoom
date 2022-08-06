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
        private Transform _thisTransform;

        private void Start()
        {
            _thisTransform = transform;
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
            CalculateDirection calculatorDirection = new CalculateDirection(_thisTransform, _spawnBullet);
            Vector3 direction = calculatorDirection.GetDirection();

            IShoot movement = new CalculateBulletMovementByDirection(Vector3.forward, _speed);
            BulletCreator creator = new BulletCreator(_prefab, _parent, _cameraTransform);

            Shooting shooting = new Shooting(movement, creator);
            shooting.Shoot(_spawnBullet.position);
        }
    }
}

