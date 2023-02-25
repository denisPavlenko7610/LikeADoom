using System;
using LikeADoom.Shooting;
using UnityEngine;

namespace LikeADoom.LikeADoom.Environment.NonInteractable.Barel
{
    public class RedBarrel : MonoBehaviour, IBarrel
    {
        public event Action onCollision;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Bullet bullet))
            {
                onCollision?.Invoke();
                Destroy(gameObject.gameObject);
            }
        }
    }
}