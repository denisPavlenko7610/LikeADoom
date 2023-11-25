using System;
using UnityEngine;

namespace LikeADoom.Environment.NonInteractable.Barrel
{
    public class RedBarrel : MonoBehaviour, IBarrel
    {
        public event Action onCollision;

        void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.TryGetComponent(out Bullet.Bullet bullet))
                return;
            
            onCollision?.Invoke();
            Destroy(gameObject.gameObject);
        }
    }
}