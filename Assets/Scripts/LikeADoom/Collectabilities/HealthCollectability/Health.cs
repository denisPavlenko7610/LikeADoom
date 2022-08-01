using UnityEngine;

namespace LikeADoom.Collectabilities
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float hpIncreaseCount;
        [SerializeField] Collider collider;
        public void HealthIncreasing()
        {
            Debug.Log("Health increased by " + hpIncreaseCount);
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}

