using System.Collections;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Bullet : MonoBehaviour, IBullet, IDestroy
    {
        [SerializeField] private Transform _bulletTransform;
        [SerializeField] private float _destroyDelay = 3f;
        private bool _isSetDestory;

        private void Update()
        {
            DestroyObject();
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
            //Debug.Log(other.gameObject.name);
        }

        public void DestroyObject()
        {
            if (_isSetDestory)
                return;

            Destroy(gameObject, _destroyDelay);
            _isSetDestory = true;
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