using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Shooting
{
    public class Bullet : MonoBehaviour, IBullet
    {
        private Transform _thisTransform;

        public void DestroyObject()
        {
            Destroy(gameObject);
        }

        public void ToShoot(IShoot shootMovement)
        {
            StartCoroutine(Shoot(shootMovement));
        }

        private void Awake()
        {
            _thisTransform = transform;
        }

        private IEnumerator Shoot(IShoot movement)
        {
            while (true)
            {
                Vector3 point = movement.GetNextShootPoint();
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

