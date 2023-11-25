using LikeADoom.ObjectCreation;
using LikeADoom.Units.Player.Health;
using RDTools.AutoAttach;
using System;
using System.Collections;
using UnityEngine;

namespace LikeADoom.Bullet
{
    public class Bullet : Poolable<IBullet>, IBullet
    {
        [SerializeField, Attach] Transform _bulletTransform;
        [SerializeField] float _destroyDelay = 3f;
        [SerializeField] int _damage;

        Coroutine _destroyRoutine;
        bool _isSetDestroy;
        bool _isReleased;

        public override event Action<IPoolable<IBullet>> ReleaseRequested;
        
        public override IBullet GetObject() => this;

        void OnCollisionEnter(Collision other)
        {
            StopCoroutine(_destroyRoutine);
            if (other.gameObject.TryGetComponent(out IDamageable damageable)) 
                damageable.TakeDamage(_damage);
            ReleaseRequested?.Invoke(this);
        }

        public void Shoot(IShootPoint shootPointMovement) => 
            StartCoroutine(ShootRoutine(shootPointMovement));

        IEnumerator ShootRoutine(IShootPoint shootPointDirection)
        {
            _destroyRoutine = StartCoroutine(RecycleAfterTimeoutRoutine(_destroyDelay));
            
            while (true)
            {
                Vector3 point = shootPointDirection.GetNextShootPoint();
                _bulletTransform.Translate(point);
                yield return null;
            }
        }

        IEnumerator RecycleAfterTimeoutRoutine(float timeoutInSeconds)
        {
            yield return new WaitForSeconds(timeoutInSeconds);
            ReleaseRequested?.Invoke(this);
        }
    }
}