using LikeADoom.Collectabilities.AmmoCollectability;
using LikeADoom.Collectabilities.ArmorCollectability;
using UnityEngine;

namespace LikeADoom.Collectabilities
{
    public class CollectabilitiesSystem : MonoBehaviour
    {
        [SerializeField] Armor armor;
        [SerializeField] Health health;
        [SerializeField] Ammo ammo;

        private void OnCollisionEnter(Collision collision)
        {
            CheckHealth(collision);
            CheckArmor(collision);
            CheckAmmo(collision);
        }

        private void CheckAmmo(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Ammo ammo))
            {
                ammo.IncreaseAmmo();
                ammo.DisableAmmoObject();
            }
        }

        private void CheckArmor(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Armor armor))
            {
                armor.IncreaseArmor();
                armor.DisableArmorObject();
            }
        }

        private void CheckHealth(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Health health))
            {
                health.IncreaseHealth();
                health.DisableHealthObjcet();
            }
        }
    }
}
    
