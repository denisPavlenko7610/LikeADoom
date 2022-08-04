using UnityEngine;

namespace LikeADoom.Shooting
{
    public class WeaponControl : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _spawnCartridge;
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
            CalculateDirection calculatorDirection = new CalculateDirection(_thisTransform, _spawnCartridge);
            Vector3 direction = calculatorDirection.GetDirection();

            IShoot movement = new CalculateBulletMovementByDirection(direction, _speed);
            BulletCreator creator = new BulletCreator(_prefab, _parent);

            Shooting shooting = new Shooting(movement, creator);
            shooting.Shoot(_spawnCartridge.position);
        }
    }
}

