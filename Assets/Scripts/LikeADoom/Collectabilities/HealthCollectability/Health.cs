using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Collectabilities
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float hpIncreaseCount;
        public void HealthIncrease()
        {
            Debug.Log("Health increased by " + hpIncreaseCount);
            gameObject.SetActive(false);
        }
    }
}

