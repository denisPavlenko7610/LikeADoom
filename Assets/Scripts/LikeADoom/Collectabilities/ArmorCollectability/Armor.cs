using UnityEngine;

namespace LikeADoom.Collectabilities.ArmorCollectability
{
    public class Armor : MonoBehaviour
    {
        [SerializeField] float armorIncrease = 3.75f;
        [SerializeField] Collider collider;
        public void IncreaseArmor()
        {
            Debug.Log("Armor increased by " + armorIncrease);
        }

        public void DisableArmorObject()
        {
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
