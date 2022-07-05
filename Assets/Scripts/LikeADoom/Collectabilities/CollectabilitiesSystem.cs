using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom.Collectabilities
{
    public class CollectabilitiesSystem : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Player")
            {
                string currentTag = gameObject.tag;
                
                switch (currentTag)
                {
                    case "Health":
                        GetComponent<Health>().HealthIncrease();
                        break;
                }
            }
        }
    }
}
    
