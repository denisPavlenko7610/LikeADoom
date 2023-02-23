using UnityEngine;

namespace LikeADoom.Collectables
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int hpIncreaseCount;
        [SerializeField] Collider collider;
        
        public void IncreaseHealth()
        {
            Debug.Log("Health increased by " + hpIncreaseCount);
        }

        public int Count => hpIncreaseCount;

        public void DisableHealthObjcet()
        {
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}

