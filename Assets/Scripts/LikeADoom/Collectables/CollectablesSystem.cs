using LikeADoom.Collectables.AmmoCollectable;
using LikeADoom.Collectables.ArmorCollectable;
using LikeADoom.Entities;
using RDTools.AutoAttach;
using UnityEngine;

namespace LikeADoom.Collectables
{
    public class CollectablesSystem : MonoBehaviour
    {
        [SerializeField] Armor armor;
        [SerializeField] Health health;
        [SerializeField] Ammo ammo;

        [SerializeField, Attach] private PlayerHealth _health;

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
                _health.ArmorUp(armor.Count);
                armor.IncreaseArmor();
                armor.DisableArmorObject();
            }
        }

        private void CheckHealth(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Health health))
            {
                _health.Heal(health.Count);
                health.IncreaseHealth();
                health.DisableHealthObjcet();
            }
        }
    }
}
    
