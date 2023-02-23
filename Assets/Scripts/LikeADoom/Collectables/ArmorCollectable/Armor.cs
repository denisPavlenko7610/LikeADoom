using UnityEngine;

namespace LikeADoom.Collectables.ArmorCollectable
{
    public class Armor : MonoBehaviour
    {
        [SerializeField] int armorIncrease;
        [SerializeField] Collider collider;

        public void IncreaseArmor()
        {
            Debug.Log("Armor increased by " + armorIncrease);
        }

        public int Count => armorIncrease;

        public void DisableArmorObject()
        {
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
