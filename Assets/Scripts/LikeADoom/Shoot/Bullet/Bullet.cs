using System.Collections;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Bullet : MonoBehaviour, IBullet
    {
        private Transform _thisTransform;

        public void DestroyObject()
        {
            Destroy(gameObject, 3f);
        }

        public void ToShoot(IShoot shootMovement)
        {
            StartCoroutine(Shoot(shootMovement));
        }

        private void Awake()
        {
            _thisTransform = transform;
        }

        private void Update()
        {
            DestroyObject();
        }

        private IEnumerator Shoot(IShoot shootDirection)
        {
            while (true)
            {
               Vector3 point = shootDirection.GetNextShootPoint();
               _thisTransform.Translate(point);
               yield return null;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            DestroyObject();
            Debug.Log(other.gameObject.name);
        }
    }
}

