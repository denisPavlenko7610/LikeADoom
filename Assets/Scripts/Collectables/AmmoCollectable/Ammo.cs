using UnityEngine;

namespace LikeADoom.Collectables.AmmoCollectable
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] float ammoIncrease = 5f;
        [SerializeField] new Collider collider;
        public void IncreaseAmmo()
        {
            Debug.Log("Ammo increased by " + ammoIncrease);
        }

        public void DisableAmmoObject()
        {
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
