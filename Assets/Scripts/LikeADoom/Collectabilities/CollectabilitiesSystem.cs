using LikeADoom.Utils;
using UnityEngine;

namespace LikeADoom.Collectabilities
{
    public class CollectabilitiesSystem : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player.Player _))
            {
                var currentTag = gameObject.tag;

                if (currentTag == Constants.HealthTag)
                {
                    GetComponent<Health>().HealthIncrease();
                }
            }
        }
    }
}
    
