using UnityEngine;

namespace LikeADoom.Collectabilities.AmmoCollectability
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] float ammoIncrease = 5f;
        [SerializeField] Collider collider;
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
