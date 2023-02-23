using System;
using System.Collections;
using LikeADoom.Creatures;
using RDTools.AutoAttach;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Bullet : Poolable<IBullet>, IBullet
    {
        [SerializeField, Attach] private Transform _bulletTransform;
        [SerializeField] private float _destroyDelay = 3f;
        [SerializeField] private int _damage;

        private Coroutine _destroyRoutine;
        private bool _isSetDestroy;
        private bool _isReleased;

        public override event Action<IPoolable<IBullet>> ReleaseRequested;
        
        public override IBullet GetObject() => this;

        private void OnCollisionEnter(Collision other)
        {
            StopCoroutine(_destroyRoutine);
            if (other.gameObject.TryGetComponent(out IDamageable damageable)) 
                damageable.TakeDamage(_damage);
            ReleaseRequested?.Invoke(this);
        }

        public void Shoot(IShootPoint shootPointMovement) => 
            StartCoroutine(ShootRoutine(shootPointMovement));

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
            ReleaseRequested?.Invoke(this);
        }
    }
}