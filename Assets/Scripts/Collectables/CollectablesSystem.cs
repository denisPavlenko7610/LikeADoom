using LikeADoom.Collectables.AmmoCollectable;
using LikeADoom.Collectables.ArmorCollectable;
using LikeADoom.Collectables.HealthCollectable;
using LikeADoom.Units.Player.Health;
using RDTools.AutoAttach;
using UnityEngine;
using UnityEngine.Serialization;

namespace LikeADoom.Collectables
{
    public class CollectablesSystem : MonoBehaviour
    {
        [SerializeField] Armor armor;
        [FormerlySerializedAs("health")] [SerializeField] AidKit aidKit;
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
            if (collision.collider.TryGetComponent(out AidKit health))
            {
                _health.Heal(health.Count);
                health.IncreaseHealth();
                health.DisableHealthObject();
            }
        }
    }
}
    
