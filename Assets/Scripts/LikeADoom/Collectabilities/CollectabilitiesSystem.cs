using LikeADoom.Utils;
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
            if (collision.collider.TryGetComponent(out Health health))
            {
                health.IncreaseHealth();
                health.DisableHealthObjcet();
            }
         
            if (collision.collider.TryGetComponent(out Armor armor))
            {
                armor.IncreaseArmor();
                armor.DisableArmorObject();
            }

            if (collision.collider.TryGetComponent(out Ammo ammo))
            {
                ammo.IncreaseAmmo();
                ammo.DisableAmmoObject();
            }
        }
    }
}
    
