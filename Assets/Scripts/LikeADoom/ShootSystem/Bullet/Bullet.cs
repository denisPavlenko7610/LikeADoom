using System.Collections;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Bullet : MonoBehaviour, IBullet, IDestroy
    {
        [SerializeField] private Transform _bulletTransform;
        [SerializeField] private float _destroyDelay = 3f;
        private bool _isSetDestroy;

        private void Update()
        {
            DestroyObject();
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }

        public void DestroyObject()
        {
            if (_isSetDestroy)
                return;

            Destroy(gameObject, _destroyDelay);
            _isSetDestroy = true;
        }

        public void Shoot(IShootPoint shootPointMovement) => StartCoroutine(ShootRoutine(shootPointMovement));

        private IEnumerator ShootRoutine(IShootPoint shootPointDirection)
        {
            while (true)
            {
                Vector3 point = shootPointDirection.GetNextShootPoint();
                _bulletTransform.Translate(point);
                yield return null;
            }
        }
    }
}