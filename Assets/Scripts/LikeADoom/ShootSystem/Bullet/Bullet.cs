using System.Collections;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private Transform _bulletTransform;
        [SerializeField] private float _destroyDelay = 3f;
        private Coroutine _destroyRoutine;
        private bool _isSetDestroy;

        public IBulletCreator Creator { get; set; }
        
        private void OnCollisionEnter(Collision other)
        {
            StopCoroutine(_destroyRoutine);
            Recycle();
        }

        private IEnumerator RecycleAfterTimeoutRoutine(float timeoutInSeconds)
        {
            yield return new WaitForSeconds(timeoutInSeconds);
            Recycle();
        }

        private void Recycle()
        {
            Creator.Recycle(this);   
        }

        public void Shoot(IShootPoint shootPointMovement) => StartCoroutine(ShootRoutine(shootPointMovement));

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
    }
}