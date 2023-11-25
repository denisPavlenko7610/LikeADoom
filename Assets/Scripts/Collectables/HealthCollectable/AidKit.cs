using UnityEngine;

namespace LikeADoom.Collectables.HealthCollectable
{
    public class AidKit : MonoBehaviour
    {
        [SerializeField] int hpIncreaseCount;
        [SerializeField] Collider collider;
        
        public void IncreaseHealth()
        {
            Debug.Log("AidKit increased by " + hpIncreaseCount);
        }

        public int Count => hpIncreaseCount;

        public void DisableHealthObject()
        {
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}

