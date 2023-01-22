using System;
using System.Collections;
using Dythervin.AutoAttach;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField, Attach] private Transform _bulletTransform;
        [SerializeField] private float _destroyDelay = 3f;

        public event Action OnBulletHit;
        public event Action OnBulletTimeOver;
        
        private Coroutine _destroyRoutine;
        private bool _isSetDestroy;

        public void Enable() => gameObject.SetActive(true);
        public void Disable() => gameObject.SetActive(false);

        private void OnCollisionEnter(Collision other)
        {
            StopCoroutine(_destroyRoutine);
            OnBulletHit?.Invoke();
        }

        public void Shoot(IShootPoint shootPointMovement) => 
            StartCoroutine(ShootRoutine(shootPointMovement));

        public void SetupBulletPosition(Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
        }
        public void Destroy() => Destroy(gameObject);

        private IEnumerator ShootRoutine(IShootPoint shootPointDirection)
        {
            _destroyRoutine = StartCoroutine(RecycleAfterTimeoutRoutine(_destroyDelay));
            
            while (true)
            {
                Vector3 point = shootPointDirection.GetNextShootPoint();
                _bulletTransform.Translate(point);
                yield return null;
            }
        }

        private IEnumerator RecycleAfterTimeoutRoutine(float timeoutInSeconds)
        {
            yield return new WaitForSeconds(timeoutInSeconds);
            OnBulletTimeOver?.Invoke();
        }
    }
}