using System.Collections;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Bullet : MonoBehaviour, IDestroy, IBullet
    {
        [SerializeField] private Transform _bulletTransform;
        [SerializeField] private float _destroyDelay = 3f;
        
        private IBulletCreator _creator;
        private Coroutine _destroyRoutine;
        private bool _isSetDestroy;

        public void Initialize(IBulletCreator creator)
        {
            _creator = creator;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            StopCoroutine(_destroyRoutine);
            DestroyObject();
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
            DestroyObject();
        }

        public void DestroyObject()
        {
            _creator.Recycle(this);
        }
    }
}