using UnityEngine;

namespace LikeADoom.Collectabilities
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float hpIncreaseCount;
        [SerializeField] Collider collider;
        public void IncreaseHealth()
        {
            Debug.Log("Health increased by " + hpIncreaseCount);
        }

        public void DisableHealthObjcet()
        {
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}

