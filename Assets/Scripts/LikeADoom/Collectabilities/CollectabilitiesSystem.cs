using LikeADoom.Utils;
using UnityEngine;

namespace LikeADoom.Collectabilities
{
    public class CollectabilitiesSystem : MonoBehaviour
    {
        Armor armor;
        Health health;
        Ammo ammo;

        private void Start()
        {
            armor = GetComponent<Armor>();
            health = GetComponent<Health>();
            ammo = GetComponent<Ammo>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Health _health))
            {
                _health.HealthIncreasing();
            }

            if (collision.collider.TryGetComponent(out Armor _armor))
            {
                _armor.ArmorIncreasing();
            }

            if (collision.collider.TryGetComponent(out Ammo _ammo))
            {
                _ammo.AmmoIncreasing();
            }
        }
    }
}
    
